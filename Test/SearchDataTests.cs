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
    public void AddItems_ShouldUpdateExistingItems()
    {
        // Arrange
        var searchData = new SearchData(".", "UpdateItems.db");
        searchData.reset();
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };
        searchData.AddItems(items);

        // Act
        items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1 new"),
            createTestItem("2", "E", "Test 2 new"),
            createTestItem("3", "E", "Test 3"),
        };
        searchData.AddItems(items);

        // Assert
        var results = searchData.GetResults("E", "Test");
        Assert.AreEqual(3, results.Count);
        Assert.AreEqual("Test 1 new", results[0].Title);
    }

    [TestMethod]
    public void DeleteItems_ShouldDeleteItems()
    {
        // Arrange
        var searchData = new SearchData(".", "DeleteItems.db");
        searchData.reset();
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };
        searchData.AddItems(items);

        // Act
        searchData.DeleteItems(new List<string> { "1" });

        // Assert
        var results = searchData.GetResults("E", "Test");
        Assert.AreEqual(1, results.Count);
    }

    [TestMethod]
    public void Reset_ShouldResetItems()
    {
        // Arrange
        var searchData = new SearchData(".", "Reset.db");
        searchData.reset();
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };
        searchData.AddItems(items);

        // Act
        searchData.reset();
        searchData.AddItems(new List<ContentItem>());

        // Assert
        var results = searchData.GetResults("E", "Test");
        Assert.AreEqual(0, results.Count);
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