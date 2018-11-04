// <copyright file="Program.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task3_Triangles
{
    using System;

    /// <summary>
    /// This class is for User Interface
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point to the program
        /// </summary>
        /// <param name="args">Args of command line</param>
        internal static void Main(string[] args)
        {
            Console.Title = " Triangles [Yuliia Kropyvna]";
            UI user = new UI();
            user.UserChoice(0);
        }
    }
}
