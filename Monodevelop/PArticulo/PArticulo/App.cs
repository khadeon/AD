using System;
using System.Data;
namespace PArticulo
{
	public class App
	{
		private App()
		{
		}
		private IDbConnection dbConnection;
		public IDbConnection DbConnection {
			get{ return dbConnection;}
		}
		private static App instance=new App();
		public static App Instance{
			get{ return instance;}
		}


	}
}

