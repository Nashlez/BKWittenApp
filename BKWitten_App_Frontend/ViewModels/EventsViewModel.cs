using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;

namespace BKWitten_App_Frontend.ViewModels
{
    //INotifyPropertyChanged ist ein Interface welches dafür sorgt, dass sich das UI automatisch aktualisiert, wenn sich die Eventliste ändert. 
    public class EventsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Events> EventsList { get; set; } = new();
        private readonly EventsServices _eventService;
        public EventsViewModel()
        {
            _eventService = new EventsServices();  // EventService instanziieren
            LoadEvents(); // Methode aufrufen, um Events zu laden
        }

        // Methode zum Laden der Events vom Service
        private async void LoadEvents()
        {
            // Events über den EventService laden
            var eventsFromServiceAPI = await _eventService.GetEventsAsync();

            // Leere die ObservableCollection, bevor neue Events hinzugefügt werden
            EventsList.Clear();

            // Füge die geladenen Events zur Liste hinzu
            foreach (var events in eventsFromServiceAPI!)
            {
                EventsList.Add(events);
            }

            // Aktualisiere das Binding
            OnPropertyChanged(nameof(EventsList));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
