
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LIMS.Model
{
    public class BillSaveResponse
    {
        public string Status { get; set;}
        public string RequestGUID { get; set;}
        public int RequestSno { get; set;}
        public string RequestSnoPrint { get; set;}
        public string Customer { get; set;}
        public string CUSTCode { get; set;}
    }
    public class BillRequest
    {
        public Customer_Master customer { get; set; } = new Customer_Master();
        public Lab_Request_Master Request_Master { get; set; } = new Lab_Request_Master();
        public IList<Lab_Request_Details> Request_Details { get; set; } = new List<Lab_Request_Details>();
        public RequestForm reqfrom { get; set; } = new RequestForm();

        public IList<RequestPatientDetails> Request_PatientDetails { get; set; } = new List<RequestPatientDetails>();
        
    }
        public class RequestForm
{
    public Guid ID { get; set; }
    public int CustID { get; set; }
    public Guid RequestGUID { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }
    public bool Smoking { get; set; }

    public bool PassiveSmoking { get; set; }
    [JsonProperty("Ethinicity")]
    public string Ethnicity { get; set; }
    public string LMP { get; set; }
    public string LMPStatus { get; set; }
    public string EDD { get; set; }
    public bool IsNatural { get; set; }

    public bool IsAssisted { get; set; }
    public bool IsSelfEgg { get; set; }
    public bool DonotEgg { get; set; }
    public string ProcedureType { get; set; }
    public string DonorAge { get; set; }
    public DateTime DonorDOB { get; set; }
    public DateTime ExtractionDate { get; set; }
    public DateTime TransferDate { get; set; }
    public DateTime DateOfUltraSound { get; set; }
    public bool IsSingle { get; set; }
    public bool IsTwin { get; set; }
    public string Chorionicity { get; set; }
    public float CRL1 { get; set; }
    public float NT1 { get; set; }
    public string NB1 { get; set; }
    public float CRL2 { get; set; }
    public float NT2 { get; set; }
    public string NB2 { get; set; }
    public float BPD { get; set; }
    public float HC { get; set; }
    public float AC { get; set; }
    public float FL { get; set; }
    public string ParityHistory { get; set; }
    public bool T21 { get; set; }
    public bool T18 { get; set; }
    public bool T13 { get; set; }
    public bool NTD { get; set; }
    public bool FamilyHistory { get; set; }
    public bool DiabeticIDDM { get; set; }
    public bool DiabeticGDM { get; set; }
    public bool Bleeding { get; set; }
    public bool FolicAcid { get; set; }
    public bool HCGDose { get; set; }
    public string LastHCGDose { get; set; }
    public string Screening { get; set; }
    public DateTime EnteredDate { get; set; }
    public int UserCode { get; set; }

}

    public class PatientDetails_Master
    {
        public int PDCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }

        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }

    }

  
    public class Lab_Request_PatientDetails
    {
         public Guid LRPDID { get; set; }
        public string RequestGUID { get; set; }
        public int Sno { get; set; }
        public int PDCode { get; set; }
        public string PDValue { get; set; }

    }

    public class ViewResultSearch
    {
        public int RequestSNo { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string CustCode { get; set; }
        public string Name { get; set; }
        public string Doctor { get; set; }
        public int RequestAmount { get; set; }
        public int DiscountPer { get; set; }
        public int DiscountAmount { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int Balance { get; set; }
        public string RequestGUID { get; set; }
        public string TestShortName { get; set; }
        public bool IsInvestigation { get; set; }
        public bool IsCulture { get; set; }
        public bool IsTextReport { get; set; }
        public string ResultStatus { get; set; } = "";
        public int TCode { get; set; }
        public int GCode { get; set; }
        public string GroupName { get; set; }
        public int EnteredBHCode { get; set; }
        public int AlteredBHCode { get; set; }
        public bool IsScan { get; set; }
        public bool IsLab { get; set; }
        public int BNCode { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsAuthorized1 { get; set; }
        public bool IsSampleCollected { get; set; }
        public bool IsSampleReceived { get; set; }
        public int BillNo { get; set; }
        public string BillNoPrint { get; set; }
        public int BillBNCode { get; set; }
        public int DCode { get; set; }
        public string Mobile { get; set; }
        public string DoctorFullName { get; set; }
        public string TestName { get; set; }
        public bool IsAuthorized2 { get; set; }
        public string RequestResultStatus { get; set; } = "";
        public bool IsInvestigationAuthorized1 { get; set; }
        public bool IsInvestigationAuthorized2 { get; set; }
        public bool IsWorkListPrinted { get; set; }
        public string PathologyNo { get; set; }
        public string? OnlineCode { get; set; }
        public string? OnlinePassword { get; set; }
        public bool IsOthers { get; set; }
        public string HospitalID { get; set; }
        public string HospitalPatientID { get; set; }
        public bool IsSendSMS { get; set; }
    }
}
