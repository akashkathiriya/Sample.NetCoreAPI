using SampleNetCore.Common.Models;
using SampleNetCore.Model.Models.Request;
using SampleNetCore.Model.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleNetCore.Common.IServices
{
    public interface IManageJsonData
    {
        GetDatalistResponse GetJsonDataList(string FilePath);
        UpdateDatalistResponse UpdateParentListData(UpdateDataListRequest updateParentListRequest);
    }
}
