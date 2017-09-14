using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using LogManager = Logger.LogManager;

namespace Task3
{
    /// <summary>
    /// Represents a manager for calculating prime factors of an integers, 
    /// can read integers from formated text files (every integer should be 
    /// on a new line w/o separators), can print prime factors separated with
    /// a coma, each prime factors set on a new line.
    /// </summary>
    public class PrimeNumbers
    {
        private readonly ILog _log;
        public PrimeNumbers()
        {
            const string logFilePath = @"logTask3.log";

            var logManager = new LogManager(logFilePath, typeof(PrimeNumbers).ToString());
            _log = logManager.Logger;
        }

        /// <summary>
        /// Gets prime factors of a number.
        /// </summary>
        /// <param name="number">The number to get prime factors.</param>
        /// <returns></returns>
        public IEnumerable<int> GetPrimeFactors(int number)
        {
            _log.InfoFormat("Entered with arguments (number='{0}')", number);
            try
            {
                if (number < 0)
                    yield break;

                if (IsPrime(number))
                {
                    yield return 1;
                    yield return number;
                    yield break;
                }

                for (int div = 2; div <= number; div++)
                {
                    while (number%div == 0)
                    {
                        yield return div;
                        number = number/div;
                    }
                }
            }
            finally
            {
                _log.InfoFormat("Exited");
            }
        }

        /// <summary>
        /// Determines whether the specified number is a prime or not.
        /// </summary>
        /// <param name="number">The candidate number.</param>
        /// <returns></returns>
        public bool IsPrime(int number)
        {
            _log.InfoFormat("Entered with arguments (number='{0}')", number);
            try
            {
                double boundary = Math.Floor(Math.Sqrt(number));

                if (number <= 1) return false;
                if (number == 2) return true;

                for (int i = 2; i <= boundary; ++i)
                {
                    if (number % i == 0) return false;
                }

                return true;
            }
            finally
            {
                _log.InfoFormat("Exited");
            }
        }

        /// <summary>
        /// Prints the prime factors of a number to console.
        /// </summary>
        /// <param name="number">The candidate number.</param>
        public void PrintPrimeFactorsToConsole(int number)
        {
            _log.InfoFormat("Entered with arguments (number='{0}')", number);
            try
            {
                if (number < 0)
                {
                    _log.ErrorFormat("Number should be between {0} and {1}. Your input is {2}", 0, int.MaxValue, number);
                    return;
                }

                if (number == 1 || number == 0)
                {
                    _log.InfoFormat("{0} is neither a prime nor a composite number", number);
                    return;
                }

                bool isFirstIteration = true;
                foreach (var primeFactor in GetPrimeFactors(number))
                {
                    if (isFirstIteration)
                    {
                        isFirstIteration = false;
                    }
                    else
                    {
                        Console.Write(", ");
                    }

                    Console.Write(primeFactor);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                _log.Error(ex.ToString());
            }
            finally
            {
                _log.InfoFormat("Exited");
            }   
        }

        /// <summary>
        /// Prints the prime factors of a number to console from a file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void PrintPrimeFactorsToConsoleFromFile(string fileName)
        {
            _log.InfoFormat("Entered with arguments (fileName='{0}')", fileName);
            try
            {
                using (var file = new StreamReader(fileName))
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        try
                        {
                            PrintPrimeFactorsToConsole(int.Parse(line));
                        }
                        catch (FormatException ex)
                        {
                            _log.Error(ex.Message);
                            _log.ErrorFormat("Could not parse '{0}' to Int32", line);
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.Message);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                _log.Error(ex.Message);
                _log.Error(ex.ToString());
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                _log.Error(ex.ToString());
            }
            finally
            {
                _log.InfoFormat("Exited");
            }
        }
    }
}
