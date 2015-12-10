using System;
using System.Data;
using SerpisAD;
using Gtk;
using System.Collections;

namespace PArticulo
{
	public class ArticuloPersister
	{
		private static object id;
		private static object categoria=null;
		private static string nombre="";
		private static decimal precio=0;

		static Articulo objeto=new Articulo();

		public static Articulo Load(object id){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from articulo where id = @id";
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			if (!dataReader.Read ()) {
				string excep = "ERROR";
				Console.Write (excep);
				dataReader.Close ();
			}
			objeto.Nombre = (String)dataReader ["nombre"];
			objeto.Categoria = dataReader ["categoria"];
			if (objeto.Categoria is DBNull)
				objeto.Categoria = null;
			objeto.Precio =(decimal) dataReader ["precio"];
			dataReader.Close ();
			//entry1.Text = nombre;
			//TODO posicionarnos en el comboboxCategoria
			//spinbutton1.Value = Convert.ToDouble (precio);
			return objeto;
		}

		public static void Insert(Articulo articulo)
		{
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
				"values (@nombre, @categoria, @precio)";


			DbCommandHelper.AddParameter(dbCommand, "nombre", objeto.Nombre);
			DbCommandHelper.AddParameter(dbCommand, "categoria", objeto.Categoria);
			DbCommandHelper.AddParameter(dbCommand, "precio", objeto.Precio);

			dbCommand.ExecuteNonQuery ();

		}
		public static void Update(Articulo articulo)
		{
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "update articulo set nombre=@nombre, categoria=@categoria, precio=@precio where id=@id";
			id = articulo.Id;
			nombre = articulo.Nombre;
			categoria = articulo.Categoria;
			precio = articulo.Precio;

			DbCommandHelper.AddParameter (dbCommand,"nombre", nombre);
			DbCommandHelper.AddParameter (dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter (dbCommand, "precio", precio);
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery ();
		}
	}
}

