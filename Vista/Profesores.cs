using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Profesores : Form
    {
        private ILogic _logic;
        private string accionActual;
        private bool accion;
        private bool verPago;
       

        public Profesores(ILogic logic)
        {
            InitializeComponent();
            _logic = logic;

            cambiarEstado();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (accionActual)
            {
                case "crearProfesor":                   
                    if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
                        !string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                        !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                        !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                        !string.IsNullOrWhiteSpace(txtDocumento.Text))
                    {
                        accion = _logic.CrearProfesor(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtDocumento.Text);
                        
                    }
                    else
                    {
                        MessageBox.Show("Datos faltantes para realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    operacionbool();
                    break;



               

                case "modificarProfesor":
                    // Lógica para la acción de modificación
                    if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
                        !string.IsNullOrWhiteSpace(cbIdProfesor.SelectedItem?.ToString()) &&
                        !string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                        !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                        !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                        !string.IsNullOrWhiteSpace(txtDocumento.Text))
                    {
                        accion = _logic.ActualizarProfesor(txtNombre.Text, cbIdProfesor.SelectedItem.ToString(), txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtDocumento.Text);
                        operacionbool();
                    }
                    else
                    {
                        MessageBox.Show("Datos faltantes para realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }               
                   break;



                case "alumnoCrear":
                    if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
                        !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                        !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                        cbIdProfesor.SelectedItem != null &&
                        !string.IsNullOrWhiteSpace(cbIdProfesor.SelectedItem.ToString()))
                    {
                        accion = _logic.CreateAlumno(txtNombre.Text, txtEmail.Text, txtTelefono.Text, cbIdProfesor.SelectedItem.ToString());
                        operacionbool();
                        
                    }
                    else
                    {
                        MessageBox.Show("Datos faltantes para realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;




                case "alumnoUpdate":
                    if (cbIdProfesor.SelectedItem != null &&
                        !string.IsNullOrWhiteSpace(cbIdProfesor.SelectedItem.ToString()) &&
                        !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                        !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                        !string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        accion = _logic.UpdateAlumno(cbIdProfesor.SelectedItem.ToString(), txtNombre.Text, txtEmail.Text, txtTelefono.Text);
                        operacionbool();
                    }
                    else
                    {
                        MessageBox.Show("Datos faltantes para realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    break;


                case "alumnoDelete":
                    if (cbIdProfesor.SelectedItem != null && !string.IsNullOrWhiteSpace(cbIdProfesor.SelectedItem.ToString()) &&
                        !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                        !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                        !string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        accion = _logic.DeleteAlumno(cbIdProfesor.SelectedItem.ToString());
                        operacionbool();
                    }
                    else
                    {
                        MessageBox.Show("Datos faltantes para realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    break;


                



                case "crearPago":
                    if (cbIdProfesor.SelectedItem != null && !string.IsNullOrWhiteSpace(cbIdProfesor.SelectedItem.ToString()) &&
                          !string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        accion = _logic.CrearPago(cbIdProfesor.SelectedItem.ToString(), txtNombre.Text);
                        operacionbool();
                    }
                    else
                    {
                        MessageBox.Show("Datos faltantes para realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    break;


                case "verPago": break;
                case "verProfesor": break;
                case "verAlumno": break;
                default:
                    // Manejo de otros casos
                    MessageBox.Show("Acción no reconocida.");
                    break;
            }
            cambiarEstado();
        }

        private void profesorcrear_Click(object sender, EventArgs e)
        {
            cambiarEstado();
            
            txtNombre.Enabled = true;
            txtNombre.Visible = true;

            txtEmail.Enabled = true;
            txtEmail.Visible = true;

            txtDocumento.Enabled = true;
            txtDocumento.Visible = true;

            txtTelefono.Enabled = true;
            txtTelefono.Visible = true;

            txtDireccion.Enabled = true;
            txtDireccion.Visible = true;

           
            //metodo crearprofesor
            accionActual = "crearProfesor";
            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;

            btnCancelar.Enabled = true;
            btnCancelar.Visible = true;



        }

        private void alumnocrear_Click(object sender, EventArgs e)
        {
            cambiarEstado();
            accionActual = "alumnoCrear";

            txtNombre.Enabled = true;
            txtNombre.Visible = true;

            txtEmail.Enabled = true;
            txtEmail.Visible = true;

            txtTelefono.Enabled = true;
            txtTelefono.Visible = true;

            
            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;

            btnAceptar.Enabled=true;
            btnAceptar.Visible=true;
            btnCancelar.Visible=true;
            btnCancelar.Enabled=true;
           
            var profesores = _logic.ObtenerProfesores();

            foreach (var profesor in profesores)
            {
                cbIdProfesor.Items.Add(profesor.ToString());
            }
            //metodo crearalumno
        }

        private void profesormodificar_Click(object sender, EventArgs e)
        {
            //segun lo que elijo aqui
            cambiarEstado();
            
            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;
            var profesores = _logic.ObtenerProfesores();

            foreach(var profesor in profesores)
            {
                cbIdProfesor.Items.Add(profesor.ToString());
            }
            accionActual = "modificarProfesor";
            txtNombre.Enabled = true;
            txtNombre.Visible = true;

            txtEmail.Enabled = true;
            txtEmail.Visible = true;

            txtDocumento.Enabled = true;
            txtDocumento.Visible = true;

            txtTelefono.Enabled = true;
            txtTelefono.Visible = true;

            txtDireccion.Enabled = true;
            txtDireccion.Visible = true;

            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;

            btnCancelar.Enabled = true;
            btnCancelar.Visible = true;



        }

        private void profesoreliminar_Click(object sender, EventArgs e)
        {
            cambiarEstado();
            accionActual = "EliminarProfesor";
            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;
            var profesores = _logic.ObtenerProfesores();


            foreach (var profesor in profesores)
            {
                cbIdProfesor.Items.Add(profesor.ToString());
            }
            btnAceptar.Enabled=true;
            btnCancelar.Enabled=true;
            btnAceptar.Visible=true;
            btnCancelar.Visible=true;

        }
       

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void cambiarEstado()
        {
            verPago = false;
            
            txtNombre.Enabled = false;
            txtNombre.Visible = false;

            txtEmail.Enabled = false;
            txtEmail.Visible = false;

            txtDocumento.Enabled = false;
            txtDocumento.Visible = false;

            txtTelefono.Enabled = false;
            txtTelefono.Visible = false;

            txtDireccion.Enabled = false;
            txtDireccion.Visible = false;

            cbIdProfesor.Enabled = false;
            cbIdProfesor.Visible = false;

            btnCancelar.Enabled = false;
            btnCancelar.Visible = false;

            btnAceptar.Enabled = false;
            btnAceptar.Visible = false;
            
            dataGridView1.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            lblsumapago.Enabled = false;
            lblsumapago.Visible = false;

            txtDireccion.Clear();
            txtTelefono.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtNombre.Clear();

            cbIdProfesor.SelectedIndex = -1;
            cbIdProfesor.Items.Clear();
            cbIdProfesor.Location = new Point(223, 222);


        }
        private void operacionbool()
        {
            if (accion)
            {
                MessageBox.Show("Operación Exitosa");
            }
            else
            {
                MessageBox.Show("No se pudo realizar la Operación");
            }
        }

        private void profesorver_Click(object sender, EventArgs e)
        {
            accionActual = "verProfesor";
            cambiarEstado();
            dataGridView1.Enabled = true;
            dataGridView1.Visible=true;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

                // Lógica para la acción de modificación
                List<string> datosProfesores = _logic.LeerNombresProfesores();
            string[] encabezados = { "ID", "Nombre", "Dirección", "Teléfono", "Email", "Documento" };

            // Agrega las columnas personalizadas al DataGridView
            foreach (string encabezado in encabezados)
            {
                dataGridView1.Columns.Add(encabezado, encabezado);
            }

            // Agrega las filas con datos de profesores
            for (int i = 1; i < datosProfesores.Count; i++)
            {
                string[] valores = datosProfesores[i].Split('\t');
                dataGridView1.Rows.Add(valores);
            }



        }

        private void alumnoeliminar_Click(object sender, EventArgs e)
        {
            // este es el metodo update alumno por cuestiones de tiempo no se corrige
            accionActual = "alumnoUpdate";
            cambiarEstado();

            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;

            var alumnos = _logic.LeerNombresAlumnos();
            foreach(var alumno in  alumnos)
            {
                cbIdProfesor.Items.Add(alumno);
            }

            txtNombre.Enabled = true;
            txtNombre.Visible = true;

            txtEmail.Enabled = true;
            txtEmail.Visible = true;

            txtTelefono.Enabled = true;
            txtTelefono.Visible = true;


          

            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            btnCancelar.Enabled = true;
        }

        private void alumnomodificar_Click(object sender, EventArgs e)
        {
            // este es el metodo eliminar alumno por cuestiones de tiempo no se corrige
            accionActual = "alumnoDelete";
            cambiarEstado();
            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;

            var alumnos = _logic.LeerNombresAlumnos();
            foreach (var alumno in alumnos)
            {
                cbIdProfesor.Items.Add(alumno);
            }
            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            btnCancelar.Enabled = true;
        }

        private void alumnover_Click(object sender, EventArgs e)
        {
            cambiarEstado();
            accionActual = "VerAlumnos";
            dataGridView1.Enabled= true;
            dataGridView1.Visible= true;



            // Separa los datos de la lista y agrega las columnas al DataGridView
            List<string> datosAlumnos = _logic.LeerDatosAlumnos();

            // Separa los datos de la lista y agrega las columnas al DataGridView
            string[] encabezados = { "ID", "Nombre", "Email", "Teléfono", "ID Profesor" };

            // Agrega las columnas personalizadas al DataGridView
            foreach (string encabezado in encabezados)
            {
                dataGridView1.Columns.Add(encabezado, encabezado);
            }

            // Agrega las filas con datos de alumnos
            for (int i = 1; i < datosAlumnos.Count; i++)
            {
                string[] valores = datosAlumnos[i].Split('\t');
                dataGridView1.Rows.Add(valores);
            }
        }

        private void profesorpagoscrear_Click(object sender, EventArgs e)
        {
            cambiarEstado();
            accionActual = "crearPago";
            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;

            var profesores = _logic.ObtenerProfesores();


            foreach (var profesor in profesores)
            {
                cbIdProfesor.Items.Add(profesor.ToString());
            }

            txtNombre.Enabled = true;
            txtNombre.Visible = true;

            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;

            btnCancelar.Visible = true;
            btnCancelar.Enabled = true;



        }

        private void profesorpagosver_Click(object sender, EventArgs e)
        {
            accionActual = "verPagos";
            cambiarEstado();
            verPago = true;
            cbIdProfesor.Enabled= true;
            cbIdProfesor .Visible= true;
            cbIdProfesor.Location = new Point(22, 39);


            var profesores = _logic.ObtenerProfesores();
            foreach (var profesor in profesores)
            {
                cbIdProfesor.Items.Add(profesor.ToString());
            }


            
        }

        private void cbIdProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (verPago)
            {
                lblsumapago.Enabled = true;
                lblsumapago.Visible = true;
                dataGridView1.Enabled = true;
                dataGridView1 .Visible = true;
               
                List<string> datosPagos = _logic.VerPagosProfesor(cbIdProfesor.SelectedItem.ToString());
     
                // Separa los datos de la lista y agrega las columnas al DataGridView
                string[] encabezados = { "idPago", "Fecha", "Cantidad", "idProfesor" };

                // Agrega las columnas personalizadas al DataGridView
                foreach (string encabezado in encabezados)
                {
                    dataGridView1.Columns.Add(encabezado, encabezado);
                }

                // Agrega las filas con datos de alumnos
                for (int i = 0; i < datosPagos.Count; i++)
                {
                    string[] valores = datosPagos[i].Split('\t');
                    dataGridView1.Rows.Add(valores);
                }

                int columnIndexCantidad = 2;
                double suma = 0.0;
                lblsumapago.Text = "Total Abonado: ";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[columnIndexCantidad].Value != null)
                    {
                        double valorCelda;
                        if (double.TryParse(dataGridView1.Rows[i].Cells[columnIndexCantidad].Value.ToString(), out valorCelda))
                        {
                            suma += valorCelda;
                        }
                    }
                }
                lblsumapago.Text += suma;
            }

        }

        private void eliminarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cambiarEstado();
            cbIdProfesor.Enabled = true;
            cbIdProfesor.Visible = true;
            accionActual = "EliminarReservaProfesor";
            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;
            var profesores = _logic.ObtenerProfesores();

            foreach (var profesor in profesores)
            {
                cbIdProfesor.Items.Add(profesor.ToString());
            }
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
