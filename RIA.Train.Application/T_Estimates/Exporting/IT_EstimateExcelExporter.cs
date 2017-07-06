using RIA.Train.Application.Dtos;
using RIA.Train.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.T_Estimates.Exporting
{
    public interface IT_EstimateExcelExporter
    {
        FileDto ExportToFile(List<T_EstimateListDto> auditLogListDtos);
    }
}
