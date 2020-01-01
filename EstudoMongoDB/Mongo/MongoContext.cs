using EstudoMongoDB.Mongo.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoMongoDB.Mongo
{
    public class MongoContext
    {
        private const string NomeDatabase = "Biblioteca";
        private const string NomeColecao = "Livros";

        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabaseBiblioteca;

        public MongoContext()
        {
            mongoClient = new MongoClient(ConnectionString());
            mongoDatabaseBiblioteca = mongoClient.GetDatabase(NomeDatabase);
        }

        private string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
        }

        public IMongoCollection<Livro> GetCollectionLivros()
        {
            return mongoDatabaseBiblioteca.GetCollection<Livro>(NomeColecao);
        }
    }
}
