using System;
namespace CCategoria.Properties
{
    public class CategoriaDao
    {

        public static Categoria Load(object id){
            
            Categoria categoria = new Categoria();
            categoria.Id = Convert.ToInt64(id);
            categoria.Nombre = "El que la lea de la base de datos";
            return categoria;

        }
        //public static CCategoria Load(object id){
			//IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
			//dbCommand.CommandText = "select * from categoria where id = @id";
			//DbCommandHelper.AddParameter(dbCommand, "id", id);
			//IDataReader dataReader = dbCommand.ExecuteReader();
			//dataReader.Read(); //TODO tratamiento de excepciones
			//string nombre = (string)dataReader["nombre"];
            //Categoria categoria = new Categoria();
            //dataReader.Close();

            //return categoria;

		//}

        //public static void Save(Categoria categoria){
            //if (categoria.Id == 0)
               // ; //insert
            //else; //update
        //}

        //public static void Delete(object id){
            
        //}
    //}
}
