namespace Okex.Net.Objects.Core;

public class OkexApiCredentials : ApiCredentials
{
    public string PassPhrase { get; }

    public OkexApiCredentials(string apiKey, string apiSecret, string apiPassPhrase) : base(apiKey, apiSecret)
    {
        PassPhrase = apiPassPhrase;
    }

    public override ApiCredentials Copy()
    {
        return new OkexApiCredentials(Key, Secret, PassPhrase);
    }
}
