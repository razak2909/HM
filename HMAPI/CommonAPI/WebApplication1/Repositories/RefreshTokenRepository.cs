using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RefreshTokenRepository
    {
        private readonly RefreshTokenDAO _refreshTokenDAO;

        public RefreshTokenRepository()
        {
            _refreshTokenDAO = new RefreshTokenDAO();
        }

        public async Task<RefreshToken> GetRefreshToken(string userName)
        {
            return await _refreshTokenDAO.GetRefreshToken(userName);
        }

        public async Task<List<RefreshToken>> GetAllRefreshToken()
        {
            return await _refreshTokenDAO.GetAllRefreshToken();
        }

        public async Task<string> InsertRefreshToken(RefreshToken user)
        {
            return await _refreshTokenDAO.InsertRefreshToken(user);
        }

        public async Task<bool> DeleteRefreshToken(string refreshTokenId)
        {
            return await _refreshTokenDAO.DeleteRefreshToken(refreshTokenId);
        }
    }
}
