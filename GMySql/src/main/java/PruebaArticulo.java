import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;

public class PruebaArticulo {
	
	//metodo main recibe y ejecuta los metodos
	public static void main(String args[]) throws SQLException
	{
		leer(conecta());
		System.out.println("");
		System.out.println("fin");
	}
	
	//metodo que realiza la conexion
	public static  Connection conecta()throws SQLException
	{
		Connection conexion=DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		return conexion;
	}
	
	//metodo que lee e imprime la base de datos
	public static void leer(Connection conexion) throws SQLException
	{
		//variables de conexion y de consulta
		Statement comando=conexion.createStatement();
		ResultSet rs=comando.executeQuery("SELECT * FROM articulo");
		ResultSetMetaData rsm=rs.getMetaData();
		//for para imprimir el nombre de las columnas
		for(int i=1;i<=rsm.getColumnCount();i++)
		{
			System.out.printf(rsm.getColumnName(i)+"\t");
		}
		
		System.out.println("");
		//bucle que avanza mientras lee la base de datos
		while(rs.next())
		{
			//for que imprime los datos de la base de datos
			for(int i=1;i<=rsm.getColumnCount();i++)
			{
				System.out.print(rs.getString(rsm.getColumnName(i))+"\t");
			}
			System.out.println("");
			
		}
		comando.close();
		conexion.close();
	}
	
	//metodo que añade a la base de datos nueva informacion
	public static void añade(Connection conexion) throws SQLException
	{
		Statement comando=conexion.createStatement();
		ResultSet rs=comando.executeQuery("INSERT INTO articulo");
		ResultSetMetaData rsm=rs.getMetaData();
	}
	
	//metodo que modifica un dato de la base de datos
	public static void modifica(Connection conexion) throws SQLException
	{
		Statement comando=conexion.createStatement();
		ResultSet rs=comando.executeQuery("UPDATE FROM articulo");
		ResultSetMetaData rsm=rs.getMetaData();
	}
	
	//metodo que elimina una fila de base de datos
	public static void elimina(Connection conexion) throws SQLException
	{
		Statement comando=conexion.createStatement();
		ResultSet rs=comando.executeQuery("DELETE FROM articulo");
		ResultSetMetaData rsm=rs.getMetaData();
	}

}
