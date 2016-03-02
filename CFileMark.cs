using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFXCoreAPI;
using System.Runtime.InteropServices;
using System.Windows;

namespace WpfSimpleApp
{
	class CFileMark
	{
		private PXC_Inst m_Inst = null;
		private IPXC_Document doc = null;

		public CFileMark(PXC_Inst inst, IPXC_Document doc)
		{
			m_Inst = inst;
			this.doc = doc;
		}

		public void SaveFile(string fileName)
		{
			try
			{
				doc.WriteToFile(fileName, null, 0);
				System.Diagnostics.Process openProcess = new System.Diagnostics.Process();
				openProcess.StartInfo.FileName = fileName;
				openProcess.StartInfo.UseShellExecute = true;
				openProcess.StartInfo.CreateNoWindow = true;
				openProcess.StartInfo.Verb = "open";
				openProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
				openProcess.Start();
				openProcess.WaitForExit();
			}
			catch (COMException e)
			{
				MessageBox.Show(string.Format("Document has been saved to '{0}'. {1}", fileName, e.Message));
			};
		}

		public void Run()
		{
			//doc.;
		}

	}
}
