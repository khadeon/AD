using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	

	public MySqlConnection conexion()
	{
		MySqlConnection mySqlConnection = new MySqlConnection(
			"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas");
		mySqlConnection.Open ();

		return mySqlConnection;
	}

	public ListStore cadena(MySqlConnection a)
	{
		MySqlCommand mySqlCommand = a.CreateCommand();
		mySqlCommand.CommandText = "select * from articulo";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

		//ListStore lista= new ListStore(typeof(String), typeof(String));

		String[] columnames = getColumnames (mySqlDataReader);

		for (int i=0; i<columnames.Length; i++)
			TreeView.AppendColumn (columnames[i], new CellRendererText(), "text", i);
		//ListStore listastore = new ListStore (typeof(String), typeof(String));

		Type[] types = getTypes (mySqlDataReader.FieldCount);
		ListStore list = new ListStore (types);

		while (mySqlDataReader.Read()) {
			string[] values = getValues (mySqlDataReader);
			list.AppendValues (values);
		}

		mySqlDataReader.Close ();
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
