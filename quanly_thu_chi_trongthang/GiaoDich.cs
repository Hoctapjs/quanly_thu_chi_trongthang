using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanly_thu_chi_trongthang
{
    class GiaoDich
    {
        public string Loai { get; set; }
        public double SoTien { get; set; }
        public string MoTa { get; set; }
        public DateTime Ngay { get; set; }


        public GiaoDich(string type, double amount, string description, DateTime date)
        {
            Loai = type;
            SoTien = amount;
            MoTa = description;
            Ngay = date;
        }

        // chuyển đổi một đối tượng thành 1 chuỗi
        public override string ToString()
        {
            return $"{Ngay:d} - {Loai} - {SoTien:C} - {MoTa}";
        }

        public static void ThemGiaoDich(List<GiaoDich> tongluongtien)
        {
            Console.Write("Nhap loai giao dich (Thu/Chi): ");
            string type = Console.ReadLine();

            Console.Write("Nhap so tien: ");
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("So tien khong hop le. Vui long nhap lai.");
                Console.Write("Nhap so tien: ");
            }

            Console.Write("Nhap mo ta: ");
            string description = Console.ReadLine();

            // Lấy ngày hiện tại
            DateTime date = DateTime.Now;

            // Tạo đối tượng Transaction và thêm vào danh sách
            GiaoDich GiaoDichMoi = new GiaoDich(type, amount, description, date); // khởi tão đối tượng dựa vào class
            tongluongtien.Add(GiaoDichMoi);

            Console.WriteLine("Giao dich duoc them thanh cong.");
        }

        public static void HienThiGiaoDich(List<GiaoDich> tonggiaodich)
        {
            Console.WriteLine("----- Danh sach giao dich -----");
            foreach (GiaoDich motgiaodich in tonggiaodich)
            {
                Console.WriteLine(motgiaodich);
            }
        }

        public static void HienThi_TongThuVaChiTrongThang(List<GiaoDich> tonggiaodich)
        {
            double TongThu = 0;
            double TongChi = 0;

            foreach (GiaoDich motgiaodich in tonggiaodich)
            {
                if (motgiaodich.Loai.Equals("Thu", StringComparison.OrdinalIgnoreCase))
                {
                    TongThu += motgiaodich.SoTien;
                }
                else if (motgiaodich.Loai.Equals("Chi", StringComparison.OrdinalIgnoreCase))
                {
                    TongChi += motgiaodich.SoTien;
                }
            }

            Console.WriteLine($"Tong thu nhap trong 1 thang: {TongThu:C}");
            Console.WriteLine($"Tong chi phi trong 1 thang: {TongChi:C}");
            // comment moi
        }
    }
}
