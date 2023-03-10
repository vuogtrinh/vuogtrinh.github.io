/*- Thực hiện phép SS để xác định và in ra màn hình các thông tin
của xạ thủ có trình độ cao hơn
- Với xạ thủ có trình độ cao hơn, được phép chuyển đổi giới tính
Với xạ thủ có trình độ thấp hơn thì giới tính là nam
- Với trình độ bậc 5 và giới tính là nam được phép sử dụng Súng máy
Với trình độ bậc 5 là nữ thì được phép sử dụng tiểu liên
In ra màn hình 2 xạ thủ này.
Từ dữ liệu của bài trước,  các em tạo mảng các xạ thủ là các bạn trong lớp với các yêu cầu:
- Chuẩn hóa tên của các xạ thủ
- Xạ thủ có tên trong các tên: Dũng, Quý,  Trâm,  Bằng Anh thì có trình độ 5.
Các xạ thủ còn lại các em tự đánh giá
*/
using System;
using System.Xml.Linq;

namespace BtvnBuoi4
{
    internal class Program
    {
        struct XaThu
        {
            public string HoTen;
            public string GioiTinh;
            public TrinhDo TD;
            public LoaiSung LS;
            public double Diem;
        }
        enum TrinhDo
        {
            LinhMoi = 1,
            BinhNhat = 2,
            DoiTruong = 3,
            ChuyenNghiep = 4,
            ChuyenGia = 5,

        }
        struct LoaiSung
        {
            public string TenSung;
            public double TyLe;
            public double CuLy;
            public double TocDo;
        }


        static void Main(string[] args)
        {
            int n;
            int i;

            Console.Write("Nhap so xa thu: ");
            n = int.Parse(Console.ReadLine());
            XaThu[] xt = new XaThu[n];

            Console.WriteLine("\n*Nhap thong tin xa thu*");
            for (i = 0; i < n; i++)
            {
                Console.Write("Nhap ten xa thu {0}: ", i + 1);
                string name = Console.ReadLine();
                xt[i].HoTen = name;

                Console.Write("Nhap gioi tinh: ");
                string gender = Console.ReadLine();
                xt[i].GioiTinh = gender;

                Console.Write("Nhap trinh do: ");
                int skill = Convert.ToInt32(Console.ReadLine());
                xt[i].TD = (TrinhDo)skill;

                Console.Write("Nhap ten sung: ");
                string gn = Console.ReadLine();
                xt[i].LS.TenSung = gn;

                Console.Write("Nhap ty le: ");
                double acc = Convert.ToDouble(Console.ReadLine());
                xt[i].LS.TyLe = acc;

                Console.Write("Nhap cu ly: ");
                double dis = Convert.ToDouble(Console.ReadLine());
                xt[i].LS.CuLy = dis;

                Console.Write("Nhap toc do: ");
                double spd = Convert.ToDouble(Console.ReadLine());
                xt[i].LS.TocDo = spd;

                Console.Write("Diem: ");
                double pt = Convert.ToDouble(Console.ReadLine());
                xt[i].Diem = pt;
                Console.Write("\n");
            }
            
            //Chuan hoa ten xa thu
            for(i= 0; i<n; i++)
            {
                //xoa dau cach thua o dau va cuoi
                xt[i].HoTen.Trim();
                //chuyen xau ve dang viet thuong
                xt[i].HoTen.ToLower();
                //kiem tra xem co 2 dau cach lien nhau khong
                while (xt[i].HoTen.IndexOf("  ") != -1)
                {
                    //xoa bot 1 dau cach neu thua
                    xt[i].HoTen.Remove(xt[i].HoTen.IndexOf("  "), 1);
                }
                //viet hoa chu cai dau tien
                //tach cac tu boi dau cach
                string[] s = xt[i].HoTen.Split(' ');
                //bien luu tru ky tu sau khi chuan hoa
                string afterFormat = "";
                //thuc hien vong lap len toan bo phan tu sau khi tach
                for (int j = 0; j < s.Length; ++j)
                {
                    //lay ra ky tu dau tien
                    string first = s[j].Substring(0, 1);
                    //lay ra xau ki tu sau chu cai dau tien
                    string another = s[j].Substring(1, s[j].Length - 1);
                    //viet lai xau sau khi chuan hoa
                    afterFormat += first.ToUpper() + another + " ";
                }
                //xoa dau cach o cuoi sau khi chuan hoa
                xt[i].HoTen = afterFormat.Remove(afterFormat.LastIndexOf(' '), 1);
                //cac xa thu co ten chuyen thanh trinh do 5
                if (xt[i].HoTen.Contains("Dung") || xt[i].HoTen.Contains("Quy") || xt[i].HoTen.Contains("Tram") || xt[i].HoTen.Contains("Bang Anh"))
                    xt[i].TD = TrinhDo.ChuyenGia;
            }
            /*
            //Doi gioi tinh cho xa thu trinh do 5
            Console.WriteLine("\n*Doi gioi tinh cho xa thu trinh do 5*");
            char checkgender;
            int max=0;
            for(i = 0; i<n; i++)
            {
                xt[max].TD = xt[0].TD;
                if (xt[max].TD == TrinhDo.ChuyenGia)
                {
                    Console.Write("Ban co muon doi gioi tinh?(y/n): ");
                    checkgender = Convert.ToChar(Console.ReadLine());
                    if (checkgender == 'y')
                    {
                        Console.Write("Nhap gioi tinh muon doi: ");
                        xt[i].GioiTinh = Console.ReadLine();
                    }
                    else if (checkgender == 'n')
                    {
                        Console.WriteLine("Gioi tinh duoc giu nguyen!");
                    }
                }
            }

            //trinh do 5 va la nam thi duoc phep doi thanh sung may, la nu thi duoc doi thanh tieu lien
            //Doi sung cho xa thu trinh do 5
            char checkgun;
            Console.WriteLine("\n*Doi sung cho xa thu co trinh do 5*");
            for (i = 0; i < n; i++)
            {
                if (xt[i].TD == TrinhDo.ChuyenGia && xt[i].GioiTinh == "nam")
                {
                    Console.Write("Ban co muon chon sung may?(y/n): ");
                    checkgun = Convert.ToChar(Console.ReadLine());
                    if (checkgun == 'y')
                        xt[i].LS.TenSung = "Sung May";
                    else if (checkgun == 'n')
                        Console.WriteLine("Khong thay doi sung!");
                }
                else if (xt[i].TD == TrinhDo.ChuyenGia && xt[i].GioiTinh == "nu")
                {
                    Console.Write("Ban co muon chon tieu lien?(y/n): ");
                    checkgun = Convert.ToChar(Console.ReadLine());
                    if (checkgun == 'y')
                        xt[i].LS.TenSung = "Tieu Lien";
                    else if (checkgun == 'n')
                        Console.WriteLine("Khong thay doi sung!");
                }
            }
            */

            //In thong tin cac xa thu
            Console.WriteLine("\n*In thong tin cac xa thu*");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("Ten xa thu {0}: {1}", i + 1, xt[i].HoTen);
                Console.WriteLine("Gioi tinh: {0}", xt[i].GioiTinh);
                Console.WriteLine("Trinh do: {0}", xt[i].TD);
                Console.WriteLine("Ten sung: {0}", xt[i].LS.TenSung);
                Console.WriteLine("Ty le: {0}%", xt[i].LS.TyLe);
                Console.WriteLine("Cu ly: {0}m", xt[i].LS.CuLy);
                Console.WriteLine("Toc do: {0}m/s", xt[i].LS.TocDo);
                Console.WriteLine("Diem: {0}", xt[i].Diem);
                Console.Write("\n");
            }

            //chuyen mang thanh danh sach
            Console.WriteLine("\n*Chuyen mang thanh danh sach*\n");
            List<string> Name = new List<string>(n);
            List<string> Gender = new List<string>(n);
            List<int> Skill = new List<int>(n);
            List<string> GunName = new List<string>(n);
            List<double> Acc = new List<double>(n);
            List<double> Dis = new List<double>(n);
            List<double> Spd = new List<double>(n);
            List<double> Point = new List<double>(n);

            for(i = 0; i<n; i++)
            {
                Name.Add(xt[i].HoTen);
                Gender.Add(xt[i].GioiTinh);
                Skill.Add(Convert.ToInt32(xt[i].TD));
                GunName.Add(xt[i].LS.TenSung);
                Acc.Add(xt[i].LS.TyLe);
                Dis.Add(xt[i].LS.CuLy);
                Spd.Add(xt[i].LS.TocDo);
                Point.Add(xt[i].Diem);
            }
            Console.WriteLine("{0,-18}{1,-9}{2,-12}{3,-10}{4,-6}{5,-6}{6,-6}{7,-6}", "Ho Ten", "Gioi Tinh", "Trinh Do", "Ten Sung", "Ty Le","Cu Ly","Toc Do","Diem");
            for(i = 0; i < n;i++)
            {
                Console.WriteLine("{0,-18}{1,-9}{2,-12}{3,-10}{4,-6}{5,-6}{6,-6}{7,-6}", Name[i], Gender[i], Skill[i], GunName[i], Acc[i] + "%", Dis[i] + "m", Spd[i]+"m/s", Point[i]);
            }

            Console.ReadKey();
        }
    }
}