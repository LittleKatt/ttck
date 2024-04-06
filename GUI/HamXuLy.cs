using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class HamXuLy
    {
        //Đếm số ngày làm việc trong tháng 
        public static int demSoNgayLamViecTrongThang(int thang, int nam)
        {
            int dem = 0 ;
            DateTime f = new DateTime(nam, thang, 01);
            int x = f.Month + 1;
            while (f.Month<x)
            {
                dem = dem +1;
                if(f.DayOfWeek ==DayOfWeek.Sunday) 
                {
                    dem = dem - 1;
                }
                f= f.AddDays(1);
            }
            return dem;
        }
        public static int laySoNgayCuaThang(int thang, int nam) 
        {
            return DateTime.DaysInMonth(nam, thang);    
        }

        public static string layThuTrongTuan (int nam,  int thang, int ngay)
        {
            string thu = "";
            DateTime newDate = new DateTime(nam, thang, ngay);
            switch(newDate.DayOfWeek.ToString())
            {
                case "Monday":
                    thu = "Thứ hai";
                    break;
                case "Tuesday":
                    thu = "Thứ ba";
                    break;
                case "Wednesday":
                    thu = "Thứ tư";
                    break;
                case "Thursday":
                    thu = "Thứ năm";
                    break;
                case "Friday":
                    thu = "Thứ sáu";
                    break;
                case "Saturday":
                    thu = "Thứ bảy";
                    break;
                case "Sunday":
                    thu = "Chủ nhật";
                    break;
            }
            return thu;
        }
        // khai báo biến sql 
        static SqlConnection con = new SqlConnection();
        //Ham ket noi 
        public static void taoKetNoi()
        {
            con.ConnectionString = @"Data Source=DESKTOP-GGD112V\SQL;Initial Catalog=QLNS;Integrated Security=True";
            try
            {
                con.Open();
            }
            catch (Exception) 
            {
                throw;
            }
        }
        //Hàm đóng kết nối 
        public static void dongKetNoi()
        {
            con.Close();
        }
        //Hàm đổ dữ liệu vào database 
        public static DataTable getData(string query)
        {
            taoKetNoi();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(tb);
            dongKetNoi();
            return tb;
        }
        //Hàm lấy dữ liệu từ database
        public static DataSet getDataSet(string query)
        {
            taoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //Hàm inset/update dữ liệu
        public static void execQuery(string qr)
        {
            taoKetNoi();
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dongKetNoi();
        }








        public static SqlCommand sqlCom;

        public void ThucThi(string sql)
        {
            try
            {
                taoKetNoi();
                sqlCom = new SqlCommand(sql, con);
                sqlCom.ExecuteNonQuery();
                dongKetNoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            
        }

        public bool SaoLuu(string sDuongDan)
        {
            try
            {

                string sTen = @"\QLNS(" + DateTime.Now.Day.ToString() + "_" +
                  DateTime.Now.Month.ToString() + "_" +
                  DateTime.Now.Year.ToString() + "_" +
                  DateTime.Now.Hour.ToString() + "_" +
                  DateTime.Now.Minute.ToString() + ").bak";
                string sql = "BACKUP DATABASE QLNS TO DISK = N'" + sDuongDan +
               sTen + "'";
                ThucThi(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool PhucHoiDuLieu(string sDuongDan)
        {

            string sql = @"
               RESTORE DATABASE QLNS
                FROM DISK = N'" + sDuongDan + "'" + "WITH REPLACE, RECOVERY";
            SqlConnection.ClearAllPools();

            try
            {
                ThucThi(sql);

                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return false;
        }
    }
}
