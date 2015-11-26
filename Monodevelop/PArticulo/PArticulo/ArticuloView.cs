using System;
using Gtk;
using System.Collections;
using SerpisAD;
using System.Data;


namespace PArticulo
{
	public delegate void SaveDelegate();
	public partial class ArticuloView : Gtk.Window
	{
		private object id;
		private object categoria=null;
		private string nombre="";
		private decimal precio=0;
		private SaveDelegate save;

		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			init ();
			save=insert;
		}
		public void init()
		{
			this.Build ();
			//entry1.Text="nuevo;
			QueryResult queryresult = PersisterHelper.Get ("select * from categoria");
			ComboBoxHelper.Fill (combobox1, queryresult, categoria);
			//spinButtonPrecio.Value=1.5;
			saveAction.Activated += delegate { save(); };
		}
		public ArticuloView(object id) : base(WindowType.Toplevel)
		{
			this.id = id;
			load ();
			init();
			save=update;
		}

		private void load()
		{
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from articulo where id = @id";
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			if (!dataReader.Read ()) {
				string excep = "ERROR";
				Console.Write (excep);
				dataReader.Close ();
			}
			nombre = (String)dataReader ["nombre"];
			categoria = dataReader ["categoria"];
			if (categoria is DBNull)
				categoria = null;
			precio =(decimal) dataReader ["precio"];
			dataReader.Close ();
			//entry1.Text = nombre;
			//TODO posicionarnos en el comboboxCategoria
			//spinbutton1.Value = Convert.ToDouble (precio);
		}


		private void insert(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
				"values (@nombre, @categoria, @precio)";


			nombre = entry1.Text;
			categoria = ComboBoxHelper.GetId(combobox1);//TODO cojerlo del comboBox
			precio = Convert.ToDecimal (spinbutton1.Value);

			DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter(dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter(dbCommand, "precio", precio);

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}

		private void update(){
			Console.WriteLine ("update");
		}



	}
}

