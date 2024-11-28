using Hangfire;
using Sheep.Core.Application.Background;
using System.Linq.Expressions;


namespace Sheep.Infra.BackgroundTask.Background
{
    public class BackgroundJobs : IBackgroundJobs
    {
        private readonly IBackgroundJobClient _backgroundClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public BackgroundJobs(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _backgroundClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        public string AddEnque(Expression<Action> methodCall)
        {
            return _backgroundClient.Enqueue(methodCall);
        }

        public string AddEnque<T>(Expression<Action<T>> methodCall)
        {
            return _backgroundClient.Enqueue<T>(methodCall);
        }

        public string AddContinuations(Expression<Action> methodCall, string jobid)
        {
            return _backgroundClient.ContinueJobWith(jobid, methodCall);
        }

        public string AddContinuations<T>(Expression<Action<T>> methodCall, string jobid)
        {
            return _backgroundClient.ContinueJobWith<T>(jobid, methodCall);
        }

        public string AddSchedule(Expression<Action> methodCall, RecuringTime recuringTime, double time)
        {
            switch (recuringTime)
            {
                case RecuringTime.Milliseconds:
                    return _backgroundClient.Schedule(methodCall, TimeSpan.FromMilliseconds(time));

                case RecuringTime.Seconds:
                    return _backgroundClient.Schedule(methodCall, TimeSpan.FromSeconds(time));

                case RecuringTime.Minutes:
                    return _backgroundClient.Schedule(methodCall, TimeSpan.FromMinutes(time));

                case RecuringTime.Hours:
                    return _backgroundClient.Schedule(methodCall, TimeSpan.FromHours(time));

                case RecuringTime.Day:
                    return _backgroundClient.Schedule(methodCall, TimeSpan.FromDays(time));

                default:
                    return _backgroundClient.Schedule(methodCall, TimeSpan.FromMinutes(time));
            }
        }

        public string AddSchedule<T>(Expression<Action<T>> methodCall, RecuringTime recuringTime, double time)
        {
            switch (recuringTime)
            {
                case RecuringTime.Milliseconds:
                    return _backgroundClient.Schedule<T>(methodCall, TimeSpan.FromMilliseconds(time));

                case RecuringTime.Seconds:
                    return _backgroundClient.Schedule<T>(methodCall, TimeSpan.FromSeconds(time));

                case RecuringTime.Minutes:
                    return _backgroundClient.Schedule<T>(methodCall, TimeSpan.FromMinutes(time));

                case RecuringTime.Hours:
                    return _backgroundClient.Schedule<T>(methodCall, TimeSpan.FromHours(time));

                case RecuringTime.Day:
                    return _backgroundClient.Schedule<T>(methodCall, TimeSpan.FromDays(time));

                default:
                    return _backgroundClient.Schedule<T>(methodCall, TimeSpan.FromMinutes(time));
            }
        }

        public void AddOrUpdate(string JobId, Expression<Action> methodCall, RecuringType recuringType,string? CronExpression)
        {
            switch (recuringType)
            {
                case RecuringType.Minutely:
                     _recurringJobManager.AddOrUpdate(JobId, methodCall, Cron.Minutely);
                    break;

                case RecuringType.Hourly:
                    _recurringJobManager.AddOrUpdate(JobId, methodCall, Cron.Hourly);
                    break;

                case RecuringType.Daily:
                    _recurringJobManager.AddOrUpdate(JobId, methodCall, Cron.Daily);
                    break;

                case RecuringType.Weekly:
                    _recurringJobManager.AddOrUpdate(JobId, methodCall, Cron.Weekly);
                    break;
                case RecuringType.Monthly:
                    _recurringJobManager.AddOrUpdate(JobId, methodCall, Cron.Monthly);
                    break;
                case RecuringType.Yearly:
                    _recurringJobManager.AddOrUpdate(JobId, methodCall, Cron.Yearly);
                    break;

                default:
                    _recurringJobManager.AddOrUpdate(JobId, methodCall, CronExpression);
                    break;
            }
            


        }
    }

}
