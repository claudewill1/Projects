using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Models
{
    public interface IEventSchedule
    {
        Event GetEvent(int id);
        IEnumerable<Event> GetAllEvents();
        Event Add(Event anEvent);
        Event Edit(Event eventChanges);
        Event Delete(int id);
    }
}
