using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace PMysql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas");

			mySqlConnection.Open ();

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "select * from articulo";
			//"select "+ "a.categoria as articulocategoria, "+"c.nombre as categorianombre, "+
//				"count(*) as numeroarticulo "+"from articulo a "+"left join categoria c "+"on a.categoria c "+
//					"on a.categoria = c.id "+"group by articulocategoria, categorianombre";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

			/*while (mySqlDataReader.Read()) {
				Console.WriteLine ("id={0} nombre={1}", mySqlDataReader ["id"], mySqlDataReader ["nombre"]);
			}*/

			showColumnNames (mySqlDataReader);

			show (mySqlDataReader);

			mySqlDataReader.Close ();

			mySqlConnection.Close ();
		}

		private static void showColumnNames(MySqlDataReader mySqlDataReader)
		{
			String columnName = "";
			for (int i=0; i<mySqlDataReader.FieldCount; i++) {
				columnName = mySqlDataReader.GetName (i);
				Console.WriteLine ("posicion "+i+ " = "+columnName+" ");
			}

		}

		//Otra forma de hacer el for en C++ para el metodo anterior
		/*foreach (String columName int columName)
		{
			Console.WriteLine ("Columna = "+columName);
		}*/

		//.Join es un metodo que junta sin necesidad de un bucle todo lo que hay en un array
		//Console.WriteLine(string.Join (", ", columName);

		private static void show(MySqlDataReader mySqlDataReader)
		{
			Console.WriteLine ("");

			while(mySqlDataReader.Read())
			{
				showRow (mySqlDataReader ());
				//Console.Write ("id = {0} | nombre = {1} | categoria = {2} | precio = {3}", mySqlDataReader["id"],
				               //mySqlDataReader["nombre"], mySqlDataReader["categoria"], mySqlDataReader["precio"]);
				//Console.WriteLine (" ");
			}
		}
		//showRow es un metodo para mostrar lo que hay en las columnas
		//Console.Write("id = "+ mySqlDataReader["id"]); muestra lo mismo que ("id = {0}, mySqlDataReader["id"])

		public static String[] getColumnas(MySqlDataReader mySqlDataReader)
		{
			int count = mySqlDataReader.FieldCount;
			List<String> columnames = new List<String>();
			for(int index=0; index < count; index++)
			{
				columnames.Add(mySqlDataReader.GetName(index));
			}
			return columnames.ToArray();
		}

	}
}
