using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;

namespace BKWitten_App_Frontend.ViewModels
{
    //INotifyPropertyChanged ist ein Interface welches dafür sorgt, dass sich das UI automatisch aktualisiert, wenn sich die UserListe ändert. 
    public class UserViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Users> userList { get; set; } = new();
        private readonly UsersService _userService;
        public UserViewModel()
        {
            _userService = new UsersService();  // UserService instanziieren
            LoadUsers(); // Methode aufrufen, um User zu laden
        }

        // Methode zum Laden der User vom Service
        private async void LoadUsers()
        {
            // Posts über den EventService laden
            var usersFromServiceAPI = await _userService.GetAllUsersAsync();

            // Leere die ObservableCollection, bevor neue User hinzugefügt werden
            userList.Clear();

            // Füge die geladenen User zur Liste hinzu
            foreach (var users in usersFromServiceAPI!)
            {
                userList.Add(users);
            }

            // Aktualisiere das Binding
            OnPropertyChanged(nameof(userList));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
