using IdentityServerFromScratch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryApiScopes(Config.GetApiScopes())
    .AddInMemoryClients(Config.GetClients())
    .AddTestUsers(Config.GetTestUser())
    .AddInMemoryApiResources(Config.GetApiResources())
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(Config.GetResources());

var app = builder.Build();

app.UseIdentityServer();

/*
 // uncomment, if you want to add MVC-based
 app.UseAuthentication();
 app.UseAuthorization();
 */

//app.MapGet("/", () => "Hello World!");
app.Run();

