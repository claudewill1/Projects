using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Summitworks_EventManager.Models
{
    public class MockEventSchedule : IEventSchedule
    {
        private readonly List<Event> _eventList;
        DateTime dt1 = new DateTime(2020,4,12,5,10,00);
        DateTime dt2 = new DateTime(2020, 4, 15, 5, 00, 00);
        DateTime dt3 = new DateTime(2020, 4, 12, 2, 000, 00);

        public MockEventSchedule()
        {
            _eventList = new List<Event>()
            {
                new Event() {ID=1,EventName="ANA Summer Camp",EventCategory=Category.Conference,Organizer="American Numismatic Association",Address="123 Mountain Drive",City="Denver",State="CO",ZipCode=70634,EventDescription="A summer get away to learn about numismatics",
                EventDateTime=dt1,Status="active"},
                new Event() {ID=2,EventName="ANA Coin Grading Camp",EventCategory=Category.Conference,Organizer="American Numismatic Association",Address="123 Mountain Drive",City="Denver",State="CO",ZipCode=70634,EventDescription="Camp to become certified in coin grading",
                EventDateTime=dt2,Status="active"},
                new Event() {ID=3,EventName="ANA Summer Camp",EventCategory=Category.Conference,Organizer="American Numismatic Association",Address="123 Mountain Drive",City="Denver",State="CO",ZipCode=70634,EventDescription="A summer get away to learn about numismatics",
                EventDateTime=dt1,Status="inactive"},

            };
        }
        public Event Add(Event anEvent)
        {
            anEvent.ID = _eventList.Max(e => e.ID) + 1;
            _eventList.Add(anEvent);
            return anEvent;
        }

        public Event Delete(int id)
        {
            Event anEvent = _eventList.FirstOrDefault(e => e.ID == id);
            if(anEvent != null)
            {
                _eventList.Remove(anEvent);
            }
            return anEvent;
        }

        public Event Edit(Event eventChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
