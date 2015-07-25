using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibTeXtoHtmlConverter
{
	public partial class GroupOptions : Form
	{
		#region WinForms auto

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
		TabControl tabControl;
		Panel panelBtns;
		Button btnOK, btnCancel;
		#endregion

		private void InitializeComponent()
		{
			this.SuspendLayout ();
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (422, 244);
			this.Name = "Form1";
			this.Text = "Opcje";
			//
			// Definicje
			//
			this.panelBtns = new Panel();
			this.tabControl = new TabControl ();
			btnOK =	new Button ();
			btnCancel = new Button ();
			//
			// tabControl
			//
			tabControl.Dock = DockStyle.Fill;
			//
			// panelBtns
			//
			// btnOK
			btnOK.Text = "OK";
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Location = new Point (panelBtns.Width - btnOK.Width - 10, 10);
			btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			// btnCancel
			btnCancel.Text = "Anuluj";
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point (10, 10);
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			// panel
			panelBtns.Dock = DockStyle.Bottom;
			panelBtns.Height = 50;
			panelBtns.Controls.AddRange (new []{ btnOK, btnCancel });
			//
			// Dodanie kontrolek do formy
			//
			this.Controls.Add(tabControl);
			this.Controls.Add (panelBtns);
			//
			// Ostatnie ustawienia
			//
			this.ResumeLayout (false);
		}
	}
}
