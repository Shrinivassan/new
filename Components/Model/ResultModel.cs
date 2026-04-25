using LIMS.Model;
using Newtonsoft.Json;

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
        [JsonProperty("requestGUID")]
        public string RequestGUID { get; set; }
        [JsonProperty("slNo")]
        public int SLNo { get; set; }
        [JsonProperty("tCode")]
        public int TCode { get; set; }
        [JsonProperty("testName")]
        public string TestName { get; set; }
        [JsonProperty("orderNo")]
        public int OrderNo { get; set; }
        [JsonProperty("groupOrder")]
        public int GroupOrder { get; set; }
        [JsonProperty("gCode")]
        public int GCode { get; set; }
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        [JsonProperty("col2")]
        public string Col2 { get; set; }
        [JsonProperty("enteredResult")]
        public string EnteredResult { get; set; }
        [JsonProperty("resultValueType")]
        public string ResultValueType { get; set; } 
        [JsonProperty("normalValue")]
        public string NormalValue { get; set; }
        [JsonProperty("testResultId")]
        public Guid TestResultId { get; set; }
        [JsonProperty("status")]
        public bool ResultStatus { get; set; }
        [JsonProperty("defaultValueforFXType")]
        public Guid DefaultValueforFXType { get; set; }
        [JsonProperty("fxTCode")]
        public Guid FXTCode { get; set; }
        [JsonProperty("resultNormal")]
        public bool ResultNormal { get; set; }
        [JsonProperty("resultHigh")]
        public bool ResultHigh { get; set; }
        [JsonProperty("resultLow")]
        public bool ResultLow { get; set; }
        [JsonProperty("resultType")]
        public string ResultType { get; set; }
        [JsonProperty("fromTcode")]
        public int FromTcode { get; set; }
        [JsonProperty("fromTestResultId")]
        public Guid FromTestResultId { get; set; }
        [JsonProperty("simpleNV")]
        public bool SimpleNV { get; set; }
        [JsonProperty("detailedNV")]
        public bool DetailedNV { get; set; }
        [JsonProperty("calculatedFormula")]
        public string CalculatedFormula { get; set; }
        [JsonProperty("defaultUnitValue")]
        public string DefaultUnitValue { get; set; } = String.Empty;
        [JsonProperty("mcCode")]
        public int MCCode { get; set; }
        [JsonProperty("machineName")]
        public string MachineName { get; set; } = string.Empty;
        [JsonProperty("sCode")]
        public int SCode { get; set; }
        public int ResultEnteredBy { get; set; }
        public bool IsAuthorized1 { get; set; }
        public bool IsAuthorized2 { get; set; }
        public int ResultAuthorizedBy { get; set; }
        public int ResultAuthorizedBy2 { get; set; }
        [JsonProperty("fixedvalues")]
        public string FixedValues { get; set; }
        [JsonProperty("sampleName")]
        public string SampleName { get; set; }
        [JsonProperty("unitName")]
        public string UnitName { get; set; }
        [JsonProperty("run")]
        public string Run { get; set; }
        [JsonProperty("custCode")]
        public string CustCode { get; set; }
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
