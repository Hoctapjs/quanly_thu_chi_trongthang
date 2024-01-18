using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Khởi tạo danh sách để lưu trữ giao dịch
        List<Transaction> transactions = new List<Transaction>();

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
                    AddTransaction(transactions);
                    break;
                case "2":
                    DisplayTransactions(transactions);
                    break;
                case "3":
                    DisplayTotalIncomeAndExpense(transactions);
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

    static void AddTransaction(List<Transaction> transactions)
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
        Transaction transaction = new Transaction(type, amount, description, date);
        transactions.Add(transaction);

        Console.WriteLine("Giao dich duoc them thanh cong.");
    }

    static void DisplayTransactions(List<Transaction> transactions)
    {
        Console.WriteLine("----- Danh sach giao dich -----");
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine(transaction);
        }
    }

    static void DisplayTotalIncomeAndExpense(List<Transaction> transactions)
    {
        double totalIncome = 0;
        double totalExpense = 0;

        foreach (Transaction transaction in transactions)
        {
            if (transaction.Type.Equals("Thu", StringComparison.OrdinalIgnoreCase))
            {
                totalIncome += transaction.Amount;
            }
            else if (transaction.Type.Equals("Chi", StringComparison.OrdinalIgnoreCase))
            {
                totalExpense += transaction.Amount;
            }
        }

        Console.WriteLine($"Tong thu nhap trong 1 thang: {totalIncome:C}");
        Console.WriteLine($"Tong chi phi trong 1 thang: {totalExpense:C}");
    }
}

class Transaction
{
    public string Type { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public Transaction(string type, double amount, string description, DateTime date)
    {
        Type = type;
        Amount = amount;
        Description = description;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date:d} - {Type} - {Amount:C} - {Description}";
    }
}
