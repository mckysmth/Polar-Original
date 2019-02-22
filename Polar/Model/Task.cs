﻿using System;
using System.ComponentModel;
using SQLite;

namespace Polar.Model
{
    public class Task : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PieceID { get; set; }
        private string taskName;

        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                OnPropertyChanged("TaskName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task()
        {
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
