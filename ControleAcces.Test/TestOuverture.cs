using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur reliée à une Porte
        // ET un Moteur d'Ouverture interrogeant ce Lecteur
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        // QUAND un Badge valide est passé devant le Lecteur
        lecteur.SimulerDétectionBadge();
        moteurOuverture.InterrogerLecteurs();

        // ALORS un signal d'ouverture est envoyé à la Porte
        Assert.True(porte.AReçuUnSignalDOuverture);
    }

    [Fact]
    public void CasRienDétecté()
    {
        // ETANT DONNE un Lecteur reliée à une Porte
        // ET un Moteur d'Ouverture interrogeant ce Lecteur
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        // QUAND aucun Badge valide n'est passé devant le Lecteur
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

        // QUAND on interroge ce Lecteur
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoyé à la Porte
        Assert.False(porte.AReçuUnSignalDOuverture);

        // ET l'erreur est loguée
        Assert.True(loggerSpy.ExceptionDansLesLogs);
    }
}