using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Summitworks_EventManager.Models
{
    public class SqlEventSchedule : IEventSchedule
    {
        private readonly AppDbContext context;
        public SqlEventSchedule(AppDbContext context)
        {
            this.context = context;
        }

        public Event Add(Event anEvent)
        {
            context.Events.Add(anEvent);
            context.SaveChanges();
            return anEvent;
        }

        public Event Delete(int id)
        {
            Event anEvent = context.Events.Find(id);
            // if event exists, remove event and save changes to database
            if(anEvent != null)
            {
                context.Events.Remove(anEvent);
                context.SaveChanges();
            }
            return anEvent;
        }

        public Event Edit(Event eventChanges)
        {
            var anEvent = context.Events.Attach(eventChanges);
            anEvent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return eventChanges;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return context.Events;
        }
        public Event GetEvent(int id)
        {
            return context.Events.Find(id);
        }
    }
}
