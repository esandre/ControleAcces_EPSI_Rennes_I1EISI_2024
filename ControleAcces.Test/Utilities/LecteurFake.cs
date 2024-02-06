namespace ControleAcces.Test.Utilities;

public class LecteurFake : ILecteur
{
    private readonly IPorte _porte;

    public LecteurFake(IPorte porte)
    {
        _porte = porte;
    }

    public void SimulerDétectionBadge()
    {
    }

    public void OuvrirPorte()
    {
        _porte.Ouvrir();
    }
}