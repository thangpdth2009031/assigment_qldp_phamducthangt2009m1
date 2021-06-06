using System;
using System.Text;
using QuanLyDuongPho.controller;

namespace QuanLyDuongPho.view
{
    public class MenuDuongPho
    {
        private DuongPhoController _duongPhoController = new DuongPhoController();
        public void DuongPhoMenu()
        {
            while (true)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                Console.WriteLine("-------Quản lí đường phố-------");
                Console.WriteLine("1. Thêm mới đường phố.");
                Console.WriteLine("2. Hiển thị danh sách đường phố.");
                Console.WriteLine("3. Tìm đường phố.");
                Console.WriteLine("4. Sửa thông tin.");
                Console.WriteLine("5. Xoá thông tin.");
                Console.WriteLine("6. Thoát");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Vui lòng nhập lựa chọn của bạn (1->6): ");
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1 || choice == 2 ||choice == 3 || choice == 4 ||choice == 5 || choice == 6)
                {
                    switch (choice)
                    {
                        case 1:
                            _duongPhoController.ThemMoiDuongPho();
                            break;
                        case 2:
                            _duongPhoController.HienThiDanhSachDuongPho();
                            break;
                        case 3:
                            _duongPhoController.TimDuongPhoTheoMa();
                            break;
                        case 4:
                            _duongPhoController.SuaThongTinDuongPho();
                            break;
                        case 5:
                            _duongPhoController.XoaThongTinDuongPho();
                            break;
                        case 6:
                            break;
                    }
                    if (choice != 6)
                    {
                        Console.WriteLine("Enter để tiếp tục.");
                        Console.ReadLine();
                    }

                    if (choice != 6) continue;
                    Console.WriteLine("Thoát chương trình.");
                    break;
                }
                else
                {
                    Console.WriteLine("\nNhập sai lựa chọn (1->6), vui lòng nhập lại.\n");
                }
            }
        }
    }
}