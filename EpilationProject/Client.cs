using System;

namespace EpilationProject
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }

        public Client()
        {
        }

        public Client(int id, string name, string phone, string service)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Service = service;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Phone} - {Service}";
        }
    }
}
