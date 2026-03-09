using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DialogueStudio
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		#region Fields
		private List<DialogueItemViewModel> dialogueItems = new List<DialogueItemViewModel>();
		private DialogueItemViewModel selectedDialogue;
		private int selectedIndex;
		#endregion

		#region Properties
		public List<DialogueItemViewModel> DialogueItems
		{
			get => dialogueItems;
			set
			{
				dialogueItems = value;
				OnPropertyChanged(nameof(DialogueItems));
			}
		}

		public DialogueItemViewModel SelectedDialogue
		{
			get => selectedDialogue;
			set
			{
				selectedDialogue = value;
				OnPropertyChanged(nameof(SelectedDialogue));
			}
		}

		public int SelectedIndex
		{ 
			get => selectedIndex;
			set
			{
				selectedIndex = value;
				OnPropertyChanged(nameof(SelectedIndex));
			}
		}
		#endregion

		#region Public methods
		public void Load()
		{
			// Open "load file dialog"
		}

		public void Save()
		{
			// Open "save file dialog"
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = "*.xml";
			saveDialog.AddExtension = true;
			saveDialog.CheckPathExists = true;
			bool? dr = saveDialog.ShowDialog();
            if (dr == true)
            {
                
            }
        }

		public void Insert()
		{
			// Open dialog to create new Dialogue item
			var dialogWnd = new DialogueItemWindow();

			// Set the list of characters already presents in the listview
			if (DialogueItems.Count > 0)
			{
				dialogWnd.ViewModel.CharacterList = DialogueItems.Select(x => x.Character).ToList();
			}

			// Display the dialog
			if (dialogWnd.DataContext is DialogueItemViewModel dialogueItemViewModel)
			{
				bool? res = dialogWnd.ShowDialog();
				if (res == true)
				{
					List<DialogueItemViewModel> tmp = new List<DialogueItemViewModel>(DialogueItems);
					if (tmp.Count == 0 || selectedIndex == tmp.Count-1)
					{
						tmp.Add(dialogueItemViewModel);
					}
                    else
                    {
						tmp.Insert(selectedIndex + 1, dialogueItemViewModel);
                    }
					DialogueItems = tmp;
				}
			}
			else
			{
				// Should never happen
				throw new ApplicationException("Application severe error.");
			}
		}
		#endregion

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
