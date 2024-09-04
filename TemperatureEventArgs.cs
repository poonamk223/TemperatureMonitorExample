using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    // Step 1: Create a class to pass as an argument for the event handlers
    public class TemperatureEventArgs : EventArgs
    {
        public double CurrentTemperature { get; }

        public TemperatureEventArgs(double currentTemperature)
        {
            CurrentTemperature = currentTemperature;
        }
    }

    // Step 2: Define the delegate
    public delegate void TemperatureExceededEventHandler(object sender, TemperatureEventArgs e);

    // Step 3: Set up the event in TemperatureSensor
    public class TemperatureSensor
    {
        // Use the custom delegate to define the event
        public event TemperatureExceededEventHandler TemperatureExceeded;

        private double _threshold;

        public TemperatureSensor(double threshold)
        {
            _threshold = threshold;
        }

        public void CheckTemperature(double temperature)
        {
            if (temperature > _threshold)
            {
                // Trigger the event
                OnTemperatureExceeded(new TemperatureEventArgs(temperature));
            }
        }

        // Method to raise the event
        protected virtual void OnTemperatureExceeded(TemperatureEventArgs e)
        {
            TemperatureExceeded?.Invoke(this, e);
        }
    }

    // Step 4: Create the event handler in TemperatureMonitor
    public class TemperatureMonitor
    {
        public void OnTemperatureExceeded(object sender, TemperatureEventArgs e)
        {
            Console.WriteLine($"Temperature alert! Current temperature: {e.CurrentTemperature}°C");
        }
    }

}
