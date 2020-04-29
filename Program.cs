using System;
using System.Collections.Generic;
using System.Threading;

namespace HomeWork28._04
{
    class Program
    {
        static List<Client> clients = new List<Client>();
        static void Main(string[] args)
        {
            Client client = new Client();
            string choice = "1";
            while (choice != "5")
            {
                TimerCallback callback = new TimerCallback(ShowChangeInBalance);
                Timer timer = new Timer(callback, clients, 0, 10000);
                System.Console.WriteLine("1. Добавить клиента\n2. Изменить баланс клиента\n3. Удалить клиента\n4. Показать баланс клиента");
                choice = Console.ReadLine();
                int id = 0;
                switch (choice)
                {
                    case "1":
                        System.Console.Write("Введите Id: ");
                        id = int.Parse(Console.ReadLine());
                        System.Console.Write("Введите баланс: ");
                        decimal balance = decimal.Parse(Console.ReadLine());
                        Thread newInsertThread = new Thread(new ThreadStart(() => { client.Insert(ref clients, id, balance); }));
                        newInsertThread.Start();
                        if(newInsertThread.ThreadState == ThreadState.Aborted)
                        {
                            newInsertThread.Abort();
                            System.Console.WriteLine("aborted");
                        }
                        break;
                    case "2":
                        // Thread newUpdateThread = new Thread(new ThreadStart(clients[1].Update));
                        // newUpdateThread.Start();
                        break;
                    case "3":
                        // Thread newDeleteThread = new Thread(new ThreadStart(clients[1].Delete));
                        // newDeleteThread.Start();
                        break;
                    case "4":
                        System.Console.WriteLine("Введите Id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Thread newSelectThread = new Thread(new ThreadStart(() => { client.Select(clients,id); }));
                        newSelectThread.Start();
                        break;
                }
                Console.ReadKey();
            }
        }
        static void ShowChangeInBalance(object Clients)
        {
            decimal balance = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                balance = clients[i].Balance;
                Thread.Sleep(5000);
                if (clients[i].Balance != balance)
                {
                    System.Console.WriteLine($"{clients[i].Id} & {balance} & {clients[i].Balance}");
                }
            }
        }
    }
}
