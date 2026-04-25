using LIMS.Model;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Lims.Components.Model
{
    public class QueryModel
    {
    }

    public class ReferralLogin
    {
        [Required(ErrorMessage = "User Name is required")]
        public string DoctorCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select a branch")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a branch")]
        public int BranchCode { get; set; }
        public string LoginType { get; set; } = "User";
    }
    public class LoginResponse
    {
        public string token { get; set; }
        public User_Master userdetails { get; set; }
        public IList<User_Rights> rights { get; set; }
    }
    public class UserAuth
    {
        public string token { get; set; }
        public int UserCode { get; set; }
        public string Name { get; set; }
        public int CounterCode { get; set; }
        public int BranchCode { get; set; }
    }
    public class User_Rights
    {
        public int UserModuleID { get; set; }
        public int Sno { get; set; }
        public string ModuleName { get; set; }
        public string Department { get; set; }
        public int UserModuleRightsID { get; set; }
        public int UserCode { get; set; }
        public bool ToAdd { get; set; }
        public bool ToView { get; set; }
        public bool ToEdit { get; set; }
        public bool ToDelete { get; set; }
    }

    public class UserModuleRights
    {
        public int UserModulesRightsID { get; set; }   // Primary Key
        public int UserCode { get; set; }              // Checked
        public int UserModuleId { get; set; }          // Checked
        public bool ToAdd { get; set; }                // Checked
        public bool ToView { get; set; }               // Checked
        public bool ToEdit { get; set; }               // Checked
        public bool ToDelete { get; set; }             // Checked
    }
    public class FileDownloadResult
    {
        public string FileName { get; set; }
        public byte[] Base64 { get; set; }
        public string ContentType { get; set; }
    }

    public class RoutineReportDto
    {
        public string ClientID { get; set; }
        public string ReportName { get; set; }
        public string DataSource { get; set; }
        public string RequestGUID { get; set; }
        public string TCode { get; set; }
        public string QueryString { get; set; }
        public bool IsAuthorized2Finished { get; set; }
        [JsonProperty("Parameters")]
        public List<ReportParameterDto> Parameters { get; set; }
    }

    public class ReportParameterDto
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }

    public class LabReportRequest
    {
        public RoutineReportDto rpt { get; set; }
    }
}
