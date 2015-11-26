using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using SerpisAD;
using System.Collections;
using PArticulo;
using SerpisAd;

public partial class MainWindow: Gtk.Window
{	

	public IDbConnection conexion()
	{
		IDbConnection dbConnection = App.Instance.DbConnection;

		return dbConnection;
	}
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Title = "Artículo";
		Console.WriteLine ("MainWindow ctor.");
		fill ();

		refreshAction.Activated += delegate{
			fill();
		};

		deleteAction.Activated += delegate{
			object id=TreeViewHelper.GetId(TreeView);
			Console.WriteLine("Click en deleteAction id={0}", id);
			delete(id);

		};

		editAction.Activated += delegate {
			object id=TreeViewHelper.GetId(TreeView);
			Console.WriteLine("Edicion de la tabla seleccionada");
			new ArticuloView(id);
		};

		TreeView.Selection.Changed += delegate {
			Console.WriteLine("ha ocurrido treeView.Selection.Changed");
			deleteAction.Sensitive=TreeViewHelper.GetId(TreeView)!=null;
		};
		deleteAction.Sensitive = false;
	}

	private void delete(object id){
		if (!WindowHelper.confirmDelete (this)) 
			return;
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		dbCommand.CommandText = "delete from articulo where id = @id";
		DbCommandHelper.AddParameter (dbCommand, "id", id);
		dbCommand.ExecuteNonQuery ();

	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		new ArticuloView ();
	}
	

	protected void fill()
	{
		QueryResult queryResult = PersisterHelper.Get("select * from articulo");
		TreeViewHelper.Fill (TreeView, queryResult);
	}

	
}
