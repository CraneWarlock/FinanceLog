using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceLog.Entites
{
    public class User
    {
        public int Id { get; set; }       
        public string? Name { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual List<FinanceLogs> FinanceLogs { get; set; }
    }
}
