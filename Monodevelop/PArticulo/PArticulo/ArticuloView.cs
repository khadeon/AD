using System;
using Gtk;
using System.Collections;
using SerpisAD;
using System.Data;


namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			//entry1.Text="nuevo;
			QueryResult queryresult = PersisterHelper.Get ("select * from categoria");
			ComboBoxHelper.Fill (combobox1, queryresult);
			//spinButtonPrecio.Value=1.5;
			saveAction.Activated += delegate { save(); };
		}
		private void save(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
				"values (@nombre, @categoria, @precio)";


			String nombre = entry1.Text;
			object categoria = ComboBoxHelper.GetId(combobox1);//TODO cojerlo del comboBox
			decimal precio = Convert.ToDecimal (spinbutton1.Value);

			DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter(dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter(dbCommand, "precio", precio);

			dbCommand.ExecuteNonQuery ();
		}



	}
}

