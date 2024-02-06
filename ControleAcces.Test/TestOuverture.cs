using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur ayant d�tect� un Badge reli� � une Porte
        var porteSpy = new PorteSpy();
        var lecteur = new LecteurFake(porteSpy);
        lecteur.SimulerD�tectionBadge();

        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuverture(lecteur);

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS un signal d'ouverture est envoy� � la Porte
        Assert.True(porteSpy.SignalOuvertureRe�u);
    }

    [Fact]
    public void CasMoteurNonInterrog�()
    {
        // ETANT DONNE un Lecteur ayant d�tect� un Badge reli� � une Porte
        var porteSpy = new PorteSpy();
        var lecteur = new LecteurFake(porteSpy);
        lecteur.SimulerD�tectionBadge();

        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuverture(lecteur);

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(porteSpy.SignalOuvertureRe�u);
    }

    [Fact]
    public void CasLecteurNonInterrog�()
    {
        // ETANT DONNE un Lecteur reli� � une Porte
        var porteSpy = new PorteSpy();
        var lecteur = new LecteurFake(porteSpy);

        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuverture(lecteur);

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(porteSpy.SignalOuvertureRe�u);
    }
}