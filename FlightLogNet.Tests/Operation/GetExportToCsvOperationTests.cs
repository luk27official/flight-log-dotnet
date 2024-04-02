namespace FlightLogNet.Tests.Operation
{
    using System;
    using System.IO;
    using FlightLogNet.Operation;

    using Xunit;
    using Microsoft.Extensions.Configuration;

    public class GetExportToCsvOperationTests(GetExportToCsvOperation getExportToCsvOperation, IConfiguration configuration)
    {
        // DONE 6.1: Odstra�t� skip a doplnt� test, aby otestoval vr�cen� CSV soubor.
        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            TestDatabaseGenerator.DeleteOldDatabase(configuration);
            DateTime fixedDate = new DateTime(2024, 3, 26, 19, 52, 38);
            TestDatabaseGenerator.CreateTestDatabaseWithFixedTime(fixedDate, configuration);

            // open csv and read bytes
            var expectedCsv = File.ReadAllText("export.csv");
            // convert this to bytes[]
            var expectedCsvBytes = System.Text.Encoding.UTF8.GetBytes(expectedCsv);

            // Act
            var result = getExportToCsvOperation.Execute();

            // Assert
            Assert.Equal(expectedCsvBytes, result);
        }
    }
}
