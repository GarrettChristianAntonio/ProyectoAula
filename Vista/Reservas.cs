using Data.Entities;
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
    public partial class Reservas : Form
    {
        private ILogic _logic;
        public Reservas(ILogic logic)
        {

            InitializeComponent();
            _logic=logic;

            dateTimePicker1.MinDate = DateTime.Now.Date;
            dateTimePicker1.MaxDate = new DateTime(2026, 10, 14);
            dateTimePickerFinal.MinDate = DateTime.Now.Date;
            dateTimePickerFinal.MaxDate = new DateTime(2026, 10, 14);
            var aulas = _logic.GetAulas();
            foreach (var aula in aulas)
            {
                cbAula.Items.Add(aula.Nombre);
            }

            var anios = _logic.GetAnio();
            //foreach (var anio in anios)
            //{
            //    cbAnio.Items.Add(anio);
            //}
            var horarios = _logic.GetHorarios();
            foreach(var horario in horarios)
            {
                cbHorario.Items.Add(horario);
            }
            var profesores = _logic.ObtenerProfesores();
            foreach(var profesor in profesores)
            {
                cbProfesor.Items.Add(profesor);
            }
            btnAceptar.Enabled = false;
            cbRepetir.Items.Add("Diario");
            cbRepetir.Items.Add("Semanal");
            
            cbRepetir.Enabled = false;
            cbRepetir.Visible = false;
            dateTimePickerFinal.Enabled = false;
            dateTimePickerFinal.Visible= false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton consultar

            if (cbAula.SelectedItem != null && dateTimePicker1.Value != null && dateTimePickerFinal.Value != null && cbHorario.SelectedItem != null)
            {
                bool permiso;
                if (checkBox1.Checked)
                {
                    permiso = _logic.ExisteReservacionEnRango(cbAula.SelectedItem.ToString(), dateTimePicker1.Value, dateTimePickerFinal.Value, cbHorario.SelectedItem.ToString());
                }
                else
                {
                    permiso = _logic.ExisteReserva(cbAula.SelectedItem.ToString(), dateTimePicker1.Value, cbHorario.SelectedItem.ToString());
                }

                if (permiso)
                {
                    MessageBox.Show("Existen coincidencias.");
                    btnAceptar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existen coincidencias");
                    btnAceptar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Faltan datos.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //boton aceptar
            bool reservaOk;
            if (checkBox1.Checked)
            {

                reservaOk = _logic.InsertarReservas(cbAula.SelectedItem.ToString(), dateTimePicker1.Value, cbHorario.SelectedItem.ToString(), cbProfesor.SelectedItem.ToString(), cbRepetir.SelectedItem.ToString(), dateTimePickerFinal.Value);
            }
            else
            {
                reservaOk = _logic.InsertarReserva(cbAula.SelectedItem.ToString(), dateTimePicker1.Value, cbHorario.SelectedItem.ToString(), cbProfesor.SelectedItem.ToString());
            }
            
            if (reservaOk)
            {
                MessageBox.Show("Exito");
                btnAceptar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
                btnAceptar.Enabled = true;
            }


            btnAceptar.Enabled=false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                cbRepetir.Enabled = true;
                cbRepetir.Visible = true;
                cbRepetir.SelectedIndex = 0;
                dateTimePickerFinal.Enabled = true;
                dateTimePickerFinal.Visible = true;
                
            }
            else
            {
                cbRepetir.Enabled = false;
                cbRepetir.Visible = false;
                dateTimePickerFinal.Enabled = false;
                dateTimePickerFinal.Visible = false;
            }
        }
    }
}
