using FinanceLog.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinanceLog
{
    public class dbSeeder
    {
        private readonly FinanceLogDbContext _dbContext;

        public dbSeeder(FinanceLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Groups.Any())
                {
                    var groups = GetGroups();
                    _dbContext.Groups.AddRange(groups);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.GroupMembers.Any())
                {
                    var members = GetMembers();
                    _dbContext.GroupMembers.AddRange(members);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.FinanceLogs.Any())
                {
                    var logs = GetFinanceLogs();
                    _dbContext.FinanceLogs.AddRange(logs);
                    _dbContext.SaveChanges();
                }
            }
           
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "Test1",
                    Login = "Test1",
                    Email = "test1@mail.com",
                    PasswordHash="123123"
                },
                new User()
                {
                    Name = "Test2",
                    Login = "Test2",
                    Email = "test2@mail.com",
                    PasswordHash="123123"
                },
                new User()
                {
                    Name = "Test2",
                    Login = "Test3",
                    Email = "test3@mail.com",
                    PasswordHash="123123"
                }
            };
            return users;
        }

        private Group GetGroups()
        {
            var newGroup = new Group()
            {
                Name = "Grupa testowa"
            };
            return newGroup;
        }

        private IEnumerable<GroupMembers> GetMembers()
        {
            var members = new List<GroupMembers>()
            {
                new GroupMembers()
                {
                    UserId=1,
                    GroupId=1
                },
                new GroupMembers()
                {
                    UserId=2,
                    GroupId=1
                }
            };
            return members;
        }

        private IEnumerable<FinanceLogs> GetFinanceLogs()
        {
            var logs = new List<FinanceLogs>()
            {
                new FinanceLogs()
                {
                    EntryName="Kupno świń",
                    Description="świnie",
                    Place="Targ świń",
                    Amount=10.60,
                    Timestamp=DateTime.UtcNow,
                    DateOfPurchase=DateTime.UtcNow,
                    UserId=1,
                    GroupId=1
                },
                new FinanceLogs()
                {
                    EntryName="Kupno kur",
                    Description="kury",
                    Place="Targ kur",
                    Amount=10,
                    Timestamp=DateTime.UtcNow,
                    DateOfPurchase=DateTime.UtcNow,
                    UserId=2,
                    GroupId=1
                },
                new FinanceLogs()
                {
                    EntryName="Bulbulator",
                    Description="Perfakcyjny bulbulator",
                    Place="Miejsce z rzeczami",
                    Amount=106.15,
                    Timestamp=DateTime.UtcNow,
                    DateOfPurchase=DateTime.UtcNow,
                    UserId=3
                }
            };
            return logs;
        }
    }
}
