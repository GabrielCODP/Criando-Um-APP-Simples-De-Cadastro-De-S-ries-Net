using CadastroEmSerie.Classes;
using CadastroEmSerie.Enums;
using System;


namespace CadastroEmSerie
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(":::::::Cadastro de Série:::::::");
            Console.WriteLine("\nInforme uma opção");

            Console.WriteLine("\n1-Listar séries\n2-Inserir nova série\n3-Atualizar série\n4-Excluir série\n5-Visualizar série\nX-Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine(":::::::Lista de Séries:::::::");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var series in lista)
            {

                Console.WriteLine($"#ID[{series.Id}] - {series.Titulo}  {(series.Excluido ? "- Excluido" : "")}");
            }
        }

        private static void InserirSerie()
        {

            Console.WriteLine(":::::::Inserir nova série:::::::");

            int genero = ImprimirGenero();

            try
            {
                Console.WriteLine();
                Console.Write("Informe o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                if (genero >= entradaGenero)
                {
                    Console.Write("Digite o Título da Série: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.Write("Digite o Ano de Inicio da Série: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite a Descrição da Série: ");
                    string entradaDescricao = Console.ReadLine();

                    Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
                    repositorio.Insere(novaSerie);
                }

                else
                    Console.WriteLine("Erro!Gênero não localizado");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }


        private static void AtualizarSerie()
        {
       
            Console.WriteLine(":::::::Atualizar Série:::::::");
            int genero = ImprimirGenero();

            try
            {
                Console.Write("\nDigite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());


                Console.WriteLine();
                Console.Write("Informe o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                if (genero >= entradaGenero)
                {
                    Console.Write("Digite o Título da Série: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.Write("Digite o Ano de Inicio da Série: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite a Descrição da Série: ");
                    string entradaDescricao = Console.ReadLine();

                    Serie novaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
                    repositorio.Atualiza(indiceSerie, novaSerie);
                }

                else
                    Console.WriteLine("Erro!Gênero não localizado");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }


        private static void ExcluirSerie()
        {
            Console.WriteLine(":::::::Excluir Série:::::::");

            Console.Write("\nDigite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static int ImprimirGenero()
        {
            int quantidadeDeGenero = 0;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
                quantidadeDeGenero++;
            }

            return quantidadeDeGenero;
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine(":::::::Visualizar Série:::::::");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }


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

                    default:
                        break;

                }
                Console.WriteLine("\n:::::::Enter para continuar:::::::");

                Console.ReadKey();
                Console.Clear();

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
    }
}
