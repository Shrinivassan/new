using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lims.Components.Model; // Added to reference ViewBills

namespace LIMS.Model
{
    public class DueCollectionModel
    {
        public Receipt_Master receipt_Master { get; set; }
        public List<Receipt_Details> receiptDetails { get; set; }

        // New class to represent a row in the Due Collection table
        // Moved from Duecollection.razor to centralize model definitions
        public class DueBillRow
        {
            public ViewBills Bill { get; set; } = new ViewBills();
            public bool Selected { get; set; }
            public decimal Collected { get; set; }
            public decimal Concession { get; set; }
            public string Status { get; set; } = "Due";

            // Computed properties for display
            public string SampleId => !string.IsNullOrEmpty(Bill.RequestSnoPrint) ? Bill.RequestSnoPrint : Bill.RequestSno.ToString();
            public string BillDateTime => Bill.RequestDatetime.ToString("dd-MM-yyyy");
            public string PatientId => Bill.CUSTCode;
            public string CustomerName => Bill.Name;
            public string RefBy => Bill.DOCTOR;
            public decimal Balance => (decimal)Bill.Balance;
            public decimal CurrentBalance => (decimal)Bill.Balance;
        }
    }

    // Minimal receipt master/details to satisfy compile; expand as needed.
   public class Receipt_Master
 {
     public string? ReceiptGUID { get; set; }
     public DateTime ReceiptDate { get; set; }
     public int ReceiptSNo { get; set; }
     
     public string ReceiptBarCode { get; set; }
     public string ReceiptCovertedBarCode { get; set; }
     public string? ReceiptTime { get; set; }
     public string? ChequeNo { get; set; }
     public string? Narration { get; set; }

     public int CNTCode { get; set; }
     public Guid CNTTID { get; set; }
     public int TmCode { get; set; } 
     public int PMCode { get; set; }
     public int CTCode { get; set; }
     public int PayLedgerCode { get; set; }
     public string BankName { get; set; }
     public string PaymentReference { get; set; }
     public DateTime ChequeDate { get; set; }
     public string CardNo { get; set; }
     public DateTime  CardDate { get; set; }
     public Double AmountPaid { get; set; }
     public Double AmountAdjusted { get; set; }
     public Double AmountTotal { get; set; }
     public bool Deleted { get; set; }
     public int EnteredBHCode { get; set; }
     public int UserCode { get; set; }
     public int ComputerCode { get; set; }
     public DateTime EnteredDate { get; set; }
     public DateTime IBSDate { get; set; }
     public bool IsBill { get; set; }
     public bool IsMonthly { get; set; }
     public bool IsPatient { get; set; }
     public bool IsRefferal { get; set; }
     public bool IsRefund { get; set; }
 }

    public class Receipt_Details
 {
     public string ReceiptGUID { get; set; }
     public String RequestGUID { get; set; }
     public int RequestSno { get; set; }
     public Double ReceiptAmount { get; set; }
     public int ReceiptSNo { get; set; }
     public Guid ReceiptDetailsID { get; set; }
     public Double DiscountAmount { get; set; }
     public Double RefundAmount { get; set; }
     public double Collected { get; set; }
     public double Concession { get; set; }
 }
    public class DueCollectionScreenData
    {
        public List<Customer_Master> Customers { get; set; }
        public List<Branch_Master> Branches { get; set; }
        public List<Counter_Master> Counters { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }

    //  [Table(name: "Customer_Master")]
    public class CustomerInfo
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string AgeYears { get; set; }
        public string Mobile { get; set; }
        public string DoctorName { get; set; }
    }

    public class OnlineYear
    {
        public Guid? OnlineYearId { get; set; }
        public int BillYear { get; set; }
        public int BillYearCount { get; set; }
    }

    public class CustomerSimpleDto
    {
        public int CUSTID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

    public class PatientDueDto
    {
        public int CUSTID { get; set; }
        public double TotalDue { get; set; }
    }

    public class SaveReceipt
    {
        public List<Receipt_Details> receipt_Details { get; set; }
        public Receipt_Master receipt_Master { get; set; }
        
        public string? requestGuid { get; set; }
        public string? title { get; set; }
    }
}