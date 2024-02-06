namespace ControleAcces.Test.Utilities;

internal class LecteurFake : ILecteur
{
    public LecteurFake(IPorte porte)
    {
        Porte = porte;
    }

    public void SimulerDétectionBadge(Badge badge)
    {
        _badgeDétectéAuProchainCycle = badge;
    }

    private Badge? _badgeDétectéAuProchainCycle;

    public IPorte Porte { get; }

    public Badge? BadgeDétecté
    {
        get
        {
            var valeur = _badgeDétectéAuProchainCycle;
            _badgeDétectéAuProchainCycle = null;
            return valeur;
        }
    }
}