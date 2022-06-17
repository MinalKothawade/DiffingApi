# DiffingApi

Required features 

• Provide 2 http endpoints (/v1/diff//left and /v1/diff//right) that accept JSON containing base64 encoded binary data on both endpoints. 

• The provided data needs to be diff-ed and the results shall be available on a third endpoint (/v1/diff/). The results shall provide the following info in JSON format: o If equal return that o If not of equal size just return that o If of the same size provide insight into where the diff is, actual diffs are not needed. So mainly offsets + length in the data Note, that we are not looking for the ideal diffing algorithm.



What's in it

•	Input Web API (api/DiffService/GetRequestData/{id}/Left)
•	Input Web API (api/DiffService/GetRequestData/{id}/Right)
•	Result Web API (api/DiffService/GetResponseData)
•	Unit Testing
•	Integration Testing

Running it

This project is developed in Visual studio 2019 in C# with target framework 5.0.

Testing
1.	Create a new diff of left side
POST api/DiffService/GetRequestData/{id}/Left

 ----------------------------------------
HTTP/1.1 201 Created
{
    “Id”: “1”,
	  “InputString”: “abc”
}
	
2.	Create a new diff of left side
POST api/DiffService/GetRequestData/{id}/Right

 ----------------------------------------
HTTP/201 Created
{
    “Id”: “1”,
	  “InputString”: “abc”
}

3.	 Get the results for the diff you created
GET api/DiffService/GetResponseData
----------------------------------------
HTTP/200 OK
{
    "StatusCode": 200",
    "DiffResultType": "Equals|SizeDoNotMatch|ContentDoNotMatch|Not Found",    
    "diffs": [
        {
            "offset": 0,
            "length": 6
        }
    ]
}


Unit and Integration Tests

Unit Testing:
1.	TestPostLeftRequestData: Test the output of API of inserting data to left side.
2.	TestPostRightRequestData: Test the output of API of inserting data to left side.
3.	TestGetResponseDataforEqualData: Test the output of API of strings of input key are equal.
4.	TestGetResponseDataforEqualSize: Test the output of API of strings size of input key are equal.
5.	TestGetResponseDataforEqualSizeDiffString: Test the output of API of strings of input key, it gives difference of two strings with needed changes to match it.
Integration Testing:
1.	TestPostLeftRequestDataAsync: Test the output of API of inserting data to left side.
2.	TestPostRightRequestDataAsync: Test the output of API of inserting data to left side.
3.	TestGetResponseDataforEqualDataAsync: Test the output of API of strings of input key are equal.
4.	TestPGetResponseDataforEqualSizeAsync: Test the output of API of strings size of input key are equal.







