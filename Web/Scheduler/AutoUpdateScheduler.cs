using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace AspMain.Web.Scheduler
{
    public class AutoUpdateScheduler
    {
        public static void Start()
        {
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler.Start();


            //IJobDetail job = JobBuilder.Create<AutoUpdate>().Build();

            ////update all status wallet = 0, user online = 0
            //ITrigger trigger = TriggerBuilder.Create()
            //  .StartNow()
            //  .WithSimpleSchedule(x => x
            //  .WithIntervalInSeconds(30)
            //  .RepeatForever())
            //  .Build();

            //scheduler.ScheduleJob(job, trigger);

        }
    }
}