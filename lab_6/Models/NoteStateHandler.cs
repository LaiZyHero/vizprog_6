/*using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace lab_6.Models
{
    public class NoteStateHandler : INoteStateHandler
    {
        private ObservableCollection<NoteState> _listWithNotesByDate;

        // This function adding new note to the file
        // Path to the we will get from NoteState.GetPathToFile()
        // User should set the to the file in dialog window
        // Note will save in the file like a string in this format:
        // [dd-mm-yy-{uid}]:{NameOfNote}
        // ... .... ...
        // ... Note ...
        // ... .... ...
        // [dd-mm-yy-{uid}]
        public void AddNewNoteToFile(string Date, string Name, string Text, int ID)
        {
            string Path = NoteState.GetPathToFile();
            if (Path != null)
            {
                try
                {
                    StreamWriter Writer = new StreamWriter(Path);
                    Writer.WriteLine("[" + Date + "-" + ID.ToString() + "]");
                    Writer.Write(":" + "{" + Name + "}");
                    Writer.WriteLine(Text);
                    Writer.WriteLine("[" + Date + "-" + ID.ToString() + "]");
                    Writer.Close();
                }
                catch
                {
                    return;
                }
            }
        }

        // Return a List with NoteState objects by {Date}
        // This function returning a List or not returning if we dont have any notes in this Date
        public void GetAllNotes(string Date, ObservableCollection<NoteState> ListForWriting)
        {
            ReadNotesFromFile(Date);
            if (_listWithNotesByDate != null)
            { 
                ListForWriting = _listWithNotesByDate;
            }
        }

        // Read all notes by current date (dd-mm-yy) in _listWithNotesByDate from file by Path
        private void ReadNotesFromFile(string Date) // Date like a 
        {
            if (NoteState.GetPathToFile() != "")
            {
                try
                {
                    int cur_id = 1;
                    StreamReader Reader = new StreamReader(NoteState.GetPathToFile());
                    string FileAtr;
                    FileAtr = Reader.ReadToEnd();
                    bool End = false;
                    while (!End)
                    {
                        if (FileAtr.Contains("[" + Date + "-" + cur_id.ToString() + "]" + ":"))
                        {
                            string Temp = "[" + Date + "-" + cur_id.ToString() + "]" + ":";
                            int PositionStart = FileAtr.IndexOf(Temp) + Temp.Length + 1;

                            string ResultNoteName = "";
                            while (FileAtr[PositionStart] != '{')
                            {
                                ResultNoteName += FileAtr[PositionStart];
                                ++PositionStart;
                            }
                            ++PositionStart;

                            string ResultNoteText = "";
                            while (PositionStart != FileAtr.IndexOf("[" + Date + "-" + cur_id.ToString() + "]", PositionStart))
                            {
                                ResultNoteText += FileAtr[PositionStart];
                                ++PositionStart;
                            }

                            NoteState Note = new NoteState(cur_id, ResultNoteText, ResultNoteName);
                            _listWithNotesByDate.Add(Note);
                        }
                        else
                        {
                            End = true;
                        }
                        ++cur_id;
                    }
                    Reader.Close();
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
*/