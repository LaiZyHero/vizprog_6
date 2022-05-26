using lab_6.Models;
using lab_6.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab_6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<NoteState> Items { get; set; }
        private Dictionary<DateTimeOffset, List<NoteState>> PlansByDay;


        ViewModelBase content;
        bool Edit = false;
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }


        string title = "";
        string description = "";



        public void ChangeView()
        {
            if (Content is NoteListControlViewModel) Content = new NoteWindowViewModel();

            else
            {
                Content = new NoteListControlViewModel();
                Edit = false;
                Title = "";
                Description = "";
            }
        }


        DateTimeOffset date = DateTimeOffset.Now.Date;
        public void AddNew(DateTimeOffset date, NoteState item)
        {
            if (!PlansByDay.ContainsKey(date))
            {
                PlansByDay.Add(date, new List<NoteState>());
            }
            PlansByDay[date].Add(item);
            Change_Items(Date);
        }


        public String Title
        {
            get { return title; }
            set { this.RaiseAndSetIfChanged(ref title, value); }
        }
        public DateTimeOffset Date
        {
            get { return date; }
            set { this.RaiseAndSetIfChanged(ref date, value); Change_Items(date); }
        }
        public String Description
        {
            get { return description; }
            set { this.RaiseAndSetIfChanged(ref description, value); }
        }


        public MainWindowViewModel()
        {
            PlansByDay = new Dictionary<DateTimeOffset, List<NoteState>>();
            Items = new ObservableCollection<NoteState>();
            Content = new NoteListControlViewModel();
        }
        public void ViewExItem(NoteState item)
        {
            Edit = true;
            Title = item.Title;
            Description = item.Text;
            ChangeView();
        }

        public void SavePlan(NoteState item)
        {
            bool fNew = false;
            if (Title != "")
            {
                if (Edit)
                {
                    var exitem = PlansByDay[date].Find(i => i.Equals(item));
                    if (exitem != null)
                    {
                        exitem.Title = Title;
                        exitem.Text = Description;
                        fNew = true;
                    }
                    Edit = false;
                }
                else
                {
                    AddNew(Date, new NoteState(Title, Description, date));
                    fNew = true;
                }
            }
            if (fNew == false)
            {
                DeletePlan(item);
                Items.Remove(item);
                AddNew(Date, new NoteState(Title, Description, date));
            }
            ChangeView();
        }

        public void DeletePlan(NoteState item)
        {
            PlansByDay[date].Remove(item);
            Change_Items(date);
        }

        public void Change_Items(DateTimeOffset date)
        {
            if (PlansByDay.ContainsKey(date) == false) Items.Clear();

            else
            {
                Items.Clear();
                foreach (var item in PlansByDay[date]) Items.Add(item);
            }
        }

    }
}
