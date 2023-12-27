namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //Limpeza do console e exibe a mensagem sobre a opção escolhida.
            Console.Clear();
            Console.WriteLine("Você escolheu a opção de cadastrar veículo.");
            // Loop para verificar se o veículo já está estacionado, caso não esteja, adiciona o veículo na lista.
            while(true){
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string addPlaca = Console.ReadLine();
                //Aqui foi utilizado o método Any(), embora não o tenhamos visto em aula, obeservei o seu funcionamento e tentei replica-lo neste ponto do código.
                if (veiculos.Any(x => x.ToUpper() == addPlaca.ToUpper()))
                {
                    Console.WriteLine("Desculpe, esse veículo já está estacionado aqui.");
                }
                else
                {
                    veiculos.Add(addPlaca.ToUpper());
                    Console.WriteLine($"O veículo {addPlaca} foi estacionado com sucesso!");
                    break;
                }
            }
        }

        public void RemoverVeiculo()
        {
            //Limpeza do console e verificação se há veículos no estacionamento, caso não haja exibe a mensagem e retorna, caso haja parte para a remoção.
            Console.Clear();
            Console.WriteLine("Você escolheu a opção de remover veículo.");
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            } else{
                // Exibe os veículos, foreach foi o laço de repetição escolhido pois não é necessário saber o índice do item.
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
                // Loop para verificar se o veículo existe, caso exista, pede a quantidade de horas e remove o veículo da lista.
                while(true){
                    Console.WriteLine("Digite a placa do veículo para remover:");
                    string placa = Convert.ToString(Console.ReadLine());

                    // Verifica se o veículo existe
                    if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        // Verificação de valores válidos - Horas(apenas números inteiros)
                        uint horas;
                        while(true){
                            try{
                                horas = Convert.ToUInt32(Console.ReadLine());
                                break;
                            }
                            catch{
                                Console.WriteLine("Digite um valor válido");
                                continue;
                            }
                        }

                        decimal valorTotal = precoInicial + (precoPorHora * horas);
                        veiculos.Remove(Convert.ToString(placa.ToUpper()));

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    }
                }
            }
        }

        public void ListarVeiculos()
        {
            //Limpa o console e exibe a mensagem sobre a opção escolhida e verifica se há veículos no estacionamento, caso haja os exibe.
            Console.Clear();
            Console.WriteLine("Você escolheu a opção de listar veículo.");
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Exibe os veículos, foreach foi o laço de repetição escolhido pois não é necessário saber o índice do item.
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
