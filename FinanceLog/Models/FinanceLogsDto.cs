using FinanceLog.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceLog.Models
{
    public class FinanceLogsDto
    {
        public int Id { get; set; }
        public string EntryName { get; set; }
        public string? Description { get; set; }
        public string? Place { get; set; }
        public double Amount { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public List<User> Users { get; set; }
        public List<Group> Groups { get; set; }

    }
}
