
// This file has been generated by the GUI designer. Do not modify.
namespace Nabeyaki
{
	public partial class AuthDialog
	{
		private global::Gtk.TextView textview1;
		
		private global::Gtk.Entry entryPin;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Nabeyaki.AuthDialog
			this.Name = "Nabeyaki.AuthDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("enter PIN code");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child Nabeyaki.AuthDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.textview1 = new global::Gtk.TextView ();
			this.textview1.Buffer.Text = "Please enter PIN code.";
			this.textview1.CanFocus = true;
			this.textview1.Name = "textview1";
			this.textview1.Editable = false;
			this.textview1.CursorVisible = false;
			this.textview1.Justification = ((global::Gtk.Justification)(2));
			w1.Add (this.textview1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(w1 [this.textview1]));
			w2.Position = 0;
			w2.Padding = ((uint)(10));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.entryPin = new global::Gtk.Entry ();
			this.entryPin.CanFocus = true;
			this.entryPin.Name = "entryPin";
			this.entryPin.IsEditable = true;
			this.entryPin.InvisibleChar = '•';
			w1.Add (this.entryPin);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(w1 [this.entryPin]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(10));
			// Internal child Nabeyaki.AuthDialog.ActionArea
			global::Gtk.HButtonBox w4 = this.ActionArea;
			w4.Name = "dialog1_ActionArea";
			w4.Spacing = 10;
			w4.BorderWidth = ((uint)(5));
			w4.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w5 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w4 [this.buttonCancel]));
			w5.Expand = false;
			w5.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w6 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w4 [this.buttonOk]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 226;
			this.Show ();
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnClickButtonOk);
		}
	}
}
