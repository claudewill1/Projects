using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Summitworks_EventManager.Models
{
    public class MockEventSchedule : IEventSchedule
    {
        private List<Event> _eventList;
        

        public MockEventSchedule()
        {
            DateTime dt1 = new DateTime(2020, 4, 12);
            DateTime dt2 = new DateTime(2020, 4, 15);
            DateTime dt3 = new DateTime(2020, 4, 12);
            _eventList = new List<Event>()
            {
                new Event() {ID=1,EventName="ANA Summer Camp",EventCategory=Category.Conference,Organizer="American Numismatic Association",Address="123 Mountain Drive",City="Denver",State="CO",ZipCode=70634,EventDescription="A summer get away to learn about numismatics",
                EventDateTime=dt1,EventStatus="active"},
                new Event() {ID=2,EventName="ANA Coin Grading Camp",EventCategory=Category.Conference,Organizer="American Numismatic Association",Address="123 Mountain Drive",City="Denver",State="CO",ZipCode=70634,EventDescription="Camp to become certified in coin grading",
                EventDateTime=dt2,EventStatus="active"},
                new Event() {ID=3,EventName="ANA Summer Camp",EventCategory=Category.Conference,Organizer="American Numismatic Association",Address="123 Mountain Drive",City="Denver",State="CO",ZipCode=70634,EventDescription="A summer get away to learn about numismatics",
                EventDateTime=dt3,EventStatus="inactive"},

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
            Event anEvent = _eventList.FirstOrDefault(e => e.ID == eventChanges.ID);
            if (anEvent != null)
            {
                anEvent.EventName = eventChanges.EventName;
                anEvent.EventCategory = eventChanges.EventCategory;
                anEvent.Organizer = eventChanges.Organizer;
                anEvent.Address = eventChanges.Address;
                anEvent.City = eventChanges.City;
                anEvent.State = eventChanges.State;
                anEvent.ZipCode = eventChanges.ZipCode;
                anEvent.EventDescription = eventChanges.EventDescription;
                anEvent.EventDateTime = eventChanges.EventDateTime;
                
                anEvent.EventStatus = eventChanges.EventStatus;

            }
            return anEvent;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventList;
        }

        public Event GetEvent(int id)
        {
            return _eventList.FirstOrDefault(e => e.ID == id);
        }
    }
}
