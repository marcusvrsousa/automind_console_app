using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Usuario
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int Idade { get; set; }
    }

    class Program
    {
        // Lista que armazena os usuários cadastrados
        static readonly List<Usuario> usuarios = [];

        static void Main(string[] args)
        {
             // Loop principal do menu, que permite a escolha das opções
            while (true) 
            {
                Console.WriteLine("Bem-vindo ao Sistema de Cadastro de Usuários!");
                Console.WriteLine("1 - Cadastrar novo usuário");
                Console.WriteLine("2 - Listar todos os usuários");
                Console.WriteLine("3 - Buscar usuário por nome");
                Console.WriteLine("4 - Alterar usuário");
                Console.WriteLine("5 - Deletar usuário");
                Console.WriteLine("6 - Sair");
                Console.Write("Escolha uma opção: ");

                 // Lê a opção escolhida pelo usuário
                string opcao = Console.ReadLine() ?? string.Empty;;

                 // Realiza a ação correspondente à opção escolhida
                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario();
                        break;
                    case "2":
                        ListarUsuarios();
                        break;
                    case "3":
                        BuscarUsuario();
                        break;
                    case "4":
                        AlterarUsuario();
                        break;
                    case "5":
                        DeletarUsuario();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        // Método para cadastrar um novo usuário
        static void CadastrarUsuario()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite a idade: ");
            string idadeInput = Console.ReadLine() ?? string.Empty;

            // Verificando se todos os campos foram preenchidos corretamente e se a idade é um número válido
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(idadeInput) || !int.TryParse(idadeInput, out int idade))
            {
                Console.WriteLine("Cadastro não realizado. Preencha todos os campos!\n");
            }
            else
            {
                // Adiciona o novo usuário à lista de usuários
                usuarios.Add(new Usuario { Nome = nome, Email = email, Idade = idade });
                Console.WriteLine("Usuário cadastrado com sucesso!\n");
            }
        }

         // Método para listar todos os usuários cadastrados
        static void ListarUsuarios()
        {
            // Verifica se há usuários cadastrados
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.\n");
                return;
            }

            Console.WriteLine("Lista de usuários:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"- {usuario.Nome} | {usuario.Email} | {usuario.Idade} anos");
            }
            Console.WriteLine();
        }

         // Método para buscar um usuário pelo nome
        static void BuscarUsuario()
        {

            Console.Write("Digite o nome do usuário: ");
            string nomeBusca = Console.ReadLine() ?? string.Empty;

            // Procura o usuário na lista usando o nome
            var usuarioEncontrado = usuarios.Find(u => 
                u.Nome != null && u.Nome.Contains(nomeBusca, StringComparison.OrdinalIgnoreCase));


            // Exibe os dados do usuário encontrado ou uma mensagem de erro
            if (usuarioEncontrado != null)
            {
                Console.WriteLine($"Usuário encontrado: {usuarioEncontrado.Nome} | {usuarioEncontrado.Email} | {usuarioEncontrado.Idade} anos\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.\n");
            }
        }

         // Método para alterar os dados de um usuário
        static void AlterarUsuario()
        {
            Console.Write("Digite o nome do usuário que deseja alterar: ");
            string nomeBusca = Console.ReadLine() ?? string.Empty;

            // Procura o usuário na lista pelo nome
            var usuarioEncontrado = usuarios.Find(u => u.Nome != null && u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            // Se o usuário for encontrado, permite alterar seus dados
            if (usuarioEncontrado != null)
            {
                Console.Write("Novo nome (ou pressione Enter para manter o atual): ");
                string novoNome = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(novoNome)) usuarioEncontrado.Nome = novoNome;

                Console.Write("Novo e-mail (ou pressione Enter para manter o atual): ");
                string novoEmail = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(novoEmail)) usuarioEncontrado.Email = novoEmail;

                Console.Write("Nova idade (ou pressione Enter para manter a atual): ");
                string novaIdade = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(novaIdade, out int idade)) usuarioEncontrado.Idade = idade;

                Console.WriteLine("Usuário alterado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.\n");
            }
        }

        // Método para deletar um usuário
        static void DeletarUsuario()
        {
            Console.Write("Digite o nome do usuário que deseja deletar: ");
            string nomeBusca = Console.ReadLine() ?? string.Empty;

             // Procura o usuário na lista pelo nome
            var usuarioEncontrado = usuarios.Find(u => u.Nome != null && u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            // Se o usuário for encontrado, o remove da lista
            if (usuarioEncontrado != null)
            {
                usuarios.Remove(usuarioEncontrado);
                Console.WriteLine("Usuário deletado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.\n");
            }
        }
    }
}
