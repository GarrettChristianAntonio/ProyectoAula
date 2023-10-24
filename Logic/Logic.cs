using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logic : ILogic
    {
        IDataAccess _dataAccess;
        public Logic(IDataAccess dataAccess)//constructor 
        {
            _dataAccess = dataAccess;
        }

        public int Login(string user,string pass)//Metodo para logeo
        {
            return _dataAccess.Login(user, pass);
        }

        public List<Aula> GetAulas()//Metodo GetAulas
        {
            return _dataAccess.GetAulas();
        }
        public void InsertTreeyearInTableCalendario()//NOOOOOOOOOO UTILIZARRRRR
        {
            _dataAccess.InsertTreeyearInTableCalendario();
        }

        public List<int> GetAnio()
        {
            return _dataAccess.GetAnio();
        }

        public List<int> GetMes(int año)
        {
            return _dataAccess.GetMes(año);
        }

        public List<string> GetHorarios()
        {
            return _dataAccess.GetHorarios();
        }

        public List<string> GetDiasConNombre(int año, int mes)
        {
            return _dataAccess.GetDiasConNombre(año, mes);
        }

        public List<Reservacion> ObtenerReservaciones(string nombreAula, string año, string mes)
        {
            return _dataAccess.ObtenerReservaciones(nombreAula, año, mes);
        }

        public List<string> ObtenerProfesores()
        {
            return _dataAccess.ObtenerProfesores();
        }

        public bool ExisteReserva(string aula, DateTime fechaCalendario, string horario)
        {
            return _dataAccess.ExisteReserva(aula, fechaCalendario, horario);
        }

        public bool InsertarReserva(string aula, DateTime fechaCalendario, string horario, string profesor)
        {
            return _dataAccess.InsertarReserva(aula, fechaCalendario, horario, profesor);
        }

        public bool ExisteReservacionEnRango(string aula, DateTime fechaInicio, DateTime fechaFin, string horario)
        {
            return _dataAccess.ExisteReservacionEnRango(aula,fechaInicio,fechaFin, horario);
        }

        public bool InsertarReservas(string aula, DateTime fechaCalendario, string horario, string profesor, string repeticion, DateTime fechaFinal)
        {
           return  _dataAccess.InsertarReservas(aula, fechaCalendario, horario, profesor, repeticion, fechaFinal);
        }





        public List<string> LeerNombresProfesores()
        {
            return _dataAccess.LeerNombresProfesores();
        }





        public bool CrearProfesor(string nombre, string direccion, string telefono, string email, string documento)
        {
            return _dataAccess.CrearProfesor(nombre, direccion, telefono, email, documento);
        }

        public bool ActualizarProfesor(string nombre, string nombreViejo, string nuevaDireccion, string nuevoTelefono, string nuevoEmail, string nuevoDocumento)
        {
            return _dataAccess.ActualizarProfesor(nombre,  nombreViejo, nuevaDireccion, nuevoTelefono, nuevoEmail, nuevoDocumento);
        }

        public bool EliminarProfesorPorNombre(string nombre)
        {
            return _dataAccess.EliminarProfesorPorNombre(nombre);
        }

        public List<string> LeerNombresAlumnos()
        {
            return _dataAccess.LeerNombresAlumnos();
        }

        public List<string> LeerDatosAlumnos()
        {
            return _dataAccess.LeerDatosAlumnos();
        }

        public bool CreateAlumno(string nombre, string email, string telefono, string nombreProfesor)
        {
            return _dataAccess.CreateAlumno(nombre, email, telefono, nombreProfesor);
        }

        public bool UpdateAlumno(string nombreViejo, string nuevoNombre, string email, string telefono)
        {
            return _dataAccess.UpdateAlumno(nombreViejo, nuevoNombre, email, telefono);
        }

        public bool DeleteAlumno(string nombre)
        {
            return _dataAccess.DeleteAlumno(nombre);
        }

        public bool CrearPago(string nombreProfesor, string cantidad)
        {
            return _dataAccess.CrearPago(nombreProfesor, cantidad);
        }

        public List<string> VerPagosProfesor(string nombreProfesor)
        {
            return _dataAccess.VerPagosProfesor(nombreProfesor);
        }
    }
}
