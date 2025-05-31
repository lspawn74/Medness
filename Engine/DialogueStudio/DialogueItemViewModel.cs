using System.ComponentModel;

namespace DialogueStudio
{
	public class DialogueItemViewModel : INotifyPropertyChanged
	{
		#region Fields
		private string id;
		private string character;
		private string text;
		private string dataFile;
		private DialogueTriggerViewModel dialogueTrigger;
		#endregion

		#region Properties
		public string Id
		{
			get => id;
			set
			{
				id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		public string Character
		{
			get => character;
			set
			{
				character = value;
				OnPropertyChanged(nameof(Character));
			}
		}

		public string Text
		{
			get => text;
			set
			{
				text = value;
				OnPropertyChanged(nameof(Text));
			}
		}

		public string DataFile
		{
			get => dataFile;
			set
			{
				dataFile = value;
				OnPropertyChanged(nameof(DataFile));
			}
		}

		public DialogueTriggerViewModel DialogueTrigger
		{
			get => dialogueTrigger;
			set
			{
				dialogueTrigger = value;
				OnPropertyChanged(nameof(DialogueTrigger));
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
