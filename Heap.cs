using System.Collections;

namespace FilaDePrioridade;

public class Heap
{
    private List<Elemento> vetor;

    public Heap(int capacidadeMax)
    {
        vetor = new List<Elemento>(capacidadeMax) { };
    }

    public static Heap ConstroiHeap(List<Elemento> vetor)
    {
        var heap = new Heap(vetor.Count);
        for (int i = vetor.Count / 2; i >= 1; i--)
        {
            heap.Heapify(vetor, i);
        }
        return heap;
    }

    public static void HeapSort(List<Elemento> vetor)
    {
        var heap = ConstroiHeap(vetor); 
        for (int i = vetor.Count; i > 1; i--)
        {
            Elemento temp = vetor[1];
            vetor[1] = vetor[i];
            vetor[i] = temp;
            heap.Heapify(vetor, i);
        }
    }

    // FORMULAS MODIFICADAS PARA CONTAR COM O INDICE 0 DO VETOR
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
        while (i > 1 && prioridade < vetor[i].prioridade)
        {
            vetor[i] = vetor[Pai(i)];
            i = Pai(i); 
        }
        vetor.Insert(i, new Elemento(elemento, prioridade));
    }

    private void Heapify(List<Elemento> vetor, int i)
    {
        int esq = FilhoEsquerda(i);
        int dir = FilhoDireita(i);
        int maior = i;
        if (esq < vetor.Count && vetor[esq].prioridade > vetor[i].prioridade)
            maior = esq;
        if (dir < vetor.Count && vetor[dir].prioridade > vetor[maior].prioridade)
            maior = dir;
        if (maior != i)
        {
            Elemento temp = vetor[i];
            vetor[i] = vetor[maior];
            vetor[maior] = temp;
            Heapify(vetor, maior);
        }
        this.vetor = vetor;
    }

    public Elemento ExtrairMax()
    {
        if (vetor.Count == 0)
            throw new Exception("Heap vazio");
        Elemento max = vetor[1];
        vetor[1] = vetor[vetor.Count - 1];
        vetor.RemoveAt(vetor.Count - 1);
        Heapify(vetor, 1);
        return max;
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

    public override string ToString()
    {
        return $"Valor: {valor}, Prioridade: {prioridade}";
    }
}
