using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Util;


namespace Util
{
    // class UList -> is a utility List, like a regular list but with extra functions
    public class UList<T> : List<T>
    {
        /*
         * Functions I'd Like to Implement
         * - drop -> drops n elements from an array
         * - DropWhileTrue -> drops until the predicate (function) returns false
         * - DropWhileFalse -> drops until the predicate returns true
         * - GetNext
         */
        
        // delegates
        public delegate bool DropFilterFunction(T x);
        
        // global variables within the class
        private int pos = -1;

        // Empty Constructor
        public UList()
        {
            
        }
        
        // Array Constructor
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
        
        // GetNext - Gets the next element in a List and Remembers where you left off
        public T GetNext(bool wrap = true)
        {
            // must increment the pos to get first element
            this.pos++;
            
            // get the element at that position
            if (this.pos > this.Count)
            {
                if (!wrap)
                {
                    // if the wrap flag is not set
                    throw new IndexOutOfRangeException("Have Reached the end of the list.\nTo avoid this, set wrap to true.");
                }
                else
                {
                    // just reset the pos to zero
                    this.pos = 0;
                }
                
            }
            
            // return the value at that position
            return this[pos];
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

        public UList<T> Drop(int numElementsToBeDropped)
        {
            // drops from the left
            return GetSlice(numElementsToBeDropped - 1);
        }

        public UList<T> DropRight(int numElementsToBeDropped)
        {
            // drops from the right
            return GetSlice(0, this.Count - numElementsToBeDropped);
        }
        
        
        
        // Interactions between two lists.
        
        // Find Unique Values in a list
        public UList<T> FindUnique()
        {
            return new UList<T>();
        }
        
        
    }
    
    // class UDict -> is a utility dictionary, like a regular dictionary but with extra functions for ease of use
    public class UDIct<T> : Dictionary<T, T>
    {
        /*
         * Functions I'd like to implement:
         * get()
         * items()
         * in()
         */
    }
    
}

namespace ListUtilityFunctions
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // get a slice of a List

            var utilList = new UList<int> {1, 2, 3, 5, 43, 42, 6 ,88, 886, 864};
            Console.WriteLine("Original Util List: ");
            Console.WriteLine(utilList);

            // call the get next. 
            Console.WriteLine(utilList.GetNext());
            Console.WriteLine(utilList.GetNext());
            utilList.GetNext();
            Console.WriteLine(utilList.GetNext());

            // make sure that the foreach still works
            Console.WriteLine(utilList);
            Console.WriteLine("Program Success.");
        }
    }
}