using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Interview
{
	[TestFixture]
	public class Tests
	{
		private InMemoryRepository<StoreableEntity> _repository;
		private object _result;

		#region (All)List Tests

		[Test]
		public void InMemoryRepository_List_ReturnsIEnumerableOfCorrectType()
		{
			_repository = new InMemoryRepository<StoreableEntity>();

			_result = _repository.All();

			Assert.True(_result is IEnumerable<StoreableEntity>);
		}
		#endregion

		#region save tests

		[Test]
		public void InMemoryRepository_Save_ThrowsArgumentNullException_WhenEmptyItemIsPassed()
		{
			_repository = new InMemoryRepository<StoreableEntity>();

			Assert.Throws<ArgumentNullException>(() => _repository.Save(null));
		}

		[Test]
		public void InMemoryRepository_Save_AddsNewItem()
		{
			_repository = new InMemoryRepository<StoreableEntity>();

			var itemToBeSaved = new StoreableEntity() { Id = 1, Name = "ItemToBeSaved" };
			_repository.Save(itemToBeSaved);

			_result = _repository.All();
			Assert.IsTrue(((IEnumerable<StoreableEntity>)_result).Contains(itemToBeSaved));
		}

		[Test]
		public void InMemoryRepository_Save_UpdatesExistingItem()
		{
			_repository = new InMemoryRepository<StoreableEntity>();
			var itemToBeSaved = new StoreableEntity() { Id = 1, Name = "ItemToBeSaved" };
			_repository.Save(itemToBeSaved);

			_repository.Save(itemToBeSaved);

			_result = _repository.All();
			Assert.IsTrue(((IEnumerable<StoreableEntity>)_result).All(c => c == itemToBeSaved));
		}

		#endregion

		#region findById test

		[Test]
		public void InMemoryRepository_FindById_ReturnsCorrectItem()
		{
			_repository = new InMemoryRepository<StoreableEntity>();

			var firstItem = new StoreableEntity() { Id = 1, Name = "firstItem" };
			_repository.Save(firstItem);

			var secondItem = new StoreableEntity() { Id = 2, Name = "SecondItem" };
			_repository.Save(secondItem);

			_result = _repository.FindById(1);

			Assert.AreEqual(firstItem, _result);
		}

		#endregion
		
		#region Delete Tests

		[Test]
		public void InMemoryRepository_Delete_RemovesExistingItem()
		{
			_repository = new InMemoryRepository<StoreableEntity>();
			var itemToBeSaved = new StoreableEntity() { Id = 1, Name = "ItemToBeSaved" };
			_repository.Save(itemToBeSaved);

			_repository.Delete(itemToBeSaved.Id);

			_result = _repository.All();
			Assert.IsFalse(((IEnumerable<StoreableEntity>)_result).Contains(itemToBeSaved));
		}

		#endregion
	}
}