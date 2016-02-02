import java.awt.Desktop.Action;
import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.DecimalFormat;
import java.util.Scanner;

public class PruebaArticulo {
	static Scanner tcl=new Scanner(System.in);
	private enum Action {Salir, Nuevo, Editar, Eliminar, Consultar, Listar}
	private static Connection connection;
	
	
	/*/metodo que realiza la conexion
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
		tcl.nextLine();
		System.out.println("Inserte nombre");
		String nombre=tcl.nextLine();
		System.out.println("Inserte precio");
		Double precio=tcl.nextDouble();
		tcl.nextLine();
		System.out.println("Inserte Categoria");
		String categoria=tcl.nextLine();
		
		Statement comando=conexion.createStatement();
		ResultSet rs=comando.executeQuery("INSERT INTO articulo("+nombre+","+precio+","+categoria+")");
		ResultSetMetaData rsm=rs.getMetaData();
		
	}
	
	//metodo que modifica un dato de la base de datos
	public static void modifica(Connection conexion) throws SQLException
	{
		System.out.println("Elige el Id de la fila que quieres modificar");
		int id=tcl.nextInt();
		tcl.nextLine();
		System.out.println("Elige el nombre nuevo");
		String nombre=tcl.nextLine();
		System.out.println("ELige el precio nuevo");
		Double precio=tcl.nextDouble();
		tcl.nextLine();
		System.out.println("Elige la categoria nueva");
		String categoria=tcl.nextLine();
		
		Statement comando=conexion.createStatement();
		ResultSet rs=comando.executeQuery("UPDATE articulo SET nombre="+nombre+",categoria="+categoria+",precio="+precio+" WHERE id="+id);
		ResultSetMetaData rsm=rs.getMetaData();
	}
	
	//metodo que elimina una fila de base de datos
	public static void elimina(Connection conexion) throws SQLException
	{
		boolean bucle=false;
		while(bucle!=true)
		{
			System.out.println("Elige el id de la fila que quieres eliminar");
			int id=tcl.nextInt();
			tcl.nextLine();
			Statement comando=conexion.createStatement();
			ResultSet rs=comando.executeQuery("DELETE * FROM articulo WHERE id="+id);
			if(rs==null)
				System.out.println("Ese id no esta en la base de datos, vuelva a introducir datos");
			else
			{
				bucle=true;
				ResultSetMetaData rsm=rs.getMetaData();
			}
		}
		
	}*/
	
	private static Action menu()
	{
		while(true)
		{
			System.out.println("0-Salir"
					+"\n"+"1-Nuevo"
					+"\n"+ "2-Editar"
					+"\n"+ "3-Eliminar"
					+"\n"+ "4-Consultar"
					+"\n"+ "5-Lista");
			String action=tcl.nextLine().trim();
			if(action.matches("[012345]"))
				return Action.values()[Integer.parseInt(action)];
			System.out.println("Opcion Invalida, gañán");
		}
	}
	private static class Articulo
	{
		private long id;
		private String nombre;
		private long categoria;
		private BigDecimal precio;
	}
	
	private static String scanString(String label)
	{
		System.out.print(label);
		return tcl.nextLine().trim();
	}
	
	private static long scanLong(String label)
	{
		while(true){
			System.out.print(label);
			String data=tcl.nextLine().trim();
			
			try{
				return Long.parseLong(data);
				
			} catch(NumberFormatException ex)
			{
				System.out.println("Debe ser un numero, gañán");
			}
		}
	}
	
	private static BigDecimal scanBigDecimal(String label)
	{
		while(true)
		{
			System.out.println(label);
			String data=tcl.nextLine().trim();
			DecimalFormat decimalFormat=(DecimalFormat)DecimalFormat.getInstance();
			decimalFormat.setParseBigDecimal(true);
			try {
				return (BigDecimal)decimalFormat.parse(data);
			} catch (java.text.ParseException e) {
				System.out.println("Debe ser un numero decimal");
			}		
		}
		
	}
	
	private static Articulo scanArticulo()
	{
		Articulo articulo=new Articulo();
		articulo.nombre=scanString(		"	nombre: ");
		articulo.categoria=scanLong(		"	categoria: ");
		articulo.precio=scanBigDecimal(		"	precio: ");
		return articulo;
	}
	private static void showArticulo(Articulo articulo)
	{
		System.out.println("		id: "+articulo.id);
		System.out.println("		nombre: "+articulo.nombre);
		System.out.println("		categoria: "+articulo.categoria);
		System.out.println("		precio: "+articulo.precio);
	}
	
	private static PreparedStatement insertPreparedStatement;
	private final static String insertSql ="insert into articulo (nombre, categoria, precio) "
			+"values(?,?,?)";
	private static void nuevo() throws SQLException
	{
		Articulo articulo=scanArticulo();
		try{
			if(insertPreparedStatement == null)
				insertPreparedStatement=connection.prepareStatement(insertSql);

			insertPreparedStatement.setString(1, articulo.nombre);
			insertPreparedStatement.setLong(2, articulo.categoria);
			insertPreparedStatement.setBigDecimal(3, articulo.precio);
			insertPreparedStatement.executeUpdate();
			System.out.println("");
			System.out.println("Articulo guardado");
		} catch (SQLException ex)
		{
			System.out.println(ex);
		}
		showArticulo(articulo);
	}
	
	private static void closePrepareStatement() throws SQLException
	{
		if(insertPreparedStatement != null)
			insertPreparedStatement.close();
	}
	
	public static void main(String args[]) throws SQLException
	{
		connection=DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba", "root", "sistemas");;
		while(true)
		{
			Action action=menu();
			if(action==Action.Salir) break;
			if(action==Action.Nuevo) nuevo();
		}
		System.out.println("");
		System.out.println("fin");
		
		closePrepareStatement();
		connection.close();
	}
}
