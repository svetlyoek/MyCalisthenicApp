namespace MyCalisthenicApp.Services.Contracts
{
    using MyCalisthenicApp.Models;
    using System.Collections.Generic;

    public interface IProgramsService
    {
        IEnumerable<Program> GetFivePopularPrograms();
    }
}
