using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur ayant détecté un Badge relié à une Porte
        var porteSpy = new PorteSpy();
        var lecteur = new LecteurFake(porteSpy);
        lecteur.SimulerDétectionBadge();

        // ET un Moteur d'Ouverture
        var moteur = new MoteurOuverture();

        // QUAND le Moteur d'Ouverture interroge le Lecteur
        moteur.InterrogerLecteur();

        // ALORS un signal d'ouverture est envoyé à la Porte
        Assert.True(porteSpy.SignalOuvertureReçu);
    }

}