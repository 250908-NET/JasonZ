using System;
using System.Collections.Generic;

namespace _6_FlowControl
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            int temperature = -41;
            while (true)
            {
                string maybeTemp = Console.ReadLine();
                if (int.TryParse(maybeTemp, out temperature) && temperature >= -40 && temperature <= 135)
                {
                    return temperature;
                }
            }
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            // this is the greatest thing since sliced bread.
            string advice = temp switch
            {
                < -20 => "hella cold",
                < 0 => "pretty cold",
                < 20 => "cold",
                < 40 => "thawed out",
                < 60 => "feels like Autumn",
                < 80 => "perfect outdoor workout temperature",
                < 90 => "niiice",
                < 100 => "hella hot",
                < 135 => "hottest",
                _ => "you are going to die.",
            };

            Console.WriteLine(advice);
        }

        static Dictionary<string, string> creds = new Dictionary<string, string>();

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();

            Console.Write("enter password: ");
            string password = Console.ReadLine();

            creds[username] = password;
            Console.WriteLine("saved!");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();

            Console.Write("enter password: ");
            string password = Console.ReadLine();

            return creds.ContainsKey(username) && creds[username] == password;
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            string advice = temp switch
            {
                <= 42 => $"{temp} is too cold!",
                <= 78 => $"{temp} is an ok temperature",
                _ => $"{temp} is too hot!",
            };

            Console.WriteLine(advice);
        }
    }//EoP
}//EoN
