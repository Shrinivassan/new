namespace Lims.Components.Model
{
    public class BookingModel
    {
    }

    public class ViewOrderModel
    {
        public string orderGUID { get; set; }
        public int orderSno { get; set; }
        public string orderBarCode { get; set; }
        public DateTime orderDateTime { get; set; }
        public bool requestedbyPatient { get; set; }
        public bool requestedbyReferral { get; set; }
        public decimal orderAmount { get; set; }
        public decimal discountPer { get; set; }
        public decimal discountAmount { get; set; }
        public decimal totalAmount { get; set; }
        public decimal paidAmount { get; set; }
        public decimal paidViaReceipt { get; set; }
        public int custID { get; set; }
        public string namewithInitials { get; set; }
        public string mobileNo { get; set; }
        public string email { get; set; }
        public int dCode { get; set; }
        public string doctorFullName { get; set; }
        public int tCode { get; set; }
        public string testName { get; set; }
        public int testOrderNo { get; set; }
        public int gCode { get; set; }
        public int groupOrderNo { get; set; }
        public string groupName { get; set; }
        public string dobInString { get; set; }
        public string gender { get; set; }
        public bool OrderStatus { get; set; }
        public bool Deleted { get; set; }
    }

    public class BookingOrders
    {
        public Guid OrderGUID { get; set; }
        public int BHCode { get; set; }
        public int CNTCode { get; set; }
        public int BNCode { get; set; }
        public DateTime BillDate { get; set; }

        public int DCode { get; set; }

        public int UserCode { get; set; }
    }
}
