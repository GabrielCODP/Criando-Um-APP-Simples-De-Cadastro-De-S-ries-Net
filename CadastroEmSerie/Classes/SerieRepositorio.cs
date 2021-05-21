
using CadastroEmSerie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEmSerie.Classes
{
    //Essa classe vai ter a conexao com a InterFace Repositorio
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public bool VerificarId(int id)
        {
            if (listaSerie.Count == 0 || listaSerie.Count - 1 < id)
            {
                Console.WriteLine("\nErro!\nLista Vazia ou id não encontrado!");
                return false;
            }

            return true;
        }

        public void Atualiza(int id, Serie entidade)
        {
            try
            {
                if (VerificarId(id) == false)
                    return;

                listaSerie[id] = entidade;
            }
           
            catch (Exception e)
            {
                Console.WriteLine($"\nErro!\n{e.Message}");
            }
        }

        public void Exclui(int id)
        {
            try
            {
                if (VerificarId(id) == false)
                    return;

                listaSerie[id].Excluir();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro!\n{e.Message}");
            }
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if (VerificarId(id) == false)
                return null;

            return listaSerie[id];
        }
    }
}
