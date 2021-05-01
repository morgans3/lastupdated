using Xunit;
using lastupdated;
using System;

public class timesincetest
{
    [Theory]
    [InlineData("Day", "1")]
    [InlineData("Week", "2")]
    public void TestResponseFormat_ContainsPassedValue(string timereference, string timevalue)
    {
        // Arrange
        // Act
        string response = Program.ResponseStructure(timereference, timevalue);
        // Assert
        Assert.Contains(timereference, response);
        Assert.Contains(timevalue, response);
    }

    [Fact]
    public void TestTimeSince_CutOffBetweenWeeksAndDays()
    {
        // Arrange
        DateTime ResShouldStateDays = DateTime.Now.AddDays(-6);
        DateTime ResShouldStateWeek = DateTime.Now.AddDays(-7);

        // Act
        string ResponseDays = Program.TimeSince(ResShouldStateDays);
        string ResponseWeek = Program.TimeSince(ResShouldStateWeek);

        // Assert
        Assert.Contains("Day", ResponseDays);
        Assert.Contains("Week", ResponseWeek);
    }
}