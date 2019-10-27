using System;

namespace JuricaInfrastructure
{
    public class InfoModel
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Tip: {this.GetType().Name} Time: {Time} Message: {Message}";
        }
    }
}
