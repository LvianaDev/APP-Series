using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	class SerieRepository : IRepository<Serie>
	{
		private List<Serie> ListSerie = new List<Serie>();

		public void Insert(Serie entity)
		{
			ListSerie.Add(entity);
		}

		public void Delete(int id)
		{
			ListSerie[id].Exclude();
		}

		public void Update(int id, Serie entity)
		{
			ListSerie[id] = entity;
		}

		public List<Serie> List()
		{
			return ListSerie;
		}

		public Serie ReturnForId(int id)
		{
			return ListSerie[id];
		}

		public int NextId()
		{
			return ListSerie.Count;
		}
	}
}
