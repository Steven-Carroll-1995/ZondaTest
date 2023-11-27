using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

//Constructor
class ZondaPage
{
    private IWebDriver driver;

    public ZondaPage(IWebDriver driver)
    {
        this.driver = driver;
    }

//Locators

    //Filter Locators

        //Locator for Filter Button
        private By FilterButton = By.XPath("//Button[text()='Subdivision status code filter']");

        //Locator for Active Filter Dropdown
        private By ActiveFilter = By.XPath("//Button[text()='Active']");

        //Locator for Future Filter Dropdown
        private By FutureFilter = By.XPath("//Button[text()='Future']");

        //Locator for Builtout Filter Dropdown
        private By BuiltoutFilter = By.XPath("//Button[text()='Builtout']");

        //Locator for Clear Filter Dropdown
        private By ClearFilter = By.XPath("//Button[text()='Clear']");

    //Sort Locators

        //Locator for Sort Button
        private By SortButton = By.XPath("//Button[text()='Sort']");

        //Locator for Name sort
        private By NameSort = By.XPath("//Button[text()='Name']");

        //Locator for NearMapImageDate sort
        private By NearMapImageDateSort = By.XPath("//Button[text()='Near Map Image Date']");

        //Locator for Longitude sort
        private By LongitudeSort= By.XPath("//Button[text()='Longitude']");

        //Locator for Latitude sort
        private By LatitudeSort = By.XPath("//Button[text()='Latitude']");
        //Locator for sort clear
        private By ClearSort = By.XPath("//Button[text()='Clear']");

    //Pagination Selectors

        //Locator for Paging Button
        private By PaginationButton= By.XPath("//*[@id='root']/div/div/div[2]/select");

    //Rows
        private By Rows= By.XPath("//table/tbody/tr");

//Filter Methods
    public void ActivateActiveFilter()
    {
        driver.FindElement(FilterButton).Click();
        driver.FindElement(ActiveFilter).Click();
        driver.FindElement(FilterButton).Click();
    }

    public void ActivateFutureFilter()
    {
        driver.FindElement(FilterButton).Click();
        driver.FindElement(FutureFilter).Click();
        driver.FindElement(FilterButton).Click();
    }

        public void ActivateBuiltoutFilter()
    {
        driver.FindElement(FilterButton).Click();
        driver.FindElement(BuiltoutFilter).Click();
        driver.FindElement(FilterButton).Click();
    }

    public void ClickClearFilter()
    {
        driver.FindElement(FilterButton).Click();
        driver.FindElement(ClearFilter).Click();
        driver.FindElement(FilterButton).Click();
    }

//Sort Methods
    public void SortByName()
    {
        driver.FindElement(SortButton).Click();
        driver.FindElement(NameSort).Click();
        driver.FindElement(SortButton).Click();
    }

        public void SortByNearMapImageDate()
    {
        driver.FindElement(SortButton).Click();
        driver.FindElement(NearMapImageDateSort).Click();
        driver.FindElement(SortButton).Click();
    }

        public void SortByLongitude()
    {
        driver.FindElement(SortButton).Click();
        driver.FindElement(LongitudeSort).Click();
        driver.FindElement(SortButton).Click();
    }

        public void SortByLatitude()
    {
        driver.FindElement(SortButton).Click();
        driver.FindElement(LatitudeSort).Click();
        driver.FindElement(SortButton).Click();
    }

        public void ClearPageSort()
    {
        driver.FindElement(SortButton).Click();
        driver.FindElement(ClearSort).Click();
        driver.FindElement(SortButton).Click();
    }

        public void PaginationSelection(int itemNumber)
    {
        SelectElement sel = new SelectElement(driver.FindElement(PaginationButton));
        sel.SelectByValue(itemNumber.ToString());
    }

    public int GetRowCount()
    {
       return driver.FindElements(Rows).Count;

    }

    public IWebElement[]  getListofRows()
    {
        IWebElement[] rows = driver.FindElements(Rows).ToArray();
        return rows;
    }

    public string[] getListofCellContents(int cellNumber)
    {
        IWebElement[] rows = getListofRows();
        string[] cellContents = new string[rows.Length];
        for (int i=0; i <rows.Length;i++)
        {
            cellContents[i] = rows[i].FindElement(By.XPath($"td[{cellNumber}]")).Text;
        }

        return cellContents;
    }

}