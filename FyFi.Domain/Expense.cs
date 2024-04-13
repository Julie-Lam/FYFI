namespace FyFi.Domain
{
    public class Expense
    {
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string? Description { get; set; }
    }
}
