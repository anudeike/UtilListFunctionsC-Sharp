using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;


namespace Util
{
    // class UList -> is a utility List, like a regular list but with extra functions
    public class UList<T> : System.Collections.Generic.List<T>
    {
        /*
         * Functions I'd Like to Implement
         * - drop -> drops n elements from an array
         * - DropWhileTrue -> drops until the predicate (function) returns false
         * - DropWhileFalse -> drops until the predicate returns true
         */
        
        // delegates
        public delegate bool DropFilterFunction(T x);
        
        public UList()
        {
            // empty
        }

        private UList(T[] arr)
        {
            // takes an array and adds it to the list
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
        
        public UList<T> GetSlice(int start)
        {
            if(this.Count == 0)
            {
                throw new System.ArgumentException("List cannot be empty.");
            }

            // logic
            return new UList<T>(this.GetRange(start, this.Count - start).ToArray());
        }
        
        /// <summary>
        /// Creates a slice of array excluding elements dropped from the beginning. Elements are dropped until predicate returns false. 
        /// </summary>
        /// <param name="f"> The function evoked per iteration</param>
        /// <returns> A slice of the array. </returns>
        public UList<T> DropWhileTrue(DropFilterFunction f)
        {
            int inPoint = 0;
            
            // while we are in the array and the function returns true
            // increment the index
            while (inPoint < this.Count && f(this[inPoint]))
            {
                inPoint++;
            }

            return GetSlice(inPoint);
        }
        
        public UList<T> DropWhileFalse(DropFilterFunction f)
        {
            int inPoint = 0;
            
            // while we are in the array and the function returns false
            // increment the index
            while (inPoint < this.Count && !f(this[inPoint]))
            {
                inPoint++;
            }

            return GetSlice(inPoint);
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
            Console.WriteLine("Original Util List: ");
            Console.WriteLine(utilList);

            var uSlice = utilList.GetSlice(2, 5);
            Console.WriteLine("\nSlice from [2-5]: " + uSlice);
            
            // testing the drop while true
            var allFive = new UList<int>{5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 4, 6};
            Console.WriteLine("\nOriginal Util List: " + allFive);
            
            var noFives = allFive.DropWhileTrue(f => f == 5);
            Console.WriteLine("Filtered out 5's: " + noFives);

            Console.WriteLine("Program Success.");
        }
    }
}