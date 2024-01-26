namespace ControleAcces.Test.Utilities;

internal class LoggerSpy : IMoteurOuvertureLogger
{
    public bool ExceptionDansLesLogs { get; private set; }

    public void LogException(Exception e)
    {
        ExceptionDansLesLogs = true;
    }
}