using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestSonarQube
{
    public class Fruit { }
    public class Orange : Fruit { }
    public class Apple : Fruit { }

    class MyTest
    {
        public void Test()
        {
            var fruitBasket = new List<Fruit>();
            fruitBasket.Add(new Orange());
            fruitBasket.Add(new Orange());
            // fruitBasket.Add(new Apple());  // uncommenting this line will make both foreach below throw an InvalidCastException

            foreach (Fruit fruit in fruitBasket)
            {
                var orange = (Orange)fruit; // This "explicit" conversion is hidden within the foreach loop below
                Console.WriteLine("added fruit");
            }

            foreach (Orange orange in fruitBasket) // Noncompliant
            {
                Console.WriteLine("NonCompliant code.");
            }
        }
    }

    class HttpPrinter
    {
        private string content;

        public async void CallNetwork(string url) //Noncompliant
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            content = await response.Content.ReadAsStringAsync();
        }

        public async Task PrintContent(string url)  // works correctly if web request finishes in under 1 second, otherwise content will be null
        {
            CallNetwork(url);
            await Task.Delay(1000);
            Console.Write(content);
        }
    }
}
