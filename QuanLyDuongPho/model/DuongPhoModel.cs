using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using QuanLyDuongPho.entity;
using QuanLyDuongPho.helper;

namespace QuanLyDuongPho.model
{
    public class DuongPhoModel
    {        
        public bool Save(DuongPho duongPho)
        {
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText =
                string.Format(
                    "INSERT INTO duongphos (Ma, Ten, MoTa, NgaySuDung, LichSu, TenQuan, TrangThai) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})",
                    duongPho.Ma, duongPho.Ten, duongPho.MoTa, duongPho.NgaySuDung, duongPho.LichSu, duongPho.TenQuan,
                    duongPho.TrangThai);
            var result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            connection.Close();
            return true;
        }

        public List<DuongPho> FindAll()
        {
            var listDuongPho = new List<DuongPho>();
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM duongphos";
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                var duongPho = new DuongPho();
                duongPho.Ma = result["Ma"].ToString();
                duongPho.Ten = result["Ten"].ToString();
                duongPho.MoTa = result["MoTa"].ToString();
                duongPho.NgaySuDung = result["NgaySuDung"].ToString();
                duongPho.LichSu = result["LichSu"].ToString();
                duongPho.TenQuan = result["TenQuan"].ToString();
                duongPho.TrangThai = Convert.ToInt32(result["TrangThai"].ToString());
                listDuongPho.Add(duongPho);
            }
            result.Close();
            return listDuongPho;
        }

        public DuongPho FindById(string id)
        {
            DuongPho duongPho = null;
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"SELECT * from duongphos WHERE Ma = '{id}'";
            var result = cmd.ExecuteReader();
            if (result.Read())
            {
                duongPho = new DuongPho();
                duongPho.Ma = result["Ma"].ToString();
                duongPho.Ten = result["Ten"].ToString();
                duongPho.MoTa = result["MoTa"].ToString();
                duongPho.NgaySuDung = result["NgaySuDung"].ToString();
                duongPho.LichSu = result["LichSu"].ToString();
                duongPho.TenQuan = result["TenQuan"].ToString();
                duongPho.TrangThai = int.Parse(result["TrangThai"].ToString());
            }
            result.Close();
            return duongPho;
        }

        public bool Update(string id, DuongPho updateDuongPho)
        {
            var duongPho = FindById(id);
            if (duongPho == null)
            {
                return false;
            }

            duongPho.Ten = updateDuongPho.Ten;
            duongPho.MoTa = updateDuongPho.MoTa;
            duongPho.NgaySuDung = updateDuongPho.NgaySuDung;
            duongPho.LichSu = updateDuongPho.LichSu;
            duongPho.TenQuan = updateDuongPho.TenQuan;
            duongPho.TrangThai = updateDuongPho.TrangThai;
            
            var connetion = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand();
            cmd.Connection = connetion;
            cmd.CommandText =
                $"UPDATE duongphos SET Ten = '{duongPho.Ten}', MoTa = '{duongPho.MoTa}', NgaySuDung = '{duongPho.NgaySuDung}', LichSu = '{duongPho.LichSu}', TenQuan = '{duongPho.TenQuan}', TrangThai = '{duongPho.TrangThai}' WHERE Ma = '{id}'";
            var ketQua = cmd.ExecuteNonQuery();
            if (ketQua == 1)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"DELETE FROM duongphos WHERE Ma = '{id}'";
            var ketQua = cmd.ExecuteNonQuery();
            if (ketQua == 1)
            {
                return true;
            }
            return false;
        }
    }
}