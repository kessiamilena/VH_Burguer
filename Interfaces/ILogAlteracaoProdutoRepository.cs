using VHBurguer.Domains;

namespace VHBurguer.Interfaces
{
    public interface ILogAlteracaoProdutoRepository
    {
        List<Log_AlteracaoProduto> Listar();
        List<Log_AlteracaoProduto> ListarPorProduto(int produtoId);
    }
}
