namespace ControleAcces.Test.Utilities;

internal class LecteurDummy : ILecteur
{
    public IPorte Porte => throw new NotSupportedException();
    public Badge BadgeDétecté => throw new NotSupportedException();
}