using System;
using System.Collections.Generic;



class Program
{
    static void Main()
    {
        // chức năng đăng nhập
        // gọi class QuanLyDangNhap
        //DangNhapManager manager = new DangNhapManager("file.xml");
        //KiemTraDangNhap(manager);




        // Khởi tạo danh sách mới để lưu trữ các đối tượng giao dịch
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
// thêm các tính năng và không gian để chương trình phát triển
// Trong C#, một class là một khái niệm quan trọng để tổ chức mã nguồn và mô tả đối tượng.
// Đối tượng là một thể hiện cụ thể của một class, và class định nghĩa các thuộc tính và hành vi của đối tượng.
// Class ở đây của ta là GiaoDich, nó sẽ quy định những thuộc tính như: loai, so tien, mota, ngay và những phương thức khởi tạo
// Class khi được khởi tạo và gán các giá trị vào những thuộc tính thì sẽ thành đối tượng
// Đối tượng của ta ở đây là GiaoDichMoi (xem thêm ở line 65)



