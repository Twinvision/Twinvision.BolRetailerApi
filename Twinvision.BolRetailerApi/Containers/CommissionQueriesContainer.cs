﻿using System;
using System.Collections.Generic;
using System.Text;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    public class CommissionQueriesContainer
    {
        public CommissionQuery[] CommissionQueries { get; set; }

        public CommissionQueriesContainer(CommissionQuery[] commissionQueries)
        {
            CommissionQueries = commissionQueries;
        }
    }
}
