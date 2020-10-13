using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_11_Exercise_Butik
{
    /// <summary>
    /// class Store
    /// </summary>
    static class Store
    {
        private static string _pathProductsCSV = Path.GetTempPath() + "YH-PGBSNH20-Csharp-Session-11-Exercise-Butik_products.csv";
        private static string _pathShoppingBasketCSV = Path.GetTempPath() + "YH-PGBSNH20-Csharp-Session-11-Exercise-Butik_shoppingBasket.csv";
        private static List<Product> Products { get; set; } = new List<Product>();

        public static void ImportProducts()
        {
            // Read from .csv file, and import the products.
            //
            // En produkt ska bestå av serienummer, namn, beskrivning och pris
            //
            // Om en produkt saknar något fält (serienummer, namn, beskrivning eller pris) ska den
            // raden i CSV-filen ignoreras och ett varningsmeddelande skrivas ut för varje felaktig rad.
            // Programmet ska sedan fortsätta som vanligt, med enbart de giltiga produkterna i sortimentet.
            //
            // Om produktfilen inte existerar ska ett användarvänligt felmeddelande skrivas ut och programmet sedan avslutas.
            ////////////////////////////////////////////

            if (File.Exists(_pathProductsCSV))
            {
                string[] allProducts = File.ReadAllLines(_pathProductsCSV);

                foreach (string productCSV in allProducts)
                {
                    string[] productColumns = productCSV.Split(',');

                    if (productColumns.Length < 4)
                    {
                        Console.WriteLine("Malformed product entry, skipping...");
                        continue;
                    }

                    double price;

                    if (!double.TryParse(productColumns[3], out price))
                    {
                        Console.WriteLine("Could not find a price for this product. The product entry is malformed, skipping...");
                        continue;
                    }

                    Product newProduct = new Product
                    {
                        SerialNumber = productColumns[0].Trim(),
                        Name = productColumns[1].Trim(),
                        Description = productColumns[2].Trim(),
                        Price = price
                    };

                    Store.Products.Add(newProduct);
                }

                if (Store.Products.Count > 0)
                {
                    Console.WriteLine($"Succesfully imported {Store.Products.Count} products");
                }
                else
                {
                    Console.WriteLine("No products were imported, the '.csv'-database is either empty or malformed.");
                }
            }
            else
            {
                //Console.WriteLine("The product-file cannot be found!");
                //Console.WriteLine("Technical difficulties :(\nWe'll have it fixed in a jiffy!");
                Console.WriteLine("You dumbass,\nwhy do you not have the database of the products we sell on your PC?");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// A Tuple&lt;string[], string[]&gt; with a header array; containing the header text and a separator line,
        /// and an array of each <![CDATA[<see cref="Product"/>]]>
        /// </returns>
        public static (string[], string[]) CreateProductsOutput()
        {
            int width_1stColumn = Store.Products.Select(p => p.SerialNumber).Append("SerialNumber").Max(s => s.Length) + 2;
            int width_2ndColumn = Store.Products.Select(p => p.Name).Append("Name").Max(s => s.Length) + 2;
            int width_3rdColumn = Store.Products.Select(p => p.Description).Append("Description").Max(s => s.Length) + 2;
            int width_4thColumn = Store.Products.Select(p => p.Price.ToString()).Append("Price").Max(s => s.Length) + 2;

            // This string sets the column widths.
            //string s = $"{{0,-{width_1stColumn}}}" + $"{{1,-{width_2ndColumn}}}" + $"{{2,-{width_3rdColumn}}}{{3}}";
            string s = "{0," + -width_1stColumn + "}{1," + -width_2ndColumn + "}{2," + -width_3rdColumn + "}{3}";
            // Header-string
            string[] header = new[]
            {
                // Header
                string.Format(s, "SerialNumber", "Name", "Description", "Price"),
                // Separator
                new string('-', width_1stColumn + width_2ndColumn + width_3rdColumn + width_4thColumn)
            };

            string[] outputProducts = new string[Store.Products.Count];
            for (int i = 0; i < Store.Products.Count; i++)
            {
                Product product = Store.Products[i];
                outputProducts[i] = string.Format(s, product.SerialNumber, product.Name, product.Description, product.Price);
            }

            return (header, outputProducts);
        }

        public static void PrintProducts()
        {
            (string[] header, string[] productLines) = CreateProductsOutput();

            Console.WriteLine(header[0]); // Header text
            Console.WriteLine(header[1]); // Header and body separator

            // Lines of Product
            foreach (string line in productLines)
            {
                Console.WriteLine(line);
            }
        }

        public static void PlaceOrder()
        {
            // Lägg till produkt. Användaren ska välja produkt från en lista och dessutom ange antal exemplar.
        }

        public static void ShoppingBasket_ImportFromFile()
        {
            // Varukorgen ska sparas i en textfil i CSV-format och programmet ska avslutas.
        }

        public static void ShoppingBasket_SaveToFile()
        {
            // Varukorgen ska sedan automatiskt läsas in från denna fil när programmet startas igen.
            //
            // Spara denna fil på en sökväg utanför projektet (så att den garanterat finns kvar mellan körningarna),
            // exempelvis C:\Windows\Temp\Cart.txt.
        }

        public static void ShoppingBasket_AddProduct()
        {
            // Lägg till produkt. Användaren ska välja produkt från en lista och dessutom ange antal exemplar.
        }

        public static void DrawMainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                int menuChoice = Program.ShowMenu("Vad vill du göra?", Program.MainMenuItems);

                switch (menuChoice)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                }
            }
        }

        public static void Start()
        {
            Console.WriteLine("Följande produkter finns i butiken:" + Environment.NewLine);
            Store.PrintProducts();
            Console.WriteLine();

            bool exit = false;

            while (!exit)
            {
                //Store.DrawMainMenu();
                int mainMenuChoice = Program.ShowMenu("Vad vill du göra?", new[] {
                    "Lägg till produkt",
                    "Beställ"
                });

                switch (mainMenuChoice)
                {
                    case 0:
                        for (bool returnToMainMenu = false; !returnToMainMenu;)
                        {
                            Console.ReadKey();
                            List<Product> p = Store.Products;
                            //int subMenuChoice = Program.ShowMenu("Vad vill du göra?", Store.Products);

                            //switch (subMenuChoice)
                            //{
                            //    case 0:
                            //        break;
                            //    case 1:
                            //        break;
                            //}
                        }
                        break;
                    case 1:
                        break;
                }
            }
        }

        public static void Init()
        {
            Store.ImportProducts();

            Store.Start();
        }
    }

    /// <summary>
    /// class Product
    /// </summary>
    class Product
    {
        public string SerialNumber;
        public string Name;
        public string Description;
        public double Price;
    }

    /// <summary>
    /// class Product
    /// </summary>
    class ShoppingBasket
    {
        public enum BasketType : byte
        {
            Cart,
            Shoppinglist,
            Wishlist
        }

        BasketType Type;

        public ShoppingBasket(BasketType type)
        {
            this.Type = type;
        }
    }

    /// <summary>
    /// class Program
    /// </summary>
    public class Program
    {
        public static string[] MainMenuItems { get; set; } = new[] {
            "Lägg till produkt",
            "Beställ"
        };

        public static int ShowMenu(string prompt, string[] options)
        {
            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Store.Init();
        }
    }

    /// <summary>
    /// class ProgramTests
    /// </summary>
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
