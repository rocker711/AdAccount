using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		
		/// <summary>
		/// Calculates the samaccount in realtime. Takes first and last names
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void name_TextChanged(object sender, TextChangedEventArgs e)
		{


			string first = fname.Text.Trim().ToLower();
			string last = lname.Text.Trim().ToLower();

			if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(last))
			{
				samcalc.Content = string.Empty;
				return;
			}

			// Start with up to 7 characters of the last name
			string samName = last.Length > 7 ? last.Substring(0, 7) : last;

			// Pad with characters from first name until at least 5 characters
			int i = 0;
			while (samName.Length < 5 && i < first.Length)
			{
				samName += first[i];
				i++;
			}

			// Append first character of first name only if it hasn't been used already
			if (samName.Length < 8 && (i == 0 || first[0] != samName[samName.Length - 1]))
			{
				samName += first[0];
			}

			// Trim to max 8 characters
			if (samName.Length > 8)
			{
				samName = samName.Substring(0, 8);
			}


			samcalc.Content = $"{samName} Length is {samName.Length}";

		}


		
		/// <summary>
		/// Takes Office selected for OU and AD field
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_CreateAD(object sender, RoutedEventArgs e)
		{

		}


		/// <summary>
		/// Change office variable and OU when new item selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Office_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string useroffice = (Office.SelectedValue).ToString();
			
		}
	}








}
