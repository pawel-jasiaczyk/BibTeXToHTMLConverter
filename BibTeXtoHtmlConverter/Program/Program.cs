using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibTeXtoHtmlConverter
{
	public class Program
	{
		[STAThread]
		public static void Main(string[]args)
		{
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);
			Application.Run (new MainWindow ());
		}
	}
}
