using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Lims.Components.Model
{
    public class CultureModel
    {
    }

    public class CultureOrganism
    {
        [Key]
        public long COCode { get; set; }

        public int OrderNo { get; set; }

        public string? ShortName { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool Deleted { get; set; }

        public int UserCode { get; set; }

        public int ComputerCode { get; set; }

        public DateTime EnteredDate { get; set; }

        public DateTime IBSDate { get; set; }

        public bool? IsNoGrowth { get; set; }
    }

    [Table("Lab_Culture_Master")]
    public class LabCultureMaster
    {
        [Key]
        public string ResultCultureGUID { get; set; } = string.Empty;

        public int? ResultCultureSNo { get; set; }

        public string? ResultCultureBarCode { get; set; }

        public string? ResultCultureConvertedBarCode { get; set; }

        public DateTime? ResultCultureDateTime { get; set; }

        public Guid? RequestGUID { get; set; }

        public decimal? RECode { get; set; }   // numeric(18,0)

        public string? Sample { get; set; }

        public DateTime? SampleReceivedDate { get; set; }

        public string? ColonyCount { get; set; }

        public string? OrganismsGrown { get; set; }

        public string? PUSCells { get; set; }

        public string? Bacteria { get; set; }

        public DateTime? CultureReportedDate { get; set; }

        public int? RTMCode { get; set; }

        public string? ReportingMethod { get; set; }

        public int? CFCode { get; set; }

        public string? FooterText { get; set; }

        public string? GramsStaining { get; set; }

        public string? ResultSMS { get; set; }

        public string? Description { get; set; }

        public bool? Deleted { get; set; }

        public int? UserCode { get; set; }

        public int? ComputerCode { get; set; }

        public DateTime? EnteredDate { get; set; }

        public DateTime? IBSDate { get; set; }

        public int? ResultEnteredBy { get; set; }

        public int? ResultAuthorizedby { get; set; }

        public bool? IsAuthorized { get; set; }

        public string? ReportStatus { get; set; }

        public bool? IsGrowth { get; set; }

        public string? OrganismsGrownB { get; set; }

        public string? OrganismsGrownC { get; set; }

        public bool? IsIsolationA { get; set; }

        public bool? IsIsolationB { get; set; }

        public bool? IsIsolationC { get; set; }

        public string? GrowthGrade { get; set; }

        public string? Diagnosis { get; set; }

        public string? ColonyCountB { get; set; }

        public string? ColonyCountC { get; set; }

        public string? SmearAFB { get; set; }

        public string? Comments { get; set; }

        public string? CommentsA { get; set; }

        public string? CommentsB { get; set; }

        public string? CommentsC { get; set; }
    }

    [Table("Lab_Culture_Isolation")]
    public class LabCultureIsolation
    {
        [Key]
        public Guid LCDIIID { get; set; }   // Primary Key

        public string ResultCultureGUID { get; set; } = string.Empty;

        public int? TCode { get; set; }

        public string? ColumnName { get; set; }

        public int? ActualSno { get; set; }

        public int? Sno { get; set; }

        public int? ABCode { get; set; }

        public string? Isolation_A { get; set; }

        public string? Isolation_B { get; set; }

        public string? Isolation_C { get; set; }

        public string? ReportStatus { get; set; }

        public string? DiskContentA { get; set; }

        public string? MMA1 { get; set; }
        public string? DiskContentB { get; set; }

        public string? MMA2 { get; set; }
        public string? DiskContentC { get; set; }

        public string? MMA3 { get; set; }
    }

    [Table("Lab_Result_Culture_Antibiotics")]
    public class LabResultCultureAntibiotics
    {
        [Key]
        public Guid LRCAID { get; set; }   // Primary Key

        public Guid? TestResultID { get; set; }

        public string? ColumnName { get; set; }

        public int? ActualSno { get; set; }

        public int? Sno { get; set; }

        public int? ABCode { get; set; }

        public string? Isolation_A { get; set; }

        public Guid LCDIIID { get; set; }   // FK to Isolation table

        public string? ReportStatus { get; set; }

        public string? DiskContentA { get; set; }

        public string? MMA { get; set; }
    }

    [Table("Lab_Result_Culture_Master")]
    public class LabResultCultureMaster
    {
        [Key]
        public Guid LRCMID { get; set; }   // Primary Key

        public Guid? TestResultID { get; set; }

        public string? Sample { get; set; }

        public DateTime? SampleReceivedDate { get; set; }

        public string? ColonyCount { get; set; }

        public string? OrganismsGrown { get; set; }

        public string? PUSCells { get; set; }

        public string? Bacteria { get; set; }

        public DateTime? CultureReportedDate { get; set; }

        public int? RTMCode { get; set; }

        public string? ReportingMethod { get; set; }

        public int? CFCode { get; set; }

        public string? FooterText { get; set; }

        public string? GramsStaining { get; set; }

        public string? ReportStatus { get; set; }

        public bool? IsGrowth { get; set; }

        public string? OrganismsGrownB { get; set; }

        public string? OrganismsGrownC { get; set; }

        public bool? IsIsolationA { get; set; }

        public bool? IsIsolationB { get; set; }

        public bool? IsIsolationC { get; set; }

        public string? GrowthGrade { get; set; }

        public string? Diagnosis { get; set; }
    }

    [Table("Lab_Culture_Details")]
    public class LabCultureDetails
    {
        [Key]
        public Guid LCDID { get; set; }   // Primary Key

        public string? ResultCultureGUID { get; set; }

        public int? TCode { get; set; }

        public int? TypeSno { get; set; }

        public string? SensitiveAntibioticName { get; set; }

        public string? SensitiveAntibioticQuantity { get; set; }

        public string? MSensitiveAntibioticName { get; set; }

        public string? MSensitiveAntibioticQuantity { get; set; }

        public string? ResistentAntibioticName { get; set; }

        public string? ResistentAntibioticQuantity { get; set; }

        public int? SensitiveStylecode { get; set; }

        public int? SensitiveQuanityStyleCode { get; set; }

        public int? MSensitiveStylecode { get; set; }

        public int? MSensitiveQuantityStylecode { get; set; }

        public int? ResistentStylecode { get; set; }

        public int? ResistentQuantityStylecode { get; set; }

        public string? ReportStatus { get; set; }

        public string? Isolation1 { get; set; }
    }

    [Table("CultureFooter_Master")]
    public class CultureFooterMaster
    {
        [Key]
        public long CFCode { get; set; }

        public int OrderNo { get; set; }

        public string? ShortName { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool Deleted { get; set; }

        public int UserCode { get; set; }

        public int ComputerCode { get; set; }

        public DateTime EnteredDate { get; set; }

        public DateTime IBSDate { get; set; }
    }

    [Table("Antibiotics")]
    public class Antibiotics
    {
        [Key]
        public long ABCode { get; set; }

        public int OrderNo { get; set; }

        public string? ShortName { get; set; }

        public string? Name { get; set; }

        public string Type { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Footer { get; set; }

        public bool Deleted { get; set; }

        public int UserCode { get; set; }

        public int ComputerCode { get; set; }

        public DateTime EnteredDate { get; set; }

        public DateTime IBSDate { get; set; }

        public int? ITCode { get; set; }

        public int? ABGCode { get; set; }
    }

    public class CultureOrganismDto
    {
        public long COCode { get; set; }
        public int OrderNo { get; set; }
        public string? ShortName { get; set; }
        public string? Name { get; set; }
        public bool? IsNoGrowth { get; set; }
    }

    // ─────────────────────────────────────────────
    // Antibiotic isolation row (grid row in form)
    // Columns: Group | Antibiotic | Disk(A) | Res(A) | MM(A) | Disk(B) | Res(B) | MM(B) | Disk(C) | Res(C) | MM(C)
    // ─────────────────────────────────────────────

    public class CultureIsolationRowDto
    {
        [JsonIgnore]
        public Guid? LCDIIID { get; set; }

        [JsonProperty("columnName")]
        public string? ColumnName { get; set; }

        [JsonProperty("tCode")]
        public int? TCode { get; set; }

        [JsonProperty("actualSno")]
        public int? ActualSno { get; set; }

        [JsonProperty("sno")]
        public int? Sno { get; set; }

        [JsonProperty("abCode")]
        public int? ABCode { get; set; }

        [JsonIgnore]
        public string? AntibioticName { get; set; }

        [JsonProperty("isolation_A")]
        public string? Isolation_A { get; set; }

        [JsonProperty("diskContentA")]
        public string? DiskContentA { get; set; }

        [JsonProperty("mma1")]
        public string? MMA1 { get; set; }

        [JsonProperty("isolation_B")]
        public string? Isolation_B { get; set; }

        [JsonProperty("diskContentB")]
        public string? DiskContentB { get; set; }

        [JsonProperty("mma2")]
        public string? MMA2 { get; set; }

        [JsonProperty("isolation_C")]
        public string? Isolation_C { get; set; }

        [JsonProperty("diskContentC")]
        public string? DiskContentC { get; set; }

        [JsonProperty("mma3")]
        public string? MMA3 { get; set; }

        [JsonProperty("reportStatus")]
        public string? ReportStatus { get; set; }
    }

    // ─────────────────────────────────────────────
    // Vitek result row (top-right panel)
    // ─────────────────────────────────────────────

    public class VitekResultDto
    {
        public string? Sample { get; set; }
        public string? Organism { get; set; }
        public string? Status { get; set; }
    }

    // ─────────────────────────────────────────────
    // Full Culture Result Entry – GET response
    // ─────────────────────────────────────────────

    public class CultureResultEntryDto
    {
        public string? ACLNo { get; set; }
        public string? PatientName { get; set; }
        public string? AgeGender { get; set; }
        public string? ReferredBy { get; set; }
        public string? SIDNo { get; set; }
        public string ResultCultureGUID { get; set; } = string.Empty;
        public decimal? RECode { get; set; }

        public string? SelectCulture { get; set; }
        public string? ReportStatus { get; set; }
        public bool? IsGrowth { get; set; }
        public string? ReportingMethod { get; set; }
        public int? RTMCode { get; set; }
        public string? Sample { get; set; }
        public string? DirectSmear { get; set; }
        public string? GrowthGrade { get; set; }
        public string? SmearAFB { get; set; }
        public string? PUSCells { get; set; }
        public string? GramsStaining { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime? SampleDate { get; set; }
        public DateTime? SampleReceivedDate { get; set; }
        public DateTime? ReportedDate { get; set; }
        public DateTime? CultureReportedDate { get; set; }
        public string? EnteredBy { get; set; }
        public string? AuthorizedBy { get; set; }
        public bool? IsAuthorized { get; set; }
        public int? EnteredByCode { get; set; }
        public int? AuthorizedByCode { get; set; }
        public string? OrganismsGrownA { get; set; }
        public string? OrganismsGrownB { get; set; }
        public string? OrganismsGrownC { get; set; }
        public bool? IsIsolationA { get; set; }
        public bool? IsIsolationB { get; set; }
        public bool? IsIsolationC { get; set; }
        public string? ColonyCountA { get; set; }
        public string? ColonyCountB { get; set; }
        public string? ColonyCountC { get; set; }
        public string? CommentsA { get; set; }
        public string? CommentsB { get; set; }
        public string? CommentsC { get; set; }
        public int? CFCode { get; set; }
        public string? FooterText { get; set; }
        public string? Description { get; set; }
        public string? Bacteria { get; set; }
        public string? Note { get; set; }
        public string? NoteMessage { get; set; }
        public string? Comments { get; set; }
        public List<VitekResultDto> VitekResults { get; set; } = new();
        public List<CultureIsolationRowDto> IsolationRows { get; set; } = new();
    }

    // ─────────────────────────────────────────────
    // Save / Update request DTO  (mirrors GET DTO,
    // separated so validation attributes can differ)
    // ─────────────────────────────────────────────

    public class SaveCultureResultRequestDto
    {
        public string ResultCultureGUID { get; set; } = string.Empty;
        public decimal? RECode { get; set; }
        public string? RequestGUID { get; set; }   // ← needed to update Lab_Request_Details
        public int? TCode { get; set; }            // ← which test is being saved

        public string? SelectCulture { get; set; }
        public string? ReportStatus { get; set; }   // Preliminary | Supplementary | Final Report
        public bool? IsGrowth { get; set; }

        public int? RTMCode { get; set; }
        public string? ReportingMethod { get; set; }
        public string? Sample { get; set; }
        public string? DirectSmear { get; set; }
        public string? GrowthGrade { get; set; }
        public string? SmearAFB { get; set; }
        public string? PUSCells { get; set; }
        public string? GramsStaining { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime? SampleDate { get; set; }
        public DateTime? SampleReceivedDate { get; set; }
        public DateTime? ReportedDate { get; set; }
        public DateTime? CultureReportedDate { get; set; }
        public int? UserCode { get; set; }
        public int? ComputerCode { get; set; }
        public string? OrganismsGrownA { get; set; }
        public string? OrganismsGrownB { get; set; }
        public string? OrganismsGrownC { get; set; }
        public bool? IsIsolationA { get; set; }
        public bool? IsIsolationB { get; set; }
        public bool? IsIsolationC { get; set; }
        public string? ColonyCountA { get; set; }
        public string? ColonyCountB { get; set; }
        public string? ColonyCountC { get; set; }
        public string? CommentsA { get; set; }
        public string? CommentsB { get; set; }
        public string? CommentsC { get; set; }
        public int? CFCode { get; set; }
        public string? FooterText { get; set; }
        public string? Description { get; set; }
        public string? Bacteria { get; set; }
        public string? Note { get; set; }
        public string? NoteMessage { get; set; }
        public string? Comments { get; set; }
        public string? ResultSMS { get; set; }
        public bool? IsAuthorized { get; set; }
        public int? EnteredByCode { get; set; }
        public int? AuthorizedByCode { get; set; }
        public List<CultureIsolationRowDto> IsolationRows { get; set; } = new();
        public List<LabCultureDetails> CultureDetails { get; set; } = new();

    }

    // ─────────────────────────────────────────────
    // Authorize request
    // ─────────────────────────────────────────────

    public class AuthorizeCultureRequestDto
    {
        public string ResultCultureGUID { get; set; } = string.Empty;
        public int AuthorizedByCode { get; set; }
        public string? ReportStatus { get; set; }   // usually "Final Report" on authorize
    }

    public class CultureTestListDto
    {
        public int TCode { get; set; }
        public string? TestName { get; set; }
        public int OrderNo { get; set; }
        public bool ResultStatus { get; set; }        // 0 = not saved, 1 = saved
        public string? ResultCultureGUID { get; set; } // null = not yet entered
        public bool? IsAuthorized { get; set; }
        public string? ReportStatus { get; set; }
    }
    public class TestCodeNameDto
    {
        public int TCode { get; set; }
        public string TestName { get; set; } = string.Empty;
    }


    public class CultureReportRequestDto
    {
        [JsonProperty("specimens")]
        public List<CultureReportSpecimenDto> Specimens { get; set; } = new();
    }

    public class CultureReportSpecimenDto
    {
        public string ClientID { get; set; } = "";
        public string ReportName { get; set; } = "CultureReport";
        public string RequestGUID { get; set; } = "";
        public string DataSource { get; set; } = "DataSet1";
        public List<string> TCode { get; set; } = new();
        public List<CultureReportParameterDto> Parameters { get; set; } = new();
    }

    public class CultureReportParameterDto
    {
        public string Name { get; set; } = "";
        public List<string> Values { get; set; } = new();
    }
}