using Newtonsoft.Json;
using SampleNetCore.Common.IServices;
using SampleNetCore.Common.Utility;
using SampleNetCore.Model.Models.Request;
using SampleNetCore.Model.Models.Response;
using System;
using System.Collections.Generic;

namespace SampleNetCore.Common.Services
{
    public class ManageJsonData : IManageJsonData
    {
        public GetDatalistResponse GetJsonDataList(string FilePath)
        {
            DtoDataObject getJsonObject = new DtoDataObject();
            GetDatalistResponse getParentlistResponse = new GetDatalistResponse();
            var stJsonData = CommonMethods.ReadTextFromFile(FilePath);
            getJsonObject = JsonConvert.DeserializeObject<DtoDataObject>(stJsonData);
            if (!string.IsNullOrEmpty(stJsonData))
            {
                getParentlistResponse.stParentObject = stJsonData;
                getParentlistResponse.success = true;
                getParentlistResponse.message = "Data read successfully";
            }
            return getParentlistResponse;
        }

        public UpdateDatalistResponse UpdateParentListData(UpdateDataListRequest updateParentListRequest)
        {
            DtoDataObject getJsonObject = new DtoDataObject();
            UpdateDatalistResponse updateParentlistResponse = new UpdateDatalistResponse();
            var stJsonData = CommonMethods.ReadTextFromFile(updateParentListRequest.stFilePath);
            getJsonObject = JsonConvert.DeserializeObject<DtoDataObject>(stJsonData);
            if (!string.IsNullOrEmpty(stJsonData))
            {
                if (getJsonObject != null)
                {
                    foreach (var item in getJsonObject.Datas)
                    {
                        if (Convert.ToDateTime(updateParentListRequest.SamplingTime) == Convert.ToDateTime(item.SamplingTime))
                        {
                            List<DtoProperty> data = JsonConvert.DeserializeObject<List<DtoProperty>>(updateParentListRequest.Properties.Replace('"', '\''));
                            item.Properties = data;
                        }
                    }
                }
                string JsonString = JsonConvert.SerializeObject(getJsonObject);
                bool IsUpdated = CommonMethods.UpdateTextFromFile(updateParentListRequest.stFilePath, JsonString);
                if (IsUpdated)
                {
                    updateParentlistResponse.success = true;
                    updateParentlistResponse.message = "Data updated successfully.";
                }
                else
                {
                    updateParentlistResponse.success = false;
                   // updateParentlistResponse.message = "While updating data getting an error, Please try again.";
                }
            }
            return updateParentlistResponse;
        }
    }
}
