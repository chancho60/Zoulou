using System;
using System.Collections.Generic;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Row<T> : IRow<T> where T : new() {
        public T Element { get; set; }
        public readonly string Id;

        //public Row(DatabaseClient client, string etag, Uri id, Uri edit, ) {
        public Row(string id) {
            this.Id = id;
        }

        public void Update() {
        }

        public void Delete() {
        }
    }
}