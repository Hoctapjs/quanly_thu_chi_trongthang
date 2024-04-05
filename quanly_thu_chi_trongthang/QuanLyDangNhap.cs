using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace quanly_thu_chi_trongthang
{
    internal class QuanLyDangNhap
    {
        private string xmlFilePath;

        public QuanLyDangNhap(string filePath)
        {
            xmlFilePath = filePath;
        }

        static void KiemTraDangNhap(QuanLyDangNhap manager)
        {
            Console.WriteLine("Nhập tên đăng nhập: ");
            string username = Console.ReadLine();
            Console.WriteLine("Nhập mật khẩu: ");
            string password = Console.ReadLine();

            if (manager.DangNhap(username, password))
            {
                ThongBaoDangNhapThanhCong();
            }
            else
            {
                ThongBaoDangNhapThatBai();
            }
        }

        static void ThongBaoDangNhapThanhCong()
        {
            Console.WriteLine("Đăng nhập thành công!");
        }

        static void ThongBaoDangNhapThatBai()
        {
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng.");
        }

        public bool DangNhap(string username, string password)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNodeList users = doc.SelectNodes("/dsnguoidung/nguoidung");

            foreach (XmlNode user in users)
            {
                string username_xml = user.SelectSingleNode("username").InnerText;
                string password_xml = user.SelectSingleNode("password").InnerText;

                if (username == username_xml && password == password_xml)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
