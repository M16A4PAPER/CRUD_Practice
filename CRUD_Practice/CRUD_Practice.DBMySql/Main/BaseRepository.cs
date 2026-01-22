using MySqlConnector;

namespace CRUD_Practice.DBMySql.Main
{
    public abstract class BaseRepository(RepositoryContext context)
    {
        protected readonly MySqlConnection _connection = context.Connection;
        protected readonly MySqlTransaction? _transaction = context.Transaction;
        protected readonly string _encryptionKey = context.EncryptionKey;
    }
}
