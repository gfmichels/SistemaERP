public interface IRepositorio<T>
{
    void Adicionar(T entidade);
    void Remover(T entidade);
    void Atualizar(T entidade);
    List<T> Listar();
}