using System;
using System.Collections.Generic;

namespace ManajemenPerpustakaan
{
    public class Book
    {
        public int ID { get; set; }
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int TahunTerbit { get; set; }
        public bool Status { get; set; }

        public Book(int id, string judul, string penulis, int tahunterbit)
        {
            ID = id;
            Judul = judul;
            Penulis = penulis;
            TahunTerbit = tahunterbit;
            Status = true;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Judul: {Judul}, Penulis: {Penulis}, Tahun: {TahunTerbit}, Status: {(Status ? "Tersedia" : "Dipinjam")}";
        }
    }

    public class Perpustakaan
    {
        public string Nama { get; set; }
        public string Alamat { get; set; }
        private List<Book> books;

        public Perpustakaan(string nama, string alamat)
        {
            Nama = nama;
            Alamat = alamat;
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Buku Berhasil Ditambahkan.");
        }

        public void DisplayBooks()
        {
            Console.WriteLine("List Buku:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public Book FindBookById(int id)
        {
            return books.Find(b => b.ID == id);
        }

        public List<Book> FindBooksByTitle(string judul)
        {
            return books.FindAll(b => b.Judul.Contains(judul, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateBook(int id, string judul, string penulis, int tahunterbit, bool status)
        {
            var book = FindBookById(id);
            if (book != null)
            {
                book.Judul = judul;
                book.Penulis = penulis;
                book.TahunTerbit = tahunterbit;
                book.Status = status;
                Console.WriteLine("Buku Berhasil Terupdate.");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }

        public void DeleteBook(int id)
        {
            var book = FindBookById(id);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Buku berhasil terhapus");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan("Perpustakaan Jaya Jaya Jaya", "Jl.Magenda");
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nSistem Managemen Perpustakaan");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Tampilkan Buku");
                Console.WriteLine("3. Update Buku");
                Console.WriteLine("4. Hapus Buku");
                Console.WriteLine("5. Cari Buku Dengan ID");
                Console.WriteLine("6. Cari Buku Dengan Judul");
                Console.WriteLine("0. Keluar");
                Console.Write("Pilihan Anda: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Masukkan ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Masukkan Judul: ");
                        string judul = Console.ReadLine();
                        Console.Write("Masukkan Nama Penulis: ");
                        string penulis = Console.ReadLine();
                        Console.Write("Masukkan Tahun Penerbitan: ");
                        int tahunterbit = int.Parse(Console.ReadLine());
                        perpustakaan.AddBook(new Book(id, judul, penulis, tahunterbit));
                        break;

                    case "2":
                        perpustakaan.DisplayBooks();
                        break;

                    case "3":
                        Console.Write("Masukkan ID buku yang ingin diupdate: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Masukkan Judul Baru: ");
                        string JudulBaru = Console.ReadLine();
                        Console.Write("Masukkan Nama Penulis Baru: ");
                        string PenulisBaru = Console.ReadLine();
                        Console.Write("Masukkan Tahun Penerbitan Baru: ");
                        int TahunTerbitBaru = int.Parse(Console.ReadLine());
                        Console.Write("Apakah bukunya tersedia? (ya/tidak): ");
                        string statusInput = Console.ReadLine().ToLower();
                        bool Status = statusInput == "ya"; // Mengubah input menjadi boolean
                        perpustakaan.UpdateBook(updateId, JudulBaru, PenulisBaru, TahunTerbitBaru, Status);
                        break;

                    case "4":
                        Console.Write("Masukkan ID buku yang ingin dihapus: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        perpustakaan.DeleteBook(deleteId);
                        break;

                    case "5":
                        Console.Write("Masukkan ID buku yang ingin dicari: ");
                        int searchId = int.Parse(Console.ReadLine());
                        var foundBookById = perpustakaan.FindBookById(searchId);
                        if (foundBookById != null)
                        {
                            Console.WriteLine("Buku Ditemukan: " + foundBookById);
                        }
                        else
                        {
                            Console.WriteLine("Buku tidak dapat ditemukan.");
                        }
                        break;

                    case "6":
                        Console.Write("Masukkan Judul buku yang ingin dicari: ");
                        string searchTitle = Console.ReadLine();
                        var foundBooksByTitle = perpustakaan.FindBooksByTitle(searchTitle);
                        if (foundBooksByTitle.Count > 0)
                        {
                            Console.WriteLine("Buku ditemukan:");
                            foreach (var book in foundBooksByTitle)
                            {
                                Console.WriteLine(book);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Buku tidak ditemukan.");
                        }
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("Selamat Tinggal!");
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }
            }
        }
    }
}