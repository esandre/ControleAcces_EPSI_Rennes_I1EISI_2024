using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur reli�e � une Porte
        // ET un Moteur d'Ouverture interrogeant ce Lecteur
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        // QUAND un Badge valide est pass� devant le Lecteur
        lecteur.SimulerD�tectionBadge();
        moteurOuverture.InterrogerLecteurs();

        // ALORS un signal d'ouverture est envoy� � la Porte
        Assert.True(porte.ARe�uUnSignalDOuverture);
    }

    [Fact]
    public void CasRienD�tect�()
    {
        // ETANT DONNE un Lecteur reli�e � une Porte
        // ET un Moteur d'Ouverture interrogeant ce Lecteur
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        // QUAND aucun Badge valide n'est pass� devant le Lecteur
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(porte.ARe�uUnSignalDOuverture);
    }

    [Fact]
    public void CasErreurLecteur()
    {
        // ETANT DONNE un Lecteur d�faillant reli� � une Porte
        var porte = new PorteSpy();
        var lecteur = new LecteurDummy();
        var loggerSpy = new LoggerSpy();
        var moteurOuverture = new MoteurOuverture(lecteur) { Logger = loggerSpy };

        // QUAND on interroge ce Lecteur
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(porte.ARe�uUnSignalDOuverture);

        // ET l'erreur est logu�e
        Assert.True(loggerSpy.ExceptionDansLesLogs);
    }
}