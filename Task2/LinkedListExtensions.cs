using System;
using System.Collections.Generic;
using log4net;

namespace Task2
{
    /// <summary>
    /// Represents extension methods for 
    /// a <see cref="LinkedList{T}"/> class.
    /// </summary>
    public static class LinkedListExtensions
    {
        private static readonly ILog _log;
        static LinkedListExtensions()
        {
            const string logFilePath = @"logTask2.log";

            var logManager = new Logger.LogManager(logFilePath, typeof(LinkedListExtensions).ToString());
            _log = logManager.Logger;
        }

        /// <summary>
        /// Seeks for a Nth element of a <see cref="LinkedList{T}"/> 
        /// class from the end of list using only one iteration through 
        /// the presented <see cref="LinkedList{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of a <see cref="LinkedList{T}"/> elements</typeparam>
        /// <param name="linkedList">The instance of a <see cref="LinkedList{T}"/> to search Nth element from the end.</param>
        /// <param name="seekingPosition">The seeking position.</param>
        /// <returns></returns>
        public static LinkedListNode<T> NthToLast<T>(this LinkedList<T> linkedList, int seekingPosition)
        {
            _log.InfoFormat("Entered with arguments (seekingPosition='{0}')", seekingPosition);
            try
            {
                if (linkedList?.First == null || seekingPosition < 1)
                {
                    if (linkedList == null)
                        _log.Warn("Seeking Position could not be reached. LinkedList is null.");

                    if (linkedList?.First == null)
                        _log.Warn("Seeking Position could not be reached. LinkedList has no items.");

                    if (seekingPosition < 1)
                        _log.WarnFormat("Seeking Position could not be reached. Position ({0}) is < 1", seekingPosition);

                    return null;
                }

                LinkedListNode<T> pointer1 = linkedList.First;
                LinkedListNode<T> pointer2 = linkedList.First;
                var iterationCount = 1;

                while (pointer2.Next != null)
                {
                    iterationCount++;

                    if (iterationCount > seekingPosition)
                    {
                        pointer1 = pointer1?.Next;
                    }

                    pointer2 = pointer2.Next;
                }

                if (iterationCount < seekingPosition)
                {
                    _log.WarnFormat("Seeking Position could not be reached. (linkedListSize='{0}', seekingPosition='{1}')",
                        iterationCount, seekingPosition);
                    return null;
                }
                else
                {
                    _log.InfoFormat("Seeking Position found. (seekingValue='{0}')",
                        pointer1.Value);

                    return pointer1;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                _log.Error(ex.ToString());
                return null;
            }
            finally
            {
                _log.InfoFormat("Exited");
            }
            
        }
    }
}
