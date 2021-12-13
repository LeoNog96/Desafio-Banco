using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Lista todos os registro do banco
        /// </summary>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<List<T>> Listar();

        /// <summary>
        /// Busca determinado registro no banco
        /// </summary>
        /// <param name="id"> id do registro ser buscado </param>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<T> Obter(long id);

        /// <summary>
        /// Persite uma entidade no banco
        /// </summary>
        /// <param name="entity"> Entidade a ser persisitido </param>
        /// <returns>Retorna a entidade já persistida no banco</returns>
        Task<T> Salvar(T entity);

        /// <summary>
        /// Persite uma range de entidades no banco
        /// </summary>
        /// <param name="entity"> Lista de Entidades a serem persisitidas </param>
        /// <returns>Retorna a Lista com as entidades já persistidas no banco</returns>
        Task<List<T>> SalvarMuitos(List<T> entity);

        /// <summary>
        /// Atualiza um registro no banco
        /// </summary>
        /// <param name="entity">Entidade atualizada</param>
        /// <param name="id">Id da entidade a ser atualizada</param>
        Task Atualizar(T entity);

        /// <summary>
        /// Atualiza um range de registros no banco
        /// </summary>
        /// <param name="entity">Lista de Entidades a serem atualizadas</param>
        Task AtualizarMuitos(List<T> entity);

        /// <summary>
        /// Remove um registro no banco
        /// </summary>
        /// <param name="id">Id da entidade a ser removida</param>
        Task Remover(long id);

        /// <summary>
        /// Remove um range de registros no banco
        /// </summary>
        /// <param name="entity">Lista de Entidades a serem atualizadas</param>
        Task RemoverMuitos(List<T> entity);
    }
}
