using EstudoMongoDB.Mongo.DAO;
using EstudoMongoDB.Mongo.Model;
using System;
using System.Collections.Generic;

namespace EstudoMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            LivroDAO livroDAO = new LivroDAO();
            var livro = livroDAO.BuscarPorTitulo("Sob a redoma");
            livro.Ano = 2014;
            livro.Paginas = 700;
            livroDAO.Alterar(livro);
        }

        public static Livro incluiValoresLivro(string Titulo, string Autor, int Ano, int Paginas, string Assuntos)
        {
            Livro Livro = new Livro();
            Livro.Titulo = Titulo;
            Livro.Autor = Autor;
            Livro.Ano = Ano;
            Livro.Paginas = Paginas;
            string[] vetAssunto = Assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();
            for (int i = 0; i <= vetAssunto.Length - 1; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }
            Livro.Assunto = vetAssunto2;
            return Livro;
        }
    }
}
