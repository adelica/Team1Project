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
        public bool PSShiftInsert(int Primary, string fact) //선택공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(Primary, fact);
        }
        public bool PSShiftReturn(int Primary, string date, string fact) //선택공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftReturn(Primary, date, fact);
        }
        public bool PSShiftInsert(string a, string b) //바코드로 공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(a, b);
        }
        public List<ProcessShiftVO> ShiftLoad() // 공정이동한 목록표시
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ShiftLoad();
        }

        public List<ProcessShiftVO> Search(string Fact, string code, string txt)//검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.Search(Fact, code, txt);
        }
        public List<InOutVo> InOutSearch(string Fact, string Gubun, string Category, string itype, string start, string end, string Icode)//검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.InOutSearch(Fact, Gubun, Category, itype, start, end, Icode);
        }
        public List<ProductOutVO> PSMSearch(string Ccode, string start, string end, string comno, string item)//ProductShipmentMag
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSMSearch(Ccode, start, end, comno, item);
        }

        public List<ProductSatus> PSMSSearch(string Ccode, string start, string end, string comno, string item)//ProductShipmentStatus
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSMSSearch(Ccode, start, end, comno, item);
        }

        public List<ProductClosingVO> ClosingSearch(string Ccode, string start, string end, string comno, string item)//SalesClosing
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ClosingSearch(Ccode, start, end, comno, item);
        }
        
            public List<ProductClosingVO> ClosingStatusSearch(string Ccode, string start, string end, string comno, string item)//SalesClosingStatus
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ClosingStatusSearch(Ccode, start, end, comno, item);
        }
        public bool OutProductCancle(string Primary, string Item, string Modifier, int Qty)// 제품출하취소
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.OutProductCancle(Primary, Item, Modifier, Qty);
        }


        public List<PSMManager> PSMManager() // 공정이동 현황 바인딩
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSMManager();
        }
        public List<PSMManager> PSMMSearch(string item, string Fact, string txt)// 공정이동 현황검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSMMSearch(item, Fact, txt);
        }


        public List<StockShift> StockBinding(string pry)// 공정이동 현황검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.StockBinding(pry);
        }
        public List<StockShift> ThisIsShift(int Primary, string Item, string Fact, string From_Fact, string Modifier, int Qty)// 공정이동 현황검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ThisIsShift(Primary, Item, Fact, From_Fact, Modifier, Qty);
        }
        public List<InOutVo> InOutBinding()// 입출고현황 바인딩
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.InOutBinding();
        }

        public bool ShiftProduct(string Item, string Fact, string Modifier, int Qty, string primary)// 제품공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ShiftProduct(Item, Fact, Modifier, Qty, primary);
        }
        public bool OutProduct(string Primary, string Item, int Price, string Modifier, int Qty)// 제품출하
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.OutProduct(Primary, Item, Price, Modifier, Qty);
        }
        public List<ProductSatus> PSStatus()// 출하현황 바인딩
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSStatus();
        }
        public List<ProductClosingVO> PClosing()
        {
            ProductClosingDAC dac = new ProductClosingDAC();
            return dac.PClosing();
        }

        public bool PCDeadline(string Primary, string Item, int Qty, string Modifier)// 제품출하
        {
            ProductClosingDAC dac = new ProductClosingDAC();
            return dac.PCDeadline(Primary, Item, Qty, Modifier);
        }
        public List<ProductClosingVO> PDeadBinding()
        {
            ProductClosingDAC dac = new ProductClosingDAC();
            return dac.PDeadBinding();
        }
        public bool PCDeadlineCancle(string Primary, string Item, int Qty, string Modifier)// 제품출하
        {
            ProductClosingDAC dac = new ProductClosingDAC();
            return dac.PCDeadlineCancle(Primary, Item, Qty, Modifier);
        }

    }
}
