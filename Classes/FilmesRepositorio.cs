using System;
using System.Collections.Generic;
using DIO.Series.Interface;


namespace DIO.Series
{
    public class FilmesRepositorio : IRepositorio<Filmes>
    {
        private List<Filmes> listaFilmes = new List<Filmes>();
        public void Atualizar(int id, Filmes objeto)
        {
            listaFilmes[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaFilmes[id].Excluir();
        }

        public void Insere(Filmes objeto)
        {
            listaFilmes.Add(objeto);
        }

        public List<Filmes> Lista()
        {
            return listaFilmes;
        }

        public int ProximoId()
        {
            return listaFilmes.Count;
        }

        public Filmes RetornaPorId(int id)
        {
            return listaFilmes[id];
        }
        
    }
}