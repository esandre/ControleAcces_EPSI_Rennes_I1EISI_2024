namespace ControleAcces.Test.Utilities;

internal class PorteSpy : IPorte
{
    public bool AReçuUnSignalDOuverture { get; private set; }

    public void Ouvrir()
    {
        AReçuUnSignalDOuverture = true;
    }
}