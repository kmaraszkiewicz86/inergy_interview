using System;
using System.Collections.Generic;
using FactoryProductSaver.Core.Interfaces;

namespace FactoryProductSaver.Core.Implementations
{
    public class StdInReader : IReader
    {
        /// <summary>
        /// Reads all text typed on std in
        /// </summary>
        public IEnumerable<string> ReadAllText()
        {
            while (true)
            {
                Console.WriteLine("Type line of text or all text to save all block of text:");
                Console.WriteLine("If you want to quit type empty line:");

                var text = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text))
                {
                    break;
                }

                if (text.StartsWith("#"))
                {
                    continue;
                }

                yield return text;
            }
        }
    }
}
