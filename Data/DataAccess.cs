using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataAccess:IDataAccess
    {
        string cadenaConexion = "Server = DESKTOP-FB1FOFU; Database=Aula1;Integrated Security = True;";
        public int Login(string user, string pass)
        {
            int verificador = 0; // 0 no encontro, 1 administrador, 2 empleado
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Administrador WHERE usuario = @usuario AND contraseña = @Contraseña";
                

                using(SqlCommand comand = new SqlCommand(query, connection))
                {
                    comand.Parameters.AddWithValue("@usuario", user);
                    comand.Parameters.AddWithValue("@Contraseña", pass);
                    int countUsuarios = (int)comand.ExecuteScalar();
                    if(countUsuarios > 0)//si encontro en tabla administrador 1
                    {
                        verificador = 1;
                    }
                }

                if (verificador != 1)//entra si no se encontro nada en la tabla administrador
                {
                    query = "SELECT COUNT(*) FROM Empleado WHERE usuario = @usuario AND contraseña = @Contraseña";
                    using (SqlCommand comand = new SqlCommand(query, connection))
                    {
                        comand.Parameters.AddWithValue("@usuario", user);
                        comand.Parameters.AddWithValue("@contraseña", pass);
                        int countAdmin = (int)comand.ExecuteScalar();//si encontro en tabla empleado 2
                        if (countAdmin > 0)
                        {
                            verificador = 2;
                        }
                    }
                }
            }
            return verificador;//vale 0 si no encontro nada.
        }
        public List<Aula> GetAulas()
        {
            List<Aula> aulas = new List<Aula>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Aula";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idAula = reader.GetInt32(reader.GetOrdinal("idAula"));
                        string nombre = reader.GetString(reader.GetOrdinal("nombre"));

                        aulas.Add(new Aula { IdAula = idAula, Nombre = nombre });
                    }
                }
            }
        return aulas;
        }
        public List<int> GetAnio()
        {
            List<int> años = new List<int>();
            string query = "SELECT DISTINCT DATEPART(YEAR, Fecha) AS Año FROM Calendario ORDER BY Año";
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int año = reader.GetInt32(0);
                            años.Add(año);
                        }
                    }
                }
                connection.Close();
            }
            return años;
        }

        public List<int> GetMes(int año)
        {
            List<int> meses = new List<int>();
            string query = "SELECT DISTINCT DATEPART(MONTH, Fecha) AS Mes FROM Calendario WHERE DATEPART(YEAR, Fecha) = @Año ORDER BY Mes";
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Año", año);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32(0);
                            meses.Add(mes);
                        }
                    }
                }
                connection.Close();
            }
            return meses;
        }

        public List<string> GetHorarios()
        {
            List<string> horarios = new List<string>();

            string query = "SELECT RangoHorario FROM Horario";

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string horario = reader.GetString(0);
                            horarios.Add(horario);
                        }
                    }
                }

                connection.Close();
            }

            return horarios;
        }
        public List<string> GetDiasConNombre(int año, int mes)
        {
            List<string> diasConNombre = new List<string>();

            string query = "SELECT DISTINCT DAY(Fecha) AS Dia, DATENAME(WEEKDAY, Fecha) AS NombreDia " +
                           "FROM Calendario " +
                           "WHERE YEAR(Fecha) = @Año AND MONTH(Fecha) = @Mes " +
                           "ORDER BY Dia";

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Año", año);
                    command.Parameters.AddWithValue("@Mes", mes);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int dia = reader.GetInt32(0);
                            string nombreDia = reader.GetString(1);
                            string diaConNombre = $"{dia} {nombreDia}";
                            diasConNombre.Add(diaConNombre);
                        }
                    }
                }

                connection.Close();
            }

            return diasConNombre;
        }

        public List<Reservacion> ObtenerReservaciones(string nombreAula, string año, string mes)
        {
            List<Reservacion> eventos = new List<Reservacion>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string consulta = @"
                SELECT 
                    CONCAT(CAST(DAY(C.Fecha) AS VARCHAR), ' ', C.DiaSemana) AS FechaConFormato,
                    CONCAT(LEFT(H.RangoHorario, 5), '-', LEFT(DATEADD(HOUR, 2, CAST(H.RangoHorario AS TIME)), 5)) AS HorarioConFormato,
                    P.nombre AS NombreProfesor
                FROM Reservacion AS R
                INNER JOIN Calendario AS C ON R.CalendarioID = C.ID
                INNER JOIN Horario AS H ON R.HorarioID = H.ID
                INNER JOIN Profesor AS P ON R.ProfesorID = P.idProfesor
                INNER JOIN Aula AS A ON R.AulaID = A.idAula
                WHERE A.nombre = @NombreAula
                    AND YEAR(C.Fecha) = @Año
                    AND MONTH(C.Fecha) = @Mes";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@NombreAula", nombreAula);
                    command.Parameters.AddWithValue("@Año", año);
                    command.Parameters.AddWithValue("@Mes", mes);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reservacion reservacion = new Reservacion
                            {
                                FechaConFormato = reader["FechaConFormato"].ToString(),
                                HorarioConFormato = reader["HorarioConFormato"].ToString(),
                                NombreProfesor = reader["NombreProfesor"].ToString()
                            };
                            eventos.Add(reservacion);
                        }
                    }
                }
            }

            return eventos;
        }
        public void InsertTreeyearInTableCalendario()//solo puede utilizarlo el programador. modificando un boton para utilizarlo una vez a nivel produción
        {
                int yearsToGenerate = 3;
                DateTime startDate = DateTime.Today; // Puedes cambiar la fecha de inicio si es necesario, se deberia documentar los dias que se utilizo desde que fecha
            //se utiliza por primera vez el día 15/10
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    for (int year = 0; year < yearsToGenerate; year++)
                    {
                        DateTime currentDate = startDate.AddYears(year);
                        DateTime endDate = currentDate.AddYears(1).AddDays(-1); // Último día del año
                        while (currentDate <= endDate)
                        {
                            string insertSql = "INSERT INTO Calendario (Fecha, DiaSemana) VALUES (@Fecha, @DiaSemana)";
                            using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                            {
                                cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = currentDate;
                                cmd.Parameters.Add("@DiaSemana", SqlDbType.VarChar, 10).Value = currentDate.ToString("dddd");

                                cmd.ExecuteNonQuery();
                            }
                            currentDate = currentDate.AddDays(1); // Avanza al siguiente día
                        }
                    }
                    connection.Close();
                }
        }
    }
}
