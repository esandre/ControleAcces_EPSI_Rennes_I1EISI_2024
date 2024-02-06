using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur reliée à une Porte
        // ET qu'un badge a été detecté
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);
        lecteur.SimulerDétectionBadge(Badge.NonBloqué);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS un signal d'ouverture est envoyé à la Porte
        Assert.True(porte.AReçuUnSignalDOuverture);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void CasDeuxLecteurs(int indexLecteurDétectantLeBadge)
    {
        // ETANT DONNE deux Lecteurs reliés à une Porte
        // ET qu'un badge a été detecté par l'un des deux
        var porte = new PorteSpy();
        var lecteurs = new[] { new LecteurFake(porte), new LecteurFake(porte)};
        var moteurOuverture = new MoteurOuverture(lecteurs.Cast<ILecteur>().ToArray());

        lecteurs[indexLecteurDétectantLeBadge].SimulerDétectionBadge(Badge.NonBloqué);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS un signal d'ouverture est envoyé à la Porte
        Assert.True(porte.AReçuUnSignalDOuverture);
    }

    [Fact]
    public void CasRienDétecté()
    {
        // ETANT DONNE un Lecteur reliée à une Porte
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoyé à la Porte
        Assert.False(porte.AReçuUnSignalDOuverture);
    }

    [Fact]
    public void CasErreurLecteur()
    {
        // ETANT DONNE un Lecteur défaillant relié à une Porte
        var porte = new PorteSpy();
        var lecteur = new LecteurDummy();
        var loggerSpy = new LoggerSpy();
        var moteurOuverture = new MoteurOuverture(lecteur) { Logger = loggerSpy };

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoyé à la Porte
        Assert.False(porte.AReçuUnSignalDOuverture);

        // ET l'erreur est loguée
        Assert.True(loggerSpy.ExceptionDansLesLogs);
    }

    [Fact]
    public void CasBadgeBloquée()
    {
        // ETANT DONNE un Lecteur reliée à une Porte
        // ET une Badge bloqué
        // ET que ce Badge a été détecté
        var porte = new PorteSpy();
        var badge = Badge.Bloqué;
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        lecteur.SimulerDétectionBadge(badge);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoyé à la Porte
        Assert.False(porte.AReçuUnSignalDOuverture);
    }
}