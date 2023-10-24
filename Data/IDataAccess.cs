using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataAccess
    {
        int Login(string user, string pass);
        List<Aula> GetAulas();
        void InsertTreeyearInTableCalendario();
        List<int> GetAnio();
        List<int> GetMes(int año);
        List<string> GetHorarios();
        List<string> GetDiasConNombre(int año, int mes);
        List<Reservacion> ObtenerReservaciones(string nombreAula, string año, string mes);
        List<String> ObtenerProfesores();
        bool ExisteReserva(string aula, DateTime fecha, string horario);
        bool InsertarReserva(string aula, DateTime fechaCalendario, string horario, string profesor);
        bool ExisteReservacionEnRango(string aula, DateTime fechaInicio, DateTime fechaFin, string horario);
        bool InsertarReservas(string aula, DateTime fechaCalendario, string horario, string profesor, string repeticion, DateTime fechaFinal);
        List<string> LeerNombresProfesores();
        bool CrearProfesor(string nombre, string direccion, string telefono, string email, string documento);
        bool ActualizarProfesor(string nombre, string nombreViejo, string nuevaDireccion, string nuevoTelefono, string nuevoEmail, string nuevoDocumento);
        bool EliminarProfesorPorNombre(string nombre);
        bool CreateAlumno(string nombre, string email, string telefono, string nombreProfesor);
        List<string> LeerNombresAlumnos();
        List<string> LeerDatosAlumnos();
        bool UpdateAlumno(string nombreViejo, string nuevoNombre, string email, string telefono);
        bool DeleteAlumno(string nombre);
        bool CrearPago(string nombreProfesor, string cantidad);
        List<string> VerPagosProfesor(string nombreProfesor);
    }
}
