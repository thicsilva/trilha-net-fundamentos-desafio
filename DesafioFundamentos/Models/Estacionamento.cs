namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal _precoInicial;
        private readonly decimal _precoPorHora;
        private readonly List<string> _veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = Console.ReadLine();
            if (!string.IsNullOrEmpty(placa))
                _veiculos.Add(placa.ToUpper());
            else
                Console.WriteLine("Obrigatório informar a placa!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            var placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa))
                Console.WriteLine("Obrigatório informar a placa!");
            else
            {
                // Verifica se o veículo existe
                if (_veiculos.Any(x => string.Equals(x, placa, StringComparison.CurrentCultureIgnoreCase)))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // Validando entrada do usuário
                    if (int.TryParse(Console.ReadLine(), out var horas))
                    {
                        var valorTotal = _precoInicial + _precoPorHora * horas;

                        _veiculos.Remove(placa?.ToUpper());

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    } else 
                        Console.WriteLine("O valor inserido para horas não é válido!");
                
                }
                else
                    Console.WriteLine(
                        "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in _veiculos) 
                    Console.WriteLine(veiculo);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
