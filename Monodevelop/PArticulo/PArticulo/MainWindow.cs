using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using PArticulo;
public partial class MainWindow: Gtk.Window
{	

	public IDbConnection conexion()
	{
		Console.WriteLine ("MainWindow ctor.");
		IDbConnection dbConnection = App.Instance.DbConnection;

		return dbConnection;
	}

	public ListStore cadena(IDbConnection a)
	{
		IDbCommand dbCommand = a.CreateCommand();
		dbCommand.CommandText = "select * from articulo";
		IDataReader dbDataReader = dbCommand.ExecuteReader ();

		String[] columnames = getColumnames (dbDataReader);

		for (int i=0; i<columnames.Length; i++)
			TreeView.AppendColumn (columnames[i], new CellRendererText(), "text", i);

		Type[] types = getTypes (dbDataReader.FieldCount);
		ListStore list = new ListStore (types);

		while (dbDataReader.Read()) {
			string[] values = getValues (dbDataReader);
			list.AppendValues (values);
		}

		dbDataReader.Close ();
		a.Close ();
		return list;
	}

	private string[] getColumnames(MySqlDataReader mySqlDataReader)
	{
		List<string> columnames = new List<string> ();
		int count = mySqlDataReader.FieldCount;
		for (int i=0; i<count; i++) 
			columnames.Add (mySqlDataReader.GetName (i));
		return columnames.ToArray ();
	}

	private Type[] getTypes(int count)
	{
		List<Type> tipos = new List<Type> ();
		for(int i=0; i < count; i++)
			tipos.Add(typeof(string));
		return tipos.ToArray();
	}

	private string[] getValues(MySqlDataReader mySqlDataReader)
	{
		List<string> values = new List<string>();
		for(int i=0; i< mySqlDataReader.FieldCount;i++)
			values.Add(mySqlDataReader[i].ToString());
		return values.ToArray();
	}

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		TreeView.Model = cadena (conexion());
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
