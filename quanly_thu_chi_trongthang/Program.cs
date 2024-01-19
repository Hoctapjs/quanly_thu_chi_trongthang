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
                    ThemGiaoDich(luongtien);
                    break;
                case "2":
                    HienThiGiaoDich(luongtien);
                    break;
                case "3":
                    HienThi_TongThuVaChi(luongtien);
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

    static void ThemGiaoDich(List<GiaoDich> luongtien)
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
        GiaoDich transaction = new GiaoDich(type, amount, description, date);
        luongtien.Add(transaction);

        Console.WriteLine("Giao dich duoc them thanh cong.");
    }

    static void HienThiGiaoDich(List<GiaoDich> transactions)
    {
        Console.WriteLine("----- Danh sach giao dich -----");
        foreach (GiaoDich transaction in transactions)
        {
            Console.WriteLine(transaction);
        }
    }

    static void HienThi_TongThuVaChi(List<GiaoDich> transactions)
    {
        double totalIncome = 0;
        double totalExpense = 0;

        foreach (GiaoDich transaction in transactions)
        {
            if (transaction.Loai.Equals("Thu", StringComparison.OrdinalIgnoreCase))
            {
                totalIncome += transaction.SoTien;
            }
            else if (transaction.Loai.Equals("Chi", StringComparison.OrdinalIgnoreCase))
            {
                totalExpense += transaction.SoTien;
            }
        }

        Console.WriteLine($"Tong thu nhap trong 1 thang: {totalIncome:C}");
        Console.WriteLine($"Tong chi phi trong 1 thang: {totalExpense:C}");
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

    public override string ToString()
    {
        return $"{Ngay:d} - {Loai} - {SoTien:C} - {MoTa}";
    }
}
// thêm các tính năng và không gian để chương trình phát triển