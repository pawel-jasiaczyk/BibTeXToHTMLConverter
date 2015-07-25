using System;
using System.Windows.Forms;
using System.Drawing;
using BibManFunctionality;
using System.IO;

namespace BibTeXtoHtmlConverter
{
	public partial class BibUsableBrowser : Form
	{
		#region Fields

		IBibUsable data;

		#endregion

		#region C'tors

		public BibUsableBrowser (IBibUsable data)
		{
			this.data = data;
			InitializeComponent ();
		}

		#endregion

		#region treeViewData methods

		void TreeViewData_AfterSelect (object sender, TreeViewEventArgs e)
		{
			try{RefreshTextBoxDetail ();}
			catch(IndexOutOfRangeException ex){
				MessageBox.Show (string.Format ("Sugestia :\n" +
				"Spróbuj odświeżyć widok i wtedy wybrać pozycje\n" +
				"Komunikat błędu:\n{0}", ex.Message), "Błąd!"
				);
			}
			catch (Exception ex){
				MessageBox.Show (string.Format("Komunikat błędu: \n{0}", ex.Message), "Błąd!");
			}
		}

		private IBibOptionSwitchable lastSelectedObject;

		void BuildNodeContextMenu(TreeNode node)
		{
			treeNodeContextMenu.MenuItems.Clear ();
			if (node != null) {
				if (GetDataObjectFromNode (node) is IBibOptionSwitchable) {
					lastSelectedObject = 
						(IBibOptionSwitchable)GetDataObjectFromNode (node);
					foreach (string option in lastSelectedObject.OptionsName) {
						MenuItem item = new MenuItem (option);
						item.Checked = lastSelectedObject.GetOptionState (option);
						item.Click += Item_Click;
						treeNodeContextMenu.MenuItems.Add (item);
					}
				} else {
				}
			} else
				MessageBox.Show ("Nie zaznaczono węzła \nlub węzeł jest pusty (null)");
		}

		void TreeViewData_MouseClick (object sender, MouseEventArgs e)
		{
			try{
				if (e.Button == MouseButtons.Left) {
				}
				if (e.Button == MouseButtons.Right) {
					BuildNodeContextMenu (treeViewData.SelectedNode);
					treeNodeContextMenu.Show(this.treeViewData, e.Location);
				}
			}
			catch(Exception ex) {
				MessageBox.Show (ex.Message, "Błąd programu!");
			}
		}

		void Item_Click (object sender, EventArgs e)
		{
			lastSelectedObject.SetOptionState ((sender as MenuItem).Text, !(sender as MenuItem).Checked);
			BuildTabPreview ();
		}

		object GetDataObjectFromNode(TreeNode node)
		{
			object toReturn = null;
			if (node != null) {
				try {
					if (node.Parent is TreeNode)
						toReturn = data.GetPositions () [node.Parent.Index].GetFields () [node.Index];
					else
						toReturn = data.GetPositions () [node.Index];
				} catch (Exception ex) {
					MessageBox.Show (ex.Message, "Błąd programu!");
				}
			} 
			return toReturn;
		}

		#endregion

		#region tabPreview methods

		private void BuildTabPreview()
		{
			tabPreview.TabPages.Clear ();
			try{
				if (this.data is IBibFileOperable) {
					foreach (IBibDataFile file in (data as IBibFileOperable).Files)
					this.tabPreview.TabPages.Add (new PreviewTab (file));
				}
			}
			catch(Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		#endregion

		#region mmuEdit methods

		void MmuEditRefresh_Click (object sender, EventArgs e)
		{
			try{
			this.RefreshData ();
			this.Refresh ();
			}
			catch(Exception ex) {
				MessageBox.Show (ex.Message, "Błąd");
			}
		}

		void MmuEditOptions_Click (object sender, EventArgs e)
		{
			GroupOptions window = new GroupOptions ();
			if (window.ShowDialog () == DialogResult.OK) {
			}
		}

		#endregion

		#region mmuSave methods

		// funkcja tymczasowa, do poprawy
		void MmuSaveFile_Click (object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog ();
			dlg.Filter = "HTML files (*.html, *.htm) | *.html, *.htm";
			IBibWriteble writebleData = (IBibWriteble)this.data;
			dlg.FileName = (writebleData).Files [0].FileName;
			if (dlg.ShowDialog () == DialogResult.OK) {
				if(writebleData.IsTextFile)
					File.WriteAllText(dlg.FileName, writebleData.GetFileText());
			}
		}

		#endregion

		#region Refresh Data methods

		private void RefreshData()
		{
			RefreshTreeViewData ();
			RefreshTextBoxDetail ();
			BuildTabPreview ();
		}

		private void RefreshTreeViewData()
		{
			treeViewData.Nodes.Clear ();
			for (int i = 0; i < data.GetPositions ().Length; i++) {
				IBibPositionUsable position = data.GetPositions () [i];
				TreeNode node = new TreeNode (position.Name);
				for (int j = 0; j < position.GetFields ().Length; j++) {
					IBibFieldUsable field = position.GetFields () [j];
					TreeNode subnode = new TreeNode (field.Name);
					node.Nodes.Add (subnode);
				}
				treeViewData.Nodes.Add (node);
			}
		}

		private void RefreshTextBoxDetail()
		{
			if (treeViewData.SelectedNode == null) {
				textBoxDetails.Text = "";
			} else {
				TreeNode node = treeViewData.SelectedNode;
				if (!(node.Parent is TreeNode)) {
					textBoxDetails.Text = string.Format ("{0} : {1}",
						data.GetPositions () [node.Index].PositionType,
						data.GetPositions () [node.Index].Name);
				} else {
					textBoxDetails.Text = string.Format ("{0} = {1}",
						data.GetPositions () [node.Parent.Index].GetFields () [node.Index].Name,
						data.GetPositions () [node.Parent.Index].GetFields () [node.Index].GetValue ()
					);
				}
			}
		}

		#endregion
	}
}
