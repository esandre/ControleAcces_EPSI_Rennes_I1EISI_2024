using ControleAcces.Test.Utilities;

namespace ControleAcces.Test;

public class TestOuverture
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE un Lecteur reli�e � une Porte
        // ET qu'un badge a �t� detect�
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);
        lecteur.SimulerD�tectionBadge(Badge.NonBloqu�);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS un signal d'ouverture est envoy� � la Porte
        Assert.True(porte.ARe�uUnSignalDOuverture);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void CasDeuxLecteurs(int indexLecteurD�tectantLeBadge)
    {
        // ETANT DONNE deux Lecteurs reli�s � une Porte
        // ET qu'un badge a �t� detect� par l'un des deux
        var porte = new PorteSpy();
        var lecteurs = new[] { new LecteurFake(porte), new LecteurFake(porte)};
        var moteurOuverture = new MoteurOuverture(lecteurs.Cast<ILecteur>().ToArray());

        lecteurs[indexLecteurD�tectantLeBadge].SimulerD�tectionBadge(Badge.NonBloqu�);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS un signal d'ouverture est envoy� � la Porte
        Assert.True(porte.ARe�uUnSignalDOuverture);
    }

    [Fact]
    public void CasRienD�tect�()
    {
        // ETANT DONNE un Lecteur reli�e � une Porte
        var porte = new PorteSpy();
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
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

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(porte.ARe�uUnSignalDOuverture);

        // ET l'erreur est logu�e
        Assert.True(loggerSpy.ExceptionDansLesLogs);
    }

    [Fact]
    public void CasBadgeBloqu�e()
    {
        // ETANT DONNE un Lecteur reli�e � une Porte
        // ET une Badge bloqu�
        // ET que ce Badge a �t� d�tect�
        var porte = new PorteSpy();
        var badge = Badge.Bloqu�;
        var lecteur = new LecteurFake(porte);
        var moteurOuverture = new MoteurOuverture(lecteur);

        lecteur.SimulerD�tectionBadge(badge);

        // QUAND le Moteur d'Ouverture interroge ses lecteurs
        moteurOuverture.InterrogerLecteurs();

        // ALORS aucun signal d'ouverture n'est envoy� � la Porte
        Assert.False(porte.ARe�uUnSignalDOuverture);
    }
}