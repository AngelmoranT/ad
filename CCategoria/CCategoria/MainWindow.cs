﻿using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;

using CCategoria;


public partial class MainWindow : Gtk.Window
{
    
    public MainWindow() : base(Gtk.WindowType.Toplevel)

    {
        Build();

        App.Instance.Connection = new MySqlConnection("server = localhost;database = dbprueba;user = root;password=sistemas");
	    App.Instance.Connection.Open();

        treeView.AppendColumn("id", new CellRendererText(), "text", 0);
        treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
        ListStore listStore = new ListStore(typeof(string));
        treeView.Model = listStore;

        IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
        dbCommand.CommandText = "select * from categoria order by id";
        IDataReader dataReader = dbCommand.ExecuteReader();
        while (dataReader.Read())

            listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombre"]);
            dataReader.Close();

        newAction.Activated += delegate {
            new CategoriaView();
        };

    } 

        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {

        App.Instance.Connection.Close();
            Application.Quit();
            a.RetVal = true;
        }
    }