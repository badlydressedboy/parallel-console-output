using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadedConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {

            while (1 == 1)
            {
                StartTasks();

                Console.WriteLine("Start again, any key");
                Console.ReadKey();
            }
        }

        static void StartTasks()
        {
            Console.CursorLeft = 0;
            var tasks = new List<Task>();
            Console.WriteLine("Starting Example Tasks...");
            Console.WriteLine();

            int headStartMs = 20;
            tasks.Add(Task.Run(() => { DoWorkOnSameLine(100, 15, "1. dots)"); }));
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoWorkOnSameLine(170, 20, "2. dots wrap)"); }));
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoSimpleWork(56, 140, "3. numbers)"); }));
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoPercentageWork(100, "4. percentage)"); }));
            Thread.Sleep(headStartMs);            
            tasks.Add(Task.Run(() => { DoWaitAnimation(80, 140, "5. animation)"); }));
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoWorkElapsedTime(170, 80, "8. time)"); }));            
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoWorkMultiCastOutput(80, 200, "7. multicast)"); }));
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoComplexWork(70, 200, "8. multimode)"); }));
            Thread.Sleep(headStartMs);
            tasks.Add(Task.Run(() => { DoWorkMultiline(200, 100, "9. multiline)"); }));            

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine();
            Console.WriteLine("ALL TASKS COMPLETE");            
        }

        #region Example ConsoleWriteContext Class Use

        static void DoSimpleWork(int workUnits, int unitTimeMs, string header = null)
        {

            var cwc = new ConsoleWriteContext(true, header);

            for (int x = 0; x <= workUnits; x++)
            {
                cwc.WriteContinue("." + x);
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteContinue(" Complete!");

        }

        static void DoPercentageWork(int unitTimeMs, string header = null)
        {

            var cwc = new ConsoleWriteContext(true, header);

            for (int x = 0; x <= 100; x++)
            {
                cwc.WritePercentage(x, true, true);
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteContinue(" Complete!");

        }
        
        static void DoComplexWork(int workUnits, int unitTimeMs, string header = null)
        {

            var cwc = new ConsoleWriteContext(true, header);

            for (int x = 0; x <= workUnits; x++)
            {
                cwc.WriteContinue("." + x);
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteContinue(" - Second Section - ");
            for (int x = 0; x <= 10; x++)
            {
                cwc.WriteAtCurrent(x.ToString());
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteStart("Section complete - line overwritten with this status");

            cwc.WriteNewLine("Starting 3rd section...");
            for (int x = 0; x <= 20; x++)
            {
                cwc.WriteWorkingAnimation();
                Thread.Sleep(unitTimeMs);
            }
            cwc.WriteContinue(" Complete!");

        }

        static void DoWorkOnSameLine(int workUnits, int unitTimeMs, string header = null)
        {
            var cwc = new ConsoleWriteContext(true, header);
                        
            for (int x = 0; x <= workUnits; x++)
            {
                cwc.WriteContinue(".");
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteContinue(" Complete!");
        }

        static void DoWorkMultiline(int workUnits, int unitTimeMs, string header = null)
        {
            var cwc = new ConsoleWriteContext(false, header);
                        
            for (int x = 0; x <= workUnits; x++)
            {
                cwc.WriteContinue(".");
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteContinue(" Complete!");
        }

        static void DoWaitAnimation(int workUnits, int unitTimeMs, string header = null)
        {
            var cwc = new ConsoleWriteContext(true, header);
            
            for (int x = 0; x <= workUnits; x++)
            {
                cwc.WriteWorkingAnimation();
                Thread.Sleep(unitTimeMs);
            }

            cwc.WriteContinue("Complete!");
        }

        static void DoWorkMultiCastOutput(int workUnits, int unitTimeMs, string header = null)
        {
            // example of having multiple console outputs from 1 Task/Thread
            var cwc1 = new ConsoleWriteContext(true, header + "a");
            var cwc2 = new ConsoleWriteContext(true, header + "b");
            var cwc3 = new ConsoleWriteContext(true, header + "c");

            for (int x = 0; x <= workUnits; x++)
            {
                cwc1.WriteContinue(".");
                cwc2.WriteContinue("_" + x.ToString());
                cwc3.WriteAtCurrent(cwc3.GetNextWorkingAnimChar() + " " + x.ToString());
                Thread.Sleep(unitTimeMs);
            }

            cwc1.WriteContinue(" Complete!");
            cwc2.WriteContinue(" Complete!");
        }

        static void DoWorkElapsedTime(int workUnits, int unitTimeMs, string header = null)
        {
            var cwc1 = new ConsoleWriteContext(true, header + "a");
            var cwc2 = new ConsoleWriteContext(true, header + "b");

            for (int x = 0; x <= workUnits; x++)
            {
                cwc1.WriteElapsedTime(ElapsedTimeUnit.Ms, true);
                cwc2.WriteElapsedTime(ElapsedTimeUnit.Second, true);
                Thread.Sleep(unitTimeMs);
            }

            cwc1.WriteContinue(" Complete!");
            cwc2.WriteContinue(" Complete!");
        }

        #endregion

    }
    
}
