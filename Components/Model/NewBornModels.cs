using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIMS.Model
{


    public class NewBornMasterData
    {
        public NewBorn_Test_Master ntm { get; set; }
        public IList<NewBorn_Test_Details> ntd { get; set; }
    }

    public class NewBorn_Test_Master
    {
         public int NTMID { get; set; }        // int, Unchecked (NULL allowed)
        public string? Comments { get; set; }   // nvarchar(50), Checked (NOT NULL)
        public string? Method { get; set; }     // nvarchar(MAX), Checked (NOT NULL)
        public string? Interpretation { get; set; } // nvarchar(MAX), Checked (NOT NULL)
        public string? Disclaimer { get; set; }     // nvarchar(MAX), Checked (NOT NULL)

        public int TCode { get; set; }
        public int NBCode { get; set; }
         public string? Abnormal { get; set; }
        public string? Normal { get; set; }


    }


    public class NewBorn_Test_Details
    {
         public Guid NTDID { get; set; }             // int

        public int NTMID { get; set; }
        public int TCode { get; set; }
        public int SLNo { get; set; }
        public string? TableTitle { get; set; }
          public string? Parameters { get; set; }
          public string? Details { get; set; }
        public string? Method { get; set; }
        public string? ObserverValue { get; set; }
        public string? MachineCode { get; set; }
        public string? RangeType { get; set; }
        public float RangeFrom { get; set; }
        public float RangeTo { get; set; }
        public string? ReferenceRange { get; set; }
         public string? Unit { get; set; }
        public string? Result { get; set; }

        public string? GroupTitle { get; set; }
        public string? Condition { get; set; }  // nvarchar(MAX), Checked (NOT NULL)
        public string RangeType1 { get; set; }
        public float RangeFrom1 { get; set; }
        public float RangeTo1 { get; set; }
            public string? Abnormal { get; set; }
        public string? Normal { get; set; }

        // int
    }
  
    public class NewBorn_Result_Master
    {
        public Guid NBID { get; set; }
        public int NBSno { get; set; }
        public int NBCode { get; set; }// int    
        public DateTime? CollectedDateTime { get; set; }  // datetime
        public DateTime? ReceivedDateTime { get; set; }   // datetime
        public DateTime? ResultDateTime { get; set; }     // datetime
        public Guid RequestGUID { get; set; }       // uniqueidentifier
        public int TCode { get; set; }              // int
         public string? Method { get; set; }          // nvarchar
         public string? Interpretation { get; set; }  // nvarchar
         public string? Comments { get; set; }        // nvarchar
         public string? Disclaimer { get; set; }      // nvarchar
        public int EnteredBy { get; set; }          // int
        public int ApprovedBy { get; set; }         // int
        public int AuthorizedBy { get; set; }
         public string? Filepath1 { get; set; }
         public string? Filepath2 { get; set; }
         public string? Filepath3 { get; set; }// int
        public string? Abnormal { get; set; }
         public string? Normal { get; set; }
    }
    public class Newborn_Result_Details
    {
        [Key] public Guid NBDetailsID { get; set; }
        public Guid NBID { get; set; }
        public int TCode { get; set; }
        public int SLNo { get; set; }
        public string? TableTitle { get; set; }
        public string? Parameters { get; set; }
        public string? Details { get; set; }
        public string? Method { get; set; }
        public string? ObserverValue { get; set; }
        public string? MachineCode { get; set; }
        public string? RangeType { get; set; }
        public float RangeFrom { get; set; }
        public float RangeTo { get; set; }
        public string? ReferenceRange { get; set; }
        public string? Unit { get; set; }
        public string? Result { get; set; }
        public string? GroupTitle { get; set; }
        public string? Condition { get; set; }
        public string RangeType1 { get; set; }
        public float RangeFrom1 { get; set; }
        public float RangeTo1 { get; set; }

        // Additional properties used by the NewBorn result UI and DTO mapping
        // Keep these as nullable strings to match how the UI code assigns/parses values
        public string? ResultLow { get; set; }
        public string? ResultHigh { get; set; }
        public string? ResultNormal { get; set; }
        public string? CutOff { get; set; }
        public string? Disorder { get; set; }
        public string? FinalRisk { get; set; }
        public string? RiskValue { get; set; }
        public string? LowMessage { get; set; }
        public string? HighMessage { get; set; }
        public string? NormalMessage { get; set; }
            public string? Abnormal { get; set; }
    public string? Normal { get; set; }


    }

    public class NewBornResultData
    {
        public NewBorn_Result_Master nrm { get; set; }
        public IList<Newborn_Result_Details> nrd { get; set; }

      
    }
      
    public class NewBornRequest
    {
        public Guid RequestGUID { get; set; }
        public int RequestSno { get; set; }
    public string? RequestSnoPrint { get; set; }

        public DateTime RequestDateTime { get; set; }
    public string? PatientName { get; set; }
    public string? Age { get; set; }

    public string? Gender { get; set; }
    public string? MobileNo { get; set; }
    public string? EmailID { get; set; }
    public string? DoctorFullName { get; set; }
        public int DCode { get; set; }
    public string? SecondDoctorName { get; set; }
    public int SecondDCode { get; set; }
    public string? TestName { get; set; }
    public int TCode { get; set; }
    public string? SkyCode { get; set; }
        public int? EnteredBy { get; set; }
        public int? ApprovedBy { get; set; }
        public int? AuthorizedBy { get; set; }

        public string? FilePath1 { get; set; }
        public string? FilePath2 { get; set; }
        public string? FilePath3 { get; set; }

    }

    public class NewBornReportModel
    {
    public string? ReportName { get; set; }
    public string? RequestGUID { get; set; }
        public int TCode { get; set; }

    }

    // DTO used by the Blazor component when posting results to the API
    public class NewbornResultDetailDto
    {
        public string? ResultLow { get; set; }
        public string? ResultHigh { get; set; }
        public string? ResultNormal { get; set; }
        public string? Parameters { get; set; }
        public string? TableTitle { get; set; } // Added missing field
        public string? Details { get; set; } // Added missing field
        public string? Method { get; set; } // Added missing field
        public string? ObserverValue { get; set; }
        public string? RangeType { get; set; } // Added missing field
        public string? ReferenceRange { get; set; }
        public string? Unit { get; set; }
        public string? Result { get; set; }
        public string? CutOff { get; set; }
        public string? Disorder { get; set; }
        public string? FinalRisk { get; set; }
        public string? RiskValue { get; set; }
        public string? LowMessage { get; set; }
        public string? HighMessage { get; set; }
        public string? NormalMessage { get; set; } 
        public string? GroupTitle { get; set; } // Added missing field
        public string? Condition { get; set; } // Added missing field
    }

    public class NewBornResultRequestDto
    { 
        public NewBorn_Result_Master? nrm { get; set; }
        public IList<NewbornResultDetailDto>? nrd { get; set; }
    }

}
