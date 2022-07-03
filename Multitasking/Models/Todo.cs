using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Multitasking.Models
{
    [Table("Tasks")]
    public class Todo : INotifyPropertyChanged
    {
        private Guid _id;
        private bool _isCompleted;
        private string _description;

        [Key]
        [Required]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ClearData()
        {
            Id = Guid.Empty;
            IsCompleted = false;
            Description = string.Empty;
        }

        public override string ToString()
        {
            return Description;
        }

        public Todo GetCopy()
        {
            return new Todo { Description = this.Description, Id = this.Id, IsCompleted = this.IsCompleted };
        }
    }
}
