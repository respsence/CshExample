using System;
using System.Collections.Generic;
using System.Linq;

namespace GetKeyByValue
{
    static class DictionaryHelper
    {
        /// <summary>
        /// Find keys by value  in Dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValueList">Values collection</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="dict">dictionary</param>
        /// <param name="val">Value to search</param>
        /// <returns>Collection of keys, that contains value.</returns>
        public static IEnumerable<TKey> GetKeysFromValue<TKey, TValueList, TValue>
            (this IDictionary<TKey, TValueList> dict, TValue val) 
                where TValueList:IEnumerable<TValue> where TValue:class
        {
            if (dict == null) throw new ArgumentNullException("dict");
           
            return  from valuePair in dict
                         from value in valuePair.Value
                            where value.Equals(val)
                            select valuePair.Key;
        }
    }

    class Program
    {
        static void Main()
        {
            var duplicates = new Dictionary<int, List<string>>
                            {
                                {1, new List<string> {"Батон КиевХлеб","Батон КХЛ"}}, 
                                {2, new List<string> {"Яйца 1дес. НР","Яйца десяток Наша Ряба"}}
                            };
            
            //Get collection of Keys that have values
            var keys = duplicates.GetKeysFromValue("Батон КХЛ");
       
            foreach (var key in keys)
                Console.WriteLine(key);
            
            //Get one key or Exception
            int exceptionIfNotExactlyOne = duplicates.GetKeysFromValue("Яйца 1дес. НР")
                                            .Single();
            Console.WriteLine(exceptionIfNotExactlyOne);
            
            //Get the first Key or Exception
            int firstProductKey = duplicates.GetKeysFromValue("Яйца десяток Наша Ряба")
                                    .First();
            Console.WriteLine(firstProductKey);

            //Get the first Key or default(TKey)
            int firstProductOrDefaultKey = duplicates.GetKeysFromValue("Батон КиевХлеб11")
                                            .FirstOrDefault();
            Console.WriteLine(firstProductOrDefaultKey);

        }
    }
}
