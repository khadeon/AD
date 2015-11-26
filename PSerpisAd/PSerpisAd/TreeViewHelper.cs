using System;
using Gtk;
using System.Collections;
namespace SerpisAD
{
	public class TreeViewHelper
	{
		public static void Fill(TreeView treeView, QueryResult queryResult)
		{
			removeAllColum (treeView);
			String[] columnames = queryResult.ColumNames;
			CellRendererText cellRenderText = new CellRendererText ();

			for (int i=0; i<columnames.Length; i++){
				int DataColumn = i;
				treeView.AppendColumn(columnames[i], cellRenderText, delegate(
					TreeViewColumn tree_colum, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					IList row= (IList)tree_model.GetValue(iter, 0);
					cellRenderText.Text=row[DataColumn].ToString();
				});
			}

			ListStore list = new ListStore (typeof(IList));
			foreach (IList row in queryResult.Rows)
				list.AppendValues (row);
			treeView.Model = list;
		}
	
		private static void removeAllColum(TreeView treeView)
		{
			TreeViewColumn[] treeColum = treeView.Columns;
			foreach (TreeViewColumn treeColums in treeColum) {
				treeView.RemoveColumn (treeColums);
			}

		}

		public static object GetId(TreeView treeView)
		{
			TreeIter treeIter;
			if (!treeView.Selection.GetSelected (out treeIter))
				return null;
			IList row=(IList)treeView.Model.GetValue(treeIter, 0);
			return row [0];
		}

		public static bool isSelected(TreeView treeView)
		{
			TreeIter treeIter;
			return treeView.Selection.GetSelected (out treeIter);
			/* o bien
		 * treeView.Selection.CountSelectedRows () != 0; */
		}
	}
}
