using System.Windows;

namespace DialogueStudio
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainWindowViewModel viewModel;

		public MainWindow()
		{
			InitializeComponent();
			viewModel = new MainWindowViewModel();
			DataContext = viewModel;
		}

		private void LoadButton_Click(object sender, RoutedEventArgs e)
		{
			viewModel.Load();
		}
	
		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			viewModel.Save();
		}

		private void InsertButton_Click(object sender, RoutedEventArgs e)
		{
			viewModel.Insert();
		}
	}
}
