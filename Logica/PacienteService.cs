using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Logica
{
    public class PacienteService
    {

        private readonly CopagoContext _context;
      
        public PacienteService(CopagoContext context)
        {
            _context=context;
        }

        public GuardarPacienteResponse Guardar(Paciente paciente)
        {
            try
            {
              var pacienteBus =_context.Pacientes.Find(paciente.Identificacion);
                if ( pacienteBus != null) 
                {
                    return new GuardarPacienteResponse("Error el paciente ya se encuentra registrada");
                }

                paciente.CalcularCopago();
             _context.Pacientes.Add(paciente);
             _context.SaveChanges();
                return new GuardarPacienteResponse(paciente);
            }
            catch (Exception e)
            {
                return new GuardarPacienteResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public class GuardarPacienteResponse 
        {
            public GuardarPacienteResponse(Paciente paciente)
            {
                Error = false;
                Paciente = paciente;
            }
            public GuardarPacienteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Paciente Paciente { get; set; }
        }


         public List<Paciente> ConsultarTodos()
        {
            List<Paciente> pacientes = _context.Pacientes.ToList();
            return pacientes;
        }
                public Paciente BuscarxIdentificacion(string identificacion)
        {
            Paciente paciente = _context.Pacientes.Find(identificacion);
            return paciente;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
              var paciente =_context.Pacientes.Find(identificacion);
                if ( paciente != null) 
                {
                    _context.Pacientes.Remove( paciente );
                    _context.SaveChanges();
                    return ($"El registro {paciente.Nombre} se ha eliminado satisfactoriamente");
                }
                else
                {
                    return ($"Lo sentimos {identificacion} no se encuentra registrada");
   
                }           
            }catch (Exception e)
            {
                    return ($"Error de la aplicacion: {e.Message}");

            }   
        }

        public string Modificar (Paciente PacienteN)
        {
            try
            {
                var PacienteV    =_context.Pacientes.Find(PacienteN.Identificacion);
                if(PacienteV != null)
                {
                    PacienteV.Nombre = PacienteN.Nombre;
                    PacienteV.Identificacion = PacienteN.Identificacion;
                    PacienteV.ValorServ = PacienteN.ValorServ;
                    PacienteV.Salario = PacienteN.Salario;
                    PacienteV.CalcularCopago();
                    _context.Pacientes.Update(PacienteV);
                    _context.SaveChanges();
                    return ($"El registro {PacienteN.Nombre} se ha modificado satisfactoriamente. ");
                }else
                {
                    return ($"Lo sentimos {PacienteN.Identificacion} No se encuentra registrada. ");

                }
            }catch (Exception e)
            {
                    return ($"Error de la aplicacion: {e.Message}");

            } 
        }


        
    }
}