using System;
using Gtk;
using System.Collections;
using SerpisAD;
using System.Data;


namespace PArticulo
{
	public delegate void SaveDelegate(Articulo a);
	public partial class ArticuloView : Gtk.Window
	{
		public Articulo articulo;
		public static SaveDelegate save;

		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			articulo = new Articulo ();
			init ();
			save=ArticuloPersister.Insert;
		}

		public ArticuloView(object id) : base(WindowType.Toplevel)
		{
			articulo=ArticuloPersister.Load(id);
			init();
			save=ArticuloPersister.Update;
		}

		public void init()
		{
			this.Build ();
			articulo.Nombre=entry1.Text;
			QueryResult queryresult = PersisterHelper.Get ("select * from categoria");
			ComboBoxHelper.Fill (combobox1, queryresult, articulo.Categoria);
			spinbutton1.Value=Convert.ToDouble(articulo.Precio);
			//saveAction.Activated += delegate { save(articulo); };

			saveAction.Activated += delegate{
				articulo.Nombre=entry1.Text;
				articulo.Categoria=ComboBoxHelper.GetId(combobox1);
			articulo.Precio=Convert.ToDecimal(spinbutton1.ValueAsInt);
				save(articulo);
			};
		}


	}
}

