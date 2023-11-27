using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace ZondaTest;

public class Tests
{

    IWebDriver driver;
    ZondaPage zonda;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        zonda = new ZondaPage(driver);
        driver.Url = "http://localhost:3000";
    }

    [Test]
    public void TestFilterButtons()
    {
        zonda.ActivateActiveFilter();
        zonda.ActivateFutureFilter();
        zonda.ActivateBuiltoutFilter();
        zonda.ClickClearFilter();
        Assert.Pass();
    }

    [Test]
    public void TestSortButtons()
    {
        zonda.SortByName();
        zonda.SortByNearMapImageDate();
        zonda.SortByLongitude();
        zonda.SortByLatitude();
        zonda.ClearPageSort();
        Assert.Pass();
    }

    [Test]
    public void PaginationTest()
    {
        zonda.PaginationSelection(20);
        Assert.That(zonda.GetRowCount() == 20);
        zonda.PaginationSelection(30);
        Assert.That(zonda.GetRowCount() == 30);
        zonda.PaginationSelection(40);
        Assert.That(zonda.GetRowCount() == 40);
        zonda.PaginationSelection(50);
        Assert.That(zonda.GetRowCount() == 50);
        zonda.PaginationSelection(10);
        Assert.That(zonda.GetRowCount() == 10);
    }

    [Test]
    public void ActiveFilterTest()
    {
        zonda.ActivateActiveFilter();
        zonda.PaginationSelection(50);
        string[] cellContents = zonda.getListofCellContents(4);
        for (int i = 0; i < cellContents.Length; i++)
        {
            Assert.That(cellContents[i] == "Active");
        }
    }

    [Test]
    public void FutureFilterTest()
    {
        zonda.ActivateFutureFilter();
        zonda.PaginationSelection(50);
        string[] cellContents = zonda.getListofCellContents(4);
        for (int i = 0; i < cellContents.Length; i++)
        {
            Assert.That(cellContents[i] == "Future");
        }
    }

    [Test]
    public void BuiltoutFilterTest()
    {
        zonda.ActivateBuiltoutFilter();
        zonda.PaginationSelection(50);
        string[] cellContents = zonda.getListofCellContents(4);
        for (int i = 0; i < cellContents.Length; i++)
        {
            Assert.That(cellContents[i] == "Builtout");
        }
    }

    [Test]
    public void NameSortTest()
    {
        zonda.SortByName();
        zonda.PaginationSelection(50);
        string[] cellContents = zonda.getListofCellContents(2);
        string[] sortedCellContents = new string[cellContents.Length];
        Array.Copy(cellContents, sortedCellContents, cellContents.Length);
        Array.Sort(sortedCellContents);
        for (int i = 0; i < cellContents.Length; i++)
        {
            Assert.That(cellContents[i] == sortedCellContents[i]);
        }
    }

    [Test]
    public void LongitudeSortTest()
    {
        zonda.SortByLongitude();
        zonda.PaginationSelection(50);
        string[] cellContents = zonda.getListofCellContents(5);
        string[] sortedCellContents = new string[cellContents.Length];
        Array.Copy(cellContents, sortedCellContents, cellContents.Length);
        Array.Sort(sortedCellContents);
        for (int i = 0; i < cellContents.Length; i++)
        {
            Assert.That(cellContents[i] == sortedCellContents[i]);
        }
    }

    [Test]
    public void LatitudeSortTest()
    {
        zonda.SortByLatitude();
        zonda.PaginationSelection(50);
        string[] cellContents = zonda.getListofCellContents(6);
        string[] sortedCellContents = new string[cellContents.Length];
        Array.Copy(cellContents, sortedCellContents, cellContents.Length);
        Array.Sort(sortedCellContents);
        for (int i = 0; i < cellContents.Length; i++)
        {
            Assert.That(cellContents[i] == sortedCellContents[i]);
        }
    }

    [OneTimeTearDown]
    public void Close()
    {
        driver.Close();
    }
}