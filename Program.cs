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
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
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

        // (01) Metodo para listar as séries
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
                var excluido = serie.retronaExcluido();

                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} {(excluido ? "** Excluido **" : " ")}");
            }
        }

        // (02) Metodo para Inserir uma série nova
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;

            InfoSerie(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        // (03) metodo para atualizar uma serie
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série");
            int IndiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;

            InfoSerie(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie atualizaSerie = new Serie(id: IndiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(IndiceSerie, atualizaSerie);
        }

        // (04) Metodo para excluir uma série 
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        //(05) Metodo para Visualizar informacoes de uma serie
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série que deseja visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }






        // Metodo para o salvar as informaçoes das series
        private static void InfoSerie(out int entradaGenero, out string entradaTitulo, out int entradaAno, out string entradaDescricao)
        {
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de início da série: ");
            entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();
        }

        // Método para chamar o menu inicial
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
