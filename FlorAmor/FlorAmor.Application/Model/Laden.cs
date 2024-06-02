using System;

namespace FlorAmor.Application.Model
{
    public class Laden
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Standort { get; set; }
      

 
        public Laden(string name, string standort)
        {
            Id = Guid.NewGuid();
            Name = name;
            Standort = standort;
         
        }
    }
}