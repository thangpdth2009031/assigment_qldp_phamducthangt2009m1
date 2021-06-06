using System;
using QuanLyDuongPho.controller;
using QuanLyDuongPho.entity;
using QuanLyDuongPho.model;
using QuanLyDuongPho.view;

namespace QuanLyDuongPho
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var menuDuongPho = new MenuDuongPho();
            menuDuongPho.DuongPhoMenu();
        }
    }
}