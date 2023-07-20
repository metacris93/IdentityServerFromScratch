using IdentityServerFromScratch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options =>
{
    //options.Events.RaiseErrorEvents = true;
    //options.Events.RaiseInformationEvents = true;
    //options.Events.RaiseFailureEvents = true;
    //options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddTestUsers(Config.GetTestUser())
    .AddInMemoryClients(Config.GetClients())
    .AddInMemoryApiResources(Config.GetApiResources())
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(Config.GetResources())
    .AddInMemoryApiScopes(Config.GetApiScopes());

var app = builder.Build();

app.UseIdentityServer();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();

