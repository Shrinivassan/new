using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LIMS.Model;

namespace BirdAPI.Model
{
    // ──────────────────────────────────────────────────────────────────────────
    //  Response model for GetResult
    // ──────────────────────────────────────────────────────────────────────────

    public class ResultEntryModel
    {
        public IList<LabResultEntry> Results { get; set; }
        public IList<UOM_MASTER> Units { get; set; }
        public IList<Sample_Master> Samples { get; set; }
        public IList<Machine_Master> Machines { get; set; }
        public IList<REPORT_METHOD> Methods { get; set; }
    }

    // ──────────────────────────────────────────────────────────────────────────
    //  Response model for GetTestResultDetails
    // ──────────────────────────────────────────────────────────────────────────

    public class TestResultDetailsModel
    {
        public bool IsResulted { get; set; }

        // Unified fields using Lab_Result_* schema
        public IList<Lab_Result_Properties> Properties { get; set; } = new List<Lab_Result_Properties>();
        public IList<Lab_Result_TextNormalValues> TextNormalValues { get; set; } = new List<Lab_Result_TextNormalValues>();
        public IList<Lab_Result_DetailedNormalValues> DetailedNormalValues { get; set; } = new List<Lab_Result_DetailedNormalValues>();
        public IList<Lab_Result_CalculatedFormula> CalculatedFormulas { get; set; } = new List<Lab_Result_CalculatedFormula>();

        public IList<Lab_Result_Properties> LabProperties { get; set; } = new List<Lab_Result_Properties>();
        public IList<Lab_Result_TextNormalValues> LabTextNormalValues { get; set; } = new List<Lab_Result_TextNormalValues>();
        public IList<Lab_Result_DetailedNormalValues> LabDetailedNormalValues { get; set; } = new List<Lab_Result_DetailedNormalValues>();
        public IList<Lab_Result_CalculatedFormula> LabCalculatedFormulas { get; set; } = new List<Lab_Result_CalculatedFormula>();
    }

    // ──────────────────────────────────────────────────────────────────────────
    //  Lab result entry (used for both GET response and POST save request)
    // ──────────────────────────────────────────────────────────────────────────

    public class LabResultEntry
    {
        public string RequestGUID { get; set; }
        public int SLNo { get; set; }
        public int TCode { get; set; }
        public string? TestName { get; set; }
        public int OrderNo { get; set; }
        public int GroupOrder { get; set; }
        public int GCode { get; set; }
        public string? GroupName { get; set; }
        public string? Col2 { get; set; }
        public string? EnteredResult { get; set; }
        public string? ResultValueType { get; set; }
        public string? NormalValue { get; set; }
        public Guid TestResultId { get; set; }
        public bool Status { get; set; }
        public Guid DefaultValueforFXType { get; set; }
        public Guid FXTCode { get; set; }
        public bool ResultNormal { get; set; }
        public bool ResultHigh { get; set; }
        public bool ResultLow { get; set; }
        public string? ResultType { get; set; }
        public int FromTcode { get; set; }
        public Guid FromTestResultId { get; set; }
        public bool SimpleNV { get; set; }
        public bool DetailedNV { get; set; }
        public string? CalculatedFormula { get; set; }
        public int DefaultUnitsCode { get; set; }
        public string? DefaultUnitValue { get; set; }
        public int MCCode { get; set; }
        public string? MachineName { get; set; }
        public int SCode { get; set; }
        public int ResultEnteredBy { get; set; }
        public bool IsAuthorized1 { get; set; }
        public bool IsAuthorized2 { get; set; }
        public int ResultAuthorizedBy { get; set; }
        public int ResultAuthorizedBy2 { get; set; }
        public string? fixedvalues { get; set; }
        public string? SampleName { get; set; }
        public string? UnitName { get; set; }
        public int RTMCode { get; set; }
        public List<Lab_Result_TextNormalValues>? EditedTextNormalValues { get; set; }
        public List<Lab_Result_DetailedNormalValues>? EditedDetailedNormalValues { get; set; }
        public List<Lab_Result_CalculatedFormula>? EditedCalculatedFormulas { get; set; }
        
        public Lab_Result_Properties? LabProperties { get; set; }
    }

    // ──────────────────────────────────────────────────────────────────────────
    //  Lab result table entities  (Lab_Result_*)
    // ──────────────────────────────────────────────────────────────────────────

    [Table("Lab_Result_Master")]
    public class Lab_Result_Master
    {
        [Key] public string ResultGUID { get; set; }
        public int ResultSNo { get; set; }
        public string ResultBarCode { get; set; }
        public string ResultConvertedBarCode { get; set; }
        public DateTime ResultDateTime { get; set; }
        public Guid RequestGUID { get; set; }
        public int RECode { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
    }

    [Table("Lab_Result_Details")]
    public class Lab_Result_Details
    {
        public string ResultGUID { get; set; }
        public Guid TestResultID { get; set; }
        public int SendSMS { get; set; }
        public string SMSShortName { get; set; }
        public int TCode { get; set; }
        public int TestSno { get; set; }
        public string Description { get; set; }
        public string QuotesColumn { get; set; }
        public string EnteredResult { get; set; }
        public string Units { get; set; }
        public string NormalValues { get; set; }
        public string DefaultNormalValues { get; set; }
        public int DStyleCode { get; set; }
        public int QStyleCode { get; set; }
        public int EStyleCode { get; set; }
        public int UStyleCode { get; set; }
        public int NStyleCode { get; set; }
        public string ValueType { get; set; }
        public string ResultType { get; set; }
        public string CalculatedFormula { get; set; }
        public int FromTCode { get; set; }
        public Guid FromTestResultID { get; set; }
        [Key] public Guid LRDID { get; set; }
    }

    [Table("Lab_Result_Properties")]
    public class Lab_Result_Properties
    {
        [Key] public Guid TRPId { get; set; }
        public Guid TestResultID { get; set; }
        public string ResultValueType { get; set; }
        public int DefaultUnitsCode { get; set; }
        public Guid FXTCode { get; set; }
        public Guid DefaultValueforFXType { get; set; }
        public string DefaultValue { get; set; }
        public bool SimpleNormalValues { get; set; }
        public bool DetailedNormalValues { get; set; }
        public string RangeType { get; set; }
        public double FromNormalValue { get; set; }
        public double ToNormalValue { get; set; }
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
        public bool ResultNormal { get; set; }
        public bool ResultHigh { get; set; }
        public bool ResultLow { get; set; }
        public bool IsGraph { get; set; }
        public double GraphValue { get; set; }
        public int DecimalValue { get; set; }
        public int SCode { get; set; }
        public int MCCode { get; set; }
        public int PerformedCount { get; set; }
        public bool UseDefault { get; set; }
        public Guid NormalValueforFXType { get; set; }
        public string NormalValue { get; set; }
        public Guid MasterTestResultId { get; set; }
        public string CriticalLowType { get; set; }
        public string CriticalLowRange { get; set; }
        public string CriticalHighType { get; set; }
        public string CriticalHighRange { get; set; }
    }

    [Table("Lab_Result_TextNormalValues")]
    public class Lab_Result_TextNormalValues
    {
        [Key] public Guid TRTID { get; set; }
        public Guid TestResultID { get; set; }
        public string sex { get; set; }   // ← lowercase, matches DB column
        public string NormalValue { get; set; }
        public int MCCode { get; set; }
        public int PerformedCount { get; set; }
        public int SCode { get; set; }
    }

    [Table("Lab_Result_DetailedNormalValues")]
    public class Lab_Result_DetailedNormalValues
    {
        [Key] public Guid TRDNID { get; set; }
        public Guid TestResultID { get; set; }
        public int Sno { get; set; }
        public int AgeFrom { get; set; }
        public string AgeFromType { get; set; }
        public int AgeTo { get; set; }
        public string AgeToType { get; set; }
        public string sex { get; set; }
        public string RangeType { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }
        public Guid SpecialConditionCode { get; set; }
        public string AgeRangeType { get; set; }
        public int MCCode { get; set; }
        public int PerformedCount { get; set; }
        public int SCode { get; set; }
    }

    [Table("Lab_Result_CalculatedFormula")]
    public class Lab_Result_CalculatedFormula
    {
        [Key] public Guid TRCFID { get; set; }
        public Guid TestResultID { get; set; }
        public string sex { get; set; }
        // Formula stored as-is from master:
        // format: {masterTestResultId}|{operator}|{masterTestResultId}
        // e.g. f7241cb4-6741-4006-87d3-069bd41bf6ab|/|ff2e7cb2-9d7a-407a-9284-ee60fa7b8519
        public string CalculatedFormula { get; set; }
        public int MCCode { get; set; }
        public int PerformedCount { get; set; }
        public int SCode { get; set; }
    }

    // ──────────────────────────────────────────────────────────────────────────
    //  Legacy / composite models (kept for backward compatibility)
    // ──────────────────────────────────────────────────────────────────────────
    // ──────────────────────────────────────────────────────────────────────────

    public class LabResultModel { }

    public class LabResultData
    {
        public Lab_Result_Master lab_Result_Masters { get; set; }
        public IList<MasterLabResultData> masterLabResultDatas { get; set; }
    }

    public class MasterLabResultData
    {
        public LabResultEntry labResultEntry { get; set; }
        public List<Lab_Result_Details> lab_Result_Details { get; set; }
        public List<Lab_Result_Properties> master_Result_Properties { get; set; }
        public List<Lab_Result_TextNormalValues> master_Result_TextNormalValues { get; set; }
        public List<Lab_Result_DetailedNormalValues> master_Result_DetailedNormalValues { get; set; }
        public List<Lab_Result_CalculatedFormula> master_Result_CalculatedFormula { get; set; }
    }

    public class LabResultSaveRequest
    {
        public Lab_Result_Master Lab_Result_Master { get; set; }
        public List<Lab_Result_Properties> Lab_Result_Properties { get; set; }
        public List<Lab_Result_Details> Lab_Result_Details { get; set; }
        public List<Lab_Result_TextNormalValues> Lab_Result_TextNormalValues { get; set; }
        public List<Lab_Result_DetailedNormalValues> Lab_Result_DetailedNormalValues { get; set; }
        public List<Lab_Result_CalculatedFormula> Lab_Result_CalculatedFormula { get; set; }
    }

    public class ApproveResultRequest
    {
        public Guid RequestGuid { get; set; }
        public List<int> Tcodes { get; set; }
        public int ResultAuthorizedBy { get; set; }
    }

    // ──────────────────────────────────────────────────────────────────────────
    //  Lookup / master entities
    // ──────────────────────────────────────────────────────────────────────────

    public class GROUP_MASTER
    {
        public int GCode { get; set; }
        public int DCode { get; set; }
        public int OrderNo { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public int DepartmentCode { get; set; }
        public bool IsScan { get; set; }
        public bool IsLab { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public bool IsPackage { get; set; }
        public bool IsCharges { get; set; }
        public string SkyCode { get; set; }
        public bool IsPrintBarcode { get; set; }
        public int WorkOrderNo { get; set; }
    }

    public class Machine_Master
    {
        [Key] public int MCCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string PortNumber { get; set; }
        public int BaudRate { get; set; }
        public string Parity { get; set; }
        public int Stopbits { get; set; }
        public int DataBits { get; set; }
        public bool Deleted { get; set; }
        public int UserCode { get; set; }
        public int ComputerCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
        public string OptTCP { get; set; }
        public bool OptImport { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public bool OptRS232 { get; set; }
        public bool OptTCPClient { get; set; }
        public bool OptTCPServer { get; set; }
    }

    public class Machine_Specimen
    {
        public string MachineName { get; set; }
        public int MachineCode { get; set; }
        public int SampleCode { get; set; }
        public string Sample { get; set; }
        public bool isdefault { get; set; }
        public Guid TestResultId { get; set; }
    }

    [Table("FixedTypeMaster")]
    public class FixedTypeMaster
    {
        public Guid FXTMCode { get; set; }
        public string FXTName { get; set; }
    }

    [Table("FixedValues")]
    public class FixedValues
    {
        public Guid FXTCode { get; set; }
        public Guid FXTMCode { get; set; }
        public int Sno { get; set; }
        public string FixedValues_1 { get; set; }
    }

    public class Master_Result_Properties
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
        public float FromNormalValue { get; set; }
        public float ToNormalValue { get; set; }
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
        public float GraphValue { get; set; }
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
        public bool ResultNormal { get; set; }
        public bool ResultHigh { get; set; }
        public bool ResultLow { get; set; }
        public Guid MasterTestResultId { get; set; }
    }
}