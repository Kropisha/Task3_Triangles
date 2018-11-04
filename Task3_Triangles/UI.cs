// <copyright file="UI.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task3_Triangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ShowMenuLib;

    /// <summary>
    /// Present visualization for user
    /// </summary>
    public class UI : GetMenu
    {
        /// <summary>
        /// Dictionary with triangles
        /// </summary>
       private SortedDictionary<double, string> triangles;

        /// <summary>
        /// Show menu 
        /// </summary>
        /// <param name="type"> The header-line of menu </param>
        /// <returns>user choice</returns>
       public override char ShowMenu(string type)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(type);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           1.Help                 ");
            Console.WriteLine("           2.Do it                ");
            Console.WriteLine("           3.Quit                 ");
            Console.WriteLine();
            Console.WriteLine(" What is your choice? [tap number]");

            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// For correct initialize each side
        /// </summary>
        /// <param name="side">Triangle`s side</param>
        /// <param name="value">Triangle`s side cutting from line</param>
        /// <returns>Is this side correct</returns>
        public bool IsException(ref double side, string value)
        {
            bool isOk = true;
            try
            {
                string helper = value;
                if (helper.Contains("."))
                {
                    helper = helper.Replace(".", ",");
                }

                side = double.Parse(helper);
                
                if (!BusinessLogic.IsCorrect(side))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Where did you see side in negative range?");
                    Console.Beep();
                    isOk = false;
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();       
                }
            }
            catch (FormatException ex)
            {               
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Write a number." + ex.Message);
                Console.Beep();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.ResetColor();
                isOk = false;
            }

            return isOk;
        }

        /// <summary>
        /// Menu actions
        /// </summary>
        /// <param name="i">Not used</param>
        public override void UserChoice(int i)
        {
            BusinessLogic.UsersAction action;
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(this.ShowMenu(" Welcome to the envelops analyzer!").ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case BusinessLogic.UsersAction.Help:
                        Help helper = new Help();
                        Console.WriteLine(helper.References(@"..\..\Files\TrianRef.txt"));
                        Console.ReadKey();
                        break;
                    case BusinessLogic.UsersAction.Program:
                        this.TaskWithTriangles();
                        break;
                    case BusinessLogic.UsersAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
            while (action != BusinessLogic.UsersAction.Quit);
        }

        /// <summary>
        /// Do task
        /// </summary>
        private void TaskWithTriangles()
        {
            this.triangles = new SortedDictionary<double, string>();
            Dictionary<string, double> trianglesDictionary = new Dictionary<string, double>();
            bool isContinue = true;
            while (isContinue)
            {
                double firstSide = 1.0;
                double secondSide = 1.0;
                double thirdSide = 1.0;
                string name = " ";
                string[] contains = null;
                string key;
                char condition = 'n';
                do
                {
                    Console.WriteLine("Enter the triangle: ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(" [name,first side,second side,third side]\n [Triangle 1,5,3.2,6.8]");
                    Console.ResetColor();
                    string input = Console.ReadLine();
                    bool isGood = true;
                    try
                    {
                        contains = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        name = contains[0];
                        if (!this.IsException(ref firstSide, contains[1]))
                        {
                            isGood = false;
                            break;
                        }

                        if (!this.IsException(ref secondSide, contains[2]))
                        {
                            isGood = false;
                            break;
                        }

                        if (!this.IsException(ref thirdSide, contains[3]))
                        {
                            isGood = false;
                            break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        isGood = false;
                        Console.WriteLine("It is something strange...Please, follow the example!");
                    }

                    if (isGood)
                    {
                        Triangle triang = new Triangle(firstSide, secondSide, thirdSide);
                        if (triang.IsExist())
                        {
                            try
                            {
                                this.triangles.Add(triang.Square(), name);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Triangle with this sides already exist.");
                            }

                            try
                            {
                                trianglesDictionary.Add(name, triang.Square());
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Triangle with this name already exist.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This triangle with your sides does not exist.");
                        }
                    }

                    Console.WriteLine("Do you want to continue?['y' or 'yes' if you want]");
                    key = Console.ReadLine();
                    try
                    {
                        condition = key.ToLower().First();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Be attentive!");
                        Console.Beep();
                        Console.ReadLine();
                    }
                }
                while (condition == 'y');
                isContinue = false;
                break;
            }

            var trianglesSortedDictionary = from entry in trianglesDictionary orderby entry.Value descending select entry;
            this.triangles = this.InitializeDictionary();
            Console.WriteLine("============= triangles list: ===============");
            int i = 1;
            foreach (var tr in this.triangles)
            {
                Console.WriteLine($"{i}. [{tr.Value}]: {Math.Round(tr.Key, 3)} cm");
                i++;
            }

            Console.WriteLine("============= Second variant : ===============");
            int k = 1;
            foreach (var trian in trianglesSortedDictionary)
            {
                Console.WriteLine($"{k}. [{trian.Key}]: {Math.Round(trian.Value, 3)} cm");
                k++;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// For initialization and sorting dictionary
        /// </summary>
        /// <returns>Sorted dictionary</returns>
        private SortedDictionary<double, string> InitializeDictionary()
        {
            SortedDictionary<double, string> dict = new SortedDictionary<double, string>();

            dict = new SortedDictionary<double, string>(
            new ReverseComparer<double>(Comparer<double>.Default));

            foreach (var tr in this.triangles)
            {
                dict.Add(tr.Key, tr.Value);
            }

            return dict;
        }
    }
}
