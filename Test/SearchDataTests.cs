using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Demo.Search.Tests;

[TestClass]
public class SearchDataTests
{

    private ContentItem createTestItem(string id, string lang, string title)
    {
        return new ContentItem
        {
            Id = id,
            Lang = lang,
            Title = title,
        };
    }

    [TestMethod]
    public void AddItems_ShouldAddItems()
    {
        // Arrange
        var searchData = new SearchData(".", "AddItems.db");
        searchData.reset();
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };

        // Act
        searchData.AddItems(items);

        // Assert
        var results = searchData.GetResults("E", "Test");
        Assert.AreEqual(2, results.Count);
    }

    [TestMethod]
    public void GetResults_ShouldReturnCorrectItems()
    {
        // Arrange
        var searchData = new SearchData(".", "GetResults.db");
        searchData.reset();
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
            createTestItem("3", "E", "Nothing"),
            createTestItem("4", "S", "Test Spanish"),
        };
        searchData.AddItems(items);

        // Act
        var results = searchData.GetResults("E", "Test");

        // Assert
        Assert.AreEqual(2, results.Count);
    }
}