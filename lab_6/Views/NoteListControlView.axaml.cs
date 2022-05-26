using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab_6.Models;
using System.Collections.Generic;

namespace lab_6.Views
{
    public partial class NoteListControlView : UserControl
    {
        public NoteListControlView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
