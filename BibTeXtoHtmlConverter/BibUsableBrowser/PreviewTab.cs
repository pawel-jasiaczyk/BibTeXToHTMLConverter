using System;
using System.Drawing;
using System.Windows.Forms;
using BibManFunctionality;

namespace BibTeXtoHtmlConverter
{
	public class PreviewTab : TabPage 
	{
		#region Controls

		private Label lblInfo;
		private TextBox textBoxPreview;

		#endregion

		#region Fields

		private IBibDataFile dataFile;

		#endregion

		#region C'tors

		public PreviewTab (IBibDataFile data)
		{
			this.dataFile = data;
			this.Text = data.FileName;

			lblInfo = new Label ();
			lblInfo.Location = new Point (20, 20);
			lblInfo.Text = "Podgląd niedostępny";

			textBoxPreview = new TextBox ();
			textBoxPreview.Multiline = true;
			textBoxPreview.ScrollBars = ScrollBars.Both;
			textBoxPreview.Dock = DockStyle.Fill;

			this.Controls.Add (lblInfo);
			this.Controls.Add (textBoxPreview);

			if (dataFile is IBibTextFile) {
				textBoxPreview.Text = (dataFile as IBibTextFile).Text;
				textBoxPreview.Visible = true;
				lblInfo.Visible = false;
			} else {
				textBoxPreview.Text = "";
				textBoxPreview.Visible = false;
				lblInfo.Visible = true;
			}
		}

		#endregion
	}
}

