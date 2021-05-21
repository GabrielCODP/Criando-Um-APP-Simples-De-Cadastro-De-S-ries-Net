using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEmSerie.Interfaces
{
    //Vou criar um repositorio, utilizando o design pattern.
    interface IRepositorio<T> //Quem implementar, vai passar um T, que é tipo génerico
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
