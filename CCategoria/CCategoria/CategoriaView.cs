using System;
using System.Data;

using CCategoria;

namespace CCategoria
{
	public partial class CategoriaWindow : Gtk.Window
	{
        object id;
        public CategoriaWindow(object id) : this(){
            this.id = id;
            IDbCommand dbCommand = AppDomain.Instance.Connection.CreateComand();
            dbCommand.CommandText = "select * froma categoria where id = @id";
            DbComandHelper.AddParameter(dbCommand, "id", id);
            IDataReader dataReader = dbCommand.ExecuteReader();
            dataReader.Read(); //TODO tratamiento de excepciones
            string nombre = (string)dataReader["nombre"];
            dataReader.Close();
            entryNombre.Text = nombre;
        }
		public CategoriaWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();

			saveAction.Activated += delegate {
				string nombre = entryNombre.Text;
				IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
				dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
				dbCommand.ExecuteNonQuery();
				Destroy();
			};
		}
	}
}