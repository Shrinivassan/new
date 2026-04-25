using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIMS.Model
{
    public class GeneticsModel
    {
    }

    public class PreNatal_Test_Master
    {
      [Key]  public int PNCode { get; set; }
        public int TCode { get; set; }
        public string Method { get; set; }
        public string Interpretation { get; set; }
        public string Comments { get; set; }
        public string Disclaimer { get; set; }
        public string Abnormal { get; set; }
        public string Normal { get; set; }
    }

   
    public class PreNatal_Test_Result_Master
    {
        [Key] public Guid PNTRID { get; set; }
        public int PNCode { get; set; } 
        public int TCode { get; set; }
        public string BiochemicalMarker { get; set; }
        public string Concentration { get; set; }
        public string Unit { get; set; }
        public string CorrMOM { get; set; }
        public string Disorder { get; set; }
        public string RiskValue { get; set; }
        public string CutOff { get; set; }
        public string FinalRisk { get; set; }

        public string RangeType { get; set; }
        public Double RangeFrom { get; set; }
        public Double RangeTo { get; set; }


        public string LowMessage { get; set; }
        public string HighMessage { get; set; }
        public string NormalMessage { get; set; }

        public string Method { get; set; }
        public string Title { get; set; }
        public string MachineCode { get; set; }
        public string RiskValueMachineCode { get; set; }
        public string CutOffMachineCode { get; set; }

    }

   
    public class PreNatal_Results_Master
    {
       [Key] public Guid PNID { get; set; }
        public int PNSno { get; set; }
        public DateTime CollectedDateTime { get; set; }
        public DateTime ReceivedDateTime { get; set; }
        public DateTime ResultDateTime { get; set; }
        public Guid RequestGUID { get; set; }
        public int TCode { get; set; }
        public string Method { get; set; }
        public string Interpretation { get; set; }
        public  string Comments { get; set; }
        public string Disclaimer { get; set; }
        
        public int EnteredBy { get; set; }
        public int ApprovedBy { get; set; }
        public int AuthorizedBy { get; set; }
        public string Filepath1 { get; set; }
        public string Filepath2 { get; set; }
        public string Filepath3 { get; set; }

    }
 
    public class PreNatal_Result_Details
    {
        public Guid PNDetailsID { get; set; }
        public Guid PNID { get; set; }
        public string BiochemicalMarker { get; set; }
        public string Concentration { get; set; }
        
        public string Unit { get; set; }
        public string CorrMOM { get; set; }
        public string Disorder { get; set; }
        public string RiskValue { get; set; }
        public string  CutOff { get; set; }
        public string FinalRisk { get; set; }
        public string RangeType { get; set; }
        public Double RangeFrom { get; set; }
        public Double RangeTo { get; set; }

        public string LowMessage { get; set; }
        public string HighMessage { get; set; }
        public string NormalMessage { get; set; }

        public bool ResultLow { get; set; }
        public bool ResultHigh { get; set; }
        public bool ResultNormal { get; set; }

        public string Title { get; set; }
        public string MachineCode { get; set; }
        public string RiskValueMachineCode { get; set; }
        public string CutOffMachineCode { get; set; }
    }

    public class PreNatalMasterData
    {
        public PreNatal_Test_Master ptm { get; set; }
        public IList<PreNatal_Test_Result_Master> ptrm { get; set; }
    }

    public class PreNatalResultData
    {
        public PreNatal_Results_Master prm { get; set; }
        public IList<PreNatal_Result_Details> prd { get; set; }
    }
    public class PreNatalRequest
    {
        public Guid RequestGUID { get; set; }
        public int RequestSno { get; set; }
        public string RequestSnoPrint { get; set; }

        public DateTime RequestDateTime { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }

        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string DoctorFullName { get; set; }
        public int DCode { get; set; }
        public string SecondDoctorName { get; set; }
        public int SecondDCode { get; set; }
        public string TestName { get; set; }
        public int TCode { get; set; }
        public string SkyCode { get; set; }
        public string RequestStatus { get; set; }


        public int? EnteredBy { get; set; }
        public int? ApprovedBy { get; set; }
        public int? AuthorizedBy { get; set; }

        public string? FilePath1 { get; set; }
        public string? FilePath2 { get; set; }
        public string? FilePath3 { get; set; }
    }
    public class PreNatalReportModel
    {
        public string ReportName { get; set; }
        public string RequestGUID { get; set; }
        public int TCode { get; set; }
        public List<Parameters> Parameters { get; set; }
    }
    public class Parameters
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
