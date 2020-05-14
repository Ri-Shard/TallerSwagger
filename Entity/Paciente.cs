using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Paciente
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int ValorServ { get; set; }
        public int Salario { get; set; }
         public int Copago { get; set; }

        public void CalcularCopago() 
        {
            int Tarifa;
            if (Salario>2500000)
            {
                Tarifa =(Salario *20)/100 ;               
                Copago=(ValorServ+Tarifa);
            }
            else
            {
                Tarifa= (Salario * 10)/100 ;
                Copago=(ValorServ+Tarifa);

            }
        }
    }
}

    
