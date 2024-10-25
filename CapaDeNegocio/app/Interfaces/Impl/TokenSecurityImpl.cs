using CapaDeNegocio.Exceptions;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;

namespace CapaDeNegocio.Security
{
    public class TokenSecurity : ITokenSecurity
    {
        private readonly string _secretKey;

        public TokenSecurity(string secretKey)
        {
            _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
        }

        public string GenerateToken<T>(T payload, TimeSpan expiration)
        {
            var payloadDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(payload));

            if (payloadDict == null)
            {
                throw new InvalidOperationException("El payload no pudo ser deserializado correctamente.");
            }

            var finalPayload = new Dictionary<string, object>
            {
                { "user", payloadDict },
                { "roles", new[] { "ADMIN" } },
                { "exp", DateTimeOffset.UtcNow.Add(expiration).ToUnixTimeSeconds() }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(finalPayload, _secretKey);
            return token;
        }

        public void ValidateToken(string token)
        {
            try
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, new JwtValidator(serializer, new UtcDateTimeProvider()), urlEncoder, algorithm);

                var jsonPayload = decoder.Decode(token, _secretKey, verify: true);
            }
            catch (TokenExpiredException)
            {
                throw new CustomTokenExpiredException("El token proporcionado ha expirado.");
            }
            catch (SignatureVerificationException)
            {
                throw new CustomSignatureVerificationException("La firma del token no es válida.");
            }
        }
    }
}
