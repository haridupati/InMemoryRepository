using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice
{
	public class InMemoryRepository<T> : IRepository<T> where T : IStoreable
	{
		private List<T> _entities = new List<T>();
		public void Save(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			// it's an update
			if (item.Id != null)
			{
				var findById = FindById(item.Id);
				findById.Name = item.Name;
			}
			else
			{
				item.Id = GenerateId();
				_entities.Add(item);
			}
		}

		public T FindById(IComparable id)
		{
			var entity = _entities.FirstOrDefault(x => Equals(x.Id, id));
			return entity;
		}

		public IEnumerable<T> All()
		{
			return _entities;
		}

		public void Delete(IComparable id)
		{
			_entities.RemoveAll(x => x.Id.Equals(id));
		}

		#region private
		private IComparable GenerateId()
		{
			return _entities.Count + 1;
		}
		#endregion
	}
}