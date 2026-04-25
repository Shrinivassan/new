using System.ComponentModel.DataAnnotations.Schema;

[Table(name: "Area_Master")]
 public class Area_Master
 {
     public int AreaCode { get; set; }
     public int OrederNo { get; set; }
     public String ShortName { get; set; }
     public string AreaName { get; set; }
     public int CityCode { get; set; }
     public String AreaPinCode { get; set; }
     public int StateCode { get; set; }
     public int CountryCode { get; set; }
     public String Description { get; set; }
     public bool Deleted { get; set; }
     public int UserCode { get; set; }
     public int ComputerCode { get; set; }
     public DateTime EnteredDate { get; set; }
     public DateTime IBSDate { get; set; }
     public float HomeCollectionCharge { get; set; }
 }