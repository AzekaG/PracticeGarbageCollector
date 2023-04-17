using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeGarbageCollector
{
    internal class Program
    {
     
        class Play: IDisposable
        {
            bool isDisposed = false;
            public string Name { get; set; }
            public string Genre { get; set; }
            public string AuthorName { get; set; }
            public DateTime DateProduction { get; set; }

            public Play() { }
            public Play(string name, string genre, string authorName, DateTime dateProduction)
            {
                Name = name;
                Genre = genre;
                AuthorName = authorName;
                DateProduction = dateProduction;
            }
            private void CleaningPlay(bool disposing)
            {
                if (!isDisposed)
                {
                    if (disposing)
                        Console.WriteLine("release of managed resources");
                    Console.WriteLine("Release of Unmanaged resourses");
                }
                isDisposed= true;
            }
            public void Dispose()
            {
                CleaningPlay(true);
                GC.SuppressFinalize(this);
            }
            public void SetInfo()
            {
                Console.WriteLine("Enter the Name of Play : ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter the Genre of Play : ");
                Genre = Console.ReadLine();
                Console.WriteLine("Enter the AuthorName of Play : ");
                AuthorName = Console.ReadLine();
                Console.WriteLine("Enter the Date Production of Play : dd.mm.yyyy");
                DateProduction = DateTime.Parse(Console.ReadLine());

            }

            public void OutputPlay()
            {
                Console.WriteLine("Name of Play : "+Name + "\nGenre : "+Genre + "\nAuthor Name : "+AuthorName + "\nDate Prod : "+DateProduction.ToShortDateString());
            }
            ~Play() 
            {
                Console.WriteLine("Очистка мусора *");
                CleaningPlay(false);
            }
           
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a datas : ");
          using (Play test = new Play())
            {
                test.SetInfo();
                test.OutputPlay();
            }
        }
    }
}
