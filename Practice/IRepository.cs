using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice
{
    public interface IRepository<T>where T : IStoreable
    {
	    void Save(T item);

	    T FindById(IComparable id);

	    IEnumerable<T> All();

	    void Delete(IComparable id);

    }
}
