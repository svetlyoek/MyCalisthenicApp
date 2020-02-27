namespace MyCalisthenicApp.Services
{
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ProgramsService : IProgramsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;

        public ProgramsService(MyCalisthenicAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Program> GetFivePopularPrograms()
        {
            var popularPrograms = this.dbContext.Programs
            .Take(5)
            .ToList();

            return popularPrograms;
        }
    }
}
