using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AuthenticationRepository :IDisposable
    {
        private readonly string _connectionString;

        public AuthenticationRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            RefreshTokenRepository repo = new RefreshTokenRepository();

            var existingToken = await repo.GetRefreshToken(token.UserName);
            if (existingToken != null)
            {
                var result = await RemoveRefreshTokenByID(existingToken.ID);
            }

            var Id = await repo.InsertRefreshToken(token);
            return !string.IsNullOrWhiteSpace(Id);
        }

        public async Task<bool> RemoveRefreshTokenByID(string refreshTokenId)
        {
            RefreshTokenRepository repo = new RefreshTokenRepository();
            return await repo.DeleteRefreshToken(refreshTokenId);
        }

        //Find the Refresh Token by token ID
        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            RefreshTokenRepository repo = new RefreshTokenRepository();
            return await repo.GetRefreshToken(refreshTokenId);
        }

        //Get All Refresh Tokens
        public async Task<List<RefreshToken>> GetAllRefreshToken()
        {
            RefreshTokenRepository repo = new RefreshTokenRepository();
            return await repo.GetAllRefreshToken();
        }

        public void Dispose()
        {

        }
    }
}