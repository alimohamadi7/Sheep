﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Framework.Application.Entity
{
    public class BasePagging
    {
        public int DataCount { get; set; }
        public int PageId { get; set; }
        public int PageCount { get; set; }
        public int Take { get; set; }
        public int CurentPage { get; set; }
        public long? MonthId { get; set; }
        public long? YearId { get; set; }
        public string Trim { get; set; }
        public string Addres { get; set; }
        public long Id { get; set; }
        public void GeneratePagging(IQueryable<object> data, int pageId, int take, string trim, string addres)
        {
            DataCount = data.Count();
            CurentPage = pageId;
            PageCount = (int)Math.Ceiling(data.Count() / (double)take);
            Take = take;
            Trim = trim;
            Addres = addres;
        }
        public void GeneratePagging_V2(IQueryable<object> data, long id, int pageId, int take, long? yearId, long? monthId, string addres)
        {
            DataCount = data.Count();
            CurentPage = pageId;
            PageCount = (int)Math.Ceiling(data.Count() / (double)take);
            Take = take;
            YearId = yearId;
            MonthId = monthId;
            Addres = addres;
            Id = id;
        }
    }
}
