using System.Collections;

namespace FilaDePrioridade;

public class Heap
{
    private List<Elemento> vetor;

    public Heap(int capacidadeMax)
    {
        vetor = new List<Elemento>(10);
    }

    private int Pai(int i)
    {
        return i / 2;
    }

    private int FilhoEsquerda(int i)
    {
        return 2 * i;
    }

    private int FilhoDireita(int i)
    {
        return 2 * i + 1;
    }

    public void Inserir(int elemento, int prioridade)
    {
        if (vetor.Count == vetor.Capacity)
            throw new Exception("Heap cheio");
        int i = vetor.Count;
        while(i > 1 && prioridade < vetor[i].prioridade)
        {
            vetor[i] = vetor[Pai(i)];
            i = Pai(i);
        }
        vetor[i] = new Elemento(elemento, prioridade);
    }
}

public class Elemento
{
    public int valor;
    public int prioridade;

    public Elemento(int valor, int prioridade)
    {
        this.valor = valor;
        this.prioridade = prioridade;
    }
}
