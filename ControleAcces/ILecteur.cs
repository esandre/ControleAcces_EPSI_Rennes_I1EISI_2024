namespace ControleAcces;

public interface ILecteur
{
    void OuvrirPorte();
    bool ADétectéBadge { get; }
}