using Microsoft.Identity.Client;

const string ClientId = "a16ac996-3f0c-4e26-a599-c671a23b9140";
const string TenantId = "48e8fa91-4555-4582-b900-fe5d660203a4";
const string RedirectUri = "http://localhost";

var app = PublicClientApplicationBuilder.Create(ClientId)
    .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
    .WithRedirectUri(RedirectUri)
    .Build();
    
var scopes = new[] { "user.read" };
var authResult = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

Console.WriteLine($"AccessToken: {authResult.AccessToken}");
