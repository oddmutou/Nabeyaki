using System;

namespace Nabeyaki
{
	public partial class AuthDialog : Gtk.Dialog
	{
		public static string pinCode;

		public AuthDialog ()
		{
			this.Build ();
		}

		protected void OnClickButtonOk (object sender, EventArgs e)
		{
			pinCode = entryPin.Text;
		}
	}
}

