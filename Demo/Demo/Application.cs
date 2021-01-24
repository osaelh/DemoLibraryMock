using System;
using System.Collections.Generic;
using System.Text;
using DemoLibrary.Logic;
using DemoLibrary.Models;

namespace Demo
{
    class Application : IApplication
    {
        IUserProcessor UserProcessor;
        public Application(IUserProcessor userProcessor)
        {
            UserProcessor = userProcessor;
        }
        public void run()
        {
            IdentifyNextStep();
        }

        private void IdentifyNextStep()
        {
            string selectedAction = "";

            do
            {
                selectedAction = GetActionChoice();

                Console.WriteLine();

                switch (selectedAction)
                {
                    case "1":
                        DisplayPeople(UserProcessor.LoadUsers());
                        break;
                    case "2":
                        AddUser();
                        break;
                    case "3":
                        Console.WriteLine("Thanks for using this application");
                        break;
                    default:
                        Console.WriteLine("That was an invalid choice. Hit enter and try again.");
                        break;
                }

                Console.WriteLine("Hit return to continue...");
                Console.ReadLine();

            } while (selectedAction != "3");
        }

        private void DisplayPeople(List<UserModel> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
            }
        }
        private string GetActionChoice()
        {
            string output = "";

            Console.Clear();
            Console.WriteLine("Menu Options".ToUpper());
            Console.WriteLine("1 - Load People");
            Console.WriteLine("2 - Create and Save Person");
            Console.WriteLine("3 - Exit");
            Console.Write("What would you like to choose: ");
            output = Console.ReadLine();

            return output;
        }

        private void AddUser()
        {
            Console.Write("What is the user's username: ");
            string userName = Console.ReadLine();
            Console.Write("What is the user's email: ");
            string email = Console.ReadLine();
            Console.Write("What is the person's password: ");
            string password = Console.ReadLine();
            Console.Write("What is the user's access: ");
            int access = Convert.ToInt32(Console.ReadLine());

            var person = UserProcessor.CreateUser(userName, email, password, access);
            UserProcessor.SaveUser(person);
        }
    }
}
