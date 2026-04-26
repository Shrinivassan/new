
using System.ComponentModel.DataAnnotations.Schema;

namespace LIMS.Model
{
    public class ReferralModel
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Name { get; set; } 
        public string Qualification { get; set; } 
        public string Reference { get; set; } 
        // Address was referenced in the UI but missing from this model — add it for compatibility
        public string Address { get; set; } 
        public int AreaCode { get; set; }
        public string AreaName { get; set; }
        public string City { get; set; }
    }


    public class Doctor_Master
    {
        public int DCode { get; set; }
        public int OrderNo { get; set; }
        public String Description { get; set; } 
        public String Name { get; set; }
        public int Qualification { get; set; }
        public string ShortName { get; set; } 
        public int SPCode { get; set; }
        public int TCode { get; set; }
        public int FTCode { get; set; }
        public int RICode { get; set; }
        public int ProCode { get; set; }
        public string Reference { get; set; } 
        public string Address { get; set; } 
        public string Area { get; set; } 
        public string City { get; set; }
        public string ZipCode { get; set; } 
        public string State { get; set; }
        public string Country { get; set; } 
        public string PhoneStdCode { get; set; } 
        public string Phone { get; set; } 
        public string FaxStdCode { get; set; } 
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; } 
        public int APPDoctor { get; set; }
    public string AreaName { get; set; }
    public int AreaCode { get; set; }
    public string ImportReference { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
    public DateTime? EnteredDate { get; set; }
    public DateTime? IBSDate { get; set; }
    public string Initial { get; set; } 
    public string NameTitle { get; set; } 
    // Computed Title property: prefer NameTitle when present, otherwise fall back to Name.
    // This provides a stable property called `Title` that UI pages can consume without
    // requiring changes to server payloads or DB schema.
    public string Title => !string.IsNullOrWhiteSpace(NameTitle) ? NameTitle : (Name ?? string.Empty);
    public string DoctorCode { get; set; } 
    public string OnlinePassword { get; set; }
    public string EntryType { get; set; } 
        public bool SendAccounts { get; set; }
        public bool SendResults { get; set; }
        public bool SendOffer { get; set; }
        public bool SendBillInfo { get; set; }
    public string AccountsMobileNo { get; set; }
    public string ResultMobileNo { get; set; } 
    public string ContactPerson { get; set; } 
    public byte[] DoctorImage { get; set; } 
    public string SMSLabName { get; set; }
    public string Bedno { get; set; } 
    public string DoctorFullName { get; set; } 

    public string DeliveredMode { get; set; }

        public string Password { get => OnlinePassword; set => OnlinePassword = value; }
        public string Code { get => DoctorCode; set => DoctorCode = value; }
        public string Narration { get => Description; set => Description = value; }
        public string SchemeRate { get; set; } = string.Empty;
        public string ResultMobile { get => ResultMobileNo; set => ResultMobileNo = value; }
        public string OffersMobile { get; set; } = string.Empty;
        public string BillInfoMobile { get; set; } = string.Empty;
        public string SendSMSTo { get; set; } = string.Empty;
        public string MonthlyAccount { get => ICChequeName; set => ICChequeName = value; }
        public bool IsvariablePrice { get; set; }
        public bool IsIC { get; set; }
    public string ICPayMode { get; set; }
    public double ICRate { get; set; }
    public string ICChequeName { get; set; }
        public int CreditLimit { get; set; }
        public bool IsSeparateSpecialRate { get; set; }
        public bool IsSpecialRate { get; set; }
        public int SchemeFTCode { get; set; }
        public int SpecialFTCode { get; set; }
        public int CreditDays { get; set; }
        public bool IsCash { get; set; }
        public bool IsCredit { get; set; }
        public int LCode { get; set; }
        public int Qualification_Dr { get; set; }
        public int BHCode { get; set; }
        public int ROTCode { get; set; }
    public string SkyCode { get; set; }

    }

    public class Speciality_Master
        {
            public int SPCode { get; set; }
            public int OrderNo { get; set; }
            public string ShortName { get; set; }
            public string Name { get; set; } 
            // Backwards-compatible alias used by some UI pages
            public string Speciality { get => Name; set => Name = value; }
            public string Description { get; set; }
            public bool Deleted { get; set; }
            public int UserCode { get; set; }
            public int ComputerCode { get; set; }
            public DateTime EnteredDate { get; set; }
            public DateTime IBSDate { get; set; }
        }

    public class Qualification_Master
    {
        public int QualificationId { get; set; }
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
        


        
    }
