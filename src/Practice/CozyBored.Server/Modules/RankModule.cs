﻿using System;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using LiteDB;
using CozyBored.Server.Models;

namespace CozyBored.Server.Modules
{
    public class RankModule : NancyModule
    {
        private LiteCollection<RankModel> table;

        public RankModule()
        {
            table = DbContent.GetInstance().GetTable<RankModel>();

            Get["query-rank/{ver}"] = param =>
            {
                Console.WriteLine("query-rank");
                string ver = param.ver;
                var result = table.FindAll().OrderByDescending(x => x.time).Take(10).ToList();
                return result;
            };

            Get["get-rank/{ver}/{time}"] = param =>
            {
                Console.WriteLine("get-rank");
                string ver = param.ver;
                int atime = param.time;
                var num = table.FindAll().OrderByDescending(x => x.time).Count(x => x.time <= atime) + 1;
                var result = new { num = num };
                return result;
            };

            Post["save/{ver}"] = param =>
            {
                var model = this.Bind<RankModel>();
                model.id = Guid.NewGuid();
                Console.WriteLine("save:" + model.name + "-" + model.time);
                if (table.Insert(model) != null)
                    return HttpStatusCode.OK;
                return HttpStatusCode.InternalServerError;
            };
        }

    }
}
