using LIMS.Model;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIMS.Model
{
    public enum Ethnicity
    {
        Caucasian,
        AfroCaribbean,
        SouthAsian,
        EastAsian,
        Hispanic,
        MiddleEastern,
        NativeAmerican,
        Other
    }

    public enum HistoryStatus
    {
        Yes,
        No,
        Unknown
    }

    public enum ConceptionMethod
    {
        Natural,
        IVF,
        ICSI,
        DonorEgg,
        Spontaneous,
        OvulationInduction,
        Unknown
    }

    public class MasterModel
    {
    }
    
    public class BillRootObject
    {
        public IList<Counter_Master> counter { get; set; }
        public IList<BillNo_Master> billno { get; set; }
        public IList<REIMBURSEMENT_COMPANY_MASTER> reimbursement { get; set; }
        public IList<Collected_Master> collectedby { get; set; }
        public IList<PayMode_Master> paymode { get; set; }
        public IList<FeeType_Master> feetype { get; set; }

        public IList<RequestPatientDetails> patdetails { get; set; } = new List<RequestPatientDetails>();
    }

    public class RequestPatientDetails
    {
        public int PDCode { get; set; }
        public int OrderNo { get; set; }
        public string Name { get; set; }
        public String PDValue { get; set; }
        public string RequestGUID { get; set; }
    }
    public class AppSettings
    {
        public string BaseUrl { get; set; }
        public string ClientId { get; set; }
    }
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
    }
    public class Sample_Master
    {
        public int SCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool Deleted { get; set; }
        public int Usercode { get; set; }
        public int ComputerCode { get; set; }

        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
    }

  
    public class Customer_Master
    {
        public int CUSTID { get; set; }
        public String CUSTCode { get; set; }

        public String BHCUSTCode { get; set; }

        public int DCode { get; set; }
        public int BHCode { get; set; }
        public DateTime AgeEDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DOBInString { get; set; }
        public int AgeYears { get; set; }
        public int AgeMonths { get; set; }
        public int AgeDays { get; set; }
        public string Gender { get; set; }
        public string NameTitile { get; set; }
        public string Initial { get; set; }
        public string Name { get; set; }
        public string CareOfTitile { get; set; }
        public string CareOfInitial { get; set; }
        public string CareOf { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string PhoneStdCode { get; set; }
        public string Phone { get; set; }
        public string FaxStdCode { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int AreaCode { get; set; }
        public string NamewithInitials { get; set; }
        public byte[] CustomerImage { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public bool IsDiabetic { get; set; }
        public bool IsRegular { get; set; }
        public string CustomerBarCode { get; set; }
        public string CustomerManualCode { get; set; }
        public int FTCode { get; set; }
        public string SignatureBase64 { get; set; }
        public byte[] SignatureImage { get; set; }
        public string AadhaarNo { get; set; }
        public string PassportNo { get; set; }
        public string Nationality { get; set; }



    }
    public class Lab_Request_Master
    {
        public string RequestGUID { get; set; }
        public int RequestSno { get; set; }
        public string RequestSnoPrint { get; set; }
        public string RequestBarCode { get; set; }
        public string RequestConvertedBarCode { get; set; }
        public DateTime RequestDatetime { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public DateTime CollectedDateTime { get; set; }
        public int BNCode { get; set; }
        public int CNTCode { get; set; }
        public Guid CNTTID { get; set; }
        public int TmCode { get; set; }
        public int CUSTID { get; set; }
        public int DCode { get; set; }
        public string Reference { get; set; }
        public int RICode { get; set; }
        public int PackCode { get; set; }
        public int FTCode { get; set; }
        public int CTCode { get; set; }
        public int DLCode { get; set; }
        public int PMCode { get; set; }
        public int LCode { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string AgeYears { get; set; }
        public string AgeMonths { get; set; }
        public string AgeDays { get; set; }
        public string Address { get; set; }
        public int AreaCode { get; set; }
        public string MobileNo { get; set; }
        public Double RequestAmount { get; set; }
        public Double DiscountPer { get; set; }
        public Double DiscountAmount { get; set; }
        public Double TotalAmount { get; set; }
        public Double PaidAmount { get; set; }
        public Double PaidViaReceipt { get; set; }

        public string BillType { get; set; }
        public string TestShortName { get; set; }
        public string TestShortNameforEntry { get; set; }
        public string TestShortNameforCuluture { get; set; }
        public string TestShortNameforTextFormat { get; set; }
        public string PendingTestShortName { get; set; }
        public string PendingTestShortNameforEntry { get;  set; }
        public string PendingTestShortNameforCuluture { get; set; }
        public string PendingTestShortNameforTextFormat { get;  set; }

        public string FinishedTestShortName { get; set; }
        public string FinishedTestShortNameforEntry { get; set; }
        public string FinishedTestShortNameforCuluture { get; set; }
        public string FinishedTestShortNameforTextFormat { get; set; }
        public string DepartmentShortName { get; set; }
        public string ThyroBarCode { get; set; }
        public string Description { get; set; }
        public string OrderGUID { get; set; }
        public Double CommissionAmount { get; set; }
        public Double OurDisPercentage { get; set; }
        public Double OurDiscount { get; set; }
        public bool OurDiscountIsPer { get; set; }
        public Double ReferalPercentage { get; set; }
        public Double ReferalDiscount { get; set; }
        public bool ReferalDiscountIsPer { get; set; }
        public Double CommissionPaid { get; set; }
        public bool CommissionStatus { get; set; }
        public bool IsBillHavingResult { get; set; }
        public bool IsInvestigation { get; set; }
        public bool IsInvestigationStatus { get; set; }
        public bool IsInvestigationPartial { get; set; }
        public bool DeliveryStatus { get; set; }
        public bool RequestStatus { get; set; }
        public bool ResultStatus { get; set; }
        public bool IsCuluture { get; set; }
        public bool CultureStatus { get; set; }
        public bool IsCulturePartial { get; set; }
        public bool IsTextReport { get; set; }
        public bool TextReportStatus { get; set; }
        public bool IsTextReportPartial { get; set; }
        public bool IsHavingLockResult { get; set; }
        public bool IsHavingOthers { get; set; }
        public string OnlineCode { get; set; }
        public bool OnlineViewStatus { get; set; }
        public string OnlinePassword { get; set; }
        public int EnteredBHCode { get; set; }
        public int AlteredBHCode { get; set; }
        public string RoomNo { get; set; }
        public string HospitalID { get; set; }
        public bool Deleted { get; set; }
        public bool IsVerified { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public Double SpecialDiscount { get; set; }
        public Double NewAmount { get; set; }
        public bool IsCashBill { get; set; }
        public bool IsCreditBill { get; set; }
        public string FrontHospitalID { get; set; }
        public string FrontHospitalPatientId { get; set; }
        public string HospitalPatientID { get; set; }
        public bool IsPriceChanged { get; set; }
        public DateTime LastPaymentOn { get; set; }
        public int SecondDCode { get; set; }
        public string SecondDoctorName { get; set; }
        public bool IsManualCommission { get; set; }
        public bool IsHomeCollection { get; set; }
        public int HomeCollectionAreaCode { get; set; }
        public Double HomeCollectionCharge { get; set; }
        public string CommissionPaymentMode { get; set; }
        public string CommissionChequeName { get; set; }
        public bool IsCommissionPaid { get; set; }
        public string ConcessionReason { get; set; }
        public bool IsPosted { get; set; }
        public int BillBNCode { get; set; }
        public int BillNo { get; set; }
        public string BillNoPrint { get; set; }
        public string PathologyNo { get; set; }
        public Double DueConcession { get; set; }
        public bool IsBillIssued { get; set; }
        public bool IsInventoryPosted { get; set; }
        public bool IsTraced { get; set; }
        public bool IsInvestigationAuthorized1 { get; set; }
        public bool IsInvestigationAuthorized2 { get; set; }
        public bool IsInvestigationPrinted1 { get; set; }
        public Double ByCard { get; set; }
        public Double ByCash { get; set; }
        public bool IsCollectionPosted { get; set; }
        public bool IsSendSMS { get; set; }
        public Double RefundAmount { get; set; }
        public string Card_refno { get; set; }
        public string Bank_App { get; set; }
    }

    public class Lab_Request_Details
    {
        public Guid RequestDetailsID { get; set; }
        public string RequestGUID { get; set; }
        public int TestSno { get; set; }
        public int PackCode { get; set; }
        public int TCode { get; set; }
        public Double TestAmount { get; set; }
        public Double CommissionAmount { get; set; }
        public Double ReferalDiscount { get; set; }
        public Double Discount { get; set; }
        public Double Collection { get; set; }
        public bool IsInvestigation { get; set; }
        public bool IsCulture { get; set; }
        public bool IsTextReport { get; set; }
        public bool IsTestHavingResult { get; set; }
        public bool ResultStatus { get; set; }
        public bool IsLockResult { get; set; }
        public bool IsOthers { get; set; }
        public bool RequestStatus { get; set; }
        public bool IsPrinted { get; set; }
        public Double CommissionPaid { get; set; }
        public Double SpecialDiscount { get; set; }
        public Double NewAmount { get; set; }
        public int NewTCode { get; set; }
        public bool IsAuthorized1 { get; set; }
        public bool IsAddSpecial { get; set; }

        public bool IsRemovedSpecial { get; set; }

        public Double StandardPrice { get; set; }
        public string CommissionType { get; set; }
        public Double FTCommissionPer { get; set; }
        public Double FTCommissionAmount { get; set; }
        public Double RunningCost { get; set; }
        public bool IsManualCommission { get; set; }
        public bool IsPack { get; set; }
        public int ResultEnteredBy { get; set; }
        public int ResultAuthorizedBy { get; set; }
        public bool IsSelect { get; set; }
        public string CommissionPaymentMode { get; set; }
        public string CommissionChequeName { get; set; }
        public bool IsCommissionPaid { get; set; }
        public DateTime CommissionGeneratedDate { get; set; }
        public bool IsSampleCollected { get; set; }
        public bool IsSampleReceived { get; set; }
        public bool IsDelivered { get; set; }
        public string DeliveredMode { get; set; }
        public bool IsInventoryPosted { get; set; }
        public int PerformedCount { get; set; }
        public bool IsAuthorized2 { get; set; }
        public bool IsUploaded { get; set; }
        public int ResultAuthorizedBy2 { get; set; }
        public bool IsWorkListPrinted { get; set; }
        public int Qty { get; set; }
        public Double TestRate { get; set; }
        public Double RefundAmount { get; set; }
        public DateTime? ResultEnteredDate { get; set; }
        public DateTime? FirstAuthorizeDate { get; set; }
        public DateTime? SecondAuthorizeDate { get; set; }
    }

    public class Test_Master
    {
        public int TCode { get; set; }
        public int GCode { get; set; }
        public int SCode { get; set; }
        public int RTCode { get; set; }
        public int UCode { get; set; }
        public int RTMCode { get; set; }
        public int OrderNo { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Qty { get; set; }
        public Double Amount { get; set; }
        public bool LockResult { get; set; }
        public bool LockSMS { get; set; }
        public bool TextContent { get; set; }
        public bool CultureReport { get; set; }
        public bool Routine { get; set; }
        public bool OutLab { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public bool PrintInSeparatePage { get; set; }
        public bool PrintGraphinReport { get; set; }
        public string GraphType { get; set; }
        public int CGCode { get; set; }
        public bool IsTest { get; set; }
        public bool IsPackage { get; set; }
        public int PackCode { get; set; }
        public bool IsDC { get; set; }
        public string SkyCode { get; set; }
        public bool IsContrast { get; set; }
        public bool IsNoIC { get; set; }
        public Double LabAmount { get; set; }
        public Double SpecialAmount { get; set; }
        public bool IsFasting { get; set; }
        public bool IsPP { get; set; }
    }
    public class Test_Result_Master
    {
        public int TRCode { get; set; }
        public Guid TestResultID { get; set; }
        public Guid TRGUID { get; set; }
        public int SLNo { get; set; }
        public int TCode { get; set; }
        public int FromTCode { get; set; }
        public string ResultType { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
        public string Col6 { get; set; }
        public string CellContent { get; set; }
        public string NormalFemale { get; set; }
        public string NormalChild { get; set; }
        public int StyleCode { get; set; }
        public bool SendSMS { get; set; }
        public string SMSShortname { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public bool PrintInSeparatePage { get; set; }
        public bool IsCalculated { get; set; }
        public bool IsEntered { get; set; }
        public string CalculatedFormula { get; set; }
        public int DStyleCode { get; set; }
        public int QStyleCode { get; set; }
        public int EStyleCode { get; set; }
        public int UStyleCode { get; set; }
        public int NStyleCode { get; set; }
        public Guid FromTestResultId { get; set; }
        public string SkyCode { get; set; }
    }
    public class REPORT_METHOD
    {
        public int RTMCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int DurationTime { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }

        public DateTime IBSDate { get; set; }
    }
    public class UOM_MASTER
    {
        public int UCode { get; set; }
        public int OrderNo { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int DecimalPlaces { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public int PackSize { get; set; }
    }
     

    public class Test_Result_Properties
    {
        public Guid TRPId { get; set; }
        public Guid TestResultID { get; set; }
        public string ResultValueType { get; set; }
        public int DefaultUnitsCode { get; set; }
        public Guid FXTCode { get; set; }
        public Guid DefaultValueforFXType { get; set; }
        public string DefaultValue { get; set; }
        public bool SimpleNormalValues { get; set; }
        public bool DetailedNormalValues { get; set; }
        public string RangeType { get; set; }
        public Double FromNormalValue { get; set; }
        public Double ToNormalValue { get; set; }
        public string ConclusionForHigher { get; set; }
        public string ConclusionForLower { get; set; }
        public bool PrintFixedTextConclusionInReport { get; set; }
        public string ConclusionforFixedText { get; set; }
        public bool ShowAgedBased { get; set; }
        public bool PrintConclusionInReport { get; set; }
        public bool PrintConclusionInBottom { get; set; }
        public bool ShowAlertOnHigherLower { get; set; }
        public bool IsAddResult { get; set; }
        public bool PrintUnitsInNormalValues { get; set; }
        public bool PrintNormalValuesatBottom { get; set; }
        public bool PrintSpecialFieldsatRightSide { get; set; }
        public bool GroupValuesbySex { get; set; }
        public bool GroupValuesbySpecialField { get; set; }
        public string FooterMessage { get; set; }
        public int RTMCode { get; set; }
        public bool PrintResultOnly { get; set; }
        public bool IsGraph { get; set; }
        public Double GraphValue { get; set; }
        public int DecimalValue { get; set; }
        public int SCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public int MCCode { get; set; }
        public int PerformedCount { get; set; }
        public bool UseDefault { get; set; }
        public Guid NormalValueforFXType { get; set; }
        public string NormalValue { get; set; }
        public bool IsAbnormal { get; set; }
        public string CriticalLowType { get; set; }
        public string CriticalLowRange { get; set; }
        public string CriticalHighType { get; set; }
        public string CriticalHighRange { get; set; }
    }



    [Table(name:"BillNo_Master")]
    public class BillNo_Master
    {
      [Key]  public int BNCode { get; set; }
        public int OrderNo { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public int BHCode { get; set; }
        public bool AllBranch { get; set; }
        public bool RestartFinancialYear { get; set; }
        public bool RestartCalendarYear { get; set; }
        public bool RestartDaily { get; set; }
        public bool IsAllDepartment { get; set; }
        public bool IsDepartmentwise { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public int CNTCode { get; set; }
        public bool RestartMonthly { get; set; }
        public bool IsBillNo { get; set; }
        public bool IsSampleNo { get; set; }

    }

    [Table(name: "BillNo_Departments")]

    public class BillNo_Departments
    {
        [Key]public int BNDCode { get; set; }
        public int BNCode { get; set; }
        public int Sno { get; set; }
        public int DCode { get; set; }
    }

    [Table(name: "Counter_Master")]
    public class Counter_Master
    {
        [Key]public int CNTCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BHCode { get; set; }
        public string CashLCode { get; set; }
        public int? PatientBillLCode { get; set; }
        public int? ReferaBilllLCode { get; set; }
        public int? PatientSalesLCode { get; set; }
        public int? ReferalSalesLCode { get; set; }
        public int? CommissionBillLCode { get; set; }
        public int? CommissionSalesLCode { get; set; }
        public bool TimingCurrent { get; set; }
        public bool TimingVariable { get; set; }
        public DateTime TimingFrom { get; set; }
        public DateTime TimingTo { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public string ExpenseLCode { get; set; }
        public int? TimingFixed { get; set; }
        public int BColor { get; set; }
    }

    [Table(name: "Branch_Master")]
    public class Branch_Master
    {
        [Key]public int BHCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public int AreaCode { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public bool IsMainBranch { get; set; }
        public bool IsBranch { get; set; }
        public bool IsCollectionCentre { get; set; }
        public string BESICNo { get; set; }
        public string BPFNo { get; set; }
        public string ESICName { get; set; }
        public string ESICAddress { get; set; }
        public int BColor { get; set; }
        public string WorkingTime { get; set; }
    }

    [Table(name: "Branch_Master")]
    public class Company_Master
    {
       [Key] public int CCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string TNGST { get; set; }
        public string CST { get; set; }
        public string DlNo { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string VAT { get; set; }
        public string CUSTCode { get; set; }
        public string Description { get; set; }
        public int AreaCode { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
    }


    [Table(name: "Reimbursement_Company_Master")]
    public class REIMBURSEMENT_COMPANY_MASTER
    {
        [Key]public int RICode { get; set; }
        public int OrderNo { get; set; }
        public int FTCode { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public int AreaCode { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public string LCode { get; set; }

    }

    [Table(name:"Collected_Master")]
    public class Collected_Master
    {
       [Key] public int CTCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int DurationTime { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }

    }

    [Table(name: "PayMode_Master")]
    public class PayMode_Master
    {
        public  int PMCode { get; set; }
        public  int OrderNo { get; set; }
        public  string ShortName { get; set; }
        public  string Name { get; set; }
        public  int DurationTime { get; set; }
        public  string Duration { get; set; }
        public  string Description { get; set; }
        public  string Footer { get; set; }
        public  bool Deleted { get; set; }
        public  int UserCode { get; set; }
        public  int ComputerCode { get; set; }
        public  DateTime EnteredDate {get; set;}
        public  DateTime IBSDate {get; set;}
    }

    public class FeeType_Master
    {
        public int FTCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double CommissionPercentage { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public bool IsPatientRate { get; set; }
        public int DCode { get; set; }
        public bool IsCommission { get; set; }
        public bool IsScheme { get; set; }
        public bool IsSpecial { get; set; }
    }

    public class User_Master
    {
        public int UserCode { get; set; }
        public int IBSDCODE { get; set; }
        public int OrderNo { get; set; }
        public string Module { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public bool PowerUser { get; set; }
        public byte[] UserImage { get; set; }
        public byte[] SignatureImage { get; set; }
        public bool Deleted { get; set; }
        public int EUserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public int BHCode { get; set; }
        public int CNTCode { get; set; }
    }
    public class eMailSetup
    {
        [Key] public int Emailid { get; set; }
        public String MailType { get; set; }
        public String MailAddress { get; set; }
        public int Port { get; set; }
        public String HostAddress { get; set; }
        public String MailPassword { get; set; }
        public bool enableSSL { get; set; }

        public string bcc { get; set; }
        public string WAinstance { get; set; }

        public string BillWA { get; set; }

        public string ReportWA { get; set; }
    }
}
