using MySqlConnector;

namespace CRUD_Practice.DBMySql.Main
{
    public class RepositoryContext(MySqlConnection connection, MySqlTransaction? transaction, string encryptionKey)
    {
        public MySqlConnection Connection { get; } = connection;
        public MySqlTransaction? Transaction { get; } = transaction;
        public string EncryptionKey { get; } = encryptionKey;
    }
}
