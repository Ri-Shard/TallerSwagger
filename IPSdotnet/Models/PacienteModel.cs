using Entity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPSdotnet.Models {

    public class PacienteInputModel {
        [Required(ErrorMessage = "El nombre  es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El Valor  es requerido")]
        public int ValorServ { get; set; }
        
        [Required(ErrorMessage = "El salario es requerido")]
        public int Salario { get; set; }
    }   

    public class PacienteViewModel : PacienteInputModel {
        public PacienteViewModel () {

        }
        public PacienteViewModel (Paciente paciente) {
            Identificacion = paciente.Identificacion;
            Nombre = paciente.Nombre;
            ValorServ = paciente.ValorServ;
            Salario = paciente.Salario;
            Copago = paciente.Copago;
        }

    public int Copago {get;set;}
    }

}