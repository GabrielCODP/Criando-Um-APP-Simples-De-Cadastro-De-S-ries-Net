using CadastroEmSerie.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEmSerie.Classes
{
    class Serie : EntidadeBase
    {

        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public bool Excluido { get; private set; }


        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            //return $"Gênero: {Genero}\nTítulo:{Titulo}\nDescrição:{Descricao}\nAno de Início:{Ano}";
            return $"Gênero: {Genero + Environment.NewLine}Título:{Titulo + Environment.NewLine}Descrição:{Descricao + Environment.NewLine}Ano de Início:{Ano + Environment.NewLine}Excluido: {Excluido}";
            //Essa função é ideal, caso você não sabe se p sistema precisa utilizar o \n
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}
