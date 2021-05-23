using System.Collections.Generic;
using Dio_Series.interfaces;


namespace Dio_Series
{
    public class DesenhoRepositorio : iRepositorio<Desenhos>
    {
        private List<Desenhos> listaDesenhos = new List<Desenhos>();
        public void Atualiza(int id, Desenhos objeto)
        {
            listaDesenhos[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaDesenhos[id].Excluir(); // seta como exluido true
        }

        public void Insere(Desenhos objeto)
        {
            listaDesenhos.Add(objeto);
        }

        public List<Desenhos> Lista()
        {
            return listaDesenhos;
        }

        public int ProximoId()
        {
            return listaDesenhos.Count;
        }

        public Desenhos RetornaPorId(int id)
        {
            return listaDesenhos[id];
        }
    }
}