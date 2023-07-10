﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Selenium_base
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver(); //khởi tạo trình duyệt

            //Định hướng tới một trang web vd: w3schools.com
            chromeDriver.Url = "https://www.w3schools.com/"; //khởi tạo Url nên dùng như này
            chromeDriver.Navigate(); //hàm navigate sẽ mặc định trỏ tới url đã set hoặc có thể dùng chromeDriver.Navigate().GotoUrl("https://www.w3schools.com/")

            ////Tìm đối tượng bằng ID
            var search = chromeDriver.FindElement(By.Id("search2"));

            //Điền giá trị cho đối tượng
            search.SendKeys("HTML");

            //Tìm đối tượng bằng ID
            var find = chromeDriver.FindElement(By.Id("learntocode_searchbtn"));

            //Click vào đối tượng
            find.Click();

            //Lấy đường dẫn trang hiện tại 
            var url = chromeDriver.Url;

            ////Tìm đối tượng bằng xpath
            var find1 = chromeDriver.FindElement(By.XPath("//a[@title=\"Search W3Schools\"]"));

            //Click vào đối tượng
            find1.Click();

            //Tìm đối tượng bằng xpath
            var search1 = chromeDriver.FindElement(By.XPath("//input[@id=\"gsc-i-id1\"]"));

            //Điền giá trị cho đối tượng
            search1.SendKeys("css");

            ////Tìm đối tượng bằng xpath
            var find2 = chromeDriver.FindElement(By.XPath("//button[@class='gsc-search-button gsc-search-button-v2']//*[name()='svg']"));

            //Click vào đối tượng
            find2.Click();
            
         
        }
    }
}