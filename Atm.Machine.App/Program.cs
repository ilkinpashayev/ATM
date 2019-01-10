using Atm.Machine.Services.Menu;

namespace Atm.Machine.App
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMenu();
        }

        static void GetMenu()
        {
            string _menuitem;
            string _cardnumber;
            string _withdrawamount;
            bool exitmenu = false;
            // Castle Windsor Dependency Injection
            var container = Container.Instance;

            _cardnumber = MenuInsertCard.InsertCard(container);
        }


    }
}
