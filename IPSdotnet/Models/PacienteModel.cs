using Entity;

namespace IPSdotnet.Models {

    public class PacienteInputModel {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public int ValorServ { get; set; }
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