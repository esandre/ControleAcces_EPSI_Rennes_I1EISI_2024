namespace ControleAcces.Test.Utilities;

internal class LecteurFake : ILecteur
{
    public LecteurFake(IPorte porte)
    {
        Porte = porte;
    }

    public void SimulerDétectionBadge()
    {
        _badgeDétectéAuProchainCycle = true;
    }

    private bool _badgeDétectéAuProchainCycle;

    public IPorte Porte { get; }

    public bool BadgeDétecté
    {
        get
        {
            if (!_badgeDétectéAuProchainCycle) 
                return false;

            _badgeDétectéAuProchainCycle = false;
            return true;
        }
    }
}