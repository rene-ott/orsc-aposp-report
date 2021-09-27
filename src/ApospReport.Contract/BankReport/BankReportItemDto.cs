﻿using System.Collections.Generic;
using ApospReport.Contract.Common;

namespace ApospReport.Contract.BankReport
{
    public class BankReportItemDto : ItemDefinitionDto
    {
        public int TotalItemCount { get; set; }
        public IList<BankReportUserDto> Users { get; set; } = new List<BankReportUserDto>();
    }
}
