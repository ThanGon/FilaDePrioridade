using FilaDePrioridade;

Heap heap = new Heap(10);

Console.WriteLine("Inserindo elementos na fila de prioridade...");

while (true)
{
    Console.WriteLine("Digite o elemento a ser inserido:");
    int elemento = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a prioridade do elemento:");
    int prioridade = int.Parse(Console.ReadLine());
    heap.Inserir(elemento, prioridade);
    Console.WriteLine("Elemento inserido com sucesso!");
    Console.WriteLine("Deseja inserir outro elemento? (s/n)");
    if (Console.ReadLine().ToLower() == "n")
        break;
}