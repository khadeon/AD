import java.util.Scanner;
public class menu {
	public static void main(String args[])
	{
		Scanner tcl=new Scanner(System.in);
		int eleccion=0;
		boolean bucle=false;
		while(bucle!=true)
		{
			System.out.println("Elige una opcion");
			System.out.println("0 Salir");
			System.out.println("1 Leer");
			System.out.println("2 Nuevo");
			System.out.println("3 Editar");
			System.out.println("4 Eliminar");
			System.out.println("5 Listar todos");
			eleccion=tcl.nextInt();
			if(eleccion<0 || eleccion>5)
				System.out.println("Error");
			else
				bucle=true;
		}
	}
}
