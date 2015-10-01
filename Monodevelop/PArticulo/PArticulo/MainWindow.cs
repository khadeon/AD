using System;
using Gtk;
using MySql.Data.MySqlClient;
public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		MySqlConnection mySqlConnection = new MySqlConnection(
			"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas");
		mySqlConnection.Open ();
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select id, nombre from articulo";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
//
//		while (mySqlDataReader.Read()) {
//			Console.WriteLine ("id={0} | nombre={1}", mySqlDataReader [0], mySqlDataReader [1]);
//		}
//		mySqlDataReader.Close ();
//		mySqlConnection.Close ();

		//añado columnas
		TreeView.AppendColumn ("id", new CellRendererText(), "text", 0);
		TreeView.AppendColumn ("Nombre", new CellRendererText(), "text", 1);
		TreeView.AppendColumn ("Descripcion", new CellRendererText(), "text", 2);

		//Modelo establecido
		ListStore listaStore = new ListStore (typeof(String), typeof(String), typeof(String));
		//Rellenar el ListStore
		listaStore.AppendValues ("1", "nombre del primero", "Objeto numero 1");
		TreeView.Model = listaStore;
		listaStore.AppendValues ("2", "nombre del segundo", "Objeto numero 2");
		listaStore.AppendValues ("3", "nombre del tercero", "Objeto numero 3");

		//Otra forma de mostrar valores
//		String [] values= new String[3];
//		values [0] = "3";
//		values [1] = "4";
//		values[2] = "5";
//		listaStore.AppendValues (values);

		listaStore.AppendValues ("---","----------------------------------","-------------------------------");

		String [] valor= new String[2];

		while (mySqlDataReader.Read()) {
			valor [0] = mySqlDataReader [0].ToString();
			valor [1] = mySqlDataReader [1].ToString();

			listaStore.AppendValues (valor);
		}
		mySqlDataReader.Close ();
		mySqlConnection.Close ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
