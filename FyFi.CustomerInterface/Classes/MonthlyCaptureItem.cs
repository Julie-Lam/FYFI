namespace FyFi.CustomerInterface.Classes
{
    public class MonthlyCaptureItem
    {
        public int MonthlyCaptureItemId { get; set; }
        public int MonthlyCaptureId { get; set; }

        public string ItemName { get; set; }
        public decimal ItemAmount { get; set; }
    }
}
