using Atm.Machine.Services;
using Atm.Machine.Services.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Atm.Machine.App
{
    public sealed class Container
    {
        public static WindsorContainer Instance  => Register();
        private static WindsorContainer Register()
        {
            var container = new WindsorContainer();
            
            container.Register(Component.For<IATMachine>().ImplementedBy<ATMachine>());

            return container;
        }
    }
}
