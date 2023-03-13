using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceLog.Entites
{
    public class FinanceLogs
    {
        public int Id { get; set; }
        public string EntryName { get; set; }
        public string? Description {get; set; }
        public string? Place { get; set; }
        public double Amount { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int UserId { get; set; }
        public int? GroupId { get; set; }

        [ForeignKey("UserId")]
        public virtual List<User> Users { get; set; }
        [ForeignKey("GroupId")]
        public virtual List<Group> Groups { get; set; }
    }
}
