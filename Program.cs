using System;

namespace Dio_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio(); //instanciando obj repositorio 
        static void Main(string[] args)
        {

            string escolhaUsuario = OpcaoUsuario();
            while (escolhaUsuario.ToUpper() != "X")
            {
                switch (escolhaUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        // AtualizarSerie();
                        break;
                    case "4":
                        // ExcluirSerie();
                        break;
                    case "5":
                        // VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                escolhaUsuario = OpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar o Totalflex" + Environment.NewLine);
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Totalflex Séries");
            Console.WriteLine("Informe a opção desejada" + Environment.NewLine);

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Série Nova");
            Console.WriteLine("3 - Atualizar suas Séries");
            Console.WriteLine("4 - Excluir uma Série");
            Console.WriteLine("5 - Visualizar uma Série");
            Console.WriteLine("6 - Limpar a Tela");
            Console.WriteLine("X - Sair do programa");
            Console.WriteLine();

            string escolha = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return escolha;

        }
    }
}
