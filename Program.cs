﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using static Util.ExtendedListFunctions;


namespace Util
{
    // class UList -> is a utility List, like a regular list but with extra functions
    public class UList<T> : System.Collections.Generic.List<T>
    {
        
        // how to access members of the list
        public void Print(string method = "standard", string separator = ",")
        {
            switch (method)
            {
                case "standard":
                    int count = 0;

                    Console.Write("[");
                    while (count < this.Count)
                    {
                        Console.Write(this[count]);

                        if (count == (this.Count - 1))
                            break;

                        Console.Write(separator + " ");
                        
                        count++;
                    }
                    
                    Console.WriteLine("]");
                    break;
                
                case "newline":
                    foreach (var elem in this)
                    {
                        Console.WriteLine(elem);
                    }
                    break;
            }
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
    }
    
    class ExtendedListFunctions
    {
        /// <summary>
        /// Gets a slice given the start and end index. Excludes the value of the end index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"> target list </param>
        /// <param name="start_index"> start index of the slice</param>
        /// <param name="end_index"> end index of the slice (exclusive) </param>
        /// <returns> Desired slice of the original list. Shallow copy.</returns>
        public static List<T> GetSlice<T>(List<T> list, int start_index, int end_index)
        {
            if(list.Count == 0)
            {
                throw new System.ArgumentException("List cannot be empty.");
            }

            if(end_index - start_index < 0)
            {
                throw new System.ArgumentException("End Index cannot be less than start index");
            }

            
            return list.GetRange(start_index, end_index - start_index);
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

            var utilList = new UList<int> {1, 2, 3, 5};
            Console.WriteLine(utilList);

            Console.WriteLine("Program Success.");
        }
    }
}