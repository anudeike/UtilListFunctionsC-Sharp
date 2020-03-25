using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;


namespace Util
{
    // class UList -> is a utility List, like a regular list but with extra functions
    public class UList<T> : System.Collections.Generic.List<T>
    {
        public UList()
        {
            // empty
        }

        private UList(T[] arr)
        {
            this.AddRange(arr);
        }

        // toString
        public override string ToString()
        {
            // overriding to allow for better visualization of contents
            var sb = new System.Text.StringBuilder();
            int count = 0;

            sb.Append("[");
            
            while (count < this.Count)
            {
                sb.Append(this[count]);

                if (count == (this.Count - 1))
                    break;

                sb.Append(", ");
                        
                count++;
            }
                    
            sb.Append("]");
            
            return sb.ToString();
        }
        
        // toString (custom separtor)
        public string ToString(string separator)
        {
            // overriding to allow for better visualization of contents
            var sb = new System.Text.StringBuilder();
            int count = 0;

            sb.Append("[");
            
            while (count < this.Count)
            {
                sb.Append(this[count]);

                if (count == (this.Count - 1))
                    break;

                sb.Append(separator + " ");
                        
                count++;
            }
                    
            sb.Append("]");
            
            return sb.ToString();
        }
        
        // === SINGLE LIST UTIL FUNCTIONS
        /// <summary>
        /// Gets a slice given the start and end index. Excludes the value of the end index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"> start index of the slice</param>
        /// <param name="end"> end index of the slice (exclusive) </param>
        /// <returns> Desired slice of the original list. Shallow copy.</returns>
        public UList<T> GetSlice(int start, int end)
        {
            if(this.Count == 0)
            {
                throw new System.ArgumentException("List cannot be empty.");
            }

            if(end - start < 0)
            {
                throw new System.ArgumentException("End Index cannot be less than start index");
            }
            
            // logic
            return new UList<T>(this.GetRange(start, end - start).ToArray());
        }
    }
    
}

namespace ListUtilityFunctions
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // // get a slice of a List
            // List<int> example = new List<int>{4, 5, 2, 5, 1, 6, 7};
            //
            // List<int> slice = GetSlice(example, 4, 7);

            var utilList = new UList<int> {1, 2, 3, 5, 43, 42, 6 ,88, 886, 864};
            Console.WriteLine(utilList);

            var uSlice = utilList.GetSlice(2, 5);
            Console.WriteLine(uSlice);

            Console.WriteLine("Program Success.");
        }
    }
}