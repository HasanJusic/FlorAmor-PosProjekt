using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FlorAmor.Application.Model;

public class Blume
{
    [Key]
    public Guid Id { get; set; }
    public string Art { get; set; }
    public decimal Preis { get; set; }
    public int Stückzahl { get; set; }
    public string Farbe { get; set; }

    [BsonIgnore]
    public bool IstVerfügbar => Stückzahl > 0;



   public Blume()
    {

    }

    public Blume(string art, decimal preis, int stückzahl, string farbe)
    {
        Art = art;
        Preis = preis;
        Stückzahl = stückzahl;
        Farbe = farbe;
        
    }
   



}
