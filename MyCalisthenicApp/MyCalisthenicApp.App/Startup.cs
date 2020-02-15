using MyCalisthenicApp.Data;

namespace MyCalisthenicApp.App
{
   public  class Startup
    {
        public static void Main()
        {
            using var dbContext = new MyCalisthenicAppDbContext();
        }
    }
}
