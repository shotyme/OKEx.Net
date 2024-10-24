﻿using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Okex.Net.Objects.Core;

public class OkexAuthenticationProvider : AuthenticationProvider<OkexApiCredentials>
{
    private readonly HMACSHA256 encryptor;
    public string Passphrase => _credentials.PassPhrase;

    private static IMessageSerializer _serializer = new SystemTextJsonMessageSerializer();

    public OkexAuthenticationProvider(OkexApiCredentials credentials) : base(credentials)
    {
        if (credentials == null || credentials.Secret == null)
            throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

       // encryptor = new HMACSHA256(Encoding.ASCII.GetBytes(credentials.Secret.GetString()));
    }

    //public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition, out SortedDictionary<string, object> uriParameters, out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
    //{
    //    uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
    //    bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
    //    headers = new Dictionary<string, string>();

    //    // Get Clients
    //    var baseClient = ((OkexClientUnifiedApi)apiClient)._baseClient;

    //    // Check Point
    //    if (!(auth || baseClient.Options.SignPublicRequests))
    //        return;

    //    // Check Point
    //    if (_credentials == null || _credentials.Key == null || _credentials.Secret == null || ((OkexApiCredentials)_credentials).PassPhrase == null)
    //        throw new ArgumentException("No valid API credentials provided. Key/Secret/PassPhrase needed.");

    //    // Set Parameters
    //    uri = uri.SetParameters(uriParameters, arraySerialization);

    //    // Signature Body
    //    // var time = (DateTime.UtcNow.ToUnixTimeMilliSeconds() / 1000.0m).ToString(CultureInfo.InvariantCulture);
    //    var time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.sssZ");
    //    var signtext = time + method.Method.ToUpper() + uri.PathAndQuery.Trim('?');

    //    if (method == HttpMethod.Post)
    //    {
    //        if (bodyParameters.Count == 1 && bodyParameters.Keys.First() == OkexClient.BodyParameterKey)
    //            signtext += JsonConvert.SerializeObject(bodyParameters[OkexClient.BodyParameterKey]);
    //        else
    //            // signtext += JsonConvert.SerializeObject(bodyParameters.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value));
    //            signtext += JsonConvert.SerializeObject(bodyParameters);
    //    }

    //    // Compute Signature
    //    var signature = Base64Encode(encryptor.ComputeHash(Encoding.UTF8.GetBytes(signtext)));

    //    // Headers
    //    headers.Add("OK-ACCESS-KEY", _credentials.Key.GetString());
    //    headers.Add("OK-ACCESS-SIGN", signature);
    //    headers.Add("OK-ACCESS-TIMESTAMP", time);
    //    headers.Add("OK-ACCESS-PASSPHRASE", ((OkexApiCredentials)_credentials).PassPhrase.GetString());

    //    // Demo Trading Flag
    //    if (baseClient.Options.DemoTradingService)
    //        headers.Add("x-simulated-trading", "1");
    //}

    public static string Base64Encode(byte[] plainBytes)
    {
        return Convert.ToBase64String(plainBytes);
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, ref IDictionary<string, object> uriParameters,
        ref IDictionary<string, object> bodyParameters, ref Dictionary<string, string> headers, bool auth,
        ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition,
        RequestBodyFormat requestBodyFormat)
    {
        var baseClient = ((OkexClientUnifiedApi)apiClient)._baseClient;

        // Check Point
        if (!(auth || baseClient.Options.SignPublicRequests))
            return;

            // Set Parameters
        if (uriParameters != null)
            uri = uri.SetParameters(uriParameters, arraySerialization);

        // Signature Body
        var time = GetTimestamp(apiClient).ToString("yyyy-MM-ddTHH:mm:ss.sssZ");
        var signtext = time + method.Method.ToUpper() + uri.PathAndQuery.Trim('?');

        if (method == HttpMethod.Post)
        {
            if (bodyParameters.Count == 1 && bodyParameters.Keys.First() == "_BODY_")
                signtext += JsonConvert.SerializeObject(bodyParameters["_BODY_"]);
            else
                // signtext += JsonConvert.SerializeObject(bodyParameters.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value));
                signtext += JsonConvert.SerializeObject(bodyParameters);
        }

        // Compute Signature
        var signature = SignHMACSHA256(signtext, SignOutputType.Base64);

        // Headers
        headers ??= new Dictionary<string, string>();
        headers.Add("OK-ACCESS-KEY", _credentials.Key);
        headers.Add("OK-ACCESS-SIGN", signature);
        headers.Add("OK-ACCESS-TIMESTAMP", time);
        headers.Add("OK-ACCESS-PASSPHRASE", _credentials.PassPhrase);

        // Demo Trading Flag
        if (baseClient.Options.DemoTradingService)
            headers.Add("x-simulated-trading", "1");
    }
}
