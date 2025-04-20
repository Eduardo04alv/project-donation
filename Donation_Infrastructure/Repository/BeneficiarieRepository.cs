using Donation_Domain.entities;
using Donation_Infrastructure.IRepository;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Donation_Infrastructure.Repository
{
    public class BeneficiarieRepository : IBeneficiarieRepository
    {

        private readonly string _connectionString;
        public readonly IConfiguration _Configuration;
        public readonly object reader;

        public BeneficiarieRepository(IConfiguration Configuration)
        {
            _Configuration = Configuration;
            _connectionString = _Configuration.GetConnectionString("cadenaSQL");
        }
        public void Add(Beneficiarie _beneficiarie)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var klk = connection.BeginTransaction())
                {
                    try
                    {
                        var command = new SqlCommand(" insert into Beneficiaries ( name_Benefi, phone_Benefi , website, description )  values ( @name_Benefi, @phone_Benefi, @website, @description )", connection);

                        command.Parameters.AddWithValue("@name_Benefi", _beneficiarie.name_Benefi);
                        command.Parameters.AddWithValue("@phone_Benefi", _beneficiarie.phone_Benefi);
                        command.Parameters.AddWithValue("@website", _beneficiarie.website);
                        command.Parameters.AddWithValue("@description", _beneficiarie.description);

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
            var command = new SqlCommand("delete from Beneficiaries where id_Benefi = @id_Benefi ", connection);
            command.Parameters.AddWithValue("id_Benefi", id);
            connection.Open();
            command.ExecuteNonQuery();
            command.Clone();
        }
        public async Task<Beneficiarie> GetBYId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Beneficiaries where id_Benefi = @id_Benefi ", connection);
                command.Parameters.AddWithValue("id_Benefi", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        return new Beneficiarie
                        {
                            id_Benefi = (int)reader["id_Benefi"],
                            name_Benefi = reader["name_Benefi"].ToString(),
                            phone_Benefi = reader["phone_Benefi"].ToString(),
                            website = reader["website"].ToString(),
                            description = reader["description"].ToString()

                        };
                    }
                }
            }
            return null;
        }
        public List<Beneficiarie> Getall()
        {
            var donors = new List<Beneficiarie>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Beneficiaries", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        donors.Add(new Beneficiarie
                        {
                            id_Benefi = (int)reader["id_Benefi"],
                            name_Benefi = reader["name_Benefi"].ToString(),
                            phone_Benefi = reader["phone_Benefi"].ToString(),
                            website = reader["website"].ToString(),
                            description = reader["description"].ToString()
                        });
                    }
                }
            }
            return donors;
        }
        public void Update(Beneficiarie _beneficiarie)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Update Beneficiaries set name_Benefi = @name_Benefi, phone_Benefi = @phone_Benefi, website = @website,  description = @description  where id_Benefi = @id_id_Benefi ", connection);

                command.Parameters.AddWithValue("@name_Benefi", _beneficiarie.name_Benefi);
                command.Parameters.AddWithValue("@phone_Benefi", _beneficiarie.phone_Benefi);
                command.Parameters.AddWithValue("@website", _beneficiarie.website);
                command.Parameters.AddWithValue("@description", _beneficiarie.description);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

