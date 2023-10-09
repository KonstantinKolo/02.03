using System;

namespace _01 {
    class Program {
        static void Main(string[] args) {





        }
    }
    public class CustomArrayList {
        private object[] arr;

        private int count;
        public int Count {
            get {
                return count;
            }
        }

        private static readonly int INITIAL_CAPACITY = 4;

        public CustomArrayList() {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }
        public void GrowIfArrayIsFull() {
            if (arr.Length == count) {
                object[] extendedArr = new object[this.arr.Length * 2];
                Array.Copy(this.arr, extendedArr, this.count);
                this.arr = extendedArr;
            }
        }
        public void Add(object item) {
            this.GrowIfArrayIsFull();
            this.arr[this.count] = item;
            this.count++;
        }
        public void Insert(int index, object item) {
            if(index >= this.count || index < 0) {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            this.GrowIfArrayIsFull();
            Array.Copy(this.arr, index, this.arr, index + 1, this.count - index);
            this.arr[index] = item;
            this.count++;
        }
        public int IndexOf(object item) {
            for (int i = 0; i < this.arr.Length; i++) {
                if(arr[i] == item) {
                    return i;
                }
            }
            return -1;
        }
        public void Clear() {
            this.arr = new object[INITIAL_CAPACITY];
            this.count = 0;
        }
        public bool Contains(object item) {
            if (IndexOf(item) == -1) {
                return false;
            }
            else {
                return true;
            }
        }
        public object this[int index] {
            get {
                if (index >= this.count || index < 0) {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                return this.arr[index];
            }
            set {
                if (index >= this.count || index < 0) {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                this.arr[index] = value;
            }
        }
        public object Remove(int index) {
            if (index >= this.count || index < 0)  {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            Object item = arr[index];

            Array.Copy(this.arr, index + 1, this.arr, index, this.count - index - 1);
            this.arr[count - 1] = null;
            count--;
            return item;
        }
        public int Remove(object item) {
            int index = this.IndexOf(item);
            if (index != -1) {
                this.Remove(index);
            }

            return index;
        }
    }
}
