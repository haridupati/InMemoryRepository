using System;

namespace Interview
{
	public class StoreableEntity : IStoreable
	{
		public string Name { get; set; }
		public IComparable Id { get; set; }
	}
}