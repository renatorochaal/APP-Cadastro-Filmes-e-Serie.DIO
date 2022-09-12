namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmesRepositorio repositoriof = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "0":
                        ListarSeries();
                        break;
                    case "1":
                        InserirSerie();
                        break;
                    case "2":
                        AtualizarSerie();
                        break;
                    case "3":
                        ExcluirSerie();
                        break;
                    case "4":
                        VisualizarSerie();
                        break;
                    case "5":
                        ListarFilmes();
                        break;
                    case "6":
                        InserirFilmes();
                        break;
                    case "7":
                        AtualizarFilmes();
                        break;
                    case "8":
                        ExcluirFilmes();
                        break;
                    case "9":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar nossos serviços. ");
            return;
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar série");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido)
                Console.WriteLine( "#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }
        

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
           
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine()); 
           
            Console.WriteLine("Digite Descrição da Série: ");
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
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
           
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine()); 
           
            Console.WriteLine("Digite Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie (id: indiceSerie,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);
            
            repositorio.Atualizar(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filme");

            var lista = repositoriof.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }
            foreach (var filmes in lista)
            {
                var excluido = filmes.retornaExcluido();
                if(!excluido)
                Console.WriteLine( "#ID {0}: - {1} - {2}", filmes.retornaId(), filmes.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }

        private static void InserirFilmes()
        {
            Console.WriteLine("Inserir novo filme");

            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Digite o Título do filmes: ");
            string entradaTitulo = Console.ReadLine();
           
            Console.WriteLine("Digite o Ano de início do filme: ");
            int entradaAno = int.Parse(Console.ReadLine()); 
           
            Console.WriteLine("Digite Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filmes novoFilmes = new Filmes (id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);
                                
            repositoriof.Insere(novoFilmes);
            
        }
        private static void AtualizarFilmes()
        {
            Console.WriteLine("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();
           
            Console.WriteLine("Digite o Ano de início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine()); 
           
            Console.WriteLine("Digite Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filmes atualizaFilme = new Filmes (id: indiceFilme,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);
            
            repositoriof.Atualizar(indiceFilme, atualizaFilme);

        }
        private static void ExcluirFilmes()
        {
            Console.WriteLine("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositoriof.Excluir(indiceFilme);
        }
        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositoriof.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();


            Console.WriteLine("0 - Listar séries. ");
            Console.WriteLine("1 - Inserir nova série.");
            Console.WriteLine("2 - Atualizar série. ");
            Console.WriteLine("3 - Excluir série. ");
            Console.WriteLine("4 - Visualizar série. ");
            Console.WriteLine("########################");
            Console.WriteLine("5 - Listar filmes. ");
            Console.WriteLine("6 - Inserir um novo filme.");
            Console.WriteLine("7 - Atualizar filme. ");
            Console.WriteLine("8 - Excluir filme. ");
            Console.WriteLine("9 - Visualizar filmes. ");
            Console.WriteLine("C - Limpar Tela. ");
            Console.WriteLine("X - Sair. ");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}