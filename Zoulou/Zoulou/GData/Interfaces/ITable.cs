using System;
using System.Collections.Generic;
using Zoulou.GData.Models;

namespace Zoulou.GData.Interfaces {
    /// <summary>
    /// Worksheet in a spreadsheet document
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITable<T> {

        void Delete();

        void Clear();

        void Rename(string newName);

        void Add(T e);

        IRow<T> Get(int rowNumber);

        IList<IRow<T>> FindAll();

        IList<IRow<T>> FindAll(int Start, int Count);

        IRow<T> FindById(string Id);

        IList<IRow<T>> Find(Query q);
    }
}
