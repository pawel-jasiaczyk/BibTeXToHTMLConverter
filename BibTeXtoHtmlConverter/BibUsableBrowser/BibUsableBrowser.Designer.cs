using System;
using System.Windows.Forms;
using BibManFunctionality;
using System.IO;

namespace BibTeXtoHtmlConverter
{
	public partial class BibUsableBrowser : Form
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

		MenuStrip mainMenu;
		ToolStripMenuItem mmuEdit, mmuEditRefresh;
		ToolStripMenuItem mmuEditOptions;
		ToolStripMenuItem mmuSave, mmuSaveFile;


		SplitContainer mainSplit, secondSplit;
		TreeView treeViewData;
		TextBox textBoxDetails;

		TabControl tabPreview;

		ContextMenu treeNodeContextMenu;

		#endregion

		#region InitializeComponent methods

		private void InitializeComponent()
		{
			this.SuspendLayout ();
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (422, 244);
			this.Name = "Form1";
			this.Text = data.Name;
			//
			// Definicje
			//
			mainSplit = new SplitContainer();
			secondSplit = new SplitContainer ();
			textBoxDetails = new TextBox ();
			treeViewData = new TreeView ();
			tabPreview = new TabControl ();
			treeNodeContextMenu = new ContextMenu ();
			// menu
			mainMenu = new MenuStrip ();
			mmuEdit = new ToolStripMenuItem ();
			mmuEditRefresh = new ToolStripMenuItem ();
			mmuSave = new ToolStripMenuItem ();
			mmuSaveFile = new ToolStripMenuItem ();
			mmuEditOptions = new ToolStripMenuItem ();
			//
			// mainMenu
			//
			// mmuEditRefresh
			mmuEditRefresh.Text = "Odśwież";
			mmuEditRefresh.ShortcutKeys = Keys.F5;
			mmuEditRefresh.Click += MmuEditRefresh_Click;
			// mmuEditOptions
			mmuEditOptions.Text = "Opcje";
			mmuEditOptions.Click += MmuEditOptions_Click;
			// mmuEdit
			mmuEdit.Text = "Edytuj";
			mmuEdit.DropDownItems.Add (mmuEditRefresh);
			mmuEdit.DropDownItems.Add (new ToolStripSeparator ());
			mmuEdit.DropDownItems.Add (mmuEditOptions);
			// mainMenu
			mainMenu.Items.Add(mmuEdit);
			//
			// secondSplit
			//
			// treeViewData
			treeViewData.Dock = DockStyle.Fill;
			treeViewData.AfterSelect += TreeViewData_AfterSelect;
			treeViewData.MouseClick+= TreeViewData_MouseClick;
			// tabPrevie
			tabPreview.Dock = DockStyle.Fill;
			// secondSplit container
			secondSplit.Dock = DockStyle.Fill;
			secondSplit.Orientation = Orientation.Vertical;
			secondSplit.Panel1.Controls.Add (treeViewData);
			secondSplit.Panel2.Controls.Add (tabPreview);
			//
			// mainSplit
			//
			// textBoxDetails
			textBoxDetails.Multiline = true;
			textBoxDetails.ScrollBars = ScrollBars.Both;
			textBoxDetails.Dock = DockStyle.Fill;
			// mainSplit container
			mainSplit.Dock = DockStyle.Fill;
			mainSplit.Orientation = Orientation.Horizontal;
			mainSplit.SplitterWidth = 3;
			mainSplit.Panel1MinSize = 30;
			mainSplit.Panel1.Controls.Add (secondSplit);
			mainSplit.Panel2.Controls.Add (textBoxDetails);
			//
			// Dodanie kontrolek do listy
			//
			this.Controls.Add(mainSplit);
			this.Controls.Add (mainMenu);
			//
			// Końcowe ustawienia
			//
			if(data is IBibWriteble) BuilSaveMenu();
			RefreshData();
			this.ResumeLayout (false);
		}

		private void BuilSaveMenu()
		{
			mmuSave.Text = "Zapisz";
			mmuSaveFile.Text = "Zapisz plik";
			mmuSaveFile.Click += MmuSaveFile_Click;
			mmuSave.DropDownItems.Add (mmuSaveFile);
			mainMenu.Items.Add (mmuSave);
		}

		#endregion
	}
}

