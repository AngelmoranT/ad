using System;
using System.Data;
namespace CCategoria
{
    public partial class CategoriaView : Gtk.Window
    {
        public CategoriaView() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            saveAction.Activated += delegate{
                string nombre = entryNombre.Text;
                IDbCommand dbComand = App.Instance.Connection.CreateCommand();
                dbComand.CommandText = "insert into categoria (noombre) values (@nombre)";
                IDataParameter dbDataParameter = dbComand.CreateParameter();
                dbDataParameter.ParameterName = "nombre";
                //TODO dbDataParameter.Value = coger lo del usuario
                dbDataParameter.Value = nombre;
                dbComand.Parameters.Add(dbDataParameter);
                dbComand.ExecuteNonQuery();

            };
        }
    }
}
