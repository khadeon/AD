using System;
using Gtk;
using MySql.Data.MySqlClient;

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
		mySqlCommand.CommandText = "select id, nombre from articulo";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

		String [] valor= new String[2];
		TreeView.AppendColumn ("id", new CellRendererText(), "text", 0);
		TreeView.AppendColumn ("Nombre", new CellRendererText(), "text", 1);
		ListStore lista= new ListStore(typeof(String), typeof(String));

		while (mySqlDataReader.Read()) {
			valor [0] = mySqlDataReader [0].ToString();
			valor [1] = mySqlDataReader [1].ToString();
			lista.AppendValues(valor);
		
		}
		mySqlDataReader.Close ();
		a.Close ();
		return lista;
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
