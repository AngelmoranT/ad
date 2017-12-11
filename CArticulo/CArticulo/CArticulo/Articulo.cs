using System;
namespace CArticulo
{
    public class Articulo
    {
        private long id;
        private string nombre = "";
        private decimal precio;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public decimal Precio
        {
            get { return Precio; }
            set { Precio = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
    }

}
