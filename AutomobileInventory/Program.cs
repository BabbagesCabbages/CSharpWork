using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Automobile1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList inventory = new ArrayList();

            Automobile a1 = new Automobile();
            a1.Year = 2000;
            a1.Make = "Dodge";
            a1.Model = "ram";
            a1.Miles = 5000;
            a1.ExteriorColor = "red";
            Automobile a2 = new Automobile();
            a2.Year = 2001;
            a2.Make = "Dodge1";
            a2.Model = "ram1";
            a2.Miles = 50000;
            a2.ExteriorColor = "red1";
            Automobile a3 = new Automobile();
            a3.Year = 2002;
            a3.Make = "Dodge2";
            a3.Model = "ram2";
            a3.Miles = 500000;
            a3.ExteriorColor = "red2";
            Automobile a4 = new Automobile();
            a4.Year = 2003;
            a4.Make = "Dodge3";
            a4.Model = "ram3";
            a4.Miles = 5000000;
            a4.ExteriorColor = "red3";
            Automobile a5 = new Automobile();
            a5.Year = 2004;
            a5.Make = "Dodge4";
            a5.Model = "ram4";
            a5.Miles = 50000000;
            a5.ExteriorColor = "red4";

            inventory.Add(a1);
            inventory.Add(a2);
            inventory.Add(a3);
            inventory.Add(a4);
            inventory.Add(a5);

            Console.WriteLine("Our inventory includes :\n");

            foreach (object item in inventory)
            {
                Automobile auto = (Automobile)item;
                auto.Print();
            }

            Console.WriteLine("Our special promotion car is:");
            Automobile promoAuto = (Automobile)inventory[1];
            promoAuto.Print();

            Console.ReadLine();



            Automobile a6 = new Automobile();
            a6.Year = 2004;
            a6.Make = "Dodge4";
            a6.Model = "ram4";
            a6.Miles = 50000000;
            a6.ExteriorColor = "red4";
            inventory.Insert(3, a6);

            inventory.RemoveAt(2);

            Automobile removeAuto = (Automobile)inventory[1];
            inventory.Remove(removeAuto);
        }
    }
}
