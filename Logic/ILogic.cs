using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface ILogic
    {
        int Login(string user, string pass);
        List<Aula> GetAulas();//Metodo GetAulas
        List<int> GetAnio();
        List<int> GetMes(int año);
        List<string> GetHorarios();
        List<string> GetDiasConNombre(int año, int mes);
        List<Reservacion> ObtenerReservaciones(string nombreAula, string año, string mes);
    }
}
