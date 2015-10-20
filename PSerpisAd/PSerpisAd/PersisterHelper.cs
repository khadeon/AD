using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
namespace SerpisAD
{
	public class PersisterHelper
	{
		public static QueryResult Get(string selectText)
		{
			IDbConnection dbConnection = App.Instance.DbConnection;
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText=selectText;

			IDataReader dataReader = dbCommand.ExecuteReader ();
			QueryResult queryResult = new QueryResult ();
			queryResult.ColumNames = getColumnames (dataReader);
			List<IList> rows=new List<IList>();
			while (dataReader.Read()) {
				rows.Add (getRow(dataReader));
			}
			queryResult.Rows = rows;

			dataReader.Close ();
			return queryResult;

		}

		private static string[] getColumnames(IDataReader mySqlDataReader)
		{
			List<string> columnames = new List<string> ();
			int count = mySqlDataReader.FieldCount;
			for (int i=0; i<count; i++) 
				columnames.Add (mySqlDataReader.GetName (i));
			return columnames.ToArray ();
		}

		private static IList getRow(IDataReader dataReader)
		{
			List<object> values = new List<object>();
			int count = dataReader.FieldCount;
			for(int i=0; i<count ;i++)
				values.Add(dataReader[i]);
			return values;
		}

		private Type[] getTypes(int count)
		{
			List<Type> tipos = new List<Type> ();
			for(int i=0; i < count; i++)
				tipos.Add(typeof(string));
			return tipos.ToArray();
		}


	}
}