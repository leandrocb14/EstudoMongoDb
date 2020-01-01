using EstudoMongoDB.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace EstudoMongoDB.Mongo.DAO
{
    public class LivroDAO
    {
        private readonly IMongoCollection<Livro> mongoCollectionLivro;

        public LivroDAO()
        {
            MongoContext mongoContext = new MongoContext();
            mongoCollectionLivro = mongoContext.GetCollectionLivros();
        }

        public void Adicionar(Livro pLivro)
        {
            mongoCollectionLivro.InsertOne(pLivro);
        }

        public void AdicionarVarios(Livro[] livros)
        {
            mongoCollectionLivro.InsertMany(livros);
        }

        public List<Livro> Listar()
        {
            var filterBuilder = Builders<Livro>.Filter.Gte(l => l.Ano, 2000) & Builders<Livro>.Filter.Gte(l => l.Paginas, 600);
            return mongoCollectionLivro.Find(filterBuilder).ToList();
        }

        public void Alterar(Livro pLivro)
        {
            var filterBuilder = Builders<Livro>.Filter.Eq(l => l.Id, pLivro.Id);
            var livro = mongoCollectionLivro.Find(filterBuilder).FirstOrDefault();
            livro.Ano = pLivro.Ano;
            livro.Paginas = pLivro.Paginas;
            mongoCollectionLivro.ReplaceOne(filterBuilder, livro);
        }

        public Livro BuscarPorTitulo(string pTitulo)
        {
            var filterBuilder = Builders<Livro>.Filter.And(
                );
            return mongoCollectionLivro.Find(filterBuilder).FirstOrDefault();
        }
    }
}
