using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityModel;

namespace IdentityServerFromScratch;
// /.well-known/openid-configuration
public static class Config
{
	public static List<TestUser> GetTestUser()
	{
        /*
         * Los siguientes parametros se los toma del método -> GetClients() y eso se lo coloca en el postman
		 POST - http://localhost:5000/connect/token
		 client_id => testclient,
		 client_secret => testsecret,
		 grant_type => client_credentials,
		 scope => testapis
		 */
        /*
		 scopes => [
			"weatherapi.read", 
			"weatherapi.write"
		 ]
		 */
        return new List<TestUser>
		{
			new TestUser
			{
				SubjectId = "12345",
				Username = "cristian",
				Password = "cristian",
				Claims =
				{
					new Claim(JwtClaimTypes.Name, "Cristian Pisco"),
                    new Claim(JwtClaimTypes.GivenName, "Cristian"),
                    new Claim(JwtClaimTypes.FamilyName, "Pisco"),
                    new Claim(JwtClaimTypes.Email, "cristian.pisco@outlook.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://cristianpisco.dev"),
                }
			}
		};
	}
	public static IEnumerable<ApiScope> GetApiScopes()
	{
		return new List<ApiScope>
		{
			//new ApiScope(name: "read",             displayName: "Read your data."),
			//new ApiScope(name: "write",            displayName: "Write your data."),
			//new ApiScope(name: "delete",           displayName: "Delete your data."),
            //new ApiScope(name: "weatherapi.read",  displayName: "Read weather data."),
            //new ApiScope(name: "weatherapi.write", displayName: "Write weather data."),
            new ApiScope(name: "test_api",         displayName: "Test API Scope.")
		};
	}
	public static IEnumerable<Client> GetClients()
	{
		return new List<Client>
		{
			new Client
			{
				ClientId = "client",
				ClientName = "Client Credentials",
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				ClientSecrets = { new Secret("secreto".Sha256()) },
                AllowedScopes = { "test_api" }
				//AllowedScopes = { "weatherapi.read", "weatherapi.write" }
			}
		};
	}
	public static IEnumerable<IdentityResource> GetResources()
	{
		return new List<IdentityResource>
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResource
			{
				Name = "role",
				UserClaims = new List<string> { "role" }
			}
		};
	}
	public static IEnumerable<ApiResource> GetApiResources()
	{
		return new List<ApiResource>
		{
			new ApiResource("weatherapi")
			{
				Scopes = new List<string> { "weatherapi.read", "weatherapi.write" },
				ApiSecrets = new List<Secret> { new Secret("secreto".Sha256()) },
				UserClaims = new List<string> { "role" },
			}
		};
	}
}

