using Serilog.Core;
using Serilog.Events;
using System.Diagnostics;

namespace DiagnosticoObservabilidadeNet10.Logging;

public class TraceIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var traceId = Activity.Current?.TraceId.ToString();

        if (!string.IsNullOrEmpty(traceId))
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty("TraceId", traceId)
            );
        }
    }
}
