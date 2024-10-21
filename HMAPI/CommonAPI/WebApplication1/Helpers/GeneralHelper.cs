using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class GeneralHelper
    {
        //public static string __BASE_URL__ = WebConfigurationManager.AppSettings["ApiBaseURL"]; // "http://208.109.10.239/PCBErpAPI";

        //public static int? GetUserWiseId(UserDetails user)
        //{
        //    int? FilterId = null;
        //    switch (user.UserLevel)
        //    {
        //        case "HeadOffice":
        //            FilterId = user.HeadOfficeId;
        //            break;
        //        case "RegionalOffice":
        //            FilterId = user.RegionalOfficeId;
        //            break;
        //        case "Zone":
        //            FilterId = user.ZoneId;
        //            break;
        //    }

        //    return FilterId;
        //}

        //public static string GenerateRandomNumber()
        //{
        //    return new Random().Next(111111, 999999).ToString().Replace("0", "1");
        //}

        //public static string NormalizeString(string InputString)
        //{
        //    string cleanedString = Regex.Replace(InputString, @"[^a-zA-Z0-9]+", "");

        //    string normalizedString = cleanedString.Length > 10 ? cleanedString.Substring(0, 10) : cleanedString;

        //    return normalizedString;
        //}

        //public static BankInfoModel GetBankInfoFromIFSC(string BankIFSC)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = httpClient.GetAsync($"https://ifsc.razorpay.com/{BankIFSC}").Result)
        //        {
        //            string apiResponse = response.Content.ReadAsStringAsync().Result;
        //            return JsonConvert.DeserializeObject<BankInfoModel>(apiResponse);
        //        }
        //    }
        //}

        //public static string GenerateUniqueId(int RegionalId, int DistrictId, int CategoryId)
        //{
        //    IndustryDAO industryDAO = new IndustryDAO();
        //    CategoryDAO categoryDAO = new CategoryDAO();
        //    DistrictDAO districtDAO = new DistrictDAO();
        //    RegionalOfficeDAO regionalOfficeDAO = new RegionalOfficeDAO();

        //    var industryId = industryDAO.GetLastIndustryId().ToString();
        //    var category = categoryDAO.GetCategoryById(CategoryId);
        //    var district = districtDAO.GetDistrictById(DistrictId);
        //    var regionalOffice = regionalOfficeDAO.GetRegionalOfficeById(RegionalId);

        //    var uniqueId = "";

        //    if (regionalOffice != null)
        //    {
        //        uniqueId += regionalOffice.UniqueCode;
        //    }
        //    if (district != null)
        //    {
        //        uniqueId += district.ShortCode;
        //    }
        //    if (category != null)
        //    {
        //        uniqueId += (category.Name == "17-Red" ? "SEV" : category.Name.Substring(0, 3));
        //    }

        //    while (industryId.Length < 6)
        //    {
        //        industryId = "0" + industryId;
        //    }

        //    uniqueId = uniqueId + industryId;

        //    return uniqueId.ToUpper();
        //}
    }
}
