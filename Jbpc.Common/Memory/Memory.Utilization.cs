
using System;
using System.Diagnostics;

namespace Jbpc.Common
{
    public class MemoryUtilization : IDisposable
    {
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        public MemoryUtilization()
        {
            InitialiseCPUCounter();
            InitializeRAMCounter();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            var msg  = "CPU Usage: " +
            Convert.ToInt32(cpuCounter.NextValue()).ToString() +
            "%";

            var x = Convert.ToInt32(ramCounter.NextValue()).ToString() + "Mb";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter(
            "Processor",
            "% Processor Time",
            "_Total",
            true
            );
        }

        private void InitializeRAMCounter()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);

        }
        public void Dispose()
        {
            cpuCounter.Dispose();
            ramCounter.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
