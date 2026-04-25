using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

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

        public int FiOutlookId { get; set; } // Required foreign key property

        public FiOutlook FiOutlook { get; set; } = null!; // Required reference navigation to principal
    }
}
