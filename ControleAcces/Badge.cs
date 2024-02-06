namespace ControleAcces;

public class Badge
{
    public static readonly Badge Bloqué = new (estBloqué: true);
    public static readonly Badge NonBloqué = new (estBloqué: false);

    public bool EstBloqué { get; }

    private Badge(bool estBloqué)
    {
        EstBloqué = estBloqué;
    }
}