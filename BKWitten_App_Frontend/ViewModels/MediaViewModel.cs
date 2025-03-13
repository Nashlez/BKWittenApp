using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;

namespace BKWitten_App_Frontend.ViewModels
{
    //INotifyPropertyChanged ist ein Interface welches dafür sorgt, dass sich das UI automatisch aktualisiert, wenn sich die MedienListe ändert. 
    public class MediaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Media> MediaList { get; set; } = new();
        private readonly MediaServices _mediaService;
        public MediaViewModel()
        {
            _mediaService = new MediaServices();  // MediaService instanziieren
            LoadMedia(); // Methode aufrufen, um Events zu laden
        }

        // Methode zum Laden der Medien vom Service
        private async void LoadMedia()
        {
            // Medien über den MedienService laden
            var mediaFromServiceAPI = await _mediaService.GetMediaAsync();

            // Leere die ObservableCollection, bevor neue Medien hinzugefügt werden
            MediaList.Clear();

            // Füge die geladenen Medien zur Liste hinzu
            foreach (var events in mediaFromServiceAPI!)
            {
                MediaList.Add(events);
            }

            // Aktualisiere das Binding
            OnPropertyChanged(nameof(MediaList));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
