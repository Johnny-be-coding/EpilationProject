using System;

namespace EpilationProject
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public string Energy { get; set; }
        public string Phototype { get; set; }

        public Client()
        {
        }

        public Client(int id, string name, string phone, string service, string energy, string phototype)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Service = service;
            Energy = energy;
            Phototype = phototype;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Phone} - {Service}";
        }
    }
}
