using System.Collections.Generic;
using System.ComponentModel;

namespace DialogueStudio
{
	public class DialogueTriggerViewModel : INotifyPropertyChanged
	{
		#region Fields
		private string type;
		private string _object;
		#endregion

		#region Properties
		public string Type
		{
			get => type;
			set
			{
				type = value;
				OnPropertyChanged(nameof(Type));
			}
		}

		public string Object
		{
			get => _object;
			set
			{
				_object = value;
				OnPropertyChanged(nameof(Object));
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
