using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    internal class Collection<Y> : IList<Y>
    {
        protected IList<Y> list = new List<Y>();
        public Collection(params Y[] values)
        {
            foreach(Y value in values)
                list.Add(value);
        }
        
        public Y this[int index] { get => list[index]; set => list[index] = value; }
        public int Count => list.Count;
        public bool IsReadOnly => list.IsReadOnly;
        public void Add(Y item) => list.Add(item);
        public void Clear() => list.Clear();
        public bool Contains(Y item) => list.Contains(item);
        public void CopyTo(Y[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public IEnumerator<Y> GetEnumerator() => list.GetEnumerator();
        public int IndexOf(Y item) => list.IndexOf(item);
        public void Insert(int index, Y item) => list.Insert(index, item);
        public bool Remove(Y item) => list.Remove(item);
        public void RemoveAt(int index) => list.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)list).GetEnumerator();
        
    }
}
