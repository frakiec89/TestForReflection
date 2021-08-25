using System;

namespace TestForReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ivan", "admin", "123");
            while(true)
            {
                Console.WriteLine("Введите пароль");

                if (user.IsAuthorization(Console.ReadLine()))
                {
                    Console.WriteLine("Hello " + user.Name);
                    break;
                }
                else
                {
                    Console.WriteLine("пароль не верный");
                }
            }
            GetStart();
        }

        private static void GetStart()
        {
            Console.WriteLine(" Вы в  системе - Ура");
            Console.ReadLine();
        }
    }

    class User
    {
        public string Name { get; private set; }
        public string Login { get; private set; }

        private string password;

        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            this.password = password;
        }

        public bool IsAuthorization ( string pass)
        {
            if (password == pass)
            {
                return true;
            }
            return false;
        }


    }
}
