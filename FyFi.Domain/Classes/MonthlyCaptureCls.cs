
namespace FyFi.Domain.Classes
{
    public class MonthlyCaptureCls
    {
        public int MonthlyCaptureId { get; set; }
        public DateTime? MonthlyCaptureDate { get; set; }

        public List<MonthlyCaptureItem> CaptureItems { get; set; } = new List<MonthlyCaptureItem>();
    }
}
