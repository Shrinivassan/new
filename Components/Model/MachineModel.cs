using LIMS.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BirdAPI.Components.Model
{
    public class MachineModel
    {
    }

    public class BiDirectionalMachineResults
    {
        [Key] public Guid BDMID { get; set; }
        public Guid SampleID { get; set; }
        public int MCCode { get; set; }
        public string SampleNo { get; set; }
        public DateTime SampleDate { get; set; }
        public int Sno { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string RawData { get; set; }
        public string SampleCode { get; set; }
        public bool IsUpdated { get; set; }
    }

    public class Machine_TestMapping
    {
        [Key] public Guid MTMID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Parameter { get; set; }
        public string ParameterFormula { get; set; }
        public int Sno { get; set; }
        public int TCode { get; set; }
        public Guid TestResultID { get; set; }
        public string ResultType { get; set; }
        public string ActualFormula { get; set; }
    }

   
    public class Manufacturer_Model_Master
    {
        [Key] public int MMID { get; set; }
        public int OrderNo { get; set; }
        public string ShortName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public bool Deleted { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime IBSDate { get; set; }
    }

    public class PagedResult<T>
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public class RequestTestList
    {
        public IList<RequestTest> test { get; set; } = new List<RequestTest>();
    }

    public class RequestTest
    {
        public int TestCode { get; set; }
        public int TestOrderNo { get; set; }
        public string TestShortName { get; set; }
        public string TestName { get; set; }

        public int TestSampleCode { get; set; }
        public string TestSampleName { get; set; }

        public int GroupCode { get; set; }
        public string GroupName { get; set; }

        public int PackCode { get; set; }
        public bool IsPackage { get; set; }

        public IList<RequestTestMaster> SubTests { get; set; } = new List<RequestTestMaster>();

    }

    public class RequestTestMaster
    {
        public Guid SubTestID { get; set; }
        public int SubTestSno { get; set; }
        public string SubTestName { get; set; }
        public string SubTestType { get; set; }

        public IList<RequestTestProperties> SubTestProperties { get; set; } = new List<RequestTestProperties>();

    }

    public class RequestTestProperties
    {
        public string SubTestType { get; set; }
        public int SubTestUnitCode { get; set; }
        public string SubTestUnitName { get; set; }
        public int SubTestSampleCode { get; set; }
        public string SubtestSampleName { get; set; }

        public int SubTestMethodCode { get; set; }
        public string SubTestMethodName { get; set; }

        public int SubTestMCCode { get; set; }
        public string SubTestMachine { get; set; }
        public bool UseDefault { get; set; }
    }
    public class MachineMappedTests
    {
        public IList<Machine_TestMapping> MachineMapping { get; set; }
        public IList<Test_Master> TestMaster { get; set; }
        public IList<Test_Result_Master> TestResultMaster { get; set; }
    }

    public class Login_Datas
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoadMachineMaster
    {
        public List<Manufacturer_Model_Master> manufacturer_Model_Masters { get; set; }
        public List<Machine_Master> machine_Masters { get; set; }
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
}
