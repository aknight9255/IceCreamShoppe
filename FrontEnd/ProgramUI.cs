using IceCreamBackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class ProgramUI
    {
        private readonly IceCreamRepo _repo = new IceCreamRepo();
        public void Run()
        {
            SeedInventory();
            OpenMenu();
        }

        private void SeedInventory()
        {
            var first = new IceCream("Mint Choco Chip", true, false, "Smooth and crunchy. Does not taste likst toothpaste", 42);
            var second = new IceCream("Sherbet Lemon", false, false, "Sorta smooth, very refreashing, a favorite of Dumbledore", 394);
            var third = new IceCream("Test Flavor", true, true, "Insert Info Here", 9001);
            var fourth = new IceCream("Void", true, true, "Not the same as null", 89);
            var five = new IceCream("Banana", false, false, "Much Banana", 404);

            _repo.AddNewIceCream(first);
            _repo.AddNewIceCream(second);
            _repo.AddNewIceCream(third);
            _repo.AddNewIceCream(fourth);
            _repo.AddNewIceCream(five);

        }

        public void OpenMenu()
        {
            var menuIsOpen = true;
            while (menuIsOpen)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Amanda's Super Cold Shoppe \n" +
                    "Please pick and option from below. \n" +
                    "1) Show All Inventory \n" +
                    "2) Add new Inventory \n" +
                    "3) Adjust Item in Inventory \n" +
                    "4) Exit and Close \n");
                var userResponse = Console.ReadLine();
                switch (userResponse)
                {
                    case "1":
                        {
                            ShowAllInventory();
                            break;
                        }
                    case "2":
                        {
                            AddNewinventory();
                            break;
                        }
                    case "3":
                        {
                            break;
                        }
                    case "4":
                        {
                            AdjustExistingInventory();
                            menuIsOpen = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose an option between 1 - 4. \n" +
                                "Use a numerical response only");
                            PutItOnPause();
                            break;
                        }
                }
            }

        }

        private void AdjustExistingInventory()
        {
            Console.WriteLine("This feature is under construction \n" +
                "Sorry about that...");
            PutItOnPause();
        }

        private void AddNewinventory()
        {
            Console.WriteLine("Welcome\n" +
                "Time to add new inventory");
            var newItem = new IceCream();
            Console.WriteLine("Please enter the new Ice Cream flavor!");
            newItem.Flavor = Console.ReadLine();
            Console.WriteLine("How would you describe the new flavor?");
            newItem.Texture = Console.ReadLine();

            Console.WriteLine("Does this new flavor contain nuts? \n" +
                "Please enter Yes or No");
            var nutResponse = Console.ReadLine();
            var containsNuts = true;
            while (containsNuts)
            {
                switch (nutResponse.ToLower())
                {
                    case "yes":
                        {
                            newItem.ContainsNuts = true;
                            containsNuts = false;
                            break;
                        }
                    case "no":
                        {
                            newItem.ContainsNuts = false;
                            containsNuts = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("please enter yes or no.");
                            PutItOnPause();
                            break;
                        }
                }
            }

            Console.WriteLine("Does this new flavor contain nuts? \n" +
               "Please enter Yes or No");
            var dairyResponse = Console.ReadLine();
            var containsDairy = true;
            while (containsDairy)
            {
                switch (dairyResponse.ToLower())
                {
                    case "yes":
                        {
                            newItem.ContainsDairy = true;
                            containsDairy = false;
                            break;
                        }
                    case "no":
                        {
                            newItem.ContainsDairy = false;
                            containsDairy = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("please enter yes or no.");
                            PutItOnPause();
                            break;
                        }
                }
            }

            Console.WriteLine("How many do we have in stock?");
            newItem.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you wish do add this product? \n" +
                "yes or no");
            DisplayOneitem(newItem);
            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                    {
                        _repo.AddNewIceCream(new IceCream());
                        Console.WriteLine("You have added the new flavor!");
                        PutItOnPause();
                        break;
                    }
                case "no":
                    {
                        Console.WriteLine("You have not added the new flavor. \n" +
                            "You will now be returned to the main menu.");
                        PutItOnPause();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You entered in an invalid response. \n" +
                            "You broke everything. \n" +
                            "you will now be sent to the main menu. \n" +
                            "None of your progess will be saved.");
                        Console.ReadLine();
                        break;
                    }
            }
        }

        private void ShowAllInventory()
        {
            var inventory = _repo.ReturnIceCreamInventory();
            Console.WriteLine("Current Inventory");
            foreach (var oneItem in inventory)
            {
                DisplayOneitem(oneItem);
            }
            PutItOnPause();
        }
        private void PutItOnPause()
        {
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        private void DisplayOneitem(IceCream item)
        {
            Console.WriteLine($"---{item.Flavor}--- \n" +
                $"Current Amount in Stock -- {item.Quantity} \n" +
                $"Description: \n" +
                $"{item.Texture}");
            if (item.ContainsDairy)
            {
                Console.WriteLine("Item Contains Dairy");
            }
            if (item.ContainsNuts)
            {
                Console.WriteLine("Item Contains Nuts");
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}
