using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanPhamvaKhachHang
{

    class Program
    {
        static List<SanPham> sanPhams = new List<SanPham>();
        static List<KhachHang> khachHangs = new List<KhachHang>();
        static List<DonHang> donHangs = new List<DonHang>();

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Sửa thông tin sản phẩm");
                Console.WriteLine("3. Xóa sản phẩm");
                Console.WriteLine("4. Thêm khách hàng");
                Console.WriteLine("5. Sửa thông tin khách hàng");
                Console.WriteLine("6. Xóa khách hàng");
                Console.WriteLine("7. Mua hàng");
                Console.WriteLine("8. Quản lý đơn hàng");
                Console.WriteLine("0. Thoát");

                Console.Write("Chọn chức năng: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        ThemSanPham();
                        break;
                    case 2:
                        SuaThongTinSanPham();
                        break;
                    case 3:
                        XoaSanPham();
                        break;
                    case 4:
                        ThemKhachHang();
                        break;
                    case 5:
                        SuaThongTinKhachHang();
                        break;
                    case 6:
                        XoaKhachHang();
                        break;
                    case 7:
                        MuaHang();
                        break;
                    case 8:
                        QuanLyDonHang();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        static void ThemSanPham()
        {
            Console.Write("Nhập tên sản phẩm: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập giá sản phẩm: ");
            decimal gia = decimal.Parse(Console.ReadLine());

            SanPham sanPham = new SanPham { Ten = ten, Gia = gia };
            sanPhams.Add(sanPham);

            Console.WriteLine("Sản phẩm đã được thêm thành công.");
        }

        static void SuaThongTinSanPham()
        {
            Console.Write("Nhập tên sản phẩm cần sửa: ");
            string ten = Console.ReadLine();
            SanPham sanPham = sanPhams.Find(sp => sp.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase));

            if (sanPham != null)
            {
                Console.Write("Nhập giá mới: ");
                decimal giaMoi = decimal.Parse(Console.ReadLine());

                sanPham.Gia = giaMoi;

                Console.WriteLine("Thông tin sản phẩm đã được cập nhật.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        static void XoaSanPham()
        {
            Console.Write("Nhập tên sản phẩm cần xóa: ");
            string ten = Console.ReadLine();
            SanPham sanPham = sanPhams.Find(sp => sp.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase));

            if (sanPham != null)
            {
                sanPhams.Remove(sanPham);
                Console.WriteLine("Sản phẩm đã được xóa.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        static void ThemKhachHang()
        {
            Console.Write("Nhập tên khách hàng: ");
            string ten = Console.ReadLine();

            KhachHang khachHang = new KhachHang { Ten = ten };
            khachHangs.Add(khachHang);

            Console.WriteLine("Khách hàng đã được thêm thành công.");
        }

        static void SuaThongTinKhachHang()
        {
            Console.Write("Nhập tên khách hàng cần sửa: ");
            string ten = Console.ReadLine();
            KhachHang khachHang = khachHangs.Find(kh => kh.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase));

            if (khachHang != null)
            {
                Console.Write("Nhập tên mới: ");
                string tenMoi = Console.ReadLine();

                khachHang.Ten = tenMoi;

                Console.WriteLine("Thông tin khách hàng đã được cập nhật.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách hàng.");
            }
        }

        static void XoaKhachHang()
        {
            Console.Write("Nhập tên khách hàng cần xóa: ");
            string ten = Console.ReadLine();
            KhachHang khachHang = khachHangs.Find(kh => kh.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase));

            if (khachHang != null)
            {
                khachHangs.Remove(khachHang);
                Console.WriteLine("Khách hàng đã được xóa.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách hàng.");
            }
        }

        static void MuaHang()
        {
            Console.Write("Nhập tên khách hàng: ");
            string tenKhachHang = Console.ReadLine();
            KhachHang khachHang = khachHangs.Find(kh => kh.Ten.Equals(tenKhachHang, StringComparison.OrdinalIgnoreCase));

            if (khachHang != null)
            {
                Console.Write("Nhập tên sản phẩm cần mua: ");
                string tenSanPham = Console.ReadLine();
                SanPham sanPham = sanPhams.Find(sp => sp.Ten.Equals(tenSanPham, StringComparison.OrdinalIgnoreCase));

                if (sanPham != null)
                {
                    Console.Write("Nhập số lượng: ");
                    int soLuong = int.Parse(Console.ReadLine());

                    DonHang donHang = new DonHang { KhachHang = khachHang, SanPham = sanPham, SoLuong = soLuong };
                    donHangs.Add(donHang);

                    Console.WriteLine("Đã mua hàng thành công.");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sản phẩm.");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách hàng.");
            }
        }

        static void QuanLyDonHang()
        {
            Console.Write("Nhập tên khách hàng: ");
            string tenKhachHang = Console.ReadLine();
            KhachHang khachHang = khachHangs.Find(kh => kh.Ten.Equals(tenKhachHang, StringComparison.OrdinalIgnoreCase));

            if (khachHang != null)
            {
                var donHangKhachHang = donHangs.FindAll(dh => dh.KhachHang == khachHang);

                if (donHangKhachHang.Count > 0)
                {
                    Console.WriteLine("Danh sách đơn hàng của khách hàng:");

                    foreach (var donHang in donHangKhachHang)
                    {
                        Console.WriteLine($"- Sản phẩm: {donHang.SanPham.Ten}, Số lượng: {donHang.SoLuong}");
                    }
                }
                else
                {
                    Console.WriteLine("Không có đơn hàng nào cho khách hàng này.");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách hàng.");
            }
        }
    }
}