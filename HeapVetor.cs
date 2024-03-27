using System.Collections;
using System.Net.Http.Headers;

namespace FilaDePrioridade;

public static class HeapVetor
{

    private static void ConstroiHeap(this Elemento[] vetor)
    {
        for (int i = TamanhoHeap(vetor) / 2 - 1; i == 0; i--)
        {
            Heapify(vetor, i);
        }
    }

    public static void HeapSort(this Elemento[] vetor)
    {
        ConstroiHeap(vetor); 
        for (int i = TamanhoHeap(vetor) - 1; i > 0; i--)
        {
            Elemento temp = vetor[0];
            vetor[0] = vetor[i];
            vetor[i] = temp;
            Heapify(vetor, i);
        }
    }

    private static int Pai(int i) => (i - 1) / 2;

    private static int FilhoEsquerda(int i) => 2 * i + 1;

    private static int FilhoDireita(int i) => 2 * i + 2;

    private static int TamanhoHeap(Elemento[] vetor) => vetor.Length;

    private static void Heapify(this Elemento[] vetor, int i)
    {
        int esq = FilhoEsquerda(i);
        int dir = FilhoDireita(i);
        int maior = i;
        if (esq < TamanhoHeap(vetor) && vetor[esq].Prioridade > vetor[maior].Prioridade)
            maior = esq;
        if (dir < TamanhoHeap(vetor) && vetor[dir].Prioridade > vetor[maior].Prioridade)
            maior = dir;
        if (maior != i)
        {
            Elemento temp = vetor[i];
            vetor[i] = vetor[maior];
            vetor[maior] = temp;
            Heapify(vetor, maior);
        }
    }

    public static Elemento ExtrairMax(this Elemento[] vetor)
    {
        if (TamanhoHeap(vetor) == 0)
            throw new Exception("Heap vazio");

        Elemento max = vetor[0];
        vetor[0] = vetor[TamanhoHeap(vetor)];
        vetor[TamanhoHeap(vetor)] = null;

        Heapify(vetor, 0);
        return max;
    }

    public static void PrintHeap(Elemento[] heap)
    {
        int maxLevel = NivelRaiz(heap.Length);
        for (int level = 0; level <= maxLevel; level++)
        {
            int nodes = (int)Math.Pow(2, level);
            string spacing = new string(' ', (int)Math.Pow(2, maxLevel - level) - 1);
            string line = spacing;
            for (int i = 0; i < nodes; i++)
            {
                int index = nodes - 1 + i;
                if (index < heap.Length)
                {
                    line += $"{heap[index],-4}";
                }
                line += spacing;
            }
            Console.WriteLine(line);
        }
    }

    private static int NivelRaiz(int n)
    {
        return (int)Math.Ceiling(Math.Log(n + 1, 2)) - 1;
    }
}

public class Elemento
{
    public int Valor;
    public int Prioridade;

    public Elemento(int valor, int prioridade)
    {
        this.Valor = valor;
        this.Prioridade = prioridade;
    }

    public override string ToString()
    {
        return Prioridade.ToString();
    }
}
