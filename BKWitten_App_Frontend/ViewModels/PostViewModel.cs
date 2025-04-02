using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;
using System.Linq;

namespace BKWitten_App_Frontend.ViewModels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Posts> PostList { get; set; }
        public ObservableCollection<Posts> AllPosts { get; set; } = new();

        private readonly PostsService _postService;

        private string _searchTextPosts;
        public string SearchTextPosts
        {
            get => _searchTextPosts;
            set
            {
                if (_searchTextPosts != value)
                {
                    _searchTextPosts = value;
                    OnPropertyChanged();
                    FilterPosts(); 
                }
            }
        }
        public PostViewModel()
        {
            _postService = new PostsService(new HttpClient());
            PostList = new ObservableCollection<Posts>();
            _ = LoadPosts();
            FilterPosts();
        }
        private async Task LoadPosts()
        {
            try
            {
                var postsFromServiceAPI = await _postService.GetAllPostsAsync();
                if (postsFromServiceAPI == null) return;

                AllPosts = new ObservableCollection<Posts>(postsFromServiceAPI);
                FilterPosts(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Posts: {ex.Message}");
            }
        }
        // Such- & Filter
        private void FilterPosts()
        {
            if (string.IsNullOrWhiteSpace(SearchTextPosts))
            {
                PostList.Clear();
                foreach (var post in AllPosts)
                    PostList.Add(post);
            }
            else
            {
                var filtered = AllPosts
                    .Where(post =>
                        (!string.IsNullOrWhiteSpace(post.Title) &&
                        post.Title.Contains(SearchTextPosts, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(post.Description) &&
                        post.Description.Contains(SearchTextPosts, StringComparison.OrdinalIgnoreCase)));

                PostList.Clear();
                foreach (var post in filtered)
                    PostList.Add(post);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
