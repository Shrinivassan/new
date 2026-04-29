using LIMS.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Lims.Components.Model
{
    public class ResultModel
    {
    }
    public class ResultEntryModel
    {
        [JsonProperty("results")]
        public IList<LabResultEntry> Results { get; set; }
        [JsonProperty("units")]
        public IList<UOM_MASTER> Units { get; set; }
        [JsonProperty("samples")]
        public IList<Sample_Master> Samples { get; set; }
        [JsonProperty("machines")]
        public IList<Machine_Master> Machines { get; set; }
        [JsonProperty("methods")]
        public IList<REPORT_METHOD> Methods { get; set; }
    }
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

        // Parameters for advanced result types
        public int DecimalValue { get; set; }
        public bool ShowAlertOnHigherLower { get; set; }
        public string? ReferenceValue { get; set; }
        public string? FooterMessage { get; set; }
        public bool PrintConclusionInReport { get; set; }
        public string? ConclusionforFixedText { get; set; }
        public bool PrintNormalValuesatBottom { get; set; }
        public bool PrintUnitsInNormalValues { get; set; }
        public bool ShowAgedBased { get; set; }
        public bool PrintSpecialFieldsatRightSide { get; set; }
        public bool GroupValuesbySpecialField { get; set; }
        public bool GroupValuesbySex { get; set; }
        public string? DefaultValue { get; set; }
        public bool PrintConclusionInBottom { get; set; }
        public string? ConclusionForLower { get; set; }
        public string? ConclusionForHigher { get; set; }
        public string? Footer { get; set; }
        public bool IsGraph { get; set; }
        public double GraphValue { get; set; }
        public List<Lab_Result_TextNormalValues>? EditedTextNormalValues { get; set; }
        public List<Lab_Result_DetailedNormalValues>? EditedDetailedNormalValues { get; set; }
        public List<Lab_Result_CalculatedFormula>? EditedCalculatedFormulas { get; set; }
    }

    public class Lab_Result_TextNormalValues
    {
        public Guid NVId { get; set; }
        public Guid TestResultID { get; set; }
        public string Sex { get; set; }
        public string NormalValue { get; set; }
    }

    public class Lab_Result_DetailedNormalValues
    {
        public Guid DNVId { get; set; }
        public Guid TestResultID { get; set; }
        public string RangeType { get; set; } = "Normal";
        public double FromValue { get; set; }
        public double ToValue { get; set; }
        public string? Sex { get; set; } = "Both";
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }
        // Required by backend validation
        public string AgeFromType { get; set; } = "Years";
        public string AgeToType { get; set; } = "Years";
        public string AgeRangeType { get; set; } = "Normal";
    }

    public class Lab_Result_CalculatedFormula
    {
        public Guid CFId { get; set; }
        public Guid TestResultID { get; set; }
        public string Formula { get; set; }
        public string Sex { get; set; }
    }

    public class TestResultDetailsModel
    {
        [JsonProperty("properties")]
        public List<LabResultEntry> Properties { get; set; }
    }

    public class Machine_Master
    {

        public int MCCode { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public string Manufacturer { get; set; }
        public String Model { get; set; }
        public String PortNumber { get; set; }
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


    public class DeltaResult
    {
        [JsonProperty("testName")]
        public string TestName { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
