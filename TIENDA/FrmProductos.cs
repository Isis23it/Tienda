using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MANEJADORES;

namespace TIENDA
{
    public partial class FrmProductos : Form
    {
        manejadorproducto mp;
        public FrmProductos()
        {
            InitializeComponent();
            mp = new manejadorproducto();
            if (Form1.idproducto > 0)
            {
                txtnombre.Text =Form1.nombre;
                txtdescripcion.Text =Form1.descripcion;
                txtprecio.Text = Form1.precio.ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.idproducto > 0)
            {
                mp.Modificar(txtnombre, txtdescripcion,  txtprecio, Form1.idproducto);
            }
            else
            {
                mp.Guardar(txtnombre, txtdescripcion, txtprecio);
            }
            Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
