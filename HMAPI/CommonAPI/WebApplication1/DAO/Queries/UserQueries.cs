
namespace WebApplication1.DAO.Queries
{
    public class UserQueries
    {
        //public const string Get_All_User_ByLawfirmId = @"Select * from [User] where LawFirmId = @LawFirmId and Status = 1";

        public const string Get_All_User_Details = @"Select * from [User] where Status =1";


        public const string GET_USER_FROM_USERID = "SELECT * FROM [User] WHERE UserId = @UserId AND Status = 1;";

        public const string GET_USER_FROM_USERROLE = "SELECT * FROM [User] WHERE RoleName = @RoleName AND Status = 1;";

        public const string GET_USER_FROM_USERNAME_AND_PASSWORD = "SELECT * FROM [User] WHERE UserId = @UserName AND Password = @Password AND Status = 1;";

        public const string DELETE_USER_FROM_USERID = "DELETE FROM [User] WHERE UserId = @UserId";
        

        //public const string DELETE_USER_FROM_USERID = "UPDATE [User] SET ModifiedBy = @ModifiedBy, Status = 0, ModifiedAt = @ModifiedAt WHERE UserId = @UserId;";

        public const string INSERT_INTO_USER = "INSERT INTO [User] " +
            "([Name],[UserId],[Password],[Photo],[PhotoFileName],[Designation],[RoleName],[Age],[EmailId],[MobileNo],[LandlineNo],[PermanentAddress],[PresentAddress],[CreatedBy],[CreatedAt],[Status]) " +
            "VALUES(@Name, @UserId, @Password, @Photo, @PhotoFilename, @Designation, @RoleName, @Age, @EmailId, " +
            "@MobileNo, @LandlineNo, @PermanentAddress, @PresentAddress,@CreatedBy, @CreatedAt, @Status)";

        public const string UPDATE_USER_FROM_USERID = "UPDATE [User] SET" +
            "[Name] = @Name,[Designation] = @Designation,[RoleName] = @RoleName,[EmailId] = @EmailId,[MobileNo] = @MobileNo,[PermanentAddress] = @PermanentAddress,[PresentAddress] = @PresentAddress,[ModifiedBy] = @ModifiedBy,[ModifiedAt] = @ModifiedAt " +
            "WHERE [UserId] = @UserId;";

        public static string getActiveUserCount = "SELECT COUNT(*) FROM [User] WHERE Status = 1";


    }
}
