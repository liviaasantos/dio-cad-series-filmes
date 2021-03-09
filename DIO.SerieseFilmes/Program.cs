using System;

namespace DIO.SerieseFilmes
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorio_2 = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
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
                    ListarFilmes();
                    break;

                    case "7":
                    InserirFilme();
                    break;

                    case "8":
                    AtualizarFilme();
                    break;

                    case "9":
                    ExcluirFilme();
                    break;

                    case "10":
                    VisualizarFilme();
                    break;

                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        //OBTER OPÇÃO USUÁRIO

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Listar filmes");
            Console.WriteLine("7 - Inserir novo filme");
            Console.WriteLine("8 - Atualizar filme");
            Console.WriteLine("9 - Excluir filme");
            Console.WriteLine("10 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        //PARA SÉRIES

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie (id: indiceSerie,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {

                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }


        //PARA FILMES

        private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio_2.Exclui(indiceFilme);
        }

        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o ID do fime: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio_2.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static void InserirFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir novo filme");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme (id: repositorio_2.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio_2.Insere(novoFilme);

        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o ID do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme (id: indiceFilme,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio_2.Atualiza(indiceFilme, atualizaFilme);

        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");
            var lista = repositorio_2.Lista();

            if (lista.Count == 0)
            {

                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }
    }
}
