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








