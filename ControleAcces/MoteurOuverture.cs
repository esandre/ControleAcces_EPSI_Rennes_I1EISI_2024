namespace ControleAcces;

public class MoteurOuverture
{
    private readonly ILecteur _lecteur;

    public MoteurOuverture(ILecteur lecteur)
    {
        _lecteur = lecteur;
    }

    public void InterrogerLecteur()
    {
        if(_lecteur.ADétectéBadge)
            _lecteur.OuvrirPorte();
    }
}