using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;

namespace BKWitten_App_Frontend.ViewModels
{
    public class MediaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Media> MediaList { get; set; }
        private readonly MediaServices _mediaService;
        public MediaViewModel()
        {
            _mediaService = new MediaServices(new HttpClient());  
            //LoadMedia(); // Methode aufrufen, um Events zu laden
        }
        private async void LoadMedia()
        {
            var mediaFromServiceAPI = await _mediaService.GetMediaAsync();

            MediaList.Clear();

            foreach (var media in mediaFromServiceAPI!)
            {
                MediaList.Add(media);
            }
            OnPropertyChanged(nameof(MediaList));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
