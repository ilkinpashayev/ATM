using Atm.Machine.App;
using Atm.Machine.Services.Menu;


namespace Atm.Machine.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.Instance;
            AdminMenu.DisplayAdminMenu(container);
        }
    }
}
