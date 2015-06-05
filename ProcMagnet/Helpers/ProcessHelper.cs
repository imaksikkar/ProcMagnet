using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.ProcMagnet.Helpers
{
  class ProcessHelper
  {
    private ProcessHelper()
    {
      // Nope
    }


    /// <summary>
    /// Given a process, attach the debugger to it
    /// </summary>
    /// <param name="process"></param>
    public static void AttachProcess(Process process)
    {
      if(process != null)
        process.Attach();
    }


    /// <summary>
    /// Search for a running process by name
    /// </summary>
    /// <param name="processName"></param>
    /// <returns></returns>
    public static List<Process> FindProcesses(String processName)
    {
      DTE dte = ProcessHelper.GetDTE();
      List<Process> processes = new List<Process>();

      if (dte != null)
      {
        foreach (Process proc in dte.Debugger.LocalProcesses.Cast<Process>())
        {
          if (((proc.Name as String) ?? "").EndsWith(processName, StringComparison.OrdinalIgnoreCase))
            processes.Add(proc);
        }
      }

      return processes;
    }


    /// <summary>
    /// Return the DTE (whatever that is...)
    /// </summary>
    /// <returns></returns>
    private static DTE GetDTE()
    {
      return ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE;
    }
  }
}
