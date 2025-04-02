using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.Services;

namespace BKWitten_App_Frontend.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Users> userList { get; set; }
        public ObservableCollection<Users> teacherList { get; set; }
        private readonly UsersService _userService;

        public UserViewModel()
        {
            _userService = new UsersService(new HttpClient());
            userList = new ObservableCollection<Users>();
            teacherList = new ObservableCollection<Users>();
            LoadUsers(); 
        }
        private async void LoadUsers()
        {
            var usersFromServiceAPI = await _userService.GetAllUsersAsync();
           
            userList.Clear();
            teacherList.Clear();

            foreach (var user in usersFromServiceAPI!)
            {
                userList.Add(user);

                if (user.IsTeacher)
                {
                    teacherList.Add(user);
                }
            }
            OnPropertyChanged(nameof(userList));
            OnPropertyChanged(nameof(teacherList));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
