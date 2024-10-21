using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class LogRepository
    {
        private readonly LogDAO _logDAO;

        public LogRepository()
        {
            _logDAO = new LogDAO();
        }

        public void SaveLog(ApiLogs Log)
        {
            _logDAO.SaveLog(Log);
        }
    }
}