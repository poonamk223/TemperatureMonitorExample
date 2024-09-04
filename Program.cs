namespace EventHandlerDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create instances of sensor and monitor
            TemperatureSensor sensor = new TemperatureSensor(30.0);
            TemperatureMonitor monitor = new TemperatureMonitor();

            // Subscribe to the event
            sensor.TemperatureExceeded += monitor.OnTemperatureExceeded;

            // Simulate temperature readings
            sensor.CheckTemperature(25.0);  // No alert
            sensor.CheckTemperature(35.0);  // Alert triggered
        }
    }
}
