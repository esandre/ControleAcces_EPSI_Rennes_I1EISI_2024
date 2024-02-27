using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur ayant détecté un Badge relié à une Porte
        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuvertureBuilder()
            .EspionnantLaPorte()
            .DétectantUnBadge()
            .Build();

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS un signal d'ouverture est envoyé à la Porte
        Assert.True(moteur.SignalOuvertureReçu);
    }

    [Fact]
    public void CasMoteurNonInterrogé()
    {
        // ETANT DONNE un Lecteur ayant détecté un Badge relié à une Porte
        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuvertureBuilder()
            .EspionnantLaPorte()
            .DétectantUnBadge()
            .Build();

        // ALORS aucun signal d'ouverture n'est envoyé à la Porte
        Assert.False(moteur.SignalOuvertureReçu);
    }

    [Fact]
    public void CasLecteurNonInterrogé()
    {
        // ETANT DONNE un Lecteur relié à une Porte
        var moteur = new MoteurOuvertureBuilder()
            .EspionnantLaPorte()
            .Build();

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS aucun signal d'ouverture n'est envoyé à la Porte
        Assert.False(moteur.SignalOuvertureReçu);
    }
}