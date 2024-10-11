using gym;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym
{
    internal class FitnessProgram
    {
       private int fitnessProgramId {  get; set; }

       private string title { get; set; }

       private string duration {  get; set; }

       private string price {  get; set; }

        public FitnessProgram(int fitnessProgramId, string title, string duration, string price)
        {
            this.fitnessProgramId = fitnessProgramId;
            this.title = title;
            this.duration = duration;
            this.price = price;
        }
        public override string ToString()
        {
            return $"fitnessProgramId: {fitnessProgramId}, Title: {title}, Duration: {duration}, Price: {price}";
        }

        public void print(int fitnessProgramId, string title, string duration, string price)
        {
            var FitnessProgram1 = new FitnessProgram(fitnessProgramId = 1, title = "Beginners YOGA ", duration = "3 months ", price = "10");
            Console.WriteLine(FitnessProgram1);
            Console.Read();
        }
       
    }


    //public void CreateFitnessProgram(string title, string duration, decimal price)
    //{
    //    var newProgram = new FitnessProgram(this.id, title, duration, price);
    //    fitnessPrograms.Add(newProgram);
    //    id++;
    //    Console.WriteLine("Program added successfully");
    //}
}