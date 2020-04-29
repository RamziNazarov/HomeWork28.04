using System;
using System.Collections.Generic;

namespace HomeWork28._04
{
    class Client
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public void Insert(ref List<Client> clients,int id,decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
            clients.Add(this);
            System.Console.WriteLine("Успешно добавлено клиент с Id " + id);
            return;
        }
        public void Update(ref List<Client> clients)
        {
            System.Console.Write("Введите Id: ");
            int id = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Введите новую сумму: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            for (int i = 0; i < clients.Count; i++)
            {
                if (id == clients[i].Id)
                {
                    clients[i].Balance = balance;
                    return;
                }
            }
        }
        public void Select(List<Client> clients,int id)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (id == clients[i].Id)
                {
                    System.Console.WriteLine(clients[i].Id);
                    System.Console.WriteLine(clients[i].Balance);
                    return;
                }
            }
        }
        public void Delete(ref List<Client> clients)
        {
            System.Console.WriteLine("Введите Id: ");
            int id = int.Parse(Console.ReadLine());
            for(int i =0; i < clients.Count;i++)
            {
                if(id == clients[i].Id)
                {
                    clients.RemoveAt(i);
                    return;
                }
            }
        }
    }
}