using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerRepairRequests;
using static ComputerRepairRequests.TimeCalculation;
using Moq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
    

namespace UnitTestsRepairService
{
    [TestClass]
    public class TimeCalculationTests
    {
        [TestMethod]
        public void ReturnsCorrectAverage_WhenDataExists()
        {
            
            var mockConnection = new Mock<IDbConnection>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();

            
            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
            mockConnection.Setup(conn => conn.Open()).Verifiable();

            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
            mockCommand.SetupGet(cmd => cmd.CommandText).Returns(It.IsAny<string>());

            var data = new List<int> { 5, 7, 10 };
            mockReader.SetupSequence(reader => reader.Read())
                .Returns(true)
                .Returns(true)
                .Returns(true)
                .Returns(false);

            mockReader.SetupSequence(reader => reader.GetInt32(0)).Returns(() => data[0]).Returns(() => data[1]).Returns(() => data[2]);

            var timeCalculation = new TimeCalculation(mockConnection.Object);

            var result = timeCalculation.CalculateAverageCompletionTime();

            Assert.AreEqual(7.33, result, 0.01); 
            mockConnection.Verify(conn => conn.Open(), Times.Once);
        }

        [TestMethod]
        public void ReturnsZero_WhenNoDataExists()
        {
            var mockConnection = new Mock<IDbConnection>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();

            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
            mockConnection.Setup(conn => conn.Open()).Verifiable();

            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
            mockCommand.SetupGet(cmd => cmd.CommandText).Returns(It.IsAny<string>());

            mockReader.Setup(reader => reader.Read()).Returns(false);  

            var timeCalculation = new TimeCalculation(mockConnection.Object);

            var result = timeCalculation.CalculateAverageCompletionTime();

            Assert.AreEqual(0, result);
            mockConnection.Verify(conn => conn.Open(), Times.Once);
        }

        [TestMethod]
        public void ReturnsSingleValue_WhenOneDataExists()
        {
            var mockConnection = new Mock<IDbConnection>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();

            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
            mockConnection.Setup(conn => conn.Open()).Verifiable();

            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
            mockCommand.SetupGet(cmd => cmd.CommandText).Returns(It.IsAny<string>());

            mockReader.SetupSequence(reader => reader.Read())
                .Returns(true)
                .Returns(false); 

            mockReader.Setup(reader => reader.GetInt32(0)).Returns(7);  

            var timeCalculation = new TimeCalculation(mockConnection.Object);

            var result = timeCalculation.CalculateAverageCompletionTime();

            Assert.AreEqual(7, result);  
            mockConnection.Verify(conn => conn.Open(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowsException_WhenDatabaseErrorOccurs()
        {
            var mockConnection = new Mock<IDbConnection>();

            mockConnection.Setup(conn => conn.Open()).Throws(new InvalidOperationException());

            var timeCalculation = new TimeCalculation(mockConnection.Object);

            timeCalculation.CalculateAverageCompletionTime(); 
        }

        [TestMethod]
        public void ReturnsZero_WhenCompletionDateIsNull()
        {
            var mockConnection = new Mock<IDbConnection>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();

            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
            mockConnection.Setup(conn => conn.Open()).Verifiable();

            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
            mockCommand.SetupGet(cmd => cmd.CommandText).Returns(It.IsAny<string>());

            mockReader.SetupSequence(reader => reader.Read())
                .Returns(true)
                .Returns(false); 

            mockReader.Setup(reader => reader.GetInt32(0)).Returns(0);  

            var timeCalculation = new TimeCalculation(mockConnection.Object);

            var result = timeCalculation.CalculateAverageCompletionTime();

            Assert.AreEqual(0, result);  
            mockConnection.Verify(conn => conn.Open(), Times.Once);
        }
    }
}
   

