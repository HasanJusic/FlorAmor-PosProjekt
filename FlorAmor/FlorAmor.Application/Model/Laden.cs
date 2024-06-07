using System;

namespace FlorAmor.Application.Model
{
    public class Laden
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Land {  get; set; }
        public string Ort { get; set; }
        public int PLZ { get; set; }




        public Laden(string name, string land, string ort, int plz)
        {
            Id = Guid.NewGuid();
            Name = name;
            Land = land;
            Ort = ort;
            PLZ = plz;
      
        }
    }
}