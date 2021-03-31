using System;

namespace DIO.Series
{
	public class Serie : BaseEntity
	{
		// Atributes
		private Genre Genre { get; set; }

		private string Title { get; set; }

		private string Description { get; set; }

		private int Year { get; set; }

		private bool Excluded { get; set; }


		// Methods
		public Serie(int id, Genre genre, string title, string description, int year) 
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
			this.Excluded = false;
		}

		public override string ToString()
		{
			string returnResult = "";
			returnResult += "Gênero: " + this.Genre + Environment.NewLine;
			returnResult += "Titulo: " + this.Title + Environment.NewLine;
			returnResult += "Descrição: " + this.Description + Environment.NewLine;
			returnResult += "Ano de Início: " + this.Year + Environment.NewLine;
			returnResult += "Excluído: " + this.Excluded + Environment.NewLine;

			return returnResult;
		}

		public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}

		public bool returnExclude()
		{
			return this.Excluded;
		}

		public void Exclude()
		{
			this.Excluded = true;
		}
	}
}
