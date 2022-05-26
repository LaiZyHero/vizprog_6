using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using lab_6.Models;
using lab_6.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace lab_6.Views
{
    public partial class MainWindow : Window
    {
       // private string _date;
       // public ObservableCollection<NoteState> NoteListByDate = new ObservableCollection<NoteState>();
        public MainWindow()
        {
            InitializeComponent();
/*            var TaskGetPathToFile = new OpenFileDialog()
            {
                Title = "Open the Database File or Empty .txt File",
                Filters = null
            }.ShowAsync((Window)this.VisualRoot);

            string[]? PathToFile = TaskGetPathToFile.Result;
            var Temp = this.DataContext as MainWindowViewModel;
            if (PathToFile != null)
            {
                NoteState.SetPathToFile(string.Join(@"\", PathToFile));
                try
                {
                    StreamReader Reader = new StreamReader(NoteState.GetPathToFile());
                    _date = Reader.ReadToEnd();
                }
                catch
                {
                    return;
                }
            }

            this.FindControl<DatePicker>("DatePicker").SelectedDateChanged += delegate
            {
                string Date = "";
                DateTimeOffset? t = this.FindControl<DatePicker>("DatePicker").SelectedDate;
                Date += t?.Day.ToString("DD") + "-";
                Date += t?.Month.ToString("MM") + "-";
                Date += t?.Year.ToString("yyyy");
                var Handler = new NoteStateHandler();
                Handler.GetAllNotes(Date, NoteListByDate);
            };*/

            #if DEBUG
                this.AttachDevTools();
            #endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /*        private void AddNoteClickEventHandler(object? Sender, RoutedEventArgs e)
                {
                    if (this.FindControl<DatePicker>("DatePicker").SelectedDate != null)
                    {
                        var Temp = new NoteWindow();
                        Temp.OkNotification += delegate (string Name, string Text)
                        {

                                var t = this.DataContext as MainWindowViewModel;
                                t.NoteName = Name;
                                DateTimeOffset? curDate = this.FindControl<DatePicker>("DatePicker").SelectedDate;
                                t.NoteDate = curDate?.Day.ToString("dd") + "-" + curDate?.Month.ToString("mm") + "-" + curDate?.ToString("yyyy");
                                var Handler = new NoteStateHandler();
                                t.NoteText = Text;
                                Handler.AddNewNoteToFile(t.NoteDate, t.NoteName, t.NoteText, NoteListByDate.Count + 1);
                        };
                        Temp.Show((Window)this.VisualRoot);
                    }
                }*/
    }
}
