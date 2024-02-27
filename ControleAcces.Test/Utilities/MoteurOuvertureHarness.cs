namespace ControleAcces.Test.Utilities;

internal class MoteurOuvertureHarness
{
    private readonly MoteurOuverture _moteur;
    private readonly PorteSpy _porte;

    public MoteurOuvertureHarness(MoteurOuverture moteur, PorteSpy porte)
    {
        _moteur = moteur;
        _porte = porte;
    }

    public bool SignalOuvertureReçu => _porte.SignalOuvertureReçu;

    public void InterrogerLecteur()
    {
        _moteur.InterrogerLecteur();
    }
}