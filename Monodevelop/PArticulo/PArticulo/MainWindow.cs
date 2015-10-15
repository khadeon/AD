using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using PArticulo;
using System.Collections;


public partial class MainWindow: Gtk.Window
{	

	public IDbConnection conexion()
	{
		IDbConnection dbConnection = App.Instance.DbConnection;

		return dbConnection;
	}
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		QueryResult queryResult = PersisterHelper.Get("select * from articulo");

		String[] columnames = queryResult.ColumNames;
		CellRendererText cellRenderText = new CellRendererText ();

		for (int i=0; i<columnames.Length; i++){
			int DataColumn = i;
			TreeView.AppendColumn(columnames[i], cellRenderText, delegate(
				TreeViewColumn tree_colum, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				IList row= (IList)tree_model.GetValue(iter, 0);
				cellRenderText.Text=row[DataColumn].ToString();
			});
		}

		ListStore list = new ListStore (typeof(IList));
		foreach (IList row in queryResult.Rows)
			list.AppendValues (row);
		TreeView.Model = list;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
