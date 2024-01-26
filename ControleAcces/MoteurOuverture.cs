namespace ControleAcces;

public class MoteurOuverture
{
    private readonly ILecteur _lecteurAPoller;

    public MoteurOuverture(ILecteur lecteurAPoller)
    {
        _lecteurAPoller = lecteurAPoller;
    }

    public IMoteurOuvertureLogger? Logger { private get; init; }

    public void InterrogerLecteurs()
    {
        try
        {
            if (_lecteurAPoller.BadgeDétecté)
                _lecteurAPoller.Porte.Ouvrir();
        }
        catch (Exception e)
        {
            Logger?.LogException(e);
        }
        
    }
}