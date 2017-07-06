using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using RIA.Train.Application.Dtos;
using RIA.Train.DataExporting;
using RIA.Train.Dto;
using RIA.Train.T_Requires.Exporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Newtonsoft.Json;

namespace RIA.Train.T_Estimates.Exporting
{
    public class T_EstimateExcelExporter : EpPlusExcelExporterBase, IT_EstimateExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        //public T_EstimateExcelExporter(
        //   ITimeZoneConverter timeZoneConverter,
        //   IAbpSession abpSession)
        //{
        //    _timeZoneConverter = timeZoneConverter;
        //    _abpSession = abpSession;
        //}
        public FileDto ExportToFile(List<T_EstimateListDto> auditLogListDtos)
        {
            return CreateExcelPackage(
                "培训课程评价信息.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add("培训评价");
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        "项目名称",
                        "教师姓名",
                        "评价内容",
                        "优",
                        "良",
                        "中",
                        "差"

                    );
                    List<Export2ColListDto> export = new List<Export2ColListDto>();
                    for (int index = 0; index <= auditLogListDtos.Count - 1; index++)
                    {
                        export.Add(new Export2ColListDto()
                        {
                            ContentCount = auditLogListDtos[index].ContentCount,
                            vClass = auditLogListDtos[index].T_Class.TrainintTeacher,
                            vContent = auditLogListDtos[index].T_Content.Content,
                            vGrade = auditLogListDtos[index].T_Grade.Grade,
                            vItem = auditLogListDtos[index].T_Class.T_Item.ProjectName
                        });
                    }

                    List<string> DimensionList = new List<string>() { "vItem", "vClass", "vContent" };
                    string DynamicColumn = "vGrade";
                    List<string> AllDynamicColumn = null;
                    List<dynamic> result = DynamicLinqToColumn.DynamicLinq(export, DimensionList, DynamicColumn, out AllDynamicColumn);
                    string rstJson = JsonConvert.SerializeObject(result, Formatting.Indented);

                    List<Export2ListDto> ex = JsonConvert.DeserializeObject<List<Export2ListDto>>(rstJson);
                    AddObjects(
                        sheet, 2, ex, o => o.vItem, o => o.vClass,
                        _ => _.vContent, _ => _.ContentCount优, _ => _.ContentCount良, _ => _.ContentCount中, _ => _.ContentCount差
                        );

                    //Formatting cells

                    var timeColumn = sheet.Column(1);
                    timeColumn.Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";

                    for (var i = 1; i <= 10; i++)
                    {
                        if (i.IsIn(5, 10)) //Don't AutoFit Parameters and Exception
                        {
                            continue;
                        }

                        sheet.Column(i).AutoFit();
                    }
                });
        }
    }
}
