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
        public Yoneticiler YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT * FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yoneticiler y = new Yoneticiler();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyisim = reader.GetString(2);
                        y.Mail = reader.GetString(3);
                        y.Sifre = reader.GetString(4);
                        y.Telefon = reader.GetString(5);
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
        #region Coin Metodları
        public bool CoinKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Coinler WHERE Isim = @isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            finally { con.Close(); }
        }
        public bool CoinEkle(Coinler c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Coinler(Isim,CoinNick,Max_Arz,Resim,Fiyat,Aktif) VALUES(@isim,@coinNick,@maxArz,@resim,@fiyat,@aktif)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", c.Isim);
                cmd.Parameters.AddWithValue("@coinNick", c.CoinNick);
                cmd.Parameters.AddWithValue("@maxArz", c.Max_Arz);
                cmd.Parameters.AddWithValue("@resim", c.Resim);
                cmd.Parameters.AddWithValue("@fiyat", c.Fiyat);
                cmd.Parameters.AddWithValue("@aktif", c.Aktif);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }

        public bool UpdateCoinPrice(decimal change)
        {
            return true;
        }
        #endregion
        #region NFT Metodları
        public bool NFTKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM NFT WHERE Isim=@isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool NFTEkle(NFT n)
        {
            try
            {
                cmd.CommandText = "INSERT INTO NFT(Isim,Fiyat,Resim) VALUES (@isim,@fiyat,@resim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", n.Isim);
                cmd.Parameters.AddWithValue("@fiyat", n.Fiyat);
                cmd.Parameters.AddWithValue("@resim", n.Resim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        #endregion
        #region Talep Metodları
        public List<Talepler> TalepListele(int d)
        {
            try
            {
                List<Talepler> list = new List<Talepler>();
                cmd.CommandText = "SELECT T.ID,T.Uye_ID,U.Isim,T.Yonetici_ID,Y.Isim,T.Miktar,T.Talep_Tarihi,T.Onay_Tarihi,T.Durum FROM Talepler AS T JOIN Uyeler AS U ON T.Uye_ID=U.ID JOIN Yoneticiler AS Y ON T.Yonetici_ID=Y.ID WHERE T.Durum=@durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", d);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Talepler t = new Talepler();
                    t.ID = reader.GetInt32(0);
                    t.Uye_ID = reader.GetInt32(1);
                    t.Uye_Adi = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici_Adi = reader.GetString(4);
                    t.Miktar = reader.GetDecimal(5);
                    t.Talep_Tarihi = reader.GetDateTime(6);
                    t.Onay_Tarihi = !reader.IsDBNull(7) ? reader.GetDateTime(7) : reader.GetDateTime(6);
                    t.Durum = reader.GetByte(8);
                    list.Add(t);
                }
                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }

        public bool bakiyeOnay(Talepler t)
        {
            try
            {
                cmd.CommandText = "UPDATE Talepler SET Durum=2 WHERE ID=@id UPDATE Uyeler SET Bakiye=Bakiye+@miktar WHERE ID=@uyeID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", t.ID);
                cmd.Parameters.AddWithValue("@miktar", t.Miktar);
                cmd.Parameters.AddWithValue("@uyeID", t.Uye_ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public Talepler talepGetir(int id)
        {
            Talepler t = new Talepler();
            try
            {
                cmd.CommandText = "SELECT T.ID,T.Uye_ID,U.Isim,T.Yonetici_ID,Y.Isim,T.Miktar,T.Talep_Tarihi,T.Onay_Tarihi,T.Durum FROM Talepler AS T JOIN Uyeler AS U ON T.Uye_ID=U.ID JOIN Yoneticiler AS Y ON T.Yonetici_ID=Y.ID WHERE T.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    t.ID = reader.GetInt32(0);
                    t.Uye_ID = reader.GetInt32(1);
                    t.Uye_Adi = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici_Adi = reader.GetString(4);
                    t.Miktar = reader.GetDecimal(5);
                    t.Talep_Tarihi = reader.GetDateTime(6);
                    t.Onay_Tarihi = !reader.IsDBNull(7) ? reader.GetDateTime(7) : reader.GetDateTime(6);
                    t.Durum = reader.GetByte(8);

                }
                return t;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public void talepUpdate(Talepler t)
        {
            try
            {
                cmd.CommandText = "UPDATE Talepler SET Onay_Tarihi=@onay_tarihi, Yonetici_ID=@yid WHERE ID=@id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@onay_tarihi", t.Onay_Tarihi);
                cmd.Parameters.AddWithValue("@yid", t.Yonetici_ID);
                cmd.Parameters.AddWithValue("@id", t.ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public bool bakiyeRed(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Talepler Set Durum=3 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }

        }
        #endregion
    }
}
