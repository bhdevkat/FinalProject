﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.StaffAS.Dto
{
    public class PagedStaffResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
