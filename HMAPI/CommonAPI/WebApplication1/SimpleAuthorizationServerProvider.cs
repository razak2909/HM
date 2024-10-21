using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using WebApplication1.Repositories;

namespace WebApplication1
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly UserRepository _userRepo;

        public SimpleAuthorizationServerProvider()
        {
            _userRepo = new UserRepository();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            /*  var originalClient = context.Ticket.Properties.Dictionary["client_id"];
              var currentClient = context.ClientId;
              if (originalClient != currentClient)
              {
                  context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                  return Task.FromResult<object>(null);
              }*/

            // Change auth ticket for refresh token requests

            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = await _userRepo.LoginUser(context.UserName, context.Password);
                if (user != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.RoleName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Provided credentials are incorrect");
                    context.Rejected();
                }

                return;
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.ToString() + ex.Message + ex.InnerException.ToString());
                context.Rejected();
            }
        }
    }
}
