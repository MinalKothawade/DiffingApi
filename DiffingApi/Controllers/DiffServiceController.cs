using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DiffingApi
{

    [ApiController]
    public class DiffServiceController : ControllerBase
    {
        //Json file path for storing data
        private string jsonFile = @"DataLog.json";

        /// <summary>
        /// First Endpoint service for left side data acceptance
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>ResponseData object with detected status code</returns>

        [HttpPost]
        [Route("api/DiffService/GetRequestData/{id}/Left")]
        public ResponseData  PostLeftRequestData(RequestData obj)        
        {
            var response = new ResponseData();
            try
            {
                //validate the requested data
                //------------------------------
                if (obj.InputString.Length > 0)
                {
                    //Read the content from json file and store it in dictionary to process
                    //------------------------------
                    var _diffDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, DiffData>>(System.IO.File.ReadAllText(jsonFile));
                    //------------------------------
                    // if Key is already present in dictionary then update the inputstring else create new entry with key
                    //------------------------------
                    if (_diffDataDictionary.ContainsKey(obj.Id))
                    {
                        _diffDataDictionary[obj.Id].LeftNode = obj.InputString;
                    }
                    else
                    {
                        _diffDataDictionary.Add(obj.Id, new DiffData(obj.Id, obj.InputString, null));
                    }
                    //------------------------------
                    //Convert the dictionary into Json string and update file with updated dictionary
                    //------------------------------
                    string json = JsonConvert.SerializeObject(_diffDataDictionary);
                    System.IO.File.WriteAllText(jsonFile, json);
                    //------------------------------
                    // send response to user for requested data
                    //------------------------------
                    response.DiffResultType = "Created";
                    response.StatusCode = 201;
                    //------------------------------
                }
                //------------------------------
                else
                {

                    response.DiffResultType = "Bad Request";
                    response.StatusCode = 400;
                }
                return response;
            }
            catch(Exception Ex)
            {

            }
            return response;
        }

        /// <summary>
        /// Second Endpoint service for left side data acceptance
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>ResponseData object with detected status code</returns>
        [HttpPost]
        [Route("api/DiffService/GetRequestData/{id}/Right")]
        public ResponseData PostRightRequestData(RequestData obj)
        {
            var response = new ResponseData();
            try
            {
                //validate the requested data
                //------------------------------
                if (obj.InputString.Length > 0)
                {

                    //Read the content from json file and store it in dictionary to process
                    //------------------------------
                    var _diffDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, DiffData>>(System.IO.File.ReadAllText(jsonFile));
                    //------------------------------
                    // if Key is already present in dictionary then update the inputstring else create new entry with key
                    //------------------------------
                    if (_diffDataDictionary.ContainsKey(obj.Id))
                    {
                        _diffDataDictionary[obj.Id].RightNode = obj.InputString;
                    }
                    else
                    {
                        _diffDataDictionary.Add(obj.Id, new DiffData(obj.Id, null, obj.InputString));
                    }
                    //------------------------------
                    //Convert the dictionary into Json string and update file with updated dictionary
                    //------------------------------
                    string json = JsonConvert.SerializeObject(_diffDataDictionary);
                    System.IO.File.WriteAllText(jsonFile, json);
                    //------------------------------
                    // send response to user for requested data
                    //------------------------------
                    response.DiffResultType = "Created";
                    response.StatusCode = 201;
                    //------------------------------
                }
                else
                {
                    response.StatusCode = 400;
                    response.DiffResultType = "Bad Request";
                }
                return response;
            }
            catch(Exception ex)
            {

            }
            return response;
        }

        /// <summary>
        /// Second Endpoint service for left side data acceptance
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>ResponseData object with detected status code</returns>
        [HttpGet]
        [Route("api/DiffService/GetResponseData")]
        public ResponseData GetResponseData(string Id)
        {
            var response = new ResponseData();
            try
            {
               
                var _diffDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, DiffData>>(System.IO.File.ReadAllText(jsonFile));
                if (_diffDataDictionary.ContainsKey(Id))
                {
                    var data = _diffDataDictionary[Id];
                    if (data.LeftNode is not null && data.RightNode is not null)
                    {
                        if (DiffingServices.CheckStringEquality(data.LeftNode, data.RightNode))
                        {
                            response.DiffResultType = "Equals";
                            response.StatusCode = 200;
                            return response;
                        }
                        else
                        if (!DiffingServices.CheckStringSize(data.LeftNode, data.RightNode))
                        {
                            response.DiffResultType = "SizeDoNotMatch";
                            response.StatusCode = 200;
                            return response;
                        }
                        else
                        {

                            response.StatusCode = 200;
                            response.DiffResultType = "ContentDoNotMatch";
                            response.diffs=DiffingServices.CheckDiffing(data.LeftNode, data.RightNode);
                        }

                    }
                    else
                    {
                        return response;
                    }
                }
                else
                {
                    response.StatusCode = 404;
                    response.DiffResultType = "Not Found";
                    return response;
                }
            }
            catch(Exception ex)
            {

            }
            return response;
        }


    }


}
