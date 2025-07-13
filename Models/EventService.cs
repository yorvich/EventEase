using System.Collections.Generic;
using System.Linq;

namespace EventEase.Models
{
    public class EventService
    {
        public List<EventModel> Events { get; private set; }

        public EventService()
        {
            Events = new List<EventModel>
            {
                new EventModel { Id = Guid.NewGuid(), Name = "Event 1", Description = "Description 1", Date = DateTime.Now, Attendees = new List<Attendee>() },
                new EventModel { Id = Guid.NewGuid(), Name = "Event 2", Description = "Description 2", Date = DateTime.Now.AddDays(1), Attendees = new List<Attendee>() },
                new EventModel { Id = Guid.NewGuid(), Name = "Event 3", Description = "Description 3", Date = DateTime.Now.AddDays(2), Attendees = new List<Attendee>() }
            };
        }

        public void AddEvent(EventModel newEvent)
        {
            Events.Add(newEvent);
        }

        public List<EventModel> GetAllEvents()
        {
            return Events;
        }

        public EventModel? GetEventById(Guid id)
        {
            return Events.FirstOrDefault(e => e.Id == id);
        }
    }
}
