using NUnit.Framework;
using DiffingApi;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {
      

        [Test]
        public void TestPostLeftRequestData()
        {
            // Arrange
            DiffServiceController testController = new DiffServiceController();
            var obj = new RequestData();
            obj.Id = "3";
            obj.InputString = "Amol";
            ResponseData ResponseObj = new ResponseData
            {
                DiffResultType = "Created",
                StatusCode = 201
            };
            // Act
            var result = testController.PostLeftRequestData(obj);
            // Assert
            Assert.AreEqual(ResponseObj.DiffResultType, result.DiffResultType);
            Assert.AreEqual(ResponseObj.StatusCode, result.StatusCode);
        }

        [Test]
        public void TestPostRightRequestData()
        {
            // Arrange
            DiffServiceController testController = new DiffServiceController();
            var obj = new RequestData();
            obj.Id = "3";
            obj.InputString = "Amol";
            ResponseData ResponseObj = new ResponseData
            {
                DiffResultType = "Created",
                StatusCode = 201
            };
            // Act
            var result = testController.PostRightRequestData(obj);
            // Assert
            Assert.AreEqual(ResponseObj.DiffResultType, result.DiffResultType);
            Assert.AreEqual(ResponseObj.StatusCode, result.StatusCode);
        }

        [Test]
        public void TestGetResponseDataforEqualData()
        {
            // Arrange
            DiffServiceController testController = new DiffServiceController();
            string Id = "1";
            ResponseData ResponseObj = new ResponseData
            {
                DiffResultType = "Equals",
                StatusCode = 200
            };
            // Act
            var result = testController.GetResponseData(Id);
            // Assert
            Assert.AreEqual(ResponseObj.DiffResultType, result.DiffResultType);
            Assert.AreEqual(ResponseObj.StatusCode, result.StatusCode);
        }

        [Test]
        public void TestGetResponseDataforEqualSize ()
        {
            // Arrange
            DiffServiceController testController = new DiffServiceController();
            string Id = "12";
            ResponseData ResponseObj = new ResponseData
            {
                DiffResultType = "SizeDoNotMatch",
                StatusCode = 200
            };
            // Act
            var result = testController.GetResponseData(Id);
            // Assert
            Assert.AreEqual(ResponseObj.DiffResultType, result.DiffResultType);
            Assert.AreEqual(ResponseObj.StatusCode, result.StatusCode);
        }

        [Test]
        public void TestGetResponseDataforEqualSizeDiffString()
        {
            // Arrange
            DiffServiceController testController = new DiffServiceController();
            string Id = "11";
            ResponseData ResponseObj = new ResponseData
            {
                DiffResultType = "ContentDoNotMatch",
                StatusCode = 200,
                diffs = new List<Diffs> { { new Diffs(0, 1) } }
            };
            // Act
            var result = testController.GetResponseData(Id);
            Assert.AreEqual(ResponseObj.DiffResultType, result.DiffResultType);
            Assert.AreEqual(ResponseObj.StatusCode, result.StatusCode);
            List<Diffs> input = ResponseObj.diffs;
            List<Diffs> output = result.diffs;
            // Assert
            Assert.AreEqual(input.Count,output.Count);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(input[i].Length,output[i].Length);
                Assert.AreEqual(input[i].Offset, output[i].Offset);
            }
        }
    }
}