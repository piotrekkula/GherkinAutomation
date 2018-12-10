using System;
using System.Reflection;
using NUnit.Core;
using NUnit.Core.Extensibility;
using System.IO;

namespace TechTalk.SpecFlow
{
    [NUnitAddin(Type = ExtensionType.Core, Name = "Reporting")]
    public class ReportingNUnitExtension : IAddin, EventListener
    {
        StreamWriter s;

        public bool Install(IExtensionHost host)
        {
            IExtensionPoint listeners = host.GetExtensionPoint("EventListeners");
            listeners.Install(this);
            return true;
        }

        private void TriggerTestRunEnd()
        {
            s.Close();
        }
    
        public void RunStarted(string name, int testCount)
        {
            try
            {
                #warning Edit this for Your directory or change to dynamic!
                Environment.CurrentDirectory = "C:\\Users\\Public\\projects\\iHCP\\bin\\Debug";

                FileStream f = new FileStream("TestResults.log", FileMode.Create);
                s = new StreamWriter(f);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("Nie można stworzyć" + e);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        
        public void RunFinished(TestResult result)
        {
            TriggerTestRunEnd();
        }

        public void RunFinished(Exception exception)
        {
            TriggerTestRunEnd();
        }

        public void TestOutput(TestOutput testOutput)
        {
            s.Write(testOutput.Text);
            s.Flush();
        }

        #region Not-affected listener methods


        public void TestStarted(TestName testName)
        {
        }

        public void TestFinished(TestResult result)
        {
        }

        public void SuiteStarted(TestName testName)
        {
        }

        public void SuiteFinished(TestResult result)
        {
        }

        public void UnhandledException(Exception exception)
        {
        }
        #endregion
    }
}
