using System;

namespace lab_6.Models
{
    public class NoteState
    {
/*        private static string _path = ""; // Path to DataBase where we have our Notes
        public static void SetPathToFile(string PathToFile) { _path = PathToFile; }
        public static string GetPathToFile() { return _path; }*/

/*        private int _uid; // Note id // Format - from 0 to 999 // Not sure that it will bigger than 10 // Example if id: 1, 2, 3 and etc... //
        public void SetUID(int uid) { _uid = uid; }
        public int GetUID() { return _uid; }*/

        public string Title { get; set; } // Name of Note, Default Name = "Note #{uid}"
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }

        public NoteState(string name, string description, DateTimeOffset date)
        {
            Date = date;
            Text = description;
            Title = name;
        }

/*        public NoteState(int id, string notetxt, string name)
        {
            //SetUID(id);
            SetNameOfNote(name);
            Text = notetxt;
        }*/
    }
}
