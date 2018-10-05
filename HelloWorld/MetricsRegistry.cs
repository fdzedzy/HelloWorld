using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Timer;

namespace HelloWorld
{
    public static class MetricsRegistry
    {
        public static CounterOptions SampleCounter => new CounterOptions
        {
            Name = "Sample Counter",
            MeasurementUnit = Unit.Calls
        };

        public static TimerOptions MyTimer => new TimerOptions
        {
            Name = "Franks Counter"
        };
    }
}