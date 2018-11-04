// <copyright file="BusinessLogic.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task3_Triangles
{
    using System;
    using System.IO;

    /// <summary>
    /// This class for logic of my program
    /// </summary>
    internal class BusinessLogic
    {
        /// <summary>
        /// Types of user choice
        /// </summary>
        public enum UsersAction
        {
            /// <summary>
            /// Represents a reference
            /// </summary>
            Help = 1,

            /// <summary>
            /// Represents a start
            /// </summary>
            Program,

            /// <summary>
            /// Represents an exit
            /// </summary>
            Quit
        }

        /// <summary>
        /// Check the side of envelop
        /// </summary>
        /// <param name="side">Envelop`s side</param>
        /// <returns>Is this side correct</returns>
        public static bool IsCorrect(double side)
        {
            return side > 0;
        }
    }
}
