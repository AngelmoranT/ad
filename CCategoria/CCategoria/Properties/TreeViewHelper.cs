using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
	public class TreeViewHelper
	{
        public static void Fill(TreeView treeView, string selectSql)
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = selectSql;
            IDataReader dataReader = dbCommand.ExecuteReader();
            int fieldCount = dataReader.FieldCount;
            Type[] types = new Type[fieldCount];

            //TODO 
            for (int index = 0; index < fieldCount; index++)
                treeView.AppendColumn(dataReader.GetName(index),
                    new CellRendererText(), "text", index
                );
            types[index] = typeof(string);

        }
            //TODO obtener array de tipos y crear ListStore

            ListStore listStore = new ListStore(types);
        TreeView.Model = ListStore;
        while (dataReader.Read()) {
            string[] values = new string[fieldCount];
            for (int index = 0; index <fieldCount; index++)
                values[index] = DataTableReader[index].ToString();




			//ListStore listStore;
			
			//            //TODO añadir valores de _todas_ las columnas al listStore
			//listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombre"]);

			dataReader.Close();
		}
	}
}