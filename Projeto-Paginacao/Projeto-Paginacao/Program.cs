public class Pagina

{
    public int Id { get; set; }
    public bool Usado {get; set;}
}
public class SecondChance{
    public int Capacidade { get; set; }
    private List<Pagina> Paginas { get; set; }
    public int Contador {get; set;}
    public SecondChance(int capacidade){
        Capacidade = capacidade;
        Paginas = new List<Pagina>();
    }
    public void Referenciar(int id)
    {
        // Encontra a Page Hit (página na memória principal) e encerra o algoritmo
        var pagina = Paginas.FirstOrDefault(p => p.Id == id);
        if (pagina != null)
        {
            Console.WriteLine($"Page Hit - Página {id}");
            pagina.Usado = true; //1
            return;
        }
        // adiciona páginas no número de quadros desde que não ultrapasse sua capacidade
        if (Paginas.Count < Capacidade)
        {
            Paginas.Add(new Pagina { Id = id, Usado = false });
        }
        // se o número de quadros chegar ao limite, remove a primeira página que entrou na fila e adiciona a nova página
        else
        {
            while (Paginas[0].Usado)
            {
                Paginas[0].Usado = false;
                Paginas.Add(Paginas[0]);
                Paginas.RemoveAt(0);
            }
            Paginas.RemoveAt(0);
            Paginas.Add(new Pagina { Id = id, Usado = false });
        }
        // se não foi encontrado na memória principal ele apresenta o page fault (página fora da memória principal)
        Console.WriteLine($"Page Fault - Página {id}");
        this.Contador++;
    }
     public void Total(){
        System.Console.WriteLine($"Total de page faults: {Contador}");
    }
}
public class FIFO
{
    private int Capacidade { get; set; }
    private List<Pagina> Paginas { get; set; }
    public int Contador { get; set; }
    public FIFO(int capacidade)
    {
        Capacidade = capacidade;
        Paginas = new List<Pagina>();
    }

    // Implementação do Algoritmo
    public void Referenciar(int id)
    {
        // Encontra a Page Hit (página na memória principal) e encerra o algoritmo
        if (Paginas.Any(p => p.Id == id))
        {
            Console.WriteLine($"Page Hit - Página {id}");
            return;
        }
        // adiciona páginas no número de quadros desde que não ultrapasse sua capacidade
        if (Paginas.Count < Capacidade)
        {
            Paginas.Add(new Pagina { Id = id });
        }
        // se o número de quadros chegar ao limite, remove a primeira página que entrou na fila e adiciona a nova página
        else
        {
            Paginas.RemoveAt(0);
            Paginas.Add(new Pagina { Id = id });
        }
        // se não foi encontrado na memória principal ele apresenta o page fault (página fora da memória principal)
        Console.WriteLine($"Page Fault - Página {id}");
        this.Contador++;
        
    }
    public void Total(){
        System.Console.WriteLine($"Total de page faults: {Contador}");
    }
}

public class NRU
{
    private int Capacidade { get; set; }
    private Dictionary<int, Pagina> Paginas { get; set; }
    
    public int Contador { get; set; }

    public NRU(int capacidade)
    {
        Capacidade = capacidade;
        Paginas = new Dictionary<int, Pagina>();
    }

    // Implementação do Algoritmo
    public void Referenciar(int id)
    {
        // Encontra a Page Hit (página na memória principal) e encerra o algoritmo
        if (Paginas.ContainsKey(id))
        {
            Console.WriteLine($"Page Hit - Página {id}");
            Paginas[id].Usado = true;
            return;
        }
        // adiciona páginas no número de quadros desde que não ultrapasse sua capacidade
        if (Paginas.Count < Capacidade)
        {
            Paginas.Add(id, new Pagina { Id = id,  Usado = false });
        }
        // se o número de quadros chegar ao limite, remove a primeira página que entrou na fila e adiciona a nova página
        else
        {
            var paginaRemovida = Paginas.First(p => !p.Value.Usado).Key;
            Paginas.Remove(paginaRemovida);
            Paginas.Add(id, new Pagina { Id = id, Usado = false });
        }
        // se não foi encontrado na memória principal ele apresenta o page fault (página fora da memória principal)
        Console.WriteLine($"Page Fault - Página {id}");
        this.Contador++;
    }
    public void Total(){
        System.Console.WriteLine($"Total de page faults: {Contador}");
    }
}

public class Program
{
    public static void Main()
    {
        // Pegando o conteúdo das linhas do arquivo e colocando no vetor linha
        var linhas = File.ReadAllLines(@"C:/Users/zsphS/source/repos/Winpenning/Sistemas-Operacionais/Projeto-Paginacao/entrada.txt");
        // linha 1 identifica o algoritmo a ser utilizado
        var algoritmo = linhas[0];
        // linha 2 identifica o número de quadros na memória
        var capacidade = int.Parse(linhas[1]);
        var referencias = linhas.Skip(2).Select(l => new { Id = int.Parse(l.Split()[0]), Modo = l.Split()[1] }).ToList();

        // Criação do objeto e uso do algoritmo FIFO
        switch(algoritmo){
            case "FIFO":
                Console.WriteLine("Algoritmo FIFO selecionado: ");
                 var fifo = new FIFO(capacidade);
                foreach (var referencia in referencias)
                {
                    fifo.Referenciar(referencia.Id);
                }
                fifo.Total();
            break;
            case "SC":
            Console.WriteLine("Algoritmo SC selecionado: ");
             var sc = new SecondChance(capacidade);
                foreach (var referencia in referencias)
                {
                    sc.Referenciar(referencia.Id);
                }
                sc.Total();
            break;
             case "NRU":
            Console.WriteLine("Algoritmo NRU selecionado: ");
            var nru = new NRU(capacidade);
            foreach (var referencia in referencias)
            {
                nru.Referenciar(referencia.Id);
            }
            nru.Total();
            break;

        }
       
    }
}