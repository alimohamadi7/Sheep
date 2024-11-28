
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;


namespace Sheep.Core.Application.Background
{

    public interface IBackgroundJobs
    {
        string AddEnque(Expression<Action> methodCall);

        string AddEnque<T>(Expression<Action<T>> methodCall);

        string AddContinuations(Expression<Action> methodCall, string jobid);

        string AddContinuations<T>(Expression<Action<T>> methodCall, string jobid);

        string AddSchedule(Expression<Action> methodCall, RecuringTime recuringTime, double time);

        string AddSchedule<T>(Expression<Action<T>> methodCall, RecuringTime recuringTime, double time);
        void AddOrUpdate( string JobId, Expression<Action> methodCall, RecuringType recuringType, string? CronExpression);


    }

    public enum RecuringType
    {
        Daily,
        Minutely,
        Hourly,
        Weekly,
        Monthly,
        Yearly,
        CronExpression
    }

    public enum RecuringTime
    {
        Milliseconds,
        Seconds,
        Minutes,
        Hours,
        Day
    }
}

