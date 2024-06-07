using System;

namespace FlorAmor.Application.Model
{
    public class Laden
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ort { get; set; }
        public int PLZ { get; set; }
       
      

 
        public Laden(string name, string ort, int plz)
        {
            Id = Guid.NewGuid();
            Name = name;
            Ort = ort;
            PLZ = plz;
        }
    }
}