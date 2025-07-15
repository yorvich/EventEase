using Blazored.LocalStorage;
using EventEase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public class SessionService
    {
        private readonly ILocalStorageService _localStorage;

        public SessionService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task AddEventToSessionAsync(string userId, EventModel eventModel)
        {
            try
            {
                var userEvents = await _localStorage.GetItemAsync<List<EventModel>>(userId) ?? new List<EventModel>();

                // Check if the event already exists in the session
                if (!userEvents.Any(e => e.Id == eventModel.Id))
                {
                    // Assign a unique GUID only if the event doesn't already have an Id
                    if (eventModel.Id == Guid.Empty)
                    {
                        eventModel.Id = Guid.NewGuid();
                    }

                    userEvents.Add(eventModel);
                    await _localStorage.SetItemAsync(userId, userEvents);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding event to session: {ex.Message}");
                throw;
            }
        }

        public async Task<List<EventModel>> GetUserEventsAsync(string userId)
        {
            try
            {
                return await _localStorage.GetItemAsync<List<EventModel>>(userId) ?? new List<EventModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user events: {ex.Message}");
                return new List<EventModel>();
            }
        }

        public async Task RemoveUserEventsAsync(string userId)
        {
            try
            {
                await _localStorage.RemoveItemAsync(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing user events: {ex.Message}");
                throw;
            }
        }
    }
}
