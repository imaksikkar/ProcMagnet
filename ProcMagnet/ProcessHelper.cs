using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.ProcMagnet
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
    public static void AttachProcess(dynamic process)
    {
      if(process != null)
        process.Attach();
    }


    /// <summary>
    /// Search for a running process by name
    /// </summary>
    /// <param name="processName"></param>
    /// <returns></returns>
    public static List<dynamic> FindProcesses(String processName)
    {
      DTE dte = ProcessHelper.GetDTE();
      List<dynamic> processes = new List<dynamic>();

      if (dte != null)
      {
        foreach (dynamic proc in dte.Debugger.LocalProcesses)
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
