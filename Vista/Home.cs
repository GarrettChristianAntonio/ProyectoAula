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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class Home : Form
    {
        private ILogic _logic;
        public Home(int AdminOEmpleado,ILogic logic)
        {
            InitializeComponent();
            _logic = logic;
            if(AdminOEmpleado == 2){button2.Enabled = false;} // se verifica si es admin o empleado para deshabilitar funcionabilidades
            var aulas = _logic.GetAulas();
            foreach(var aula in aulas)
            {
                cbAula.Items.Add(aula.Nombre);
            }

            var anios = _logic.GetAnio();
            foreach (var anio in anios)
            {
                cbAnio.Items.Add(anio);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Profesores(_logic).ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)//boton para actualizar la grilla
        {
            // Limpiar la DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (cbAula.SelectedItem!= null && cbAnio.SelectedItem != null && cbMes.SelectedItem != null) 
            {
                var horarios = _logic.GetHorarios();
                var dias = _logic.GetDiasConNombre(Convert.ToInt32(cbAnio.SelectedItem), Convert.ToInt32(cbMes.SelectedItem));
                var reservas = _logic.ObtenerReservaciones(cbAula.SelectedItem.ToString(), cbAnio.SelectedItem.ToString(), cbMes.SelectedItem.ToString());
                //MessageBox.Show(cbAula.SelectedItem.ToString() + " " + cbAnio.SelectedItem.ToString() + " " + cbMes.SelectedItem.ToString());

                // Agregar encabezados de columnas
                dataGridView1.Columns.Add("Horarios", "Horarios");
                foreach (string dia in dias)
                {
                    dataGridView1.Columns.Add(dia.ToLower(), dia.ToLower());
                }

                // Agregar filas para horarios
                foreach (string horario in horarios)
                {

                    dataGridView1.Rows.Add(horario);
                }

                foreach (var reserva in reservas)
                {
                    foreach (DataGridViewColumn columna in dataGridView1.Columns)
                    {
                        string encabezado = columna.HeaderText;

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {

                            //MessageBox.Show(reserva.HorarioConFormato + " y " + dataGridView1[0, i].Value.ToString() + " = " + (reserva.HorarioConFormato == dataGridView1[0, i].Value.ToString()).ToString());
                            //MessageBox.Show(reserva.FechaConFormato + " y " + columna.HeaderText + " = " + (reserva.FechaConFormato == columna.HeaderText).ToString());
                            if (reserva.FechaConFormato == columna.HeaderText && reserva.HorarioConFormato == dataGridView1[0, i].Value.ToString())
                            {
                                dataGridView1[columna.Index, i].Value = reserva.NombreProfesor;
                            }
                            //MessageBox.Show(dataGridView1[0, i].Value.ToString() + " " + i.ToString());
                        }

                    }
                }
            }
            // Obtener horarios, días y reservaciones
            
            // Limpiar la DataGridView


        }
        private void cbAnio_SelectedIndexChanged(object sender, EventArgs e)// evento para el combobox del año
        {
            int anio = Convert.ToInt32(cbAnio.SelectedItem.ToString());
            var meses = _logic.GetMes(anio);
            cbMes.Items.Clear();
            foreach (var mes in meses)
            {
                cbMes.Items.Add(mes);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Reservas(_logic).ShowDialog();
           
        }
       
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {


           
                Application.Exit(); // Finaliza la ejecución del programa si el usuario elige "Sí".
            

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void cbAula_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

            // Deshabilitar el botón si no hay selecciones en ningún ComboBox
            
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
