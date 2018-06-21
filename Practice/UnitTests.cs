using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Practice
{

	public class UnitTests
	{
		InMemoryRepository<StoreableEntity> inMemoryRepository = new InMemoryRepository<StoreableEntity>();

		#region Save Tests
		[Fact]
		public void Save_Should_SaveStoreableEntity()
		{
			var storeableEntity = new StoreableEntity() { Name = "Hari" };
			inMemoryRepository.Save(storeableEntity);


			StoreableEntity findById = inMemoryRepository.FindById(storeableEntity.Id);
			Assert.Equal(findById.Id, storeableEntity.Id);
		}


		[Fact]
		public void Save_Should_UpdateStoreableEntity()
		{
			var storeableEntity = new StoreableEntity() { Name = "Hari" };
			inMemoryRepository.Save(storeableEntity);

			var tobeUpdated = new StoreableEntity() { Id = storeableEntity.Id, Name = "Shiva" };
			inMemoryRepository.Save(tobeUpdated);

			StoreableEntity findById = inMemoryRepository.FindById(storeableEntity.Id);
			Assert.Equal(tobeUpdated.Name, findById.Name);
		}

		[Fact]
		public void InMemoryRepository_Save_ThrowsArgumentNullException_WhenEmptyItemIsPassed()
		{
			Assert.Throws<ArgumentNullException>(() => inMemoryRepository.Save(null));
		}


		#endregion

		#region FindById Tests

		[Fact]
		public void FindById_should_returnCorrectItem()
		{
			var storeableEntity1 = new StoreableEntity() { Name = "Hari" };
			inMemoryRepository.Save(storeableEntity1);

			var storeableEntity2 = new StoreableEntity() { Name = "Shiva" };
			inMemoryRepository.Save(storeableEntity2);

			StoreableEntity findById = inMemoryRepository.FindById(storeableEntity1.Id);
			Assert.Equal(findById.Name,storeableEntity1.Name);
		}

		#endregion

		#region Delete Tests
		[Fact]
		public void Delete_Should_RemoveFromTheList()
		{
			var itemToBeSaved = new StoreableEntity() {Name = "Hari"};
			inMemoryRepository.Save(itemToBeSaved);

			inMemoryRepository.Delete(itemToBeSaved.Id);

			var findById = inMemoryRepository.FindById(itemToBeSaved.Id);
			Assert.True(findById==null);
		}

		#endregion

		#region All Tests
		[Fact]
		public void All_Should_ReturnAllTheEntities()
		{
			var storeableEntity1 = new StoreableEntity() { Name = "Hari" };
			inMemoryRepository.Save(storeableEntity1);

			var storeableEntity2 = new StoreableEntity() { Name = "Shiva" };
			inMemoryRepository.Save(storeableEntity2);

			var storeableEntities = inMemoryRepository.All();

			Assert.Equal(expected: 2,actual: storeableEntities.Count());
			
		}
		#endregion

	}
}
