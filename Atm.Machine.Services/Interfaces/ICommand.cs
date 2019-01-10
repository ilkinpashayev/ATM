using Castle.Windsor;


namespace Atm.Machine.Services.Interfaces
{
    public interface ICommand
    {
        void execute(WindsorContainer container);
    }
}
