﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class ItemService
    {
        public List<ItemVO> GetAllItem()
        {
            ItemDAC dac = new ItemDAC();
           return dac.GetAllItem();
        }

        internal List<ItemVO> SearchItem(string sg)
        {
            ItemDAC dac = new ItemDAC();
            return dac.SearchItem(sg);
        }

        internal bool SaveItem(ItemVO item)
        {
            ItemDAC dac = new ItemDAC();
            return dac.SaveItem(item);
        }

        internal bool DeleteItem(string condition)
        {
            ItemDAC dac = new ItemDAC();
            return dac.DeleteItem(condition);
        }

        internal void IpGoUpdate(int barID)
        {

            ItemDAC dac = new ItemDAC();
             dac.IpGoUpdate(barID);
        }
    }
}