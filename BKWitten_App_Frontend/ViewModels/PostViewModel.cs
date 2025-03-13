using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;

namespace BKWitten_App_Frontend.ViewModels
{
    //INotifyPropertyChanged ist ein Interface welches dafür sorgt, dass sich das UI automatisch aktualisiert, wenn sich die PostListe ändert. 
    public class PostViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Posts> postList { get; set; } = new();
        private readonly PostsService _PostService;
        public PostViewModel()
        {
            _PostService = new PostsService();  // PostsService instanziieren
            LoadPosts(); // Methode aufrufen, um Posts zu laden
        }

        // Methode zum Laden der Posts vom Service
        private async void LoadPosts()
        {
            // Posts über den PostsService laden
            var postFromServiceAPI = await _PostService.GetAllPostsAsync();

            // Leere die ObservableCollection, bevor neue Posts hinzugefügt werden
            postList.Clear();

            // Füge die geladenen Posts zur Liste hinzu
            foreach (var posts in postFromServiceAPI!)
            {
                postList.Add(posts);
            }

            // Aktualisiere das Binding
            OnPropertyChanged(nameof(postList));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
