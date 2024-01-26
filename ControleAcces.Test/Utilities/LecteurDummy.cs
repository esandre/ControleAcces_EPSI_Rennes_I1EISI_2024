namespace ControleAcces.Test.Utilities;

internal class LecteurDummy : ILecteur
{
    public IPorte Porte => throw new NotSupportedException();
    public bool BadgeDétecté => throw new NotSupportedException();
}