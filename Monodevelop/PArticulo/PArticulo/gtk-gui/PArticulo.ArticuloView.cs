
// This file has been generated by the GUI designer. Do not modify.
namespace PArticulo
{
	public partial class ArticuloView
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action saveAction;
		private global::Gtk.VBox vbox1;
		private global::Gtk.Toolbar toolbar1;
		private global::Gtk.Table table1;
		private global::Gtk.Label categoria;
		private global::Gtk.ComboBox combobox1;
		private global::Gtk.Entry entry1;
		private global::Gtk.Label nombre;
		private global::Gtk.Label precio;
		private global::Gtk.SpinButton spinbutton1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PArticulo.ArticuloView
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.saveAction = new global::Gtk.Action ("saveAction", null, null, "gtk-save");
			w1.Add (this.saveAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "PArticulo.ArticuloView";
			this.Title = global::Mono.Unix.Catalog.GetString ("ArticuloView");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PArticulo.ArticuloView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='saveAction' action='saveAction'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox1.Add (this.toolbar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.categoria = new global::Gtk.Label ();
			this.categoria.Name = "categoria";
			this.categoria.LabelProp = global::Mono.Unix.Catalog.GetString ("Categoría");
			this.table1.Add (this.categoria);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.categoria]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.combobox1 = global::Gtk.ComboBox.NewText ();
			this.combobox1.Name = "combobox1";
			this.table1.Add (this.combobox1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.combobox1]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entry1 = new global::Gtk.Entry ();
			this.entry1.CanFocus = true;
			this.entry1.Name = "entry1";
			this.entry1.IsEditable = true;
			this.entry1.InvisibleChar = '•';
			this.table1.Add (this.entry1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.entry1]));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.nombre = new global::Gtk.Label ();
			this.nombre.Name = "nombre";
			this.nombre.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre");
			this.table1.Add (this.nombre);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.nombre]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.precio = new global::Gtk.Label ();
			this.precio.Name = "precio";
			this.precio.LabelProp = global::Mono.Unix.Catalog.GetString ("Precio");
			this.table1.Add (this.precio);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.precio]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.spinbutton1 = new global::Gtk.SpinButton (0, 100, 1);
			this.spinbutton1.CanFocus = true;
			this.spinbutton1.Name = "spinbutton1";
			this.spinbutton1.Adjustment.PageIncrement = 10;
			this.spinbutton1.ClimbRate = 1;
			this.spinbutton1.Digits = ((uint)(2));
			this.spinbutton1.Numeric = true;
			this.table1.Add (this.spinbutton1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.spinbutton1]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.table1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 511;
			this.DefaultHeight = 201;
			this.Show ();
		}
	}
}
