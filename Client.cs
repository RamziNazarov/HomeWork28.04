using System;
using System.Collections.Generic;

namespace HomeWork28._04
{
    class Client
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public void Insert(int id,decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
            Program.clients.Add(new Client(){Id = id,Balance = balance});
            Program.balances.Add(new Client(){Id = id,Balance = balance});
            System.Console.WriteLine("Успешно добавлено клиент с Id " + id);
            return;
        }
        public void Update(int id,decimal balance)
        {
            
            for (int i = 0; i < Program.clients.Count; i++)
            {
                if (id == Program.clients[i].Id)
                {
                    Program.clients[i].Balance = balance;
                    return;
                }
            }
        }
        public void Select(int id)
        {
            for (int i = 0; i < Program.clients.Count; i++)
            {
                if (id == Program.clients[i].Id)
                {
                    System.Console.WriteLine(Program.clients[i].Id);
                    System.Console.WriteLine(Program.clients[i].Balance);
                    return;
                }
            }
        }
        public void Delete(int id)
        {
            for(int i =0; i < Program.clients.Count;i++)
            {
                if(id == Program.clients[i].Id)
                {
                    Program.clients.RemoveAt(i);
                    return;
                }
            }
        }
    }
}