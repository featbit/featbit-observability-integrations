using FeatBit.Sdk.Server;
using FeatBit.Sdk.Server.Model;
using OpenTelemetry.Trace;

namespace OpenTelemetryApm
{
    public interface IOtelFeatBitClient
    {
        bool BoolVariation(FbUser user, string flagKey, bool defaultValue = false);
    }
    public class OtelFeatBitClient: IOtelFeatBitClient
    {
        private readonly FbClient _client;
        public OtelFeatBitClient(
            FbClient fbClient)
        {
            _client = fbClient;
        }
        public bool BoolVariation(FbUser user, string flagKey, bool defaultValue = false)
        {
            var span = Tracer.CurrentSpan;
            //var attributeData = new Dictionary<string, object>
            //{
            //    {"foo", 1 },
            //    { "bar", "Hello, World!" },
            //    { "baz", new int[] { 1, 2, 3 } }
            //};
            //span.AddEvent("feature-flags-trigger", DateTimeOffset.Now, new(attributeData));
            var variation = _client.BoolVariation(flagKey, user, defaultValue);
            span.SetAttribute("feature-flags", $"{flagKey}:{variation}");
           
            return variation;
        }
    }
}
