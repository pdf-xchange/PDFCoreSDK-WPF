using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSimpleApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public partial class MainWindow : Window
	{
		private CSampleFill smp = new CSampleFill();

		public MainWindow()
		{
			smp.InitializeSDK();
			InitializeComponent();
		}
		private void Window_Initialized(object sender, EventArgs e)
		{
			uint nVer = smp.g_Inst.APIVersion;
			label.Content = String.Format("API version: {0}.{1}.{2}.{3}  (0x{4:x})", CSampleFill.HiByte(CSampleFill.HiWord(nVer)), CSampleFill.LoByte(CSampleFill.HiWord(nVer)), CSampleFill.HiByte(CSampleFill.LoWord(nVer)), CSampleFill.LoByte(CSampleFill.LoWord(nVer)), nVer);
		}
		private void Window_Closed(object sender, EventArgs e)
		{
			smp.FinalizeSDK();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = "pdf";
			saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			if (saveFileDialog.ShowDialog() == false)
			{
				MessageBox.Show("User break");
				return;
			}
			smp.Perform(saveFileDialog.FileName);
		}

	}
}
