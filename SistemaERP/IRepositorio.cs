using System.Collections.Generic;

public interface IRepositorio<T>
{
    void Adicionar(T item);
    void Remover(T item);
    List<T> Listar();
    T BuscarPorNome(string nome);
    T BuscarPorCodigo(string codigo);
    void SalvarDados();
    void CarregarDados();
}