namespace ControleAcces;

public interface ILecteur
{
    IPorte Porte { get; }
    bool BadgeDétecté { get; }
}