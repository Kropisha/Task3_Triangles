// <copyright file="IShape.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task3_Triangles
{
    /// <summary>
    /// The obvious interface for every geometric shape
    /// </summary>
    internal interface IShape
    {
        /// <summary>
        /// Check if the shape correct
        /// </summary>
        /// <returns>Is exist</returns>
        bool IsExist();

        /// <summary>
        /// Set square value
        /// </summary>
        /// <returns>Shape's square</returns>
        double Square();
    }
}