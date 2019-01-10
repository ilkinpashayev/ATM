using Atm.Machine.Models;

namespace Atm.Machine.Services.Interfaces
{
    public interface IPaperNoteCount
    {
        Money GetPaperNoteCount(int amount);
    }
}
