﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    class InService
    {
       
        public List<FactoryVO> FactoryInfo()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.FactoryInfo();
        }
    }
}
