// <copyright file="Triangle.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task3_Triangles
{
    using System;

    /// <summary>
    /// Represents a triangle
    /// </summary>
    internal class Triangle : IShape
    {
        /// <summary>
        /// First side
        /// </summary>
        private double sideA;

        /// <summary>
        /// Second side
        /// </summary>
        private double sideB;
        
        /// <summary>
        /// Third side
        /// </summary>
        private double sideC;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class 
        /// </summary>
        public Triangle()
        {
            this.sideA = 1;
            this.sideB = 1;
            this.sideC = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class 
        /// </summary>
        /// <param name="sideA">First side</param>
        /// <param name="sideB">Second side</param>
        /// <param name="sideC">Third side</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        /// <summary>
        /// Set square value
        /// </summary>
        /// <returns>Triangle's square</returns>
        public double Square()
        {
            double p = (this.sideA + this.sideB + this.sideC) / 2;
            return Math.Sqrt(p * (p - this.sideA) * (p - this.sideB) * (p - this.sideC));
        }

        /// <summary>
        /// Check if the triangle correct
        /// </summary>
        /// <returns>Is exist</returns>
        public bool IsExist()
        {
            if (this.sideA + this.sideB > this.sideC &&
                this.sideA + this.sideC > this.sideB &&
                this.sideB + this.sideC > this.sideA)
            {
                return true;
            }

            return false;
        }
    }
}
