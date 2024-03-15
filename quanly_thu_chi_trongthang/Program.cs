using System;
using System.Collections.Generic;



class Program
{
    static void Main()
    {
        // Khởi tạo danh sách để lưu trữ giao dịch
        List<GiaoDich> luongtien = new List<GiaoDich>();

        while (true)
        {
            Console.WriteLine("----- Quan ly thu chi trong 1 thang -----");
            Console.WriteLine("1. Them giao dich");
            Console.WriteLine("2. Hien thi giao dich");
            Console.WriteLine("3. Tong thu chi trong 1 thang");
            Console.WriteLine("0. Thoat");

            Console.Write("Chon mot chuc nang (0-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GiaoDich.ThemGiaoDich(luongtien);
                    break;
                case "2":
                    GiaoDich.HienThiGiaoDich(luongtien);
                    break;
                case "3":
                    GiaoDich.HienThi_TongThuVaChiTrongThang(luongtien);
                    break;
                case "0":
                    Console.WriteLine("Ung dung ket thuc.");
                    return;
                default:
                    Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                    break;
            }

            Console.WriteLine();
        }
    }
}


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
    }
}
// thêm các tính năng và không gian để chương trình phát triển
// Trong C#, một class là một khái niệm quan trọng để tổ chức mã nguồn và mô tả đối tượng.
// Đối tượng là một thể hiện cụ thể của một class, và class định nghĩa các thuộc tính và hành vi của đối tượng.
// Class ở đây của ta là GiaoDich, nó sẽ quy định những thuộc tính như: loai, so tien, mota, ngay và những phương thức khởi tạo
// Class khi được khởi tạo và gán các giá trị vào những thuộc tính thì sẽ thành đối tượng
// Đối tượng của ta ở đây là GiaoDichMoi (xem thêm ở line 65)



