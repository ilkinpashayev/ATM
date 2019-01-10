using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atm.Machine.Models;
using Atm.Machine.Services.Exceptions;
using Atm.Machine.Services.Interfaces;
using Atm.Machine.App;
using Atm.Machine.Services.Menu;

namespace Atm.Machine.Backend
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
