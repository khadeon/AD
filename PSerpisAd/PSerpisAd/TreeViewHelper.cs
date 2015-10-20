using System;
using Gtk;
using System.Collections;
namespace SerpisAD
{
	public class TreeViewHelper
	{
		public static void Fill(TreeView treeView, QueryResult queryResult)
		{
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
	}
}

