﻿using SistemasVentas.BSS;
using SistemasVentas.VISTA.DetalleIngVistas;
using SistemasVentas.VISTA.DetalleVentaVistas;
using SistemasVentas.VISTA.ProveeVistas;
using SistemasVentas.VISTA.UsuarioVistas;
using SistemasVentas.VISTA.VentaVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasVentas.VISTA.ProductoVistas
{
    public partial class ProductoListarVista : Form
    {
        public ProductoListarVista()
        {
            InitializeComponent();
        }
        ProductoBss bss = new ProductoBss();
        private void ProductoListarVista_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarProductosBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleIngInsertarVista.IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DetalleIngEditarVista.IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DetalleVentaInsertarVista.IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DetalleVentaEditarVista.IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ProveeInsertarVista.IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ProveeEditarVista.IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductoInsertarVista fr = new ProductoInsertarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = bss.ListarProductosBss();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ProductoEditarVista fr = new ProductoEditarVista(IdProductoSeleccionado);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = bss.ListarProductosBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int IdProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Estas Seguro de eliminar este producto?", "Eliminado", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarProductoBss(IdProductoSeleccionado);
                dataGridView1.DataSource = bss.ListarProductosBss();
            }
        }
    }
}
