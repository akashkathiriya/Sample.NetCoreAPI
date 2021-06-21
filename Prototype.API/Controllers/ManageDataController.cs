using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleNetCore.Common.IServices;
using SampleNetCore.Model.Models.Request;
using SampleNetCore.Model.Models.Response;
using System;

namespace SampleNetCore.API.Controllers
{
    [Route("api/ManageData")]
    [ApiController]
    public class ManageDataController : ControllerBase
    {
        private readonly ILogger<ManageDataController> _logger;
        private readonly IManageJsonData _manageJsonData;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ManageDataController(ILogger<ManageDataController> logger
           , IManageJsonData manageJsonData
            , IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _manageJsonData = manageJsonData;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [Route("GetData")]
        public GetDatalistResponse GetParentlist()
        {
            GetDatalistResponse getParentlistResponse = new GetDatalistResponse();
            string stFilePath = String.Format("{0}{1}", _hostEnvironment.ContentRootPath.ToString(), "\\DataFile\\data.json");
            return  _manageJsonData.GetJsonDataList(stFilePath);
        }

        [HttpPost]
        [Route("UpdateData")]
        public UpdateDatalistResponse UpdateParentList([FromBody] UpdateDataListRequest updateParentListRequest)
        {
            UpdateDatalistResponse updateParentlistResponse = new UpdateDatalistResponse();
            updateParentListRequest.stFilePath = String.Format("{0}{1}", _hostEnvironment.ContentRootPath.ToString(), "\\DataFile\\data.json");
            return _manageJsonData.UpdateParentListData(updateParentListRequest);
        }
    }
}
