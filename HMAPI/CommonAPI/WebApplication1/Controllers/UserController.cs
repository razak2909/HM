using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using WebApplication1.DAO;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Log]

    public class UserController : ApiController
    {
        private readonly UserRepository _userRepo;


        public UserController()
        {
            _userRepo = new UserRepository();
        }

    
        [Route("api/User/getAllUser")]
        public IHttpActionResult GetUser()
        {
            
            var result = _userRepo.GetAllUser();
            return Ok(result);
        }

        public IHttpActionResult GetUser(string Key)
        {
            var result = _userRepo.GetSingleUser(Key);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/User/UserRole")]
        public IHttpActionResult GetUserBasedOnRole(string RoleName)
        {
            var result = _userRepo.GetUserBasedOnRole(RoleName);
            return Ok(result);
        }

        [Route("api/User/AddEdit")]
        public IHttpActionResult PostAddEditUser(bool IsEdit = false)
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                ClaimsIdentity identity = User.Identity as ClaimsIdentity;

                var jsonStr = httpRequest.Form["JsonObjStr"];
                Console.WriteLine(jsonStr);  // Check what JSON string is being passed


                var obj = JsonConvert.DeserializeObject<User>(httpRequest.Form["JsonObjStr"]);

                obj.Name = obj.UserId;

                if (obj == null)
                {
                    return Ok(new ResultModel()
                    {
                        Success = false, 
                        Data = null,
                        ErrorMessage = "Bad Request.",
                        TechDetails = "Bad Request."
                    });
                }

                DateTime currentDate = DateTime.Now;

                var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/ProjectFiles/UserProfile/");
                if (!System.IO.Directory.Exists(mappedPath))
                    System.IO.Directory.CreateDirectory(mappedPath);

                var files = httpRequest.Files;
                for (int i = 0; i < files.AllKeys.Length; i++)
                {
                    string fileKey = files.AllKeys[i];
                    if (fileKey == "ProfilePhoto")
                    {
                        var postedFile = httpRequest.Files[files.AllKeys[i]];
                        using (var binaryReader = new BinaryReader(postedFile.InputStream))
                        {
                            var bts = binaryReader.ReadBytes(postedFile.ContentLength);
                            if (bts != null && bts.Length > 0)
                            {
                                obj.PhotoFileName = "Profile" + currentDate.ToString("dd_MMM_yyyy_HH_mm_ss") + Path.GetExtension(postedFile.FileName);

                                var path = Path.Combine(mappedPath, obj.PhotoFileName);
                                File.WriteAllBytes(path, bts);
                            }
                        }
                    }
                }

                var result = _userRepo.InsertUpdateUser(obj, IsEdit, identity.Name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error processing request.",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                });
            }
        }

        [HttpDelete]
        [Route("api/User/Delete")]
        public IHttpActionResult DeleteUser(string Key)
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                ClaimsIdentity identity = User.Identity as ClaimsIdentity;

                var result = _userRepo.DeleteUser(Key, identity.Name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error processing request.",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                });
            }
        }

        [HttpPut]
        [Route("api/User/forgotpassword")]
        public IHttpActionResult ForgotUserController()
        {
            try
            {
                UserDetails user = JsonConvert.DeserializeObject<UserDetails>
                   (HttpContext.Current.Request.Form["JsonObjStr"]);


                var obj = new UserRepository();
                if (obj.ForgotUserRepository(user))
                {
                    return Ok(new ResultModel
                    {
                        Success = true,
                        Data = $"Password has been updated sucessfully",
                        TechDetails = string.Empty,
                        ErrorMessage = string.Empty
                    });
                }
                else
                {
                    return Ok(new ResultModel
                    {
                        Success = false,
                        Data = $"UserId {user.UserId} and EmailId {user.EmailId} Invalid",
                        TechDetails = string.Empty,
                        ErrorMessage = string.Empty
                    });
                }

            }
            catch (Exception e)
            {
                return Ok(new ResultModel
                {
                    Success = false,
                    Data = null,
                    TechDetails = e.Message,
                    ErrorMessage = e.StackTrace
                });
            }
        }


        [HttpGet]
        [Route("api/getTotalUserCount")]
        public IHttpActionResult GetUserCount()
        {
            var obj = new UserRepository();
            var result = obj.GetUserCountRepo();
            return Ok(result);
        }
    }
}
