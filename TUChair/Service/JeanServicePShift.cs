﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class JeanServicePShift
    {
        public List<ProcessShiftVO> PSBinding()
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSBinding();
        }
        public List<EXProcessShiftVO> Bacode()
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.Bacode();
        }
        public bool PSShiftInsert(ProcessShiftVO sht) //선택공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(sht);
        }
        public bool PSShiftReturn(ProcessShiftVO sht) //선택공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftReturn(sht);
        }
        public bool PSShiftInsert(string a, string b) //바코드로 공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(a,b);
        }
        public List<ProcessShiftVO> ShiftLoad() // 공정이동한 목록표시
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ShiftLoad();
        }
        
    }
}