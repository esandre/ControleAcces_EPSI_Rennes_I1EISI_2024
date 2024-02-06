namespace ControleAcces;

public class MoteurOuverture
{
    public MoteurOuverture(IPorte porte)
    {
        porte.Ouvrir();
    }

    public void InterrogerLecteur()
    {
    }
}