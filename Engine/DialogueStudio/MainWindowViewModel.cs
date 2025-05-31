using System.Collections.Generic;
using System.ComponentModel;

namespace DialogueStudio
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		#region Fields
		private DialogueItemViewModel selectedDialogue;
		#endregion

		#region Properties
		public List<DialogueItemViewModel> DialogueItems { get; set; } = new List<DialogueItemViewModel>();
		public DialogueItemViewModel SelectedDialogue
		{
			get => selectedDialogue;
			set
			{
				selectedDialogue = value;
				OnPropertyChanged(nameof(SelectedDialogue));
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
		}

		public void Insert()
		{
			// Open dialog to create new Dialogue item
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
