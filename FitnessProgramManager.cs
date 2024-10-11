using gym;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym
{
    internal class FitnessProgramManager
    {
        private List<FitnessProgram> fitnessPrograms;
        public int id = 1; //i changed id type string to int

        public FitnessProgramManager()
        {
            fitnessPrograms = new List<FitnessProgram>();
            
        }

        public void CreateFitnessProgram(int id, string title, string duration, string price)
        {
            var newProgram = new FitnessProgram(id, title, duration, price);
            fitnessPrograms.Add(newProgram);
            id++; //i changed id type string to int

            Console.WriteLine("Program added successfully");
        }

        public void ReadFitnessPrograms()
        {
            if (fitnessPrograms.Count == 0)
            {
                Console.WriteLine("No programs available");
                return;
            }
            else
            {
                Console.WriteLine("List of fitness programs");
                foreach (var fitnessProgram in fitnessPrograms)
                {

                    Console.WriteLine(fitnessProgram.ToString());

                }
            }
        }

        //public void UpdateFitnessProgram(int id, string title, string duration, string price)
        //{
        //    var findedProgram = fitnessPrograms.Find(p => p.id == id);
        //    if (findedProgram != null)
        //    {
        //        findedProgram.ti = title;
        //        findedProgram.duration = duration;
        //        findedProgram.price = price;
        //        Console.WriteLine("Program updated Successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Program not found with id: {id}");
        //    }
        //}

        //public void DeleteFitnessProgram(string id)
        //{
        //    var findedProgram = fitnessPrograms.Find(p => p. == id);
        //    fitnessPrograms.Remove(findedProgram);
        //    Console.WriteLine("Program deleted successfully");
        //}


    }
}

