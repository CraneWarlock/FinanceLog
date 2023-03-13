using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceLog.Entites
{
    public class GroupMembers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        [ForeignKey("UserId")]
        public virtual List<User> Users { get; set; }
        [ForeignKey("GroupId")]
        public virtual List<Group> Groups { get; set; }
    }
}
