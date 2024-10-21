using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Threading.Tasks;
using WebApplication1.DAO;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            //Get the client ID from the Ticket properties
            var userId = context.Ticket.Identity.Name;
            //   contex
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            //Generating a Uniqure Refresh Token ID
            var refreshTokenId = Guid.NewGuid().ToString("n");

            using (AuthenticationRepository _repo = new AuthenticationRepository())
            {
                // Getting the Refesh Token Life Time From the Owin Context
                var refreshTokenLifeTime = context.OwinContext.Get<string>("ta:clientRefreshTokenLifeTime");

                //Creating the Refresh Token object
                var token = new RefreshToken()
                {
                    //storing the RefreshTokenId in hash format
                    ID = HashHelper.GetHash(refreshTokenId),
                    UserName = context.Ticket.Identity.Name,
                    IssuedTime = DateTime.UtcNow,
                    ExpiredTime = DateTime.UtcNow.AddMinutes(5)
                };

                //Setting the Issued and Expired time of the Refresh Token
                context.Ticket.Properties.IssuedUtc = token.IssuedTime;
                context.Ticket.Properties.ExpiresUtc = token.ExpiredTime;

                token.ProtectedTicket = context.SerializeTicket();

                var result = await _repo.
                    AddRefreshToken(token);

                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
            string hashedTokenId = HashHelper.GetHash(context.Token);
            using (AuthenticationRepository _repo = new AuthenticationRepository())
            {
                var refreshToken = await _repo.FindRefreshToken(hashedTokenId);
                if (refreshToken != null)
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket(refreshToken.ProtectedTicket);
                    var result = await _repo.RemoveRefreshTokenByID(hashedTokenId);
                }
            }
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}