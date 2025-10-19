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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private bool isNuevo = false;
        private bool isEditar = false;

        private void mensajeOkay (string mensaje)
        {
            MessageBox.Show(mensaje, "Titulo del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Titulo del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar ()
        {
            txtID.Text = string .Empty; 
            txtNombre.Text = string .Empty;
        }

        private void Habilitar (bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtNombre.Focus ();
        }

        private void  Botones ()
        {
            if (isNuevo || isEditar)
            {
                Habilitar(true);    
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnEliminar.Enabled = true;
                btnEditar.Enabled = true;
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            Mostrar ();
            Limpiar ();
            Botones (); 
        }

        private void Mostrar ()
        {
            dgvCategorias.DataSource = CN_Categorias.Mostrar ();
            dgvCategorias.Columns[0].Visible = false;
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

                if (txtNombre.Text == string.Empty)
                {
                    mensajeError ("Falta ingresar datos");
                    txtNombre.Focus ();
                }
                else
                {
                    if (isNuevo)
                    {
                        query = CN_Categorias.Insertar (txtNombre.Text);
                    }
                    else
                    {
                        // editar
                    }
                    if (query.Equals ("Okay"))
                    {
                        if (isNuevo)
                        {
                            mensajeOkay("Se inserto");
                        }
                        else
                        {
                            mensajeOkay("Se actualizo");
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
                mensajeError(ex.Message + ex.StackTrace);
            }
        }
    }
}
