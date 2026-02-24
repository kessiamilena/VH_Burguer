using VHBurguer.Domains;

namespace VHBurguer.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();
        Categoria ObterPorId(int id);

        bool NomeExiste(string nome, int? categoriaIdAtual = null);

        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Remover(int id);
    }
}
