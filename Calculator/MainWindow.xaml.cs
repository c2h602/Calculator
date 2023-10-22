using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			foreach(UIElement el in MainRoot.Children)
			{
				if(el is Button)
				{
					((Button)el).Click += Button_Click;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string str = (string)((Button)e.OriginalSource).Content; /* мы берем объект е класса RoutedEventArgs,
			                                                            * преобразовываем его к классу Button,
			                                                            * берем содержимое объекта с помощью .OriginalSource (???),
			                                                            * получаем надпись, находяшуюся на кнопке с помощью .Content */

			if(str == "AC")
			{
				textLabel.Text = "";
			}
			else if(str == "=")
			{
				string value = new DataTable().Compute(textLabel.Text, null).ToString(); /* создаем объект на основе класса DataTable
				                                                                          * c помощью метода Compute() можно высчитать любую мат операцию */
				textLabel.Text = value;
			}
			
			else
			textLabel.Text += str; // обращаемся к значению Text в textLabel, чтобы добавить еще одно значение
		}
	}
}
