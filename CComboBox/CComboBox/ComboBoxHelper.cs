using Gtk;
using System;
namespace CComboBox
{
    public class ComboBoxHelper
    {
        public ComboBoxHelper()
        {
            public const string ComboNullLabel = "<sin asignar>";
            public static void Fill(ComboBox comboBox, string selectSql, object id){
            CellRendererText cellRendererText = new CellRendererText();
                comboBox.PackStart(cellRendererText, false);
                comboBox.AddAttribute(cellRendererText, "text", 1);


            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = selectSql;
            IDataReader dataReader = dbCommand.ExecuteReader();



            ListStore listStore = new ListStore(typeof(string), typeof(string));
            TreeIter initialTreeIter = ListStore.AppendValues("0", NullLabel);
                while (dataReader.Read()) {
                    TreeIter treeIter = listStore.AppendValues(dataReader[0].ToString)
                }
            }
        }
    }



    //private static void init(ComboBox comboBox) {
        
    }
}
