
namespace Projeto_Relogio_de_Threads.Entities
{
    public class Cronometro
    {
        public int hora { get; set; } = 0;
        public int minuto { get; set; } = 0;
        public int segundo { get; set; } = 0;
        public bool contando { get; set; } = false;
        public void zerarCronometro()
        {
            this.segundo = 0;
            this.minuto = 0;
            this.hora = 0;
        }

        public void pararCronometro()
        {
            contando = false;
            //iniciarCronometro();
            Console.WriteLine("Hora: " + hora + " Minuto: " + minuto + " Segundo: " + segundo);
        }
        public void executarCronômetro()
        {
            contando = true;
            iniciarCronometro();
        }
        public void iniciarCronometro()
        {
            while (contando)
            {
                Thread.Sleep(1000);
                if (segundo < 59)
                {
                    segundo++;
                    // Console.WriteLine("Hora: " + hora + " Minuto: " + minuto + " Segundo: " + segundo);
                }
                else if (minuto < 59)
                {
                    segundo = 0;
                    minuto++;
                    //Console.WriteLine("Hora: " + hora + " Minuto: " + minuto + " Segundo: " + segundo);
                }
                else
                {
                    segundo = 0;
                    minuto = 0;
                    hora++;
                    // Console.WriteLine("Hora: " + hora + " Minuto: " + minuto + " Segundo: " + segundo);
                }
            }
        }
    }
}
