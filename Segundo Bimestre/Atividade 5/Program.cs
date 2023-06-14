using Microsoft.Data.Sqlite;
using Atividade5.Database;
using Atividade5.Repositories;
using Atividade5.Models;
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
        Console.WriteLine("Pedido Listar");
        int indicador = 1;
        foreach (var pedido in pedidoRepository.Listar())
        {
            Console.WriteLine($"{pedido.PedidoId, -12} {pedido.EmpregadoId, -14} {pedido.DataPedido, -16} {pedido.Peso, -9} {pedido.CodTransportadora, -26} {pedido.PedidoClienteId}");
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
    if(modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Pedido");
        Console.WriteLine("Id do Pedido: ");
        int pedidoid = Convert.ToInt32(Console.ReadLine());
        if(pedidoRepository.Apresentar(pedidoid))
        {
            var pedido = pedidoRepository.GetById(pedidoid);
            Console.WriteLine($"\nId do Pedido: {pedido.PedidoId}\nId do Empregado: {pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\nId do Cliente: {pedido.PedidoClienteId}\n");
        } 
        else 
        {
            Console.WriteLine($"O pedido com Id {pedidoid} não existe.");
        }
    }
    if(modelAction == "MostrarPedidosCliente"){
        Console.WriteLine("\nPedido Mostrar Pedidos Cliente");
        Console.WriteLine("Qual o Id do Cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());
        if(pedidoRepository.MostrarPedidosCliente(clienteid))
        {
            foreach (var pedido in pedidoRepository.GetByClienteId(clienteid))
            {
                Console.WriteLine($"\nId do Pedido: {pedido.PedidoId}\nId do Empregado: {pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\n");
            }
        }
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
        Console.WriteLine("Cliente Listar");
        Console.WriteLine("Id Cliente   Endereço do Cliente      Cidade      Região      Código Postal   País      Telefone");
        foreach (var cliente in clienteRepository.Listar())
        {
            Console.WriteLine($"{cliente.ClienteId, -12} {cliente.Endereco, -24} {cliente.Cidade, -11} {cliente.Regiao, -11} {cliente.CodigoPostal, -15} {cliente.Pais, -9} {cliente.Telefone}");
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
     if(modelAction == "Apresentar")
    {
        Console.WriteLine("\nCliente Apresentar");
        Console.WriteLine("Qual o Id do Cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());
        if(clienteRepository.Apresentar(clienteid))
        {
            var cliente = clienteRepository.GetById(clienteid);
            Console.WriteLine($"\nCliente Id: {cliente.ClienteId}\nEndereço: {cliente.Endereco}\nCidade: {cliente.Cidade}\nRegião: {cliente.Regiao}\nCódigo Postal: {cliente.CodigoPostal}\nPaís: {cliente.Pais}\nTelefone: {cliente.Telefone}\n");
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {clienteid} não existe.");
        }
    }
    else{
        Console.WriteLine("Comando Inválido!");
    }
}
else{
    Console.WriteLine("Database não encontrada!");
}