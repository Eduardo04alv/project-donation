using Donation_Infrastructure.IRepository;
using Microsoft.Extensions.Configuration;
using project_donation.Models.donations;
using System.Data.SqlClient;


namespace Donation_Infrastructure.Repository
{
    public class DonationsRepository : IDonationsRepository
    {
        private readonly string _connectionString;
        public readonly IConfiguration _Configuration;
        public readonly object reader;

        public DonationsRepository(IConfiguration Configuration)
        {
            _Configuration = Configuration;
            _connectionString = _Configuration.GetConnectionString("cadenaSQL");
        }
        public void Add(Donations _Donations)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var klk = connection.BeginTransaction())
                {
                    try
                    {
                        var command = new SqlCommand(" insert into donations ( id_donor, id_Benefi, amount, type_donation, date_donation )  values ( @id_donor, @id_Benefi, @amount, @type_donation, @date_donationi )", connection);
                        command.Parameters.AddWithValue(" @id_donor", _Donations.id_donor);
                        command.Parameters.AddWithValue(" @id_Benefi", _Donations.id_Benefi);
                        command.Parameters.AddWithValue(" @amount", _Donations.amount);
                        command.Parameters.AddWithValue(" @type_donation", _Donations.type_donation);
                        command.Parameters.AddWithValue(" @date_donation", _Donations.date_donation);

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
            var command = new SqlCommand("delete from donations where d_donation = @d_donation ", connection);
            command.Parameters.AddWithValue("d_donation", id);
            connection.Open();
            command.ExecuteNonQuery();
            command.Clone();
        }
        public async Task<Donations> GetBYId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from donations where d_donation = @d_donation ", connection);
                command.Parameters.AddWithValue("d_donation", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Donations
                        {
                            d_donation = (int)reader["d_donation"],
                            id_donor = (int)reader["id_donor"],
                            id_Benefi = (int)reader["id_Benefi"],
                            amount = (decimal)float.Parse(reader["amount"].ToString()),
                            date_donation = reader["date_donation"].ToString(),

                        };
                    }
                }
            }
            return null;
        }
        public List<Donations> Getall()
        {
            var _Donations = new List<Donations>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from donations", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _Donations.Add(new Donations
                        {
                            d_donation = (int)reader["d_donation"],
                            id_donor = (int)reader["id_donor"],
                            id_Benefi = (int)reader["id_Benefi"],
                            amount = (decimal)float.Parse(reader["amount"].ToString()),
                            date_donation = reader["date_donation"].ToString(),
                        });
                    }
                }
            }
            return _Donations;
        }
        public void Update(Donations _Donations)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Update donations set id_donor = @id_donor, id_Benefi = @id_Benefi, amount = @amount, type_donation = @type_donation, date_donation = @date_donation  where d_donation = @d_donation ", connection);
                command.Parameters.AddWithValue(" @id_donor", _Donations.id_donor);
                command.Parameters.AddWithValue(" @id_Benefi", _Donations.id_Benefi);
                command.Parameters.AddWithValue(" @amount", _Donations.amount);
                command.Parameters.AddWithValue(" @type_donation", _Donations.type_donation);
                command.Parameters.AddWithValue(" @date_donation", _Donations.date_donation);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
