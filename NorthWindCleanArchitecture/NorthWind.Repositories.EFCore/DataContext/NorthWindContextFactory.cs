using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Repositories.EFCore.DataContext {
    public class NorthWindContextFactory : IDesignTimeDbContextFactory<NorthWindContext> {
        public NorthWindContext CreateDbContext(string[] args) {
            var optionBuilder = new DbContextOptionsBuilder<NorthWindContext>();
            optionBuilder.UseSqlServer("Server=(local);database=NorthWindDB;Integrated Security=True;");
            return new NorthWindContext(optionBuilder.Options);
        }
    }
}
