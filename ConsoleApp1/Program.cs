using Diary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string userName;
            string userPassword;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в дневник!\n");
                Console.WriteLine("1. Зарегистрироваться в дневнике\n2. Войти в дневник\n\nЧтобы выйти нажмите 'x'");

                string userChoice = Console.ReadLine()!;
                switch (userChoice)
                {
                    case "1":
                        PrintAccountEntering(out userName, out userPassword);

                        if (userName != "" && userPassword != "")
                        {
                           DbAccountHandler dbHandler = new DbAccountHandler();
                            dbHandler.SignIn(userName, userPassword);
                        }
                        break;

                    case "2":
                        PrintAccountEntering(out userName, out userPassword);

                        if (userName != "" && userPassword != "")
                        {
                            DbAccountHandler dbHandler = new DbAccountHandler();
                            dbHandler.LogIn(userName, userPassword);
                        }
                        else Console.WriteLine("\nНеправильный логин или пароль\nНажмите любую кнопку для продолжения...");
                        Console.ReadKey();
                        break;

                    case "x":
                        exit = true;
                        break;

                    default:
                        break;
                }
            }
        }
        static void PrintAccountEntering(out string userName, out string userPassword)
        {
            Console.Write("Введите логин: ");
            userName = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            userPassword = Console.ReadLine()!;
        }
    }
}






