using Xunit;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Demo.Search.Tests;

public class SearchDataTests
{
    string filePath = Assembly.GetExecutingAssembly().Location;

    [Fact]
    public void AddOrUpdateItems_ShouldAddItems()
    {
        // Arrange
        var searchData = new SearchData(filePath);
        var items = new List<ContentItem>
        {
            new ContentItem { Id = "1", Title = "Test 1" },
            new ContentItem { Id = "2", Title = "Test 2" }
        };

        // Act
        searchData.AddOrUpdateItems(items);

        // Assert
        var results = searchData.GetResults("Test");
        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void GetResults_ShouldReturnCorrectItems()
    {
        // Arrange
        var searchData = new SearchData(filePath);
        var items = new List<ContentItem>
        {
            new ContentItem { Id = "1", Title = "Test 1" },
            new ContentItem { Id = "2", Title = "Test 2" },
            new ContentItem { Id = "3", Title = "Another Test" }
        };
        searchData.AddOrUpdateItems(items);

        // Act
        var results = searchData.GetResults("Test");

        // Assert
        Assert.Equal(2, results.Count);
    }
}