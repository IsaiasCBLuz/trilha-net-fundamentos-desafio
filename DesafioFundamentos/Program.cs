using DesafioFundamentos.Models;

//Limpa o consele para a nova execução
Console.Clear();

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
// Verificação de valores válidos - Preço inicial
while(true){
    Console.WriteLine("Digite o preço inicial: (Ex: 10,00)");
    try{
        precoInicial = Convert.ToDecimal(Console.ReadLine());
        if (precoInicial <= 0){
            Console.WriteLine("Digite um valor válido");
            continue;
        }
        break;
    }
    catch{
        Console.WriteLine("Digite um valor válido");
        continue;
    }
}
// Verificação de valores válidos - Preço por hora
while(true){
    Console.WriteLine("Digite o preço por hora: (Ex: 2,50)");
    try{
        precoPorHora = Convert.ToDecimal(Console.ReadLine());
        if (precoPorHora <= 0){
            Console.WriteLine("Digite um valor válido");
            continue;
        }
        break;
    }
    catch{
        Console.WriteLine("Digite um valor válido");
        continue;
    }
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
