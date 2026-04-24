using System.ComponentModel.DataAnnotations.Schema;

namespace FYFI.Repository.InMemory.Model
{
    public class FiOutlookYear
    {
        public int FiOutlookYearId { get; set; }

        public DateTime YearDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cash { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SavingsYearly { get; set; }
    }
}
