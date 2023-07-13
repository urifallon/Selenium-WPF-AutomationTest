# Selenium-WPF-AutomationTest
 Selenium Directory & WPF - C# - Chrome 114.0.5735.199


# Một số thuộc tính và phương thức cơ bản trong Selenium

--> **Lấy Source page hiện tại**

    driver.PageSource

--> **Lấy địa chỉ URL hiện tại:**

    driver.Url

--> **Chuyển tới trang trước,sau đó:**  

    driver.Navigate().Back()  
    driver.Navigate().Forwad()

--> **F5 (Refresh) lại trang:**  

    driver.Navigate().Refresh()

--> **Handle arlet:**  

    IAlert a = driver.SwitchTo().Alert();  
    a.Accept();  
    a.Dismiss();

--> **Chuyển đổi giữa các cửa sổ hoặc tab:**  

    ReadOnlyCollection<string> windowHandles = driver.WindowHandles;  
    string firstTab = windowHandles.First();  
    string lastTab = windowHandles.Last();  
    driver.SwitchTo().Window(lastTab);

--> **Maximize window:**  

    this.driver.Manage().Window.Maximize();

--> **Add cookies:**  

    Cookie cookie = new OpenQA.Selenium.Cookie("key", "value");  
    this.driver.Manage().Cookies.AddCookie(cookie);

--> **Get all cookies:**  

    var cookies = this.driver.Manage().Cookies.AllCookies;

--> **Delete cookie:**  

    this.driver.Manage().Cookies.DeleteCookieNamed("CookieName");

--> **Chụp màn hình:**  

    Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();  
    screenshot.SaveAsFile(@"pathToImage", ImageFormat.Png);  
    @pathToImage là đường dẫn tới file hình sẽ lưu

--> **Đợi đến khi Website load xong hết các đoạn JavaScript:**  

    WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));  
    wait.Until((x) =>  
    {  
     return ((IJavaScriptExecutor)this.driver).ExecuteScript("return document.readyState").Equals("complete");  
    });

--> **Chuyển đổi giữa các frames:**  

    this.driver.SwitchTo().Frame(1);  
    this.driver.SwitchTo().Frame("frameName");  
    IWebElement element = this.driver.FindElement(By.Id("id"));  
    this.driver.SwitchTo().Frame(element);

--> **Chuyển tới document mặc định:**  

    this.driver.SwitchTo().DefaultContent();


# Tương tác với Selenium
--> **Lấy ra một đối tượng với ID - Classname - CssSelector - LinkText - Name - 
PartialLinkText - TagName**  

    driver.FindElement(By.Id("id"))  
    driver.FindElement(By.ClassName("className"));  
    driver.FindElement(By.CssSelector("css"));  
    driver.FindElement(By.XPath("input"));  
    driver.FindElement(By.LinkText("text"));  
    driver.FindElement(By.Name("name"));  
    driver.FindElement(By.PartialLinkText("pText"));  
    driver.FindElement(By.TagName("input"));  
    !!! Các element này đang được tìm ở Window hoặc frame đang active.  
    !!!! Sử dụng XPath nếu k được sử dụng theo CssSelector

--> **Điền giá trị vào đối tượng**  

    Variable.SendKeys("Selenium Kteam");  
    Variable là biến đã được gán với đối tượng vd: var Variable = chromeDriver.FindElement(By.Id("id"));

--> **Click vào đối tượng**  

    Variable.Click();  
    Variable là biến đã được gán với đối tượng vd: var Variable = chromeDriver.FindElement(By.Id("id"));

--> **Lấy dữ liệu từ JS như: text, bla bla...**  

    // thực thi JavaScript dùng IJavaScriptExecutor  
    IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;  
    // javascript cần return giá trị.  
    var dataFromJS = (string)js.ExecuteScript("var content = document.getElementsByClassName('contentpagetop')[0].children[0].innerHTML;return content;");  
    MessageBox.Show(dataFromJS);

--> **Xóa ALL nội dung Element**  

    Variable.Clear();  
    Variable là biến đã được gán với đối tượng vd: var Variable = chromeDriver.FindElement(By.Id("id"));

--> **Kiểm tra 2 element có phải là 1 hay không**  

    bool isDisplayed = Variable.Equals(Variable1);

--> **Tìm element trong element hiện tại**  

    Variable Ele = Variable.FindElement(By.Id("NULL"));
    !!! result is an Element

--> **Tìm các element trong element hiện tại**  

    List<Variable> EleList = Variable.FindElements(By.Id("NULL"));
    !!! result is an Element

--> **Lấy thuộc tính HTML mà element đó đang có**  

    String href = Variable.GetAttribute("href");

--> **Lấy thuộc tính CSS mà element đó đang có**  

    String css = Variable.GetCssValue("font-size");

--> **Lấy tọa độ mà element đó đang có**  

    System.Drawing.Point location = Variable.Location;

--> **Kiểm tra element đã được chọn hay chưa**  

    bool isSelected = Variable.Selected;

--> **Trả về kích thước của element trên website**  

    System.Drawing.Size size = Variable.Size;

--> **submit element cho webserver**  

    variable.submit();  
    !!! nó sẽ tự tìm button để submit được cài sẵn

--> **Lấy tagname của element**  

    String tagname = Variable.TagName;

--> **Lấy text của element**  

    String text = Variable.Text;  
    !!! khoảng trắng bị loại bỏ


# Driver (Set up chrome - profile - proxy)

--> **Khởi tạo trình duyệt trống**

    ChromeDriver chromeDriver = new ChromeDriver();

--> **Khởi tạo trình duyệt với profile có sẵn**

    ChromeOptions option = new ChromeOptions();
    option.AddArguments("user-data-dir=/Users/nhduo/AppData/Local/Google/Chrome/User Data/");
    option.AddArguments("profile-directory=Default");
    ChromeDriver chromeDriver = new ChromeDriver(option);

--> **Khởi tạo trình duyệt + profile tại thư mục chỉ định**

    string forderProfile = "Profile";
    ChromeOptions option = new ChromeOptions();
    if (!Directory.Exists(forderProfile))
    {
        Directory.CreateDirectory(forderProfile);
    }
    if (Directory.Exists(forderProfile))
    {
        // Tên profile
        int nameProfile = 1;
        // Lấy dường dẫn thư mục chứa forderProfile
        string workingDirectory = Environment.CurrentDirectory;
        // Tạo option có path tới profile
        option.AddArguments($"user-data-dir="+ workingDirectory + "/" + forderProfile +"/"+ nameProfile);
    }
    ChromeDriver chromeDriver = new ChromeDriver(option);

--> **Khởi tạo trình duyệt với proxy không auto**

    ChromeOptions option = new ChromeOptions();
    var proxy = new Proxy();
    proxy.Kind = ProxyKind.Manual;
    proxy.IsAutoDetect = false;
    proxy.SslProxy = "ip:port";
    option.Proxy = proxy;
    option.AddArgument("ignore-certificate-errors");
    ChromeDriver chromeDriver = new ChromeDriver(option);

--> **Khởi tạo trình duyệt với proxy auto với extention**

@import "bin\Debug\Extention\ggmdpepbjljkkkdaklfihhngmmgmpggp"

    ChromeOptions option = new ChromeOptions();
    option.AddExtension(workingDirectory +"/" + "Extention/ggmdpepbjljkkkdaklfihhngmmgmpggp/2.0_0.crx");
    var proxy = new Proxy();
    proxy.Kind = ProxyKind.Manual;
    proxy.IsAutoDetect = false;
    proxy.SslProxy = ip:port;
    option.Proxy = proxy;
    option.AddArgument("ignore-certificate-errors");
    ChromeDriver chromeDriver = new ChromeDriver(option);
            
    chromeDriver.Url = "chrome-extension://ggmdpepbjljkkkdaklfihhngmmgmpggp/options.html";
    chromeDriver.Navigate();
    var userName = chromeDriver.FindElement(By.Id("login"));
    userName.SendKeys(username);
    var Pass = chromeDriver.FindElement(By.Id("password"));
    Pass.SendKeys(pass);
    var Save = chromeDriver.FindElement(By.Id("save"));
    Save.Click();