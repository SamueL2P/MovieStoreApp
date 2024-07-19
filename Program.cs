using MovieStoreApp.Models;

namespace MovieStoreApp
{
    internal class Program
    {
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to movie store developed by : Samuel\n" +
                    "1. Add new Movie\n" +
                    "2. Display All Movies\n" +
                    "3. Find Movie by Id\n" +
                    "4. Update Movie\n"+
                    "5. Remove Movie by Id\n" +
                    "6. Clear All Movies\n" +
                    "7. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);
            }
        }

        static void DoTask(int choice) {

            switch (choice) {
                case 1:
                    AddNewMovie();
                    break;
                case 2:
                    if(movies.Count == 0)
                        Console.WriteLine("No Movies to Display");
                    else 
                        movies.ForEach(movie => Console.WriteLine(movie));
                    break;
                case 3:
                    Movie findMovie = FindMovieById();
                    if (findMovie != null)
                        Console.WriteLine(findMovie);
                    else
                        Console.WriteLine("Movie not Found !");
                    break;
                case 4:
                    UpdateMovieDetails();
                    break;

                case 5:
                    RemoveMovie();
                    break;
                case 6:
                    if(movies.Count == 0)
                        Console.WriteLine("Movie List Already Empty ");
                    else
                        movies.Clear();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please Enter a valid Input!");
                    break;


            }

        }

        static void RemoveMovie()
        {
            Movie findMovie = FindMovieById();
            if(findMovie != null)
            {   
                movies.Remove(findMovie);
                Console.WriteLine("Movie Removed Successfully!"); 
            }
            else
                Console.WriteLine("Movie Not Found");
        }


        static void UpdateMovieDetails()
        {
            Movie findMovie = FindMovieById();
            if(findMovie == null)
                Console.WriteLine("Movie Not Found !");
            else
            {
                Console.WriteLine("Which field do you want to update ?");
                Console.WriteLine("1. Id \n2. Name\n3. Year Of Release \n4. Genre");
                int choice = Convert.ToInt32(Console.ReadLine());
                UpdateMovieField(choice , findMovie);
                
            }
        }

        static void UpdateMovieField(int choice ,Movie findMovie) {
            switch (choice) {
                case 1:
                    Console.WriteLine("Enter Updated Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    findMovie.Id = id;
                    Console.WriteLine("Moive id updated successfully");
                    break;
                case 2:
                    Console.WriteLine("Enter Updated Name");
                    string name = (Console.ReadLine());
                    findMovie.Name = name;
                    Console.WriteLine("Moive Name updated successfully");
                    break;
                case 3:
                    Console.WriteLine("Enter Updated Id");
                    int year= Convert.ToInt32(Console.ReadLine());
                    findMovie.YearOfRelease = year;
                    Console.WriteLine("Moive Year Of Release updated successfully");
                    break;
                case 4:
                    Console.WriteLine("Enter Updated Genre");
                    string genre = Console.ReadLine();
                    findMovie.Genre = genre;
                    Console.WriteLine("Moive Genre updated successfully");
                    break;
                default:
                    Console.WriteLine("Enter Field Properly");
                    break;
            }
        }


        static void AddNewMovie()
        {
            if(movies.Count() == 5)
            {
                Console.WriteLine("Cannot add movie . Store limit Exceeded");
            }
            else
            {
                Console.WriteLine("Enter Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Year Of Release : ");
                int yearOfRelease = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Genre : ");
                string genre = Console.ReadLine();
                Movie newMovie = Movie.CreateMovie(id, name, yearOfRelease, genre);
                movies.Add(newMovie);
                Console.WriteLine("New Movie Added Successfully");

            }
            
        }

        public static Movie FindMovieById() {
            Movie findMovie = null;
            Console.WriteLine("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            findMovie = movies.Where(item  => item.Id == id).FirstOrDefault();
            return findMovie;
        }
    }
}
