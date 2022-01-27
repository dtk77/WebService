using Microsoft.EntityFrameworkCore;
using WebService.ApplicationCore.Entity;

namespace WebService.Infrastructure.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options) {}
    public DbSet<MailSendingReportToDb> MailSendingReports { get; set; } = null!;
    }
}
