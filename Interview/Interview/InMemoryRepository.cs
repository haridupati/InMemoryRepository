using System;
using System.Collections.Generic;

namespace Interview
{
	public class InMemoryRepository<T> : IRepository<T> where T : IStoreable
	{
		private readonly List<T> _entities = new List<T>();
		public IEnumerable<T> All()
		{
			return _entities;
		}

		public void Delete(IComparable id)
		{
			_entities.RemoveAll(x => x.Id.Equals(id));
		}

		public void Save(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			_entities.RemoveAll(x => x.Id.Equals(item.Id));
			_entities.Add(item);
		}

		public T FindById(IComparable id)
		{
			return _entities.Find(x => x.Id.Equals(id));
		}
	}
}