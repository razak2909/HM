using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAO.Queries
{
    public class CommonQueries
    {
        public const string CommonGet = "Select * from @TableName where Status = 1";

        public const string GetLawFirmIdByUserName = @"Select LawFirmId from [User] where [Name]=@UserName";
    }
}