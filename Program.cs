using FilaDePrioridade;

Console.WriteLine("Quantos elementos serao inseridos na fila?");
Elemento[] vetorElementos = new Elemento[int.Parse(Console.ReadLine())];

for (int i = 0; i < vetorElementos.Length; i++)
{
    Console.WriteLine("Digite o elemento a ser inserido:");
    int elemento = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a prioridade do elemento:");
    int prioridade = int.Parse(Console.ReadLine());
    vetorElementos[i] = new Elemento(elemento, prioridade);
}

vetorElementos.ConstroiHeap();
HeapVetor.PrintHeap(vetorElementos);


vetorElementos.HeapSort();
Console.WriteLine(string.Join(", ", vetorElementos.Select(x => x.Prioridade)));

//Console.Write(heap.ToString());
