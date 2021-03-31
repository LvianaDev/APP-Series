using System;

namespace DIO.Series
{
	class Program
	{
		static SerieRepository repository = new SerieRepository();

		static void Main(string[] args)
		{
			string optionUser = GetUserOption();

			while (optionUser.ToUpper() != "X")
			{
				switch (optionUser)
				{
					case "1":
						ListSerie();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						DeleteSerie();
						break;
					case "5":
						ViewSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				optionUser = GetUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}


		private static void ListSerie()
		{
			Console.WriteLine("Listar Séries");

			var list = repository.List();


			if (list.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in list)
			{
				var excluded = serie.returnExclude();
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluded? "Excluido": ""));
			}
		}

		private static void InsertSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int genreEntry = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string titleEntry = Console.ReadLine();

			Console.Write("Digite o Ano de Inicio da Série: ");
			int yearEntry = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string descriptionEntry = Console.ReadLine();

			Serie newSerie = new Serie(id: repository.NextId(),
									   genre: (Genre)genreEntry,
									   title: titleEntry,
									   year: yearEntry,
									   description: descriptionEntry);

			repository.Insert(newSerie); 
		}

		private static void UpdateSerie()
		{
			Console.WriteLine("Digite o Id da série:");
			int indexSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int genreEntry = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string titleEntry = Console.ReadLine();

			Console.Write("Digite o Ano de Inicio da Série: ");
			int yearEntry = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string descriptionEntry = Console.ReadLine();

			Serie updateSerie = new Serie(id: indexSerie,
									   genre: (Genre)genreEntry,
									   title: titleEntry,
									   year: yearEntry,
									   description: descriptionEntry);

			repository.Update(indexSerie, updateSerie);
		}

		private static void DeleteSerie()
		{
			Console.WriteLine("Digite o Id da Série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			repository.Delete(indexSerie);
		}

		private static void ViewSerie()
		{
			Console.WriteLine("Digite o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repository.ReturnForId(indexSerie);

			Console.WriteLine(serie);
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Dio Series a seu Dispor PAPAI!!!");
			Console.WriteLine("Informe a opção desejada: ");

			Console.WriteLine("1- Listar Séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string OptionUser = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return OptionUser;
		}

	}
}
