// <copyright file="ReverseComparer.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task3_Triangles
{
    using System.Collections.Generic;

    /// <summary>
    /// This class for dictionary reversing
    /// </summary>
    /// <typeparam name="T">Your value type</typeparam>
    internal sealed class ReverseComparer<T> : IComparer<T>
    {
        /// <summary>
        /// base value for comparing
        /// </summary>
        private readonly IComparer<T> original;

        /// <summary>
        /// Initializes a new instance of the <see cref="{ReverseComparer}"/> class
        /// </summary>
        /// <param name="original">standard value</param>
        public ReverseComparer(IComparer<T> original)
        {
            // TODO: Validation
            this.original = original;
        }

        /// <summary>
        /// Compare values
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>changing values</returns>
        public int Compare(T left, T right)
        {
            return this.original.Compare(right, left);
        }
    }
}
