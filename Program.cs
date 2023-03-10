using System;
using System.ComponentModel;

namespace KiemTra1
{
    internal class Program
    {
        struct SinhVien
        {
            public string HoTen;
            public string GioiTinh;
            public string Que;
            public string HocLuc;
        }
        static void Main(string[] args)
        {
            int n,i;

            Console.Write("Nhap so sinh vien: ");
            n = int.Parse(Console.ReadLine());

            SinhVien[] sv = new SinhVien[n];

            for(i=0;i<n;i++)
            {
                Console.Write("\nNhap ten sinh vien {0}: ", i+1);
                string name = Console.ReadLine();
                sv[i].HoTen = name;

                Console.Write("Nhap gioi tinh: ");
                string gender = Console.ReadLine();
                sv[i].GioiTinh = gender;
                
                Console.Write("Nhap que quan: ");
                string que = Console.ReadLine();
                sv[i].Que = que;

                Console.Write("Nhap hoc luc: ");
                string hocluc = Console.ReadLine();
                sv[i].HocLuc = hocluc;
            }

            //Chuan hoa ho ten va que quan
            for (i = 0; i < n; i++)
            {
                sv[i].HoTen.Trim();

                sv[i].HoTen.ToLower();

                while (sv[i].HoTen.IndexOf("  ") != -1)
                {
                    sv[i].HoTen.Remove(sv[i].HoTen.IndexOf("  "), 1);
                }

                string[] s = sv[i].HoTen.Split(' ');

                string afterFormatn = "";

                for (int j = 0; j < s.Length; ++j)
                {
                    string firstn = s[j].Substring(0, 1);
                    string anothern = s[j].Substring(1, s[j].Length - 1);
                    afterFormatn += firstn.ToUpper() + anothern + " ";
                }
                sv[i].HoTen = afterFormatn.Remove(afterFormatn.LastIndexOf(' '), 1);
            }

            //in thong tin sinh vien
            for(i = 0; i<n; i++)
            {
                Console.Write("Ten sinh vien {0}:", i + 1);
                Console.WriteLine(sv[i].HoTen);
                Console.Write("Gioi tinh: ");
                Console.WriteLine(sv[i].GioiTinh);
                Console.Write("Que quan: ");
                Console.WriteLine(sv[i].Que);
                Console.Write("Hoc luc: ");
                Console.WriteLine(sv[i].HocLuc);
            }

            //Xoa sinh vien trong mang
            Console.WriteLine("\n*Xoa sinh vien trong mang*");

            int pos;
            char check;
        xoa:
            pos = 0;
            //Chuan hoa ten sinh vien can xoa
            Console.Write("Nhap ten sinh vien can xoa: ");
            string namep = Console.ReadLine();
            sv[pos].HoTen = namep;
                sv[pos].HoTen.Trim();
                sv[pos].HoTen.ToLower();
                while (sv[pos].HoTen.IndexOf("  ") != -1)
                {
                    sv[pos].HoTen.Remove(sv[pos].HoTen.IndexOf("  "), 1);
                }
                string[] p = sv[pos].HoTen.Split(' ');
                string afterFormatpos = "";
                for (int j = 0; j < p.Length; ++j)
                {
                    string firstpos = p[j].Substring(0, 1);
                    string anotherpos = p[j].Substring(1, p[j].Length - 1);
                    afterFormatpos += firstpos.ToUpper() + anotherpos + " ";
                }
                sv[pos].HoTen = afterFormatpos.Remove(afterFormatpos.LastIndexOf(' '), 1);

            for (i = 0; i<n; i++)
            {
                if (sv[pos].HoTen == sv[i].HoTen)
                {
                    sv[i].HoTen = sv[i+1].HoTen;
                    sv[i].GioiTinh = sv[i+1].GioiTinh;
                    sv[i].Que = sv[i + 1].Que;
                    sv[i].HocLuc = sv[i + 1].HocLuc;
                    n--;
                }
                else
                {
                    Console.WriteLine("Ten sinh vien khong co tren he thong!");
                    Console.WriteLine("Ban co muon nhap lai?(y/n): ");
                    check = Convert.ToChar(Console.ReadLine());
                    if (check == 'y')
                        goto xoa;
                }
            }
            Console.Write("\nBan co muon xoa tiep?(y/n): ");
            check = Convert.ToChar(Console.ReadLine());
            if (check == 'y')
                goto xoa;
                

            //Them sinh vien vao mang
            Console.WriteLine("\n*Them sinh vien vao he thong*");

        them:
            Console.Write("Nhap ten sinh vien muon them: ");
            string nameadd = Console.ReadLine();
            sv[n-1].HoTen = nameadd;
                
            Console.Write("Nhap gioi tinh: ");
            string genderadd = Console.ReadLine();
            sv[n-1].GioiTinh = genderadd;

            Console.Write("Nhap que quan: ");
            string queadd = Console.ReadLine();
            sv[n-1].Que = queadd;

            Console.Write("Nhap hoc luc: ");
            string hoclucadd = Console.ReadLine();
            sv[n-1].HocLuc = hoclucadd;

            Console.Write("\nBan co muon them sinh vien tiep?(y/n): ");
            check = Convert.ToChar(Console.ReadLine());
            n++;
            if (check == 'y')
                goto them;

            //in thong tin sinh vien
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("Ten sinh vien {0}: {1}", i + 1, sv[i].HoTen);
                Console.WriteLine("Gioi tinh: {0}",sv[i].GioiTinh);
                Console.WriteLine("Que quan: {0}",sv[i].Que);
                Console.WriteLine("Hoc luc: {0}", sv[i].HocLuc);
            }
            Console.ReadKey();

            //Chuyen mang thanh danh sach
            List<string> Name = new List<string>(n);
            List<string> Gender = new List<string> (n);
            List<string> HomeTown = new List<string>(n);
            List<string> Classify = new List<string>(n);

            for(i=0; i<n; i++)
            {
                Name.Add(sv[i].HoTen);
                Gender.Add(sv[i].GioiTinh);
                HomeTown.Add(sv[i].Que);
                Classify.Add(sv[i].HocLuc);
            }

            Console.WriteLine("{0,-18} {1,-9} {2, -15} {3, -9}", "Ho Ten", "Gioi Tinh", "Que Quan", "Hoc luc");
            for (i=0; i<n;i++)
            {
                Console.WriteLine("{0,-18} {1,-9} {2, -15} {3, -9}", Name[i], Gender[i], HomeTown[i], Classify[i]);
            }



            Console.ReadKey();
        }
    }
}