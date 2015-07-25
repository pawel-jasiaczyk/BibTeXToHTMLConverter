using System;
using System.Windows.Forms;
using System.Drawing;
using BibManFunctionality;

namespace BibTeXtoHtmlConverter
{
	public partial class MainWindow : Form
	{
		#region Fields
		IBibUsable bibtexdata;
		IBibUsable htmlExporter;
		#endregion

		#region C'tors

		public MainWindow ()
		{
			bibtexdata = new BibTeX.BibTeXDataBase () as IBibUsable;
			htmlExporter = new BibToHTMLPlugin.BibToHtmlExporter ();
			InitializeComponent ();
		}

		#endregion

		#region File Menu methods

		void MmuFileExit_Click (object sender, EventArgs e)
		{
			Close ();
		}

		#endregion

		#region BibTeX Menu methods

		void MmuBibTeXOpen_Click (object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog ();
			dlg.DefaultExt = "bib";
			dlg.Filter = "BibTeX files (*.bib) | *.bib";
			dlg.Multiselect = false;
			if (dlg.ShowDialog () == DialogResult.OK) {
				try{
					(bibtexdata as IBibReadable).OpenFile (dlg.FileName);
				}
				catch(Exception ex) {
					MessageBox.Show (string.Format (
						"Błąd podczas otwierania pliku BibTeX:\n{0}", 
						ex.Message, "Błąd!"));
				}
			}
		}

		void MmuBibTeXAdd_Click (object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog ();
			dlg.DefaultExt = "bib";
			dlg.Filter = "BibTeX files (*.bib) | *.bib";
			dlg.Multiselect = false;
			if (dlg.ShowDialog () == DialogResult.OK) {
				try{
					(bibtexdata as IBibReadable).AddFile (dlg.FileName);
				}
				catch(Exception ex) {
					MessageBox.Show (string.Format (
						"Błąd podczas otwierania pliku BibTeX:\n{0}", 
						ex.Message, "Błąd!"));
				}
			}
		}

		void MmuBibTeXClear_Click (object sender, EventArgs e)
		{
			try{(this.bibtexdata as IBibReadable).ClearBase ();}
			catch(Exception ex) {
				MessageBox.Show (ex.Message, "Błąd programu!");
			}
		}

		void MmuBibTeXPreview_Click (object sender, EventArgs e)
		{
			BibUsableBrowser window = new BibUsableBrowser (bibtexdata as IBibUsable);
			window.Show ();
		}

		#endregion

		#region HTML Menu methods

		void MmuHtmlExport_Click (object sender, EventArgs e)
		{
			(htmlExporter as IBibImportable).ImportData (bibtexdata);
			BibUsableBrowser window = new BibUsableBrowser (htmlExporter as IBibUsable);
			window.Show ();
		}

		#endregion
	}
}