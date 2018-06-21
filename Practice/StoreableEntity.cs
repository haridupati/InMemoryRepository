using System;

namespace Practice
{
	public class StoreableEntity : IStoreable
	{
		public IComparable Id { get; set; }
		public string Name { get; set; }
	}
}