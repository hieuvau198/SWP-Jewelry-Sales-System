using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using MyProject.Tests.ServiceGem;

public class GemServiceTests
{
    private readonly Mock<JewelDbContext> _mockDbContext;
    private readonly GemService _gemService;
    private readonly List<Gem> _mockGemSet;

    public GemServiceTests()
    {
        _mockDbContext = new Mock<JewelDbContext>();

        _mockGemSet = new List<Gem>
        {
            new Gem { GemId = "1", GemName = "Ruby", GemPrice = 1000 },
            new Gem { GemId = "2", GemName = "Sapphire", GemPrice = 2000 }
        };

        var mockGemDbSet = _mockGemSet.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(db => db.Gems).Returns(mockGemDbSet.Object);

        _gemService = new GemService(_mockDbContext.Object);
    }

    [Fact]
    public void AddGem_ShouldReturnTrue_WhenGemIsAddedSuccessfully()
    {
        var newGem = new Gem { GemId = "3", GemName = "Emerald", GemPrice = 3000 };

        var result = _gemService.AddGem(newGem);

        Assert.True(result);
        Assert.Contains(newGem, _mockGemSet);
    }

    [Fact]
    public void AddGem_ShouldReturnFalse_WhenGemAlreadyExists()
    {
        var existingGem = new Gem { GemId = "1", GemName = "Ruby", GemPrice = 1000 };

        var result = _gemService.AddGem(existingGem);

        Assert.False(result);
    }

    [Fact]
    public void GetGems_ShouldReturnAllGems()
    {
        var result = _gemService.GetGems();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetGem_ShouldReturnCorrectGem_WhenGemIdIsProvided()
    {
        var result = _gemService.GetGem("1");

        Assert.NotNull(result);
        Assert.Equal("Ruby", result.GemName);
    }

    [Fact]
    public void RemoveGem_ShouldReturnTrue_WhenGemIsRemovedSuccessfully()
    {
        var result = _gemService.RemoveGem("1");

        Assert.True(result);
        Assert.DoesNotContain(_mockGemSet, g => g.GemId == "1");
    }

    [Fact]
    public void UpdateGem_ShouldReturnTrue_WhenGemIsUpdatedSuccessfully()
    {
        var updatedGem = new Gem { GemId = "1", GemName = "Updated Ruby", GemPrice = 1500 };

        var result = _gemService.UpdateGem(updatedGem);

        Assert.True(result);
        Assert.Equal("Updated Ruby", _mockGemSet.First(g => g.GemId == "1").GemName);
    }
}

public static class DbSetMockBuilder
{
    public static Mock<Microsoft.EntityFrameworkCore.DbSet<T>> BuildMockDbSet<T>(this IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        return mockSet;
    }
}
