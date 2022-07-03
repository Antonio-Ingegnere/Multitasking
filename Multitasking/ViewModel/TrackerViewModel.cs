using Multitasking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Multitasking.ViewModel
{
    public class TrackerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Todo> _todoList = new ObservableCollection<Todo>();
        public Todo NewTodo { get; set; } = new Todo();

        public ObservableCollection<Todo> MyStrings { get; set; }

        public ObservableCollection<Todo> TodoList { get; set; }
        //{
        //    get { return _todoList; }
        //    set
        //    {
        //        _todoList = value;
        //        OnPropertyChanged();
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public TrackerViewModel()
        {
            TodoList = new ObservableCollection<Todo>();

            MyStrings = new ObservableCollection<Todo>();
            //MyStrings = new ObservableCollection<string>
            //{
            //    "Hey, have you",
            //    "Subscribed to",
            //    "My channel",
            //    "YET?!"
            //};
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //public void AddTodo()
        //{
        //    TodoList.Add(NewTodo);
        //    NewTodo.ClearData();
        //}

        public void MoveNewItemToList(bool clearNewItemOnAdd = true)
        {
            TodoList.Add(NewTodo.GetCopy());

            if (clearNewItemOnAdd)
                NewTodo.ClearData();
        }
    }
}
