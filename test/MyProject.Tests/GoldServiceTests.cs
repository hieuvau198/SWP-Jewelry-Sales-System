using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using MyProject.Tests.Data;
using MyProject.Tests.ServiceGold;

public class GoldServiceTests
{
    private readonly Mock<JewelDbContext> _mockDbContext;
    private readonly GoldService _goldService;
    private readonly List<Gold> _mockGoldSet;

    public GoldServiceTests()
    {
        _mockDbContext = new Mock<JewelDbContext>();

        _mockGoldSet = new List<Gold>
        {
            new Gold { GoldId = "1", GoldName = "Gold A", GoldPrice = 1500 },
            new Gold { GoldId = "2", GoldName = "Gold B", GoldPrice = 2000 }
        };

        var mockGoldDbSet = _mockGoldSet.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(db => db.Golds).Returns(mockGoldDbSet.Object);

        _goldService = new GoldService(_mockDbContext.Object);
    }

    [Fact]
    public void AddGold_ShouldReturnTrue_WhenGoldIsAddedSuccessfully()
    {
        var newGold = new Gold { GoldId = "3", GoldName = "Gold C", GoldPrice = 2500 };

        var result = _goldService.AddGold(newGold);

        Assert.True(result);
        Assert.Contains(newGold, _mockGoldSet);
    }

    [Fact]
    public void AddGold_ShouldReturnFalse_WhenGoldAlreadyExists()
    {
        var existingGold = new Gold
        {
            GoldId = "1
