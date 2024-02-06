namespace ControleAcces.Test.Utilities;

internal class PorteSpy : IPorte
{
    public bool SignalOuvertureReçu { get; private set; }

    public void Ouvrir()
    {
        SignalOuvertureReçu = true;
    }
}