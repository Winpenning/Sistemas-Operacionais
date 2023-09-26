using System;
using System.Linq;
public class Processo
{
    public int id { get; set; }
    public int burstTime { get; set; } // tempo de execução necessário para completar a tarefa
    public int prioridade { get; set; } // será usado apenas no Priority

    public Processo(int id, int burstTime, int prioridade)
    {
        this.id = id;
        this.burstTime = burstTime;
        this.prioridade = prioridade;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        List<Processo> processos = new List<Processo>()
        {
            new Processo(1, 24,1),
            new Processo(2, 3,4),
            new Processo(3, 3,2)
        };
        int quantum = 4;
        FCFS(processos);
        Console.WriteLine("\n\n");
        SJF(processos);
        Console.WriteLine("\n\n");
        RR(processos, quantum);
        Priority(processos);


    }
    public static void Priority(List<Processo> p)
    {
        p = p.OrderBy(p=> p.prioridade).ToList();
        Console.WriteLine("Os processos serão executados nessa ordem: ");
        foreach(var p0 in p)
        {
            Console.WriteLine("Processo: " + p0.id  + " Prioridade: " + p0.prioridade);
        }
    }
    public static void RR(List<Processo> p, int quantum)
    {
        int n = p.Count;

        int[] tempo_de_espera = new int[n];
        int[] tempo_medio = new int[n];
        int tempo_de_espera_total = 0;
        int tempo_medio_total = 0;

        int[] copia_do_tempo_de_burst = new int[n];
        for (int i = 0; i < n; i++)
            copia_do_tempo_de_burst[i] = p[i].burstTime;
        while (true)
        {
            bool concluido = true;
            for (int i = 0; i < n; ++i)
            {
                if (copia_do_tempo_de_burst[i] > 0)
                {
                    concluido = false;
                    if (copia_do_tempo_de_burst[i] > quantum)
                    {
                        tempo_medio_total += quantum;
                        copia_do_tempo_de_burst[i] -= quantum;
                    }
                    else
                    {
                        tempo_de_espera[i] += tempo_medio_total - p[i].burstTime;
                        tempo_medio_total += copia_do_tempo_de_burst[i];
                        tempo_medio[i] = tempo_medio_total - tempo_de_espera[i];
                        copia_do_tempo_de_burst[i] = 0;
                    }
                }
            }
            if (concluido == true)
                break;
        }
        Console.WriteLine("Processos    Burst Time     Tempo de espera      Tempo de retorno");
        for (int i = 0; i < n; i++)
        {
            tempo_de_espera_total += tempo_de_espera[i];
            tempo_medio_total += tempo_medio[i];
            Console.WriteLine(" " + p[i].id + "\t\t" + p[i].burstTime + "\t\t" + tempo_de_espera[i] + "\t\t" + tempo_medio[i]);
        }
        Console.WriteLine("\nTempo médio de espera: " + (float)tempo_de_espera_total / n);
        Console.WriteLine("Tempo médio de retorno: " + (float)tempo_medio_total / n);
    }

    public static void SJF(List<Processo> p)
    {
        int n = p.Count;

        // ordena o processo utilizando uma expressão lambda
        p = p.OrderBy(p => p.burstTime).ToList();

        int[] wt = new int[n];
        int[] tat = new int[n];
        int total_wt = 0, total_tat = 0;

        // cálculo do tempo de espera
        for (int i = 1; i < n; i++)
            wt[i] = p[i - 1].burstTime + wt[i - 1];

        for (int i = 0; i < n; i++)
        {
            tat[i] = p[i].burstTime + wt[i];
            total_wt += wt[i];
            total_tat += tat[i];
            Console.WriteLine(" " + p[i].id + "\t\t" + p[i].burstTime + "\t\t" + wt[i] + "\t\t" + tat[i]);
        }

        Console.WriteLine("\nTempo médio de espera: " + (float)total_wt / n);
        Console.WriteLine("Tempo médio de retorno: " + (float)total_tat / n);
    }
    public static void FCFS(List<Processo> p)
    {
        int n = p.Count;
        int[] wt = new int[n]; // tempo de espera
        int[] tat = new int[n]; // tempo medio de espera
        int total_wt = 0, total_tat = 0;

        wt[0] = 0;

        // cálculo do tempo de espera
        for (int i = 1; i < n; i++)
            wt[i] = p[i - 1].burstTime + wt[i - 1];
        // cálculo do tempo de retorno
        for (int i = 0; i < n; i++)
        {
            tat[i] = p[i].burstTime + wt[i];
            total_wt += wt[i];
            total_tat += tat[i];

            Console.WriteLine(" " + p[i].id + "\t\t" + p[i].burstTime + "\t\t" + wt[i] + "\t\t" + tat[i]);
        }

        Console.WriteLine("\nTempo médio de espera: " + (float)total_wt / n);
        Console.WriteLine("Tempo médio de retorno: " + (float)total_tat / n);
    }
}
