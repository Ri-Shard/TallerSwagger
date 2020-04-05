using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class PacienteRepository
    {
        
        private readonly SqlConnection _connection;
        private readonly List<Paciente> _personas = new List<Paciente>();
        public PacienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }


       public void Guardar(Paciente paciente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into pacientep (Identificacion,Nombre,ValorServ,Salario,Copago) 
                                        values (@Identificacion,@Nombre,@ValorServ,@Salario,@Copago)";
                command.Parameters.AddWithValue("@Identificacion", paciente.Identificacion);
                command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                command.Parameters.AddWithValue("@ValorServ", paciente.ValorServ);
                command.Parameters.AddWithValue("@Salario", paciente.Salario);
                command.Parameters.AddWithValue("@Copago", paciente.Copago);
                var filas = command.ExecuteNonQuery();
            }
        }

     public List<Paciente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Paciente> pacientes = new List<Paciente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from pacientep";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Paciente paciente = DataReaderMapToPaciente(dataReader);
                        pacientes.Add(paciente);
                    }
                }
            }
            return pacientes;
        }

        public Paciente BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from pacientep where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPaciente(dataReader);
            }
        }


        private Paciente DataReaderMapToPaciente(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Paciente paciente = new Paciente();
            paciente.Identificacion = (string)dataReader["Identificacion"];
            paciente.Nombre = (string)dataReader["Nombre"];
            paciente.ValorServ = (int)dataReader["ValorServ"];
            paciente.Salario = (int)dataReader["Salario"];
            paciente.Copago = (int)dataReader["Copago"];
            return paciente;
            
         }


        
    }
}