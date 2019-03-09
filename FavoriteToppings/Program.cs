using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FavoriteToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText(@"pizzas.json"));
            var bestPizzas = new List<Pizza>();
            var counter = 0;
            foreach(Pizza pizza in pizzas)
            {
                var sameToppingsNumber = pizzas.FindAll(curPizza => curPizza.Toppings.Count == pizza.Toppings.Count);
                var sameToppings = 0;
                foreach(Pizza curPizza in sameToppingsNumber)
                {
                    counter = 0;
                    for (var i = 0; i < curPizza.Toppings.Count; i++)
                    {
                        if (curPizza.Toppings[i] == pizza.Toppings[i])
                        {
                            counter++;
                        }
                    }
                    if (counter == pizza.Toppings.Count)
                    {
                        sameToppings++;
                    }
                }
                for (var i = 0; i < 20; i++)
                {
                    var dontAdd = false;
                    foreach (Pizza curPizza in bestPizzas)
                    {
                        counter = 0;
                        for (var j = 0; j < curPizza.Toppings.Count; j++)
                        {
                            if (curPizza.Toppings.Count == pizza.Toppings.Count)
                            {
                                if (curPizza.Toppings[j] == pizza.Toppings[j])
                                {
                                    counter++;
                                }
                            }
                            
                        }
                        if (counter == pizza.Toppings.Count)
                        {
                            dontAdd = true;
                            break;
                        }
                    }
                    if (bestPizzas.Count > i & dontAdd == false)
                    {
                        if (sameToppings > bestPizzas[i].Popularity)
                        {
                            bestPizzas.Add(pizza);
                            bestPizzas[i].Popularity = sameToppings;
                            break;
                        }
                    } else if (dontAdd == false)
                    {
                        bestPizzas.Add(pizza);
                        bestPizzas[i].Popularity = sameToppings;
                        break;
                    }
                    
                }      
            }

            var finalizedBest = bestPizzas.Take(20);
            
            foreach(Pizza curPizza in finalizedBest)
            {
                foreach (string topping in curPizza.Toppings)
                {
                    Console.WriteLine(topping);
                }
                Console.WriteLine(Environment.NewLine + $"Ordered {curPizza.Popularity} times" + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
