using Xunit;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Demo.Search.Tests;

public class SearchDataTests
{
    string filePath = Assembly.GetExecutingAssembly().Location;

    private ContentItem createTestItem(string id, string lang, string title)
    {
        return new ContentItem
        {
            Id = id,
            Lang = lang,
            Title = title,
        };
    }

    [Fact]
    public void AddOrUpdateItems_ShouldAddItems()
    {
        // Arrange
        var searchData = new SearchData(filePath);
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };

        // Act
        searchData.AddItems(items);

        // Assert
        var results = searchData.GetResults("E", "test");
        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void GetResults_ShouldReturnCorrectItems()
    {
        // Arrange
        var searchData = new SearchData(filePath);
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
        Assert.Equal(2, results.Count);
    }
}