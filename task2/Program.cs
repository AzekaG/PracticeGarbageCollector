using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{

    enum TypeofShop
    {
        Products=1,
        Hardware ,
        clothing,
        shoe

    }
    class Shop : IDisposable
    {
       
        public string NameShop { get; set; }
        public string AdressShop { get; set; }

        public TypeofShop Type { get; set; }
        public Shop() { SetInfo(); }
        public void SetInfo()
        {


            Console.WriteLine("Enter a Name of shop : ");
            NameShop = Console.ReadLine();
            Console.WriteLine("Enter a Adress of shop : ");
            AdressShop = Console.ReadLine();
            Console.WriteLine("Choose type of shop :  " + "\n1-Product" + "\n2-Hardware" + "\n3 -Clothing " + "\n4-shoe");
            Type = new TypeofShop();
            Type = (TypeofShop)int.Parse(Console.ReadLine());


        }


        bool isDisposed = false;
        private void Cleaning(bool dispoding)
        {
            if (!isDisposed)
            {
                if (dispoding)
                {
                    Console.WriteLine("Очистка управляемых ресурсов");
                }
                Console.WriteLine("Очистка неуправляемых ресурсов");
            }
            isDisposed = true;

        }
        public void OutputInfo()
        {
            Console.WriteLine("Name of shop : " + NameShop + "\nType of shop : " + Type + "\nAdress of shop  : " + AdressShop);
        }
        public void Dispose() 
        {
            Cleaning(true);
            GC.SuppressFinalize(this);
        
        }
        ~Shop()
        {
           
            Dispose(); 
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {

            using (Shop shop = new Shop()) 
            {
                shop.OutputInfo();
               shop.Dispose();
            }
        }
    }
}
