using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private bool isNuevo = false;
        private bool isEditar = false;

        private void mensajeOkay (string mensaje)
        {
            MessageBox.Show(mensaje, "Titulo del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Titulo del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar ()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;    
            txtEmail.Text = string.Empty;   
        }

        private void Habilitar (bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtNombre.Focus ();

            txtApellido.ReadOnly = !valor;
            txtApellido.Focus();

            txtEmail.ReadOnly = !valor;
            txtEmail.Focus();
        }

        private void Botones ()
        {
            if (isNuevo || isEditar)
            {
                Habilitar (true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true; 
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Mostrar ();
            Limpiar ();
            Botones ();
        }
        private void Mostrar ()
        {
            dgvClientes.DataSource = CN_Clientes.Mostrar ();
            dgvClientes.Columns[0].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            isNuevo = true;
            Limpiar ();
            Botones ();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            isNuevo = false;    
            isEditar = false;   
            Limpiar ();
            Botones ();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty)
                {
                    mensajeError("Falta ingresar datos.");

                    if (txtNombre.Text == string.Empty)
                    {
                        txtNombre.Focus();
                    }
                    else if (txtApellido.Text == string.Empty)
                    {
                        txtApellido.Focus();
                    }
                }
                else
                {
                    if (isNuevo)
                    {
                        query = CN_Clientes.Insertar(txtNombre.Text, txtApellido.Text, txtEmail.Text);
                    }
                    else
                    {
                        query = CN_Clientes.Editar(int.Parse(txtID.Text), txtNombre.Text, txtApellido.Text, txtEmail.Text);
                    }
                    if (query.Equals ("Okay."))
                    {
                        if (isNuevo)
                        {
                            mensajeOkay ("Se inserto.");
                        }
                        else
                        {
                            mensajeOkay("Se actualizo.");
                        }
                    }
                    else
                    {
                        mensajeError (query);   
                    }

                    isNuevo = false;    
                    isEditar = false; 
                    
                    Mostrar ();
                    Limpiar ();
                    Botones ();
                }
            }
            catch (Exception ex)
            {
                mensajeError (ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == string.Empty)
                {
                    mensajeError("Falta ingresar algunos datos.");
                }
                else
                {
                    isEditar = true;
                    isNuevo = false;
                    Botones ();
                    Habilitar (true);
                }
            }
            catch (Exception ex)
            {
                mensajeError (ex.Message);
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dgvClientes.CurrentRow.Cells [1].Value.ToString ();
                txtNombre.Text = dgvClientes.CurrentRow.Cells [2].Value.ToString ();
                txtApellido.Text = dgvClientes.CurrentRow.Cells [3].Value.ToString ();
                txtEmail.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                mensajeError (ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
