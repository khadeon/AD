using System;
using Gtk;
using System.Collections;
using SerpisAD;


namespace PArticulo
{
	public class ComboBoxHelper
	{
		public static void Fill(ComboBox combobox1, QueryResult queryresult)
		{
			CellRendererText cellRendererText = new CellRendererText ();
			combobox1.PackStart (cellRendererText, false);
			
			combobox1.SetCellDataFunc (cellRendererText,
						    delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				IList row = (IList)tree_model.GetValue (iter, 0);
				cellRendererText.Text = row[1].ToString();
					});
			ListStore listStore = new ListStore (typeof(IList));
			IList first=new object[]{null,"<sin asignar>"};
			TreeIter treeIterFirst=listStore.AppendValues (first);
			foreach (IList row in queryresult.Rows)
				listStore.AppendValues (row);
			
			combobox1.Model = listStore;
			//combobox1.Active = 0;
			combobox1.SetActiveIter (treeIterFirst);
		}

		public static object GetId(ComboBox comboBox)
		{
			TreeIter treeIter;
			comboBox.GetActiveIter (out treeIter);
			IList row = (IList)comboBox.Model.GetValue (treeIter, 0);
			return row [0];
		}
	}
}

