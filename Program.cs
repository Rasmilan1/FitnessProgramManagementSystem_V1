using gym;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var manager = new FitnessProgramManager();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\nFitness Program Management System: ");
                Console.WriteLine("1. Add a FitnessProgram");
                Console.WriteLine("2. View All FitnessPrograms");
                Console.WriteLine("3. Update a FitnessProgram");
                Console.WriteLine("4. Delete a FitnessProgram");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        CreateFitnessProgram(manager);
                        break;
                    case "2":
                        Console.Clear();
                        //ViewAllPrograms();

                        break;
                    case "3":
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        DeleteFitnessProgram();
                        break;
                    case "5":
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine(); // Pause for user to see the result before clearing

                }

            }
        }




        static void CreateFitnessProgram(FitnessProgramManager manager)

        {
            Console.WriteLine("---ADD PROGRAMS---");
            Console.WriteLine("Enter FitnessProgram Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter FitnessProgram Duration:");
            string duration = Console.ReadLine();
            Console.WriteLine("Enter FitnessProgram Price:");
            string price = Console.ReadLine();

            //manager.CreateFitnessProgram(title, duration, price);
        }

        //static void ViewAllPrograms()
        //{
        //    List<FitnessProgram> programs = repository.GetAllPrograms();
        //    if (programs.Count == 0)
        //    {
        //        Console.WriteLine("No programs available");
        //    }
        //    else
        //    {
        //        foreach (var program in programs)
        //        {
        //            Console.WriteLine(program.ToString());
        //        }
        //    }
        //}

        static void UpdateFitnessProgram()
        {
            Console.WriteLine("Enter the FitnessProgram ID to update:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter new Duration:");
            string duration = Console.ReadLine();
            //Console.WriteLine("Enter new Price:");
            //decimal price = decimal.Parse(Console.ReadLine());
            string price =Console.ReadLine();

            //manager.UpdateFitnessProgram(id, title, duration, price);
        }

        static void DeleteFitnessProgram()
        {
            Console.WriteLine("Enter the FitnessProgram ID to delete:");
            int id = int.Parse(Console.ReadLine());

        }


    }

}
