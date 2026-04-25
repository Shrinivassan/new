﻿namespace Lims.Components.Model
{
    public class FrontOfficeModel
    {
    }

    public class ViewBills
    {
        public int RequestSno { get; set; }
        public DateTime RequestDatetime { get; set; }
        public string CUSTCode { get; set; }
        public string Name { get; set; }
        public string DOCTOR { get; set; }
        public Double RequestAmount { get; set; }
        public Double DiscountPer { get; set; }
        public Double DiscountAmount { get; set; }
        public Double TotalAmount { get; set; }
        public Double PaidAmount { get; set; }
        public Double Balance { get; set; }
        public string RequestGUID { get; set; }
        public string TestShortName { get; set; }
        public string TestShortNameforEntry { get; set; }
        public string TestShortNameforCuluture { get; set; }
        public string TestShortNameforTextFormat { get; set; }
        public string PendingTestShortName { get; set; }
        public string PendingTestShortNameforEntry { get; set; }
        public string PendingTestShortNameforCuluture { get; set; }
        public string PendingTestShortNameforTextFormat { get; set; }
        public string FinishedTestShortName { get; set; }
        public string FinishedTestShortNameforEntry { get; set; }
        public string FinishedTestShortNameforCuluture { get; set; }
        public string FinishedTestShortNameforTextFormat { get; set; }
        public string UserName { get; set; }
        public string Computer { get; set; }
        public string BillType { get; set; }
        public Double CommissionAmount { get; set; }
        public string SecondDoctorName { get; set; }
        public int ProCode { get; set; }
        public int CTCode { get; set; }
        public int UserCode { get; set; }
        public string AgeYears { get; set; }
        public string AgeMonths { get; set; }
        public string AgeDays { get; set; }
        public string Gender { get; set; }
        public int DCode { get; set; }
        public string NameTitile { get; set; }
        public string NameWithoutInitial { get; set; }
        public bool IsCashBill { get; set; }
        public bool IsCreditBill { get; set; }
        public Double PaidViaReceipt { get; set; }
        public int EnteredBHCode { get; set; }
        public string Mobile { get; set; }
        public string RequestSnoPrint { get; set; }
        public bool Deleted { get; set; }



    }

    


    
}
