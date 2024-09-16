using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MANEJADORES
{
    public class manejadorproducto
    {
        funciones f = new funciones();
        public void Guardar(TextBox nombre, TextBox descripcion, TextBox precio)
        {

            MessageBox.Show(f.guardar($"Insert into producto values(null,'{nombre.Text}','{descripcion.Text}',{precio.Text})"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(int idproducto, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar{dato}",
                "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.borrar($"delete from producto where idproducto = {idproducto}");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void Modificar(TextBox Nombre, TextBox descripcion, TextBox precio  , int idproducto)
        {
            MessageBox.Show(f.modificar($"update producto set nombre = '{Nombre.Text}',descripcion ='{descripcion.Text}',precio = {precio.Text} where idproducto = {idproducto}"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;

        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.mostrar($"select * from producto where nombre like '%{filtro}%'",
                "TIENDA").Tables[0];
            tabla.Columns.Insert(4, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();


        }
    }
}
