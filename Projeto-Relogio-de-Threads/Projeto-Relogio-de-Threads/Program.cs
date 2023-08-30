using Projeto_Relogio_de_Threads.Entities;
using System.Threading;

int segundo = 0;
int minuto = 0;
int hora = 0;
int h = 1;
int m = 0;
Cronometro cronometro = new Cronometro();

Thread threadRelogio = new Thread(() => { contador(); });
Thread threadPrincipal = new Thread(() => { principal(); });
Thread threadCronometro = new Thread(() => { });
Thread threadAlarme = new Thread(() => { verificaralarme(); });

threadPrincipal.Start();
threadRelogio.Start();
threadAlarme.Start();
void principal()
{

    int esc = 0;
    while (esc != 7)
    {
        Console.WriteLine("--------------");
        Console.WriteLine("1) Ajustar horário");
        Console.WriteLine("2) Visualizar horário");
        Console.WriteLine("3) Iniciar cronômetro");
        Console.WriteLine("4) Parar cronômetro retornado seu valor");
        Console.WriteLine("5) Zerar cronômetro");
        Console.WriteLine("6) ajustar alarme");
        Console.WriteLine("7) Sair");
        Console.WriteLine("--------------");
        Console.Write("--> ");
        esc = int.Parse(Console.ReadLine());

        switch (esc)
        {
            case 1:
                ajustarhorario();
                break;
            case 2:
                visualizarhorario();
                break;
            case 3:
                threadCronometro = new Thread(new ThreadStart(cronometro.executarCronômetro));
                threadCronometro.Start();
                break;
            case 4:
                threadCronometro = new Thread(new ThreadStart(cronometro.pararCronometro));
                threadCronometro.Start();
                break;
            case 5:
                threadCronometro = new Thread(new ThreadStart(cronometro.zerarCronometro));
                threadCronometro.Start();
                break;
            case 6:
                ajustaralarme();
                threadAlarme = new Thread(() => { verificaralarme(); });
                threadAlarme.Start();
                break;
            case 7:
                esc = 7;
                break;
            default:
                Console.WriteLine("Selecione uma opção válida");
                break;
        }
    }
}

void ajustaralarme()
{
    Console.Write("Defina a hora: ");
    h = int.Parse(Console.ReadLine());
    Console.Write("Defina o minuto: ");
    m = int.Parse(Console.ReadLine());
}
void verificaralarme()
{
    bool verificador = true;
    while (verificador == true)
    {
        if (h == hora && m == minuto)
        {
            Console.WriteLine("ALARME ATIVADO!");
            Thread.Sleep(100);
            verificador = false;
        }
    }
}
void ajustarhorario()
{
    Console.Write("Defina a hora: ");
    int h = int.Parse(Console.ReadLine());
    Console.Write("Defina o minuto: ");
    int m = int.Parse(Console.ReadLine());
    Console.Write("Defina o segundo: ");
    int s = int.Parse(Console.ReadLine());

    hora = h;
    minuto = m;
    segundo = s;
}

void visualizarhorario()
{
    Console.WriteLine("hora: " + hora + " minuto: " + minuto + " segundo: " + segundo);
}
void contador()
{
    while (true)
    {
        if (segundo < 59)
        {
            Thread.Sleep(1000);
            segundo++;
        }
        else if (minuto < 59)
        {
            Thread.Sleep(1000);
            segundo = 0;
            minuto++;
        }
        else
        {
            Thread.Sleep(1000);
            segundo = 0;
            minuto = 0;
            hora++;
        }
    }
}