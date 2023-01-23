using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.H20con);
            cmd = con.CreateCommand();
        }

        #region Yönetici Metodları
        public Yoneticiler YoneticiGiris(string mail,string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi=Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi>0)
                {
                    cmd.CommandText = "SELECT * FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader= cmd.ExecuteReader();
                    Yoneticiler y = new Yoneticiler();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim=reader.GetString(1);
                        y.Soyisim=reader.GetString(2);
                        y.Mail= reader.GetString(3);
                        y.Sifre= reader.GetString(4);
                        y.Telefon= reader.GetString(5);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
               
            }
            catch 
            {

                return null;
            }
            finally { con.Close(); }
        }
        #endregion
    }
}
