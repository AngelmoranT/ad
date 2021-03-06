﻿using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using CCategoria;
using Serpis.Ad;

public partial class MainWindow : Gtk.Window
{

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{

		Build();
		Title = "Categoria";
		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		//CONEXION CON LA BASE DE DATOS
		string connectionString = "server=localhost;database=dbprueba;user=root;password=sistemas";
		App.Instance.Connection = new MySqlConnection(connectionString);
		App.Instance.Connection.Open();

		//AÑADIMOS COLUMNAS AL TREEVIEW
		TreeViewHelper.Fill(treeView, "select * from categoria");
		//treeView.AppendColumn("id", new CellRendererText(), "text", 0);
		//treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
		//ListStore listStore = new ListStore(typeof(string), typeof(string));
		//treeView.Model = listStore;

        fillListStore((ListStore)treeView.Model);

		//PARA BLOQUEAR EL BOTÓN DELETE SINO ESTÁ SELECCIONADA NINGUNA FILA
		treeView.Selection.Changed += delegate {
			bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
			deleteAction.Sensitive = hasSelected;
			editAction.Sensitive = hasSelected;
		};

		//BOTÓN NUEVA
		newAction.Activated += delegate {
			Categoria categoria = new Categoria();
			new CategoriaWindow(categoria);
		};

		//BOTÓN EDIT
		editAction.Activated += delegate {
			object id = getId();
			Categoria categoria = CategoriaDao.Load(id);
			new CategoriaWindow(categoria);
		};

		//BOTÓN REFRESH 
		refreshAction.Activated += delegate {
			fillListStore(listStore);
		};

		//BOTÓN DELETE
		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
			{
				object id = getId();
				CategoriaDao.Delete(id);
			}
		};
	}

	private object getId()
	{
		TreeIter treeIter;
		treeView.Selection.GetSelected(out treeIter);
		return treeView.Model.GetValue(treeIter, 0);
	}

	private void fillListStore(ListStore listStore)
	{
		listStore.Clear();
		IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
		dbCommand.CommandText = "select * from categoria order by id";
		IDataReader dataReader = dbCommand.ExecuteReader();
		while (dataReader.Read())
			listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombre"]);
		dataReader.Close();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		App.Instance.Connection.Close();
		Application.Quit();
		a.RetVal = true;
	}
}