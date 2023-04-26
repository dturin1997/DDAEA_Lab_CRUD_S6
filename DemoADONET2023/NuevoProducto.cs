using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoADONET2023
{
    public partial class NuevoProducto : Form
    {
        public NuevoProducto()
        {
            InitializeComponent();
        }

        private void Grabar_Click(object sender, EventArgs e)
        {

            try
            {
                BProducto negocio = new BProducto();
                negocio.Insertar(new Entidad.Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = int.Parse(txtPrecio.Text),
                });
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }
            

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            BProducto negocio = new BProducto();
            dataGridView1.DataSource = negocio.Listar(txtNombre.Text);
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            txtFechaCreacion.Text = dataGridView1.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            txtActivo.Text = dataGridView1.CurrentRow.Cells["Activo"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Actualizar(new Entidad.Producto
                {
                    Id=int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Precio = int.Parse(txtPrecio.Text),
                    FechaCreacion = DateTime.Parse(txtFechaCreacion.Text),
                    Activo = Boolean.Parse(txtActivo.Text),
                });
                MessageBox.Show("Actualizacion exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Eliminar(new Entidad.Producto
                {
                    Id = int.Parse(txtId.Text),
                    Activo = Boolean.Parse(txtActivo.Text),
                });
                MessageBox.Show("Eliminación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }
        }
    }
}
