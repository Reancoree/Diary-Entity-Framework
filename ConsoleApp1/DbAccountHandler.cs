using Diary.Entities;

namespace Diary
{
    class DbAccountHandler : IAccountHandler
    {
        public void SignIn(string userName, string userPassword)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Users.Any(u => u.Login == userName))
                {
                    Console.WriteLine("Пользователь с таким именем уже зарегестрирован\n" +
                        "Нажмите любую кнопку для продолжения...");
                    Console.ReadKey();
                }
                else
                {
                    User user = new User() { Login = userName, Password = userPassword };
                    db.Users.Add(user);
                    db.SaveChanges();

                    Console.WriteLine("Вы успешно зарегестрированы!\n" +
                        "Нажмите любую кнопку для продолжения...");
                    Console.ReadKey();
                }
            }
        }
        public void LogIn(string userName, string userPassword)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Users.Any(u => u.Login == userName && u.Password == userPassword))
                {
                    PrintDiaries(userName, userPassword, db);

                    PrintLoginMenu(userName, db);
                }
                else Console.WriteLine("Неправильный логин или пароль");
                Console.ReadKey();
            }
        }
        public void PrintDiaries(string userName, string userPassword, ApplicationContext db)
        {
            var user = db.Users.Where(u => u.Login == userName).FirstOrDefault();
            var userDiaries = db.Diaries.Where(d => d.UserId == user!.Id).ToList();
            Console.WriteLine("Содержимое вашего дневника:\n");
            foreach (var u in userDiaries)
                Console.WriteLine($"{u.DateTime}:\n {u.Content}");
            Console.WriteLine();
        }
        public void PrintLoginMenu(string userName, ApplicationContext db)
        {
            bool tempExit = false;
            while (!tempExit)
            {
                Console.WriteLine();
                Console.WriteLine("1. Добавить новую запись\nНажмите Enter чтобы выйти\n");
                string tempChoice = Console.ReadLine()!;
                if (tempChoice == "1")
                {
                    Console.Clear();
                    User user = db.Users.Where(u => u.Login == userName).FirstOrDefault()!;
                    string diaryEntry = Console.ReadLine()!;
                    if (diaryEntry != "")
                    {
                        UserDiary userDiary = new UserDiary() { Content = diaryEntry, UserId = user!.Id, DateTime = DateTime.Now };
                        db.Diaries.Add(userDiary);
                        db.SaveChanges();
                    }
                }
                else if (tempChoice == "")
                    tempExit = true;
            }
        }
    }
}
