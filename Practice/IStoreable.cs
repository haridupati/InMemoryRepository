using System;

namespace Practice
{
	public interface IStoreable
	{
		IComparable Id { get; set; }
		string Name { get; set; }
	}
}