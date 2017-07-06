using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using RIA.Train.Application.Dtos;
using RIA.Train.DataExporting;
using RIA.Train.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;

namespace RIA.Train.T_Requires.Exporting
{
    public class T_RequireExcelExporter : EpPlusExcelExporterBase, IT_RequireExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        //public T_RequireExcelExporter(
        //   ITimeZoneConverter timeZoneConverter,
        //   IAbpSession abpSession)
        //{
        //    _timeZoneConverter = timeZoneConverter;
        //    _abpSession = abpSession;
        //}
        public FileDto ExportToFile(List<T_RequireListDto> auditLogListDtos)
        {

            return CreateExcelPackage(
                "需求提报.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add("需求提报");
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        "提报时间",
                        "提报建议",
                        "提报人"

                    );

                    AddObjects(
                        sheet, 2, auditLogListDtos, o => o.SubmitTime,  o => o.Content, o => o.UserName
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
