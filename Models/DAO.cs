using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RateMyBeer.Models
{
    public class DAO
    {
        SqlConnection conn;
        public string message = "";

        public void Connection()
        {
            string rateMyBeerConn = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            conn = new SqlConnection(rateMyBeerConn);
        }

        public int Insert(Beer beer)
        {
            int count = 0;
            Connection();
            SqlCommand cmd = new SqlCommand("INSERT_INTO_Beer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", beer.Name);
            cmd.Parameters.AddWithValue("@style", beer.Style);
            cmd.Parameters.AddWithValue("@abv", beer.ABV);
            cmd.Parameters.AddWithValue("@price", beer.Price);
            cmd.Parameters.AddWithValue("@breweryname", beer.BreweryName);
            cmd.Parameters.AddWithValue("@image", beer.Image);
            cmd.Parameters.AddWithValue("@description", beer.Description);
            cmd.Parameters.AddWithValue("@rating", beer.Rating);


            using (conn)
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            return count;
        }

        public void InsertRating(int beerId)
        {
            decimal rating = ReturnRating(beerId);
            string insertRating = "UPDATE tbBeer SET Rating=" + rating + " WHERE BeerID=" + beerId;

            Connection();
            SqlCommand cmd = new SqlCommand(insertRating, conn);
            cmd.CommandType = CommandType.Text;

            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Beer> ShowAllBeers()
        {
            List<Beer> list = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("AllBeers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    //beer.Rating = ReturnRating(int.Parse(reader["Rating"].ToString()));
                    list.Add(beer);

                }
            }
            return list;
        }
        public List<Brewery> ShowAllBrewerys()
        {
            List<Brewery> list = new List<Brewery>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspBreweries", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brewery brewery = new Brewery();
                    brewery.BreweryID = int.Parse(reader["BreweryID"].ToString());
                    brewery.Name = reader["Name"].ToString();
                    brewery.Location = reader["Country"].ToString();
                    brewery.WebsiteUrl = reader["Website"].ToString();
                    brewery.Founded = DateTime.Parse(reader["Date Founded"].ToString());
                    list.Add(brewery);

                }
            }
            return list;
        }
        public List<Beer> ShowAllTopRated()
        {
            List<Beer> list = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspTopRated", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    list.Add(beer);

                }
            }
            return list;
        }
        public List<Beer> ShowAllAles()
        {
            List<Beer> list = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspAllAles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    list.Add(beer);

                }
            }
            return list;
        }

        public List<Beer> ShowAllIpas()
        {
            List<Beer> list = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspAllIpas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    list.Add(beer);

                }
            }
            return list;
        }
        public List<Beer> ShowAllStouts()
        {
            List<Beer> list = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspAllStouts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    list.Add(beer);

                }
            }
            return list;
        }
        public List<Beer> ShowAllBlondes()
        {
            List<Beer> list = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspAllBlondes", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    list.Add(beer);

                }
            }
            return list;
        }

        public Beer ReturnBeerByID(int beerId)
        {
            string id = "'" + beerId.ToString() + "';";

            Beer individualBeer = new Beer();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbBeer WHERE BeerID=" + id, conn);
            cmd.CommandType = CommandType.Text;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());

                    individualBeer = beer;
                }
            }

            return individualBeer;
        }

        public List<Beer> ReturnBreweryByName(string breweryName)
        {

            List<Beer> individualBrewery = new List<Beer>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbBeer WHERE BreweryName=" + "'"+breweryName+"';", conn);
            cmd.CommandType = CommandType.Text;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    individualBrewery.Add(beer);

                }
            }
                return individualBrewery;
        }

        public List<Review> ReturnReviewByBeerID(int beerId)
        {
            string id = "'" + beerId.ToString() + "';";

            List<Review> list = new List<Review>();

            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbReview WHERE BeerID=" + id, conn);
            cmd.CommandType = CommandType.Text;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Review review = new Review();
                    //review.BeerID = int.Parse(reader["BeerID"].ToString());
                    review.ReviewID = int.Parse(reader["ReviewID"].ToString());
                    review.Title = reader["Title"].ToString();
                    review.Rating = decimal.Parse(reader["Rating"].ToString());
                    review.Date = DateTime.Parse(reader["Date"].ToString());
                    review.UserName = reader["UserName"].ToString();
                    review.ReviewBody = reader["Review"].ToString();
                    list.Add(review);

                }
            }

            return list;
        }

        public int InsertReview(WriteReviewViewModel review)
        {

            int count = 0;
            Connection();
            // Initialise object of sqlcommand passing the name of the Stored Proc for this action in the DB
            SqlCommand com = new SqlCommand("INSERT_INTO_Review", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@title", review.Reviews.Title);
            com.Parameters.AddWithValue("@rating", review.Reviews.Rating);
            com.Parameters.AddWithValue("@date", DateTime.Now);
            com.Parameters.AddWithValue("@beerid", review.Reviews.BeerID);
            com.Parameters.AddWithValue("@username", review.Reviews.UserName);
            com.Parameters.AddWithValue("@review", review.Reviews.ReviewBody);

            using (conn)
            {
                conn.Open();
                count = com.ExecuteNonQuery();
            }
            return count;

        }

        public decimal ReturnRating(int beerId)
        {
            string id = "'" + beerId.ToString() + "';";
            int ratingCount = 0;
            decimal rating;
            decimal roundRating;

            Connection();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*), SUM(CASE WHEN BeerID =" + beerId + " THEN 1 ELSE 0 END) FROM tbReview;", conn);
            cmd.CommandType = CommandType.Text;

            using (conn)
            {
                conn.Open();
                ratingCount = Convert.ToInt32(cmd.ExecuteScalar());

            }

                Connection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.TableMappings.Add("Table", "tbReview");
                conn.Open();

                SqlCommand command = new SqlCommand(
                        "SELECT * FROM dbo.tbReview;",
                        conn);
                command.CommandType = CommandType.Text;
                adapter.SelectCommand = command;

                DataSet dataSet = new DataSet("tbReview");
                adapter.Fill(dataSet);
                DataTable table;
                table = dataSet.Tables["tbReview"];

                if (table.Compute("SUM(Rating)", "BeerID =" + beerId) == DBNull.Value)
                {
                    return 0;
                }

                else
                {
                    decimal sumObject;
                    sumObject = Convert.ToDecimal(table.Compute("SUM(Rating)", "BeerID =" + beerId));
                    rating = sumObject / ratingCount;
                    roundRating = Math.Round(rating, 1);
                    return roundRating;
                }

        }

        public string CheckLogin(Member member)
        {
            //string memberName = "";

            Connection();
            SqlCommand cmd = new SqlCommand("CheckLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@pass", member.Password);
            try
            {
                conn.Open();
                member.UserName = (string)cmd.ExecuteScalar();
                // memberName = member.FirstName;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            // return memberName;
            return member.UserName;

        }

        public int InsertMember(Member member)
        {
            int count = 0;
            Connection();
            SqlCommand cmd = new SqlCommand("Insert_Into_tbMember", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //adding parameters with value
            cmd.Parameters.AddWithValue("@user", member.UserName);
            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@pass", member.Password);
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {

                conn.Close();
            }

            return count;
        }

        public List<Beer> SearchBeer(string searchString)
        {
            searchString = "'%" + searchString + "%'";

            List<Beer> searchResult = new List<Beer>();

            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbBeer WHERE Name LIKE " + searchString, conn);
            cmd.CommandType = CommandType.Text;
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer = new Beer();
                    beer.BeerID = int.Parse(reader["BeerID"].ToString());
                    beer.Name = reader["Name"].ToString();
                    beer.Style = reader["Style"].ToString();
                    beer.ABV = decimal.Parse(reader["ABV"].ToString());
                    beer.Price = decimal.Parse(reader["Price"].ToString());
                    beer.BreweryName = reader["BreweryName"].ToString();
                    beer.Description = reader["Description"].ToString();
                    beer.Image = reader["Image"].ToString();
                    beer.Rating = decimal.Parse(reader["Rating"].ToString());
                    searchResult.Add(beer);

                }
            }

            return searchResult;
        }


    }
}