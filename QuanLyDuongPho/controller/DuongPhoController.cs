using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using QuanLyDuongPho.entity;
using QuanLyDuongPho.model;

namespace QuanLyDuongPho.controller
{
    public class DuongPhoController
    {
        private DuongPhoModel _duongPhoModel = new DuongPhoModel();

        public void ThemMoiDuongPho()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            DuongPho duongPho = new DuongPho();
            Console.WriteLine("Thêm mới đường phố.");
            Console.WriteLine("Vui lòng nhập mã: ");
            var maDuongPho = Console.ReadLine();
            duongPho.Ma = maDuongPho;
            Console.WriteLine("Vui lòng nhập tên: ");
            var tenDuongPho = Console.ReadLine();
            duongPho.Ten = tenDuongPho;
            Console.WriteLine("Vui lòng nhập mô tả: ");
            var moTa = Console.ReadLine();
            duongPho.MoTa = moTa;
            Console.WriteLine("Vui lòng nhập ngày sử dụng: ");
            var ngaySd = Console.ReadLine();
            duongPho.NgaySuDung = ngaySd;
            Console.WriteLine("Vui lòng nhâp lịch sử: ");
            var lichSu = Console.ReadLine();
            duongPho.LichSu = lichSu;
            Console.WriteLine("Vui lòng nhập tên quận: ");
            var tenQuan = Console.ReadLine();
            duongPho.TenQuan = tenQuan;
            Console.WriteLine("Vui lòng nhâp trạng thái: ");
            var trangThai = Convert.ToInt32(Console.ReadLine());
            duongPho.TrangThai = trangThai;
            bool resut = _duongPhoModel.Save(duongPho);
            if (resut)
            {
                Console.WriteLine("Thêm mới đường thành công!");
            }
            else
            {
                Console.WriteLine("Thêm mới đường thất bại!");
            }
        }

        public void HienThiDanhSachDuongPho()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var list = _duongPhoModel.FindAll();
            Console.WriteLine("Danh sách đường phố");
            for (int i = 0; i < list.Count; i++)
            {
                var duongPho = list[i];
                Console.WriteLine(
                    $"Mã: {duongPho.Ma}  |  Tên: {duongPho.Ten}  |  Lịch sử: {duongPho.LichSu}  |  Mô tả: {duongPho.MoTa}  |  \nTên Quận: {duongPho.TenQuan}  |  Ngày sử dụng: {duongPho.NgaySuDung}  |  Trạng thái: {duongPho.TrangThai}\n");
            }
        }

        public void TimDuongPhoTheoMa()
        {
            Console.WriteLine("Vui lòng nhập mã đường muốn tìm kiếm: ");
            var ma = Console.ReadLine();
            DuongPho duongPho = _duongPhoModel.FindById(ma);
            if (duongPho == null)
            {
                Console.WriteLine("Mã không khớp vui lòng nhập lại.");
                return;
            }

            Console.WriteLine("Thông tin đường được tìm thấy là:");
            Console.WriteLine(
                $"Mã: {duongPho.Ma}  |  Tên: {duongPho.Ten}  |  Lịch sử: {duongPho.LichSu}  |  Mô tả: {duongPho.MoTa}  |  \nTên Quận: {duongPho.TenQuan}  |  Ngày sử dụng: {duongPho.NgaySuDung}  |  Trạng thái: {duongPho.TrangThai}\n");
        }

        public void SuaThongTinDuongPho()
        {
            Console.WriteLine("Vui lòng nhập mã đường muốn sửa thông tin: ");
            var ma = Console.ReadLine();
            DuongPho duongPho = _duongPhoModel.FindById(ma);
            if (duongPho == null)
            {
                Console.WriteLine("Không tìm thấy mã đường phố tương ứng!");
                return;
            }

            Console.WriteLine("Vui lòng nhập tên đường mới: ");
            var ten = Console.ReadLine();
            duongPho.Ten = ten;
            Console.WriteLine("Vui lòng nhập lịch sử mới: ");
            var lichSu = Console.ReadLine();
            duongPho.LichSu = lichSu;
            Console.WriteLine("Vui lòng nhập mô tả:");
            var moTa = Console.ReadLine();
            duongPho.MoTa = moTa;
            Console.WriteLine("Vui lòng nhập tên quận:");
            var tenQuan = Console.ReadLine();
            duongPho.TenQuan = tenQuan;
            Console.WriteLine("Vui lòng nhập ngày sử dụng:");
            var ngaySd = Console.ReadLine();
            duongPho.NgaySuDung = ngaySd;
            Console.WriteLine("Vui lòng nhập trạng thái:");
            var trangThai = Convert.ToInt32(Console.ReadLine());
            duongPho.TrangThai = trangThai;
            bool ketQua = _duongPhoModel.Update(ma, duongPho);
            if (ketQua)
            {
                Console.WriteLine("Sửa thông tin thành công.");
            }
            else
            {
                Console.WriteLine("Sửa thông tin thất bại, vui lòng thử lại sau.");
            }
        }

        public void XoaThongTinDuongPho()
        {
            Console.WriteLine("Vui lòng nhập mã đường mà bạn muốn xoá: ");
            var ma = Console.ReadLine();
            DuongPho duongPho = _duongPhoModel.FindById(ma);
            if (duongPho == null)
            {
                Console.WriteLine("Không tìm thấy mã đường phố tương ứng.");
                return;
            }

            Console.WriteLine($"Tìm thấy đường phố có mã là: {duongPho.Ma}  |  Tên đường là: {duongPho.Ten}");
            Console.WriteLine("Bạn có muốn xoá đường phố này không (C/K) ?");
            var luaChon = Console.ReadLine();
            if (luaChon.ToLower().Equals("c"))
            {
                bool ketQua = _duongPhoModel.Delete(ma);
                if (ketQua)
                {
                    Console.WriteLine("Xoá thành công.");
                }
                else
                {
                    Console.WriteLine("Xoá thất bại.");
                }
            }
            else
            {
                Console.WriteLine("Thông tin chưa được xoá!");
            }
        }
    }
}