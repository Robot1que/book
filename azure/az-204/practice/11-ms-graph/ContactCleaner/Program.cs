using Azure.Identity;
using Microsoft.Graph;

const string ClientId = "226b1f5b-8977-4701-aba9-8d6f2070f8d0";
const string TenantId = "32cc4661-2c75-4fa3-a1d6-a7c02192a7d3";

var scopes = new [] { "User.Read", "Contacts.ReadWrite" };

var credOptions = new InteractiveBrowserCredentialOptions
{
    TenantId = TenantId,
    ClientId = ClientId,
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
    RedirectUri = new Uri("http://localhost")
};
var cred = new InteractiveBrowserCredential(credOptions);
var client = new GraphServiceClient(cred, scopes);

var me = await client.Me.Request().GetAsync();

var contacts = await client.Me.Contacts.Request().GetAsync();
foreach (var contact in contacts)
{
    Console.WriteLine(contact.DisplayName);
}
