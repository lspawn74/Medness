using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DialogueStudio
{
	/// <summary>
	/// Interaction logic for DialogueItemWindow.xaml
	/// </summary>
	public partial class DialogueItemWindow : Window
	{
		#region Fields
		private DialogueItemViewModel viewModel;
		#endregion

		#region Constructor
		public DialogueItemWindow()
		{
			InitializeComponent();
			viewModel = new DialogueItemViewModel();
			DataContext = viewModel;
			TriggerTypesComboBox.ItemsSource = viewModel.types;
		}
		#endregion

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Close();
		}

		private void BrowseDataFileButton_Click(object sender, RoutedEventArgs e)
		{

        }
    }
}
