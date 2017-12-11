using System;
namespace CArticulo
{
    public partial class ArticuloWindow : Gtk.Window
    {
        public ArticuloWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            entryNombre.Text = Articulo.Nombre;
            spinButtoPrecio.Value = Convert.ToDouble(Articulo.Precio);
            entryCategoria.Text = Articulo.Categoria.ToString();


            saveAction.Activated += delegate{
                
            }
        }
    }
}
