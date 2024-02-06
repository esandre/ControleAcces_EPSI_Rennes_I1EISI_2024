namespace ControleAcces;

public class MoteurOuverture
{
    private readonly ILecteur[] _lecteursAPoller;

    public MoteurOuverture(params ILecteur[] lecteurAPoller)
    {
        _lecteursAPoller = lecteurAPoller;
    }

    public IMoteurOuvertureLogger? Logger { private get; init; }

    public void InterrogerLecteurs()
    {
        foreach (var lecteur in _lecteursAPoller)
        {
            try
            {
                var badgeDetecté = lecteur.BadgeDétecté;

                if (badgeDetecté == null)
                    continue;

                if (badgeDetecté.EstBloqué)
                    continue;

                lecteur.Porte.Ouvrir();
            }
            catch (Exception e)
            {
                Logger?.LogException(e);
            }
        }
    }
}