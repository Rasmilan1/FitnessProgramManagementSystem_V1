//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace gym
//{
//    internal class test
//    {
//    }
//}


//namespace gym_console
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string masterDbConnectionString = "Server=ACER\\SQLEXPRESS; Database=master; Trusted_Connection=True; TrustServerCertificate=True;";
//            string fitnessDbConnectionString = "Server=ACER\\SQLEXPRESS; Database=FitnessProgramManagement; Trusted_Connection=True; TrustServerCertificate=True;";

//            string createDatabaseQuery = @"
//                    IF NOT EXISTS (SELECT * FROM sys.databases WHERE name= 'FitnessProgramManagement')
//                    CREATE DATABASE FitnessProgramManagement;";

//            string createTableQuery = @"
//                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FitnessPrograms' AND xtype='U')
//                    CREATE TABLE FitnessPrograms(
//                        FitnessProgramId INT IDENTITY(1,1) PRIMARY KEY,
//                        Title NVARCHAR(100) NOT NULL,
//                        Duration NVARCHAR(50) NOT NULL,
//                        Price DECIMAL(10,2) NOT NULL
//                    ); ";

//            string insertQuery = @"INSERT INTO FitnessPrograms (Title,Duration,Price)
//                    VALUES ('Weight Training', '6 months', 10.00);";

//            try
//            {
//                using (SqlConnection connection = new SqlConnection(masterDbConnectionString))
//                {
//                    connection.Open();
//                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
//                    {
//                        command.ExecuteNonQuery();
//                        Console.WriteLine("Database created successfully");

//                    }
//                }

//                using (SqlConnection connection = new SqlConnection(fitnessDbConnectionString))
//                {
//                    connection.Open();
//                    using (SqlCommand command1 = new SqlCommand(createTableQuery, connection))
//                    {
//                        command1.ExecuteNonQuery();
//                        Console.WriteLine("The table created");
//                    }

//                    /* using (SqlCommand command2 = new SqlCommand(insertQuery, connection))
//                     {
//                         command2.ExecuteNonQuery();
//                         Console.WriteLine("Sample data added successfully");
//                         Console.WriteLine("operation complete");

//                     }*/
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            //Console.ReadKey();
//            //ques11
//            /*FitnessProgram progrm1 = new IndividualFitnessProgram(88, "running", "6 month", 500, "annual", true);
//            FitnessProgram progrm2 = new GroupFitnessProgram(88, "running", "6 month", 500, "morning", 10);
//            Console.WriteLine(progrm1.DisplayFitnessProgramInfo());
//            Console.WriteLine(progrm2.DisplayFitnessProgramInfo());
//            Console.ReadKey();*/


//            var manager = new FitnessProgramManager();
//            var repository = new FitnessProgramRepository();
//            bool exit = false;
//            while (!exit)
//            {
//                Console.Clear();
//                Console.WriteLine("\nFitness Program Management System: ");
//                Console.WriteLine("1. Add a FitnessProgram");
//                Console.WriteLine("2. View All FitnessPrograms");
//                Console.WriteLine("3. Update a FitnessProgram");
//                Console.WriteLine("4. Delete a FitnessProgram");
//                Console.WriteLine("5. View Program By ID: ");
//                Console.WriteLine("6. Exit");
//                Console.Write("Choose an option: ");
//                string option = Console.ReadLine();

//                switch (option)
//                {
//                    case "1":
//                        Console.Clear();
//                        CreateFitnessProgram(manager, repository);
//                        break;
//                    case "2":
//                        Console.Clear();
//                        //manager.ReadFitnessPrograms();
//                        ViewAllPrograms(repository);
//                        break;
//                    case "3":
//                        Console.Clear();
//                        UpdateFitnessProgram(manager, repository);
//                        break;
//                    case "4":
//                        Console.Clear();
//                        DeleteFitnessProgram(manager, repository);
//                        break;
//                    case "5":
//                        Console.Clear();
//                        GetProgramByID(repository);
//                        break;
//                    case "6":
//                        Console.Clear();
//                        exit = true;
//                        break;
//                    default:
//                        Console.WriteLine("Invalid option. Please try again.");
//                        break;
//                }
//                if (!exit)
//                {
//                    Console.WriteLine("\nPress Enter to continue...");
//                    Console.ReadLine(); // Pause for user to see the result before clearing

//                }

//            }

//        }

//        static void CreateFitnessProgram(FitnessProgramManager manager, FitnessProgramRepository repository)
//        {
//            Console.WriteLine("Enter FitnessProgram Title:");
//            string title = Console.ReadLine();
//            Console.WriteLine("Enter FitnessProgram Duration:");
//            string duration = Console.ReadLine();
//            //Console.WriteLine("Enter FitnessProgram Price:");
//            //decimal price = decimal.Parse(Console.ReadLine());
//            decimal price = manager.ValidateFitnessProgramPrice();

//            //manager.CreateFitnessProgram(title, duration, price);
//            repository.CreateFitnessProgram(title, duration, price);
//        }

//        static void UpdateFitnessProgram(FitnessProgramManager manager, FitnessProgramRepository repository)
//        {
//            Console.WriteLine("Enter the FitnessProgram ID to update:");
//            int id = int.Parse(Console.ReadLine());
//            Console.WriteLine("Enter new Title:");
//            string title = Console.ReadLine();
//            Console.WriteLine("Enter new Duration:");
//            string duration = Console.ReadLine();
//            //Console.WriteLine("Enter new Price:");
//            //decimal price = decimal.Parse(Console.ReadLine());
//            decimal price = manager.ValidateFitnessProgramPrice();

//            //manager.UpdateFitnessProgram(id, title, duration, price);
//            repository.UpdateFitnessProgram(id, title, duration, price);
//        }

//        static void DeleteFitnessProgram(FitnessProgramManager manager, FitnessProgramRepository repository)
//        {
//            Console.WriteLine("Enter the FitnessProgram ID to delete:");
//            int id = int.Parse(Console.ReadLine());

//            //manager.DeleteFitnessProgram(id);
//            repository.DeleteFitnessProgram(id);
//        }

//        static void GetProgramByID(FitnessProgramRepository repository)
//        {
//            Console.WriteLine("Enter the FitnessProgram ID to view:");
//            int id = int.Parse(Console.ReadLine());
//            FitnessProgram program = repository.GetProgramByID(id);
//            if (program != null)
//            {
//                Console.WriteLine(program.ToString());
//            }
//            else
//            {
//                Console.WriteLine("Program not found");
//            }
//        }
//        static void ViewAllPrograms(FitnessProgramRepository repository)
//        {
//            List<FitnessProgram> programs = repository.GetAllPrograms();
//            if (programs.Count == 0)
//            {
//                Console.WriteLine("No programs available");
//            }
//            else
//            {
//                foreach (var program in programs)
//                {
//                    Console.WriteLine(program.ToString());
//                }
//            }
//        }
//    }



//    internal class FitnessProgram
//    {
//        public static int TotalFitnessPrograms { get; private set; } = 0;
//        public int FitnessProgramId { get; set; }
//        public string Title { get; set; }
//        public string Duration { get; set; }
//        public decimal Price { get; set; }

//        public FitnessProgram(int fitnessProgramId, string title, string duration, decimal price)
//        {
//            FitnessProgramId = fitnessProgramId;
//            Title = title;
//            Duration = duration;
//            Price = price;
//            TotalFitnessPrograms++;
//        }
//        public override string ToString()
//        {
//            return $"ID: {FitnessProgramId}, Title: {Title}, Duration: {Duration}, Price: {Price}";
//        }

//        public virtual string DisplayFitnessProgramInfo()
//        {
//            return $"ID: {FitnessProgramId}, Title: {Title}, Duration: {Duration}, Price: {Price}";
//        }
//    }


//    internal class FitnessProgramManager
//    {
//        private List<FitnessProgram> fitnessPrograms;
//        private int id = 1;

//        public FitnessProgramManager()
//        {
//            fitnessPrograms = new List<FitnessProgram>();
//        }

//        public void CreateFitnessProgram(string title, string duration, decimal price)
//        {
//            var newProgram = new FitnessProgram(this.id, title, duration, price);
//            fitnessPrograms.Add(newProgram);
//            id++;
//            Console.WriteLine("Program added successfully");
//        }

//        public void ReadFitnessPrograms()
//        {
//            if (fitnessPrograms.Count == 0)
//            {
//                Console.WriteLine("No programs available");
//                return;
//            }
//            else
//            {
//                Console.WriteLine("List of fitness programs");
//                foreach (var fitnessProgram in fitnessPrograms)
//                {

//                    Console.WriteLine(fitnessProgram.ToString());

//                }
//            }
//        }

//        public void UpdateFitnessProgram(int id, string title, string duration, decimal price)
//        {
//            var findedProgram = fitnessPrograms.Find(p => p.FitnessProgramId == id);
//            if (findedProgram != null)
//            {
//                findedProgram.Title = title;
//                findedProgram.Duration = duration;
//                findedProgram.Price = price;
//                Console.WriteLine("Program updated Successfully");
//            }
//            else
//            {
//                Console.WriteLine($"Program not found with id: {id}");
//            }
//        }

//        public void DeleteFitnessProgram(int id)
//        {
//            var findedProgram = fitnessPrograms.Find(p => p.FitnessProgramId == id);
//            fitnessPrograms.Remove(findedProgram);
//            Console.WriteLine("Program deleted successfully");
//        }

//        public decimal ValidateFitnessProgramPrice()
//        {
//            decimal price;
//            while (true)
//            {
//                Console.Write("Enter the program price: ");
//                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
//                {
//                    return price;
//                }
//                Console.WriteLine("Invalid price!!, Please enter the valid price");
//            }
//        }
//    }












//    internal class FitnessProgramRepository
//    {
//        string connectionString = "Server=ACER\\SQLEXPRESS; Database=FitnessProgramManagement; Trusted_Connection=True; TrustServerCertificate=True;";

//        public string Capitalize(string value)
//        {
//            string[] words = value.Split(' ');
//            for (int i = 0; i < words.Length; i++)
//            {
//                if (words[i].Length > 0)
//                {
//                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
//                }
//            }
//            return string.Join(" ", words);
//        }
//        public void CreateFitnessProgram(string title, string duration, decimal price)
//        {

//            try
//            {
//                string insertQuery = @"INSERT INTO FitnessPrograms (Title, Duration, Price) VALUES (@title, @duration, @price)";
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    string capitalizeTitle = Capitalize(title);
//                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@title", capitalizeTitle);
//                        cmd.Parameters.AddWithValue("@duration", duration);
//                        cmd.Parameters.AddWithValue("@price", price);
//                        cmd.ExecuteNonQuery();
//                        Console.WriteLine("Program added successfully");
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }

//        public void UpdateFitnessProgram(int id, string title, string duration, decimal price)
//        {
//            string updateQuery = @"UPDATE FitnessPrograms SET Title=@title, Duration=@duration, Price=@price WHERE FitnessProgramId=@id";
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string capitalizeTitle = Capitalize(title);
//                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
//                {
//                    cmd.Parameters.AddWithValue("@title", capitalizeTitle);
//                    cmd.Parameters.AddWithValue("@duration", duration);
//                    cmd.Parameters.AddWithValue("@price", price);
//                    cmd.Parameters.AddWithValue("@id", id);
//                    cmd.ExecuteNonQuery();
//                    Console.WriteLine("Program updated successfully");
//                }
//            }
//        }

//        public void DeleteFitnessProgram(int id)
//        {
//            string deleteQuery = @"DELETE FROM FitnessPrograms WHERE FitnessProgramId=@id";
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
//                {
//                    cmd.Parameters.AddWithValue("@id", id);
//                    cmd.ExecuteNonQuery();
//                    Console.WriteLine("prgram deleted successfully");
//                }
//            }
//        }

//        public FitnessProgram GetProgramByID(int id)
//        {
//            FitnessProgram program = null;

//            try
//            {
//                string selectQuery = @"SELECT FitnessProgramId,Title,Duration,Price FROM FitnessPrograms WHERE FitnessProgramId=@id";
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@id", id);
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            if (reader.Read())
//                            {
//                                int programid = reader.GetInt32(0);
//                                string title = reader.GetString(1);
//                                string duration = reader.GetString(2);
//                                decimal price = reader.GetDecimal(3);
//                                program = new FitnessProgram(programid, title, duration, price);
//                            }
//                        }

//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//            return program;

//        }

//        public List<FitnessProgram> GetAllPrograms()
//        {
//            var programs = new List<FitnessProgram>();
//            try
//            {
//                string selectAllQuery = @"SELECT * FROM FitnessPrograms";
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand(selectAllQuery, conn))
//                    {
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                int programid = reader.GetInt32(0);
//                                string title = reader.GetString(1);
//                                string duration = reader.GetString(2);
//                                decimal price = reader.GetDecimal(3);
//                                programs.Add(new FitnessProgram(programid, title, duration, price));
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//            return programs;
//        }
//    }
//}