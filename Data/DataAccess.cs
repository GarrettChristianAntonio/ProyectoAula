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

        public List<string> ObtenerProfesores()
        {
           
                List<string> profesores = new List<string>();

                string query = "SELECT nombre FROM Profesor";

                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string profesor = reader.GetString(0);
                                profesores.Add(profesor);
                            }
                        }
                    }

                    connection.Close();
                }

                return profesores;
            
        }

        public bool ExisteReserva(string aula, DateTime fechaCalendario, string horario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string query = @"SELECT COUNT(*) 
                             FROM Reservacion AS R
                             INNER JOIN Aula AS A ON R.AulaID = A.idAula
                             INNER JOIN Calendario AS C ON R.CalendarioID = C.ID
                             INNER JOIN Horario AS H ON R.HorarioID = H.ID
                             WHERE A.nombre = @aula
                             AND C.Fecha = @fecha
                             AND H.RangoHorario = @horario";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@aula", SqlDbType.NVarChar, 255) { Value = aula });
                    command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date) { Value = fechaCalendario });
                    command.Parameters.Add(new SqlParameter("@horario", SqlDbType.VarChar, 20) { Value = horario });

                    int rowCount = (int)command.ExecuteScalar();

                    return rowCount > 0;
                }
            }
        }

        public bool InsertarReserva(string aula, DateTime fechaCalendario, string horario, string profesor)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Primero, verifica si ya existe una reserva con los mismos parámetros
                if (ExisteReserva(aula, fechaCalendario, horario))
                {
                    // Si ya existe una reserva, devuelve false (no se puede insertar)
                    return false;
                }

                // Si no existe una reserva, procede a insertarla
                string insertQuery = @"INSERT INTO Reservacion (CalendarioID, HorarioID, AulaID, ProfesorID)
                               SELECT C.ID, H.ID, A.idAula, P.idProfesor
                               FROM Calendario AS C
                               INNER JOIN Horario AS H ON H.RangoHorario = @horario
                               INNER JOIN Aula AS A ON A.nombre = @aula
                               INNER JOIN Profesor AS P ON P.nombre = @profesor
                               WHERE C.Fecha = @fecha";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.Add(new SqlParameter("@aula", SqlDbType.NVarChar, 255) { Value = aula });
                    insertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date) { Value = fechaCalendario });
                    insertCommand.Parameters.Add(new SqlParameter("@horario", SqlDbType.VarChar, 20) { Value = horario });
                    insertCommand.Parameters.Add(new SqlParameter("@profesor", SqlDbType.NVarChar, 255) { Value = profesor });

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    // Devuelve true si se insertó correctamente
                    return rowsAffected > 0;
                }
            }
        }

        public bool ExisteReservacionEnRango(string aula, DateTime fechaInicio, DateTime fechaFin, string horario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string query = @"SELECT COUNT(*) 
                         FROM Reservacion AS R
                         INNER JOIN Aula AS A ON R.AulaID = A.idAula
                         INNER JOIN Calendario AS C ON R.CalendarioID = C.ID
                         INNER JOIN Horario AS H ON R.HorarioID = H.ID
                         WHERE A.nombre = @aula
                         AND H.RangoHorario = @horario
                         AND C.Fecha BETWEEN @fechaInicio AND @fechaFin";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@aula", SqlDbType.NVarChar, 255) { Value = aula });
                    command.Parameters.Add(new SqlParameter("@horario", SqlDbType.VarChar, 20) { Value = horario });
                    command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) { Value = fechaInicio });
                    command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) { Value = fechaFin });

                    int rowCount = (int)command.ExecuteScalar();

                    return rowCount > 0;
                }
            }
        }

        public bool InsertarReservas(string aula, DateTime fechaCalendario, string horario, string profesor, string repeticion, DateTime fechaFinal)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Calcula el intervalo de días (1 para diario y 7 para semanal)
                int intervalo = (repeticion == "Diario") ? 1 : 7;

                // Inserta reservas en un rango de fechas
                while (fechaCalendario <= fechaFinal)
                {
                    // Verifica si el día de la semana no es sábado ni domingo
                    if (fechaCalendario.DayOfWeek != DayOfWeek.Saturday && fechaCalendario.DayOfWeek != DayOfWeek.Sunday)
                    {
                        string insertQuery = @"INSERT INTO Reservacion (CalendarioID, HorarioID, AulaID, ProfesorID)
                                       SELECT C.ID, H.ID, A.idAula, P.idProfesor
                                       FROM Calendario AS C
                                       INNER JOIN Horario AS H ON H.RangoHorario = @horario
                                       INNER JOIN Aula AS A ON A.nombre = @aula
                                       INNER JOIN Profesor AS P ON P.nombre = @profesor
                                       WHERE C.Fecha = @fecha";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.Add(new SqlParameter("@aula", SqlDbType.NVarChar, 255) { Value = aula });
                            insertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date) { Value = fechaCalendario });
                            insertCommand.Parameters.Add(new SqlParameter("@horario", SqlDbType.VarChar, 20) { Value = horario });
                            insertCommand.Parameters.Add(new SqlParameter("@profesor", SqlDbType.NVarChar, 255) { Value = profesor });

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            // Verifica si se insertó correctamente
                            if (rowsAffected <= 0)
                            {
                                // Si no se insertó correctamente, devuelve false
                                return false;
                            }
                        }
                    }

                    // Añade el intervalo de días para la próxima reserva
                    fechaCalendario = fechaCalendario.AddDays(intervalo);
                }

                // Devuelve true si todas las inserciones se realizaron con éxito
                return true;
            }
        }

        public List<string> LeerNombresProfesores()
        {
            List<string> datosProfesores = new List<string>();


            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                string consulta = "SELECT * FROM Profesor";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["idProfesor"].ToString();
                            string nombre = reader["nombre"].ToString();
                            string direccion = reader["direccion"].ToString();
                            string telefono = reader["telefono"].ToString();
                            string email = reader["email"].ToString();
                            string documento = reader["documento"].ToString();

                            // Crear una cadena con todos los campos
                            string datosProfesor = $"{id}\t{nombre}\t{direccion}\t{telefono}\t{email}\t{documento}";

                            datosProfesores.Add(datosProfesor);
                        }
                    }
                }
            }

            return datosProfesores;
        }

        // Método para Crear un nuevo profesor
        public bool CrearProfesor(string nombre, string direccion, string telefono, string email, string documento)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                string consulta = "INSERT INTO Profesor (idProfesor, nombre, direccion, telefono, email, documento) " +
                    "VALUES ((SELECT ISNULL(MAX(idProfesor), 0) + 1 FROM Profesor), @Nombre, @Direccion, @Telefono, @Email, @Documento)";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Documento", documento);

                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para Actualizar un profesor existente
        public bool ActualizarProfesor(string nombre,string nombreViejo, string nuevaDireccion, string nuevoTelefono, string nuevoEmail, string nuevoDocumento)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Primero, obtenemos el ID del profesor por el nombre viejo
                string consultaId = "SELECT idProfesor FROM Profesor WHERE nombre = @NombreViejo";
                int idProfesor;

                using (SqlCommand idCommand = new SqlCommand(consultaId, connection))
                {
                    idCommand.Parameters.AddWithValue("@NombreViejo", nombreViejo);

                    idProfesor = (int)idCommand.ExecuteScalar();
                }

                if (idProfesor == 0)
                {
                    // Si no se encontró un profesor con el nombre viejo, retornar false
                    return false;
                }

                // Luego, actualizamos la información del profesor con el ID obtenido
                string consultaUpdate = "UPDATE Profesor SET direccion = @Direccion, telefono = @Telefono, " +
                    "email = @Email, documento = @Documento WHERE idProfesor = @IdProfesor";

                using (SqlCommand updateCommand = new SqlCommand(consultaUpdate, connection))
                {
                    updateCommand.Parameters.AddWithValue("@IdProfesor", idProfesor);
                    updateCommand.Parameters.AddWithValue("@Direccion", nuevaDireccion);
                    updateCommand.Parameters.AddWithValue("@Telefono", nuevoTelefono);
                    updateCommand.Parameters.AddWithValue("@Email", nuevoEmail);
                    updateCommand.Parameters.AddWithValue("@Documento", nuevoDocumento);

                    int filasAfectadas = updateCommand.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para Eliminar un profesor por su nombre
        public bool EliminarProfesorPorNombre(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                string consulta = "DELETE FROM Profesor WHERE nombre = @Nombre";
                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);

                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        public bool CreateAlumno(string nombre, string email, string telefono, string nombreProfesor)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Consulta el último idAlumno
                string consultaMaxIdAlumno = "SELECT ISNULL(MAX(idAlumno), 0) FROM Alumno";
                int ultimoIdAlumno;
                using (SqlCommand maxIdAlumnoCommand = new SqlCommand(consultaMaxIdAlumno, connection))
                {
                    ultimoIdAlumno = (int)maxIdAlumnoCommand.ExecuteScalar();
                }

                // Consulta el idProfesor correspondiente al nombreProfesor
                string consultaIdProfesor = "SELECT idProfesor FROM Profesor WHERE nombre = @NombreProfesor";
                int idProfesor;
                using (SqlCommand idProfesorCommand = new SqlCommand(consultaIdProfesor, connection))
                {
                    idProfesorCommand.Parameters.AddWithValue("@NombreProfesor", nombreProfesor);
                    idProfesor = (int)idProfesorCommand.ExecuteScalar();
                }

                // Inserta el nuevo alumno
                string consulta = "INSERT INTO Alumno (idAlumno, nombre, email, telefono, idProfesor) " +
                                 "VALUES (@IdAlumno, @Nombre, @Email, @Telefono, @IdProfesor)";
                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@IdAlumno", ultimoIdAlumno + 1);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@IdProfesor", idProfesor);

                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }


        public List<string> LeerNombresAlumnos()
        {
            List<string> nombresAlumnos = new List<string>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                string consulta = "SELECT nombre FROM Alumno";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nombresAlumnos.Add(reader["nombre"].ToString());
                        }
                    }
                }
            }

            return nombresAlumnos;
        }
        public List<string> LeerDatosAlumnos()
        {
            List<string> datosAlumnos = new List<string>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                string consulta = "SELECT * FROM Alumno";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StringBuilder datosAlumno = new StringBuilder();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                datosAlumno.Append(reader[i].ToString());
                                if (i < reader.FieldCount - 1)
                                {
                                    datosAlumno.Append("\t");
                                }
                            }
                            datosAlumnos.Add(datosAlumno.ToString());
                        }
                    }
                }
            }

            return datosAlumnos;
        }
        public bool UpdateAlumno(string nombreViejo, string nuevoNombre, string email, string telefono)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Consulta el idAlumno y el idProfesor del nombre antiguo
                string consultaIds = "SELECT idAlumno, idProfesor FROM Alumno WHERE nombre = @NombreViejo";
                int idAlumno;
                int idProfesor;

                using (SqlCommand idsCommand = new SqlCommand(consultaIds, connection))
                {
                    idsCommand.Parameters.AddWithValue("@NombreViejo", nombreViejo);
                    SqlDataReader idsReader = idsCommand.ExecuteReader();

                    if (idsReader.Read())
                    {
                        idAlumno = idsReader.GetInt32(0);
                        idProfesor = idsReader.GetInt32(1);
                    }
                    else
                    {
                        // Cerrar el DataReader antes de salir en caso de que no se encontraran datos.
                        idsReader.Close();
                        // No se encontró el registro
                        return false;
                    }

                    // Cerrar el DataReader después de obtener los valores necesarios.
                    idsReader.Close();
                }

                // Realiza la actualización
                string consulta = "UPDATE Alumno SET nombre = @NuevoNombre, email = @Email, telefono = @Telefono " +
                                 "WHERE idAlumno = @IdAlumno AND idProfesor = @IdProfesor";
                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@IdAlumno", idAlumno);
                    command.Parameters.AddWithValue("@IdProfesor", idProfesor);

                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        public bool DeleteAlumno(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string consulta = "DELETE FROM Alumno WHERE nombre = @Nombre";
                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool CrearPago(string nombreProfesor, string cantidad)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Buscar el id del profesor por su nombre
                int idProfesor = ObtenerIdProfesorPorNombre(connection, nombreProfesor);

                if (idProfesor == -1)
                {
                    // No se encontró el profesor, no se puede crear el pago
                    return false;
                }

                // La fecha se insertará automáticamente como fecha actual
                string consulta = "INSERT INTO Pago (idProfesor, cantidad) VALUES (@IdProfesor, @Cantidad)";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@IdProfesor", idProfesor);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);

                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public List<string> VerPagosProfesor(string nombreProfesor)
        {
            List<string> pagos = new List<string>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                // Buscar el id del profesor por su nombre
                int idProfesor = ObtenerIdProfesorPorNombre(connection, nombreProfesor);

                if (idProfesor == -1)
                {
                    // No se encontró el profesor, no hay pagos que mostrar
                    return pagos;
                }

                string consulta = "SELECT * FROM Pago WHERE idProfesor = @IdProfesor";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@IdProfesor", idProfesor);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StringBuilder datosPago = new StringBuilder();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                datosPago.Append(reader[i].ToString());

                                if (i < reader.FieldCount - 1)
                                {
                                    datosPago.Append("\t");
                                }
                            }

                            pagos.Add(datosPago.ToString());
                        }
                    }
                }
            }

            return pagos;
        }

        private int ObtenerIdProfesorPorNombre(SqlConnection connection, string nombreProfesor)
        {
            string consulta = "SELECT idProfesor FROM Profesor WHERE nombre = @Nombre";

            using (SqlCommand command = new SqlCommand(consulta, connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombreProfesor);
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return (int)result;
                }
                Console.WriteLine(result);
                return -1; // Retorna -1 si no se encuentra el profesor
            }
        }
    }
}
