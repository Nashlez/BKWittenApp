using BKWitten_App_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKWitten_App_Frontend.Services
{
    internal class AddNewTeacher
    {
        private ObservableCollection<Teacher> _teachers;

        public AddNewTeacher()
        {
            _teachers = new ObservableCollection<Teacher>();
        }
        public ObservableCollection<Teacher> Teachers => _teachers;

        public void AddTeacher(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Der Name darf nicht leer sein.", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Die E-Mail-Adresse darf nicht leer sein.", nameof(email));

            Teacher newTeacher = new Teacher { Name = name, Email = email };
            _teachers.Add(newTeacher);
        }
    }
}

