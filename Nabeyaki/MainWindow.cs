using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public static string consumerKey = 
		"5M7LWCFsAE4FAcDtwI6pKUwEa";
	public static string consumerKeySecret = 
		"cyhQUTuJy1YuyONzGNEC6pEjkqEBqxdRaN469fmuPM7e5OX3mm";

	public static CoreTweet.Tokens tokens;

	public static string nabeyakiDir = System.IO.Path.Combine(
		System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
		".nabeyaki"
	);

	public static string tokenFile = ".token";

	public static Gtk.ListStore statusListStore = 
		new Gtk.ListStore (typeof (string), typeof (string));

	public static long lastRead = 0;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		TreeViewColumn idColumn = new Gtk.TreeViewColumn ();
		idColumn.Title = "ID";
		Gtk.CellRendererText idNameCell = new Gtk.CellRendererText ();
		idColumn.PackStart (idNameCell, true);
		treeviewMain.AppendColumn (idColumn);

		TreeViewColumn bodyColumn = new Gtk.TreeViewColumn ();
		bodyColumn.Title = "Body";
		Gtk.CellRendererText bodyNameCell = new Gtk.CellRendererText ();
		bodyColumn.PackStart (bodyNameCell, true);
		treeviewMain.AppendColumn (bodyColumn);

		idColumn.AddAttribute (idNameCell, "text", 0);
		bodyColumn.AddAttribute (bodyNameCell, "text", 1);
		treeviewMain.Model = statusListStore;

		if (File.Exists (System.IO.Path.Combine (nabeyakiDir, tokenFile))) {
			LoadToken ();
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnClickLogin (object sender, EventArgs e)
	{
		CoreTweet.OAuth.OAuthSession session = CoreTweet.OAuth.Authorize(
			consumerKey,
			consumerKeySecret
		);
		System.Diagnostics.Process.Start(session.AuthorizeUri.AbsoluteUri);

		Dialog dialog = new Nabeyaki.AuthDialog();

		if (dialog.Run() == (int)ResponseType.Ok) 
		{
			string pinCode = Nabeyaki.AuthDialog.pinCode;
			dialog.Destroy();
			tokens = session.GetTokens (pinCode);
			statusbarMain.Push(statusbarMain.GetContextId("") , 
				"Login : @" + tokens.Account.UpdateProfile().ScreenName) ;
			Task.Run( () => {
				SaveToken();
			} );
		}
		else 
		{
			dialog.Destroy();
		}
	}

	protected void OnClickPost (object sender, EventArgs e)
	{	
		Task.Run (() => {
			string body = entryPost.Text;
			tokens.Statuses.Update (status => body);
		});
	}

	protected void OnClickRefresh (object sender, EventArgs e)
	{
		int readNew = 0;
		int maxRead = 10;
		var statuses = 
			tokens.Statuses.HomeTimeline (count => maxRead);

		foreach (CoreTweet.Status status in statuses) {
			if (lastRead == status.Id) {
				break;
			}
			readNew++;
		}
		statusbarMain.Push (statusbarMain.GetContextId (""), 
			"get" + readNew.ToString() + " new statuses.");
		
		int readingCount = 0;
		int skipNumber = maxRead - readNew;
		Console.WriteLine (skipNumber.ToString());
		foreach (CoreTweet.Status status in statuses.Reverse()) {
			readingCount++;
			if(readingCount <= skipNumber){
				continue;
			}
			statusListStore.SetValues (
				statusListStore.Prepend(),
				"@" + status.User.ScreenName, status.Text 
			);
			lastRead = status.Id;
		}
		treeviewMain.Model = statusListStore;
	}

	protected void SaveToken()
	{
		if (!File.Exists (System.IO.Path.Combine (nabeyakiDir))) {
			System.IO.Directory.CreateDirectory (nabeyakiDir);
		}
		StreamWriter sw = new StreamWriter(
			System.IO.Path.Combine (nabeyakiDir, tokenFile),
			false,
			Encoding.ASCII
		);
		Console.WriteLine (tokens.AccessToken + "," + tokens.AccessTokenSecret);
		sw.Write(tokens.AccessToken+ "," + tokens.AccessTokenSecret);
		sw.Close();
	}

	protected void LoadToken()
	{
		StreamReader sr = new StreamReader (
			System.IO.Path.Combine (nabeyakiDir, tokenFile),
			System.Text.Encoding.ASCII
		);
		string[] readArray = sr.ReadToEnd ().Split(',');
		sr.Close ();
		tokens = CoreTweet.Tokens.Create(
			consumerKey, consumerKeySecret, 
			readArray[0], readArray[1]);
		statusbarMain.Push(statusbarMain.GetContextId("") , 
			"Login : @" + tokens.Account.UpdateProfile().ScreenName) ;
	}
}










