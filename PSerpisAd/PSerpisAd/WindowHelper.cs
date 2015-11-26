using System;
using Gtk;
namespace SerpisAd
{
	public class WindowHelper
	{
		public static bool confirmDelete(Window window)
		{
			//TODO localizacion del ¿Quieres eliminar...
			MessageDialog mensajeDialogo = new MessageDialog(
				window,
				DialogFlags.DestroyWithParent,
				MessageType.Question,
				ButtonsType.YesNo,
				"¿Quieres eliminar el elemento seleccionado?"
				);
			mensajeDialogo.Title = window.Title;
			ResponseType response = (ResponseType)mensajeDialogo.Run ();
			mensajeDialogo.Destroy ();
			return response == ResponseType.Yes;
		}
	}
}

