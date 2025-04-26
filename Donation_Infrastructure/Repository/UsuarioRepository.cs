using Donation_Domain.entities;
using Donation_Infrastructure.IRepository;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace Donation_Infrastructure.Repository
{
    public class UsuarioRepository : IusuarioRepository
    {
        private readonly string _connectionString;
        public readonly IConfiguration _Configuration;
        public readonly object reader;

        public UsuarioRepository(IConfiguration Configuration)
        {
            _Configuration = Configuration;
            _connectionString = _Configuration.GetConnectionString("cadenaSQL");
        }
        public void Add(Usuario _usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var klk = connection.BeginTransaction())
                {
                    try
                    {

                        var command = new SqlCommand(" insert into usuario ( username, pasword, rol )  values ( @username, @pasword, @rol )", connection);
                       
                        command.Parameters.AddWithValue(" @username", _usuario.username);
                        command.Parameters.AddWithValue(" @pasword", _usuario.pasword);
                        command.Parameters.AddWithValue(" @rol", _usuario.rol);
                        
                        command.ExecuteNonQuery();
                        klk.Commit();
                    }
                    catch (Exception)
                    {
                        klk.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public void Delete(int id)
        {
            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("delete from usuario where id = @id ", connection);
            command.Parameters.AddWithValue("id", id);
            connection.Open();
            command.ExecuteNonQuery();
            command.Clone();
        }
        public async Task<Usuario> GetBYId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from usuario where id = @id ", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            id = (int)reader["id"],
                            username = reader["username"].ToString(),
                            pasword = reader["pasword"].ToString(),
                            rol = reader["rol"].ToString()                           

                        };
                    }
                }
            }
            return null;
        }
        public List<Usuario> Getall()
        {
            var _Donations = new List<Usuario>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from usuario", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _Donations.Add(new Usuario
                        {
                            id = (int)reader["id"],
                            username = reader["username"].ToString(),
                            pasword = reader["pasword"].ToString(),
                            rol = reader["rol"].ToString()                           
                        });
                    }
                }
            }
            return _Donations;
        }
        public void Update(Usuario _usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Update usuario set username = @username, pasword = @pasword, rol = @rol  where id = @id ", connection);
                command.Parameters.AddWithValue(" @id", _usuario.id);
                command.Parameters.AddWithValue(" @username", _usuario.username);
                command.Parameters.AddWithValue(" @pasword", _usuario.pasword);
                command.Parameters.AddWithValue(" @rol", _usuario.rol);               

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

