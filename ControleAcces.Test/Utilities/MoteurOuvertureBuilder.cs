namespace ControleAcces.Test.Utilities;

internal class MoteurOuvertureBuilder
{
    private PorteSpy _porte;
    private bool _détecteUnBadge;

    public MoteurOuvertureHarness Build()
    {
        var lecteur = new LecteurFake(_porte);
        if(_détecteUnBadge) lecteur.SimulerDétectionBadge();
        var moteur = new MoteurOuverture(lecteur);
        return new MoteurOuvertureHarness(moteur, _porte);
    }

    public MoteurOuvertureBuilder EspionnantLaPorte()
    {
        _porte = new PorteSpy();
        return this;
    }

    public MoteurOuvertureBuilder DétectantUnBadge()
    {
        _détecteUnBadge = true;
        return this;
    }
}