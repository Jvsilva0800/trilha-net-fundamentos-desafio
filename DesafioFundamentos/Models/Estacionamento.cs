using System.Text.RegularExpressions;
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
        private bool VerificarPlaca(string placa){
            placa = placa.ToUpper().Replace(" ", "").Replace("-", "");
            string padrao = @"^[A-Za-z]{3}[0-9]{4}$";
            return Regex.IsMatch(placa, padrao);//Verifica se a string placa corresponde ao padrão definido
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            bool pass = true;
            do{
                Console.WriteLine("Digite a placa do veículo (VÁLIDA) para estacionar:");
                string placa = Console.ReadLine();
                if(VerificarPlaca(placa)){
                    pass = false;
                    veiculos.Add(placa);
                    Console.WriteLine($"Placa {placa} registrada com sucesso!");
                }else{
                    Console.WriteLine("Placa INVÁLIDA!!");
                }
            }while(pass);
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))//converte cada elemento da lista de veículos e os aplica ToUpper em seguida é feita a comparação com a placa coletada para saber se defato ela existe.
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                // TODO: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach(string i in veiculos){
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
