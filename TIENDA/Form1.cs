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
    public partial class Form1 : Form
    {
        manejadorproducto mp = new manejadorproducto();
        int fila = 0, columna = 0;
        public static int idproducto = 0;
        public static string nombre = "", descripcion = "";
        public static double precio = 0.0;

        private void btn1_Click(object sender, EventArgs e)
        {
            FrmProductos f = new FrmProductos();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         dataGridView1.Visible = true;
            mp.Mostrar(dataGridView1, textBox1.Text);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 4:
                    {
                        idproducto = int.Parse(dataGridView1.Rows[fila].Cells[0].Value.ToString());
                        mp.Borrar(idproducto, dataGridView1.Rows[fila].Cells[1].Value.ToString());
                      dataGridView1.Visible = false;
                    }
                    break;
                case 5:
                    {

                        idproducto = int.Parse(dataGridView1.Rows[fila].Cells[0].Value.ToString());
                        nombre = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                        descripcion = dataGridView1.Rows[fila].Cells[2].Value.ToString();

                        precio = double.Parse(dataGridView1.Rows[fila].Cells[3].Value.ToString());
                        FrmProductos de = new FrmProductos();
                        de.ShowDialog();
                        dataGridView1.Visible = false;
                    }
                    break;
            }
        }

     
    }
}
