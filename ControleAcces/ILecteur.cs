namespace ControleAcces;

public interface ILecteur
{
    IPorte Porte { get; }
    Badge? BadgeDétecté { get; }
}