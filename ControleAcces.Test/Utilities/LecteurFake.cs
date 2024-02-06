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
        ADétectéBadge = true;
    }

    public void OuvrirPorte()
    {
        _porte.Ouvrir();
    }

    public bool ADétectéBadge { get; private set; }
}