using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibTeXtoHtmlConverter
{
	public partial class MainWindow : Form
	{
		#region WinForms Auto

		private System.ComponentModel.IContainer components = null;

		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#endregion

		#region Controls

		private Panel mainPanel;
		private MenuStrip mainMenu;
		private ToolStripMenuItem mmuFile, mmuFileExit;
		private ToolStripMenuItem mmuBibTeX, mmuBibTeXOpen, mmuBibTeXAdd, mmuBibTeXClear, mmuBibTeXPreview;
		private ToolStripMenuItem mmuHtml, mmuHtmlExport, mmuHtmlFastExport, mmuHtmlOptions;

		#endregion

		#region InitializeComponent methods

		private void InitializeComponent()
		{
			this.SuspendLayout ();
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (422, 244);
			this.Name = "Form1";
			this.Text = "Konwerter BibTeX na HTML";
			//
			// Deklaracje
			//
			// panel
			mainPanel = new Panel();
			// menu
			mainMenu = new MenuStrip ();
			// mmuFile
			mmuFile = new ToolStripMenuItem ();
			mmuFileExit = new ToolStripMenuItem ();
			// mmuBibTeX
			mmuBibTeX = new ToolStripMenuItem ();
			mmuBibTeXAdd = new ToolStripMenuItem ();
			mmuBibTeXClear = new ToolStripMenuItem ();
			mmuBibTeXOpen = new ToolStripMenuItem ();
			mmuBibTeXPreview = new ToolStripMenuItem ();
			// mmuHtml
			mmuHtml = new ToolStripMenuItem ();
			mmuHtmlExport = new ToolStripMenuItem ();
			mmuHtmlFastExport = new ToolStripMenuItem ();
			mmuHtmlOptions = new ToolStripMenuItem ();
			//
			// mmuFile
			//
			mmuFile.Text = "Plik";
			//
			// mmuFileExit
			//
			mmuFileExit.Text = "Koniec";
			mmuFileExit.Click += MmuFileExit_Click;
			mmuFile.DropDownItems.Add (mmuFileExit);
			//
			// mmuBibTeX
			//
			// mmuBibTeXOpen
			mmuBibTeXOpen.Text = "Otwórz plik BibTeX";
			mmuBibTeXOpen.Click += MmuBibTeXOpen_Click;
			// mmuBibTeXAdd
			mmuBibTeXAdd.Text = "Dodaj plik BibTeX";
			mmuBibTeXAdd.Click += MmuBibTeXAdd_Click;
			// mmuBibTeXClear
			mmuBibTeXClear.Text = "Wyczyść";
			mmuBibTeXClear.Click += MmuBibTeXClear_Click;
			// mmuBibTeXPreview
			mmuBibTeXPreview.Text = "Przeglądaj bazę";
			mmuBibTeXPreview.Click += MmuBibTeXPreview_Click;
			// mmuBibTeX
			mmuBibTeX.Text = "BibTeX";
			mmuBibTeX.DropDownItems.AddRange(new []{mmuBibTeXOpen, mmuBibTeXAdd, mmuBibTeXClear});
			mmuBibTeX.DropDownItems.Add (new ToolStripSeparator ());
			mmuBibTeX.DropDownItems.AddRange (new []{ mmuBibTeXPreview });
			//
			// mmuHtml
			//
			// mmuHtmlExport
			mmuHtmlExport.Text = "Exportuj do HTML";
			mmuHtmlExport.Click += MmuHtmlExport_Click;
			// mmuHtmlFastExport
			mmuHtmlFastExport.Text = "Szybki export do HTML";
			// mmuHtmlOptions
			mmuHtmlOptions.Text = "Opcje HTML";
			// mmuHtml
			mmuHtml.Text = "HTML";
			mmuHtml.DropDownItems.AddRange(new []{mmuHtmlExport, mmuHtmlFastExport} );
			mmuHtml.DropDownItems.Add (new ToolStripSeparator ());
			mmuHtml.DropDownItems.AddRange (new []{ mmuHtmlOptions });
			//
			// mainMenu
			//
			this.mainMenu.Items.AddRange(new []{mmuFile, mmuBibTeX, mmuHtml} );
			//
			// mainPanel
			//
			this.mainPanel.Dock = DockStyle.Fill;
			//
			// Dodanie kontrolek do kolekcji
			//
			this.Controls.Add (mainPanel);
			this.Controls.Add (mainMenu);
			//
			// Ostatnie ustawienia
			//
			this.ResumeLayout (false);
		}

		#endregion
	}
}
