using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;
using Microsoft.Extensions.Logging;

namespace BKWitten_App_Frontend.ViewModels
{
    public class EventsViewModel : INotifyPropertyChanged
    {
        public HttpClient HttpClient { get; set; }
        public ObservableCollection<Events> EventsList { get; set; }
        public ObservableCollection<Events> AllEvents { get; set; } = new();
        private readonly EventsServices _eventService;
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FilterEvents(); 
                }
            }
        }
        public EventsViewModel()
        {
            HttpClient = new HttpClient(); 
            _eventService = new EventsServices(HttpClient);
            EventsList = new ObservableCollection<Events>(); 
            _ = LoadEvents();
            FilterEvents();
        }
        private async Task LoadEvents()
        {
            try
            {
                var eventsFromServiceAPI = await _eventService.GetEventsAsync();
                if (eventsFromServiceAPI == null) return;

                AllEvents = new ObservableCollection<Events>(eventsFromServiceAPI);

                FilterEvents(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Events" + ex);
            }
        }
        private void FilterEvents()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                EventsList.Clear();
                foreach (var ev in AllEvents)
                    EventsList.Add(ev);
            }
            else
            {
                var filtered = AllEvents
                    .Where(ev =>
                        (!string.IsNullOrWhiteSpace(ev.Title) &&
                        ev.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(ev.Description) &&
                        ev.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));

                EventsList.Clear();
                foreach (var ev in filtered)
                    EventsList.Add(ev);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
