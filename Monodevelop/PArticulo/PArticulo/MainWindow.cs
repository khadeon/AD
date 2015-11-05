using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using SerpisAD;
using System.Collections;
using PArticulo;

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
		TreeViewHelper.Fill (TreeView, queryResult);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		new ArticuloView ();
	}

	
}
