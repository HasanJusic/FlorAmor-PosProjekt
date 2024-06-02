namespace FlorAmor.Application.Model;

public class Blume
{

    public Guid Id { get; set; }
    public string Art { get; set; }
    public decimal Preis { get; set; }
    public int Stückzahl { get; set; }
    public string Farbe { get; set; }
    
    public Blume(string art, decimal preis, int stückzahl, string farbe )
    {
        Art = art;
        Preis = preis;
        Stückzahl = stückzahl;
        Farbe = farbe;
    
    }


}
