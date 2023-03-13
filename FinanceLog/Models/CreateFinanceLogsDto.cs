using System.ComponentModel.DataAnnotations;

namespace FinanceLog.Models
{
    public class CreateFinanceLogsDto
    {
        [Required]
        [MaxLength(50)]
        public string EntryName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Place { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime Timestamp = DateTime.UtcNow;

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
