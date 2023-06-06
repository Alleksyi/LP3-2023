using Microsoft.Data.Sqlite;
using Atividade3.Database;
using Atividade3.Repositories;
using Atividade3.Models;
var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);
Console.WriteLine("Database: ");
var modelName = Console.ReadLine();
if(modelName == "Pedido")
{
    Console.WriteLine("Comando: ");
    var modelAction = Console.ReadLine();
    if(modelAction == "Listar")
    {
        Console.WriteLine("Listar Pedido");
        int indicador = 1;
        foreach (var pedido in pedidoRepository.Listar())
        {
            Console.WriteLine($"\n{indicador}º Registro\nId do Pedido: {pedido.PedidoId}\nId do Empregado{pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\nId do Cliente: {pedido.PedidoClienteId}\n");
            ++indicador;
        }
        indicador = 1;
    }
    if(modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Pedido");
        Console.WriteLine("Id: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Id do Empregado: ");
        int empregoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Data do Pedido: ");
        string dataPedido = Console.ReadLine();
        Console.WriteLine("Peso do Pedido: ");
        string peso = Console.ReadLine();
        Console.WriteLine("Código da Transportadora: ");
        int codTransportadora = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Id do Cliente que fez o Pedido: ");
        int pedidoClienteId = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedido(pedidoId, empregoId, dataPedido, peso, codTransportadora, pedidoClienteId);
        pedidoRepository.Inserir(pedido);
    }
    else{
        Console.WriteLine("Comando Inválido!");
    }
}
if(modelName == "Cliente")
{
    Console.WriteLine("Comando: ");
    var modelAction = Console.ReadLine();
    if(modelAction == "Listar")
    {
        int indicador = 1;
        Console.WriteLine("Listar Cliente");
        foreach (var cliente in clienteRepository.Listar())
        {
            Console.WriteLine($"\n{indicador}º Registro\nCliente Id: {cliente.ClienteId}\nEndereço: {cliente.Endereco}\nCidade: {cliente.Cidade}\nRegião: {cliente.Regiao}\nCódigo Postal: {cliente.CodigoPostal}\nPaís: {cliente.Pais}\nTelefone: {cliente.Telefone}\n");
            ++indicador;
        }
        indicador = 0;
    }
    if(modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Cliente");
        Console.WriteLine("Id: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Endereço: ");
        string endereco = Console.ReadLine();
        Console.WriteLine("Cidade: ");
        string cidade = Console.ReadLine();
        Console.WriteLine("Região: ");
        string regiao = Console.ReadLine();
        Console.WriteLine("Codigo Postal: ");
        string codigopostal = Console.ReadLine();
        Console.WriteLine("País: ");
        string pais = Console.ReadLine();
        Console.WriteLine("Telefone: ");
        string telefone = Console.ReadLine();
        var cliente = new Cliente(clienteid, endereco, cidade, regiao, codigopostal, pais, telefone);
        clienteRepository.Inserir(cliente);
    }
    else{
        Console.WriteLine("Comando Inválido!");
    }
}
else{
    Console.WriteLine("Database não encontrada!");
}