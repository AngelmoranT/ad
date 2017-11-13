using Gtk;
using System;
using System.Data;
using MySql.Data.MySqlClient;


using Serpis.Ad;


public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
		App.Instance.Connection = new MySqlConnection(connectionString);
		App.Instance.Connection.Open();

        TreeViewHelper.Fill(TreeView,
            "select a.id, a.nombre, a.precio c.nombre as categoria" +
            "from articulo a left join categoria c on (a.categoria = c.id)" +
            " order by a.id");


    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {

        App.Instance.Connection.CLose();
        Application.Quit();
        a.RetVal = true;
    }
}
