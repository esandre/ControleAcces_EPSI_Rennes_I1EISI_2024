using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur ayant d�tect� un Badge reli� � une Porte
        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuvertureBuilder()
            .EspionnantLaPorte()
            .D�tectantUnBadge()
            .Build();

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS un signal d'ouverture est envoy� � la Porte
        Assert.True(moteur.SignalOuvertureRe�u);
    }

    [Fact]
    public void CasMoteurNonInterrog�()
    {
        // ETANT DONNE un Lecteur ayant d�tect� un Badge reli� � une Porte
        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuvertureBuilder()
            .EspionnantLaPorte()
            .D�tectantUnBadge()
            .Build();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(moteur.SignalOuvertureRe�u);
    }

    [Fact]
    public void CasLecteurNonInterrog�()
    {
        // ETANT DONNE un Lecteur reli� � une Porte
        var moteur = new MoteurOuvertureBuilder()
            .EspionnantLaPorte()
            .Build();

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(moteur.SignalOuvertureRe�u);
    }
}