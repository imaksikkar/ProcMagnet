using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Company.ProcMagnet
{
  /// <summary>
  /// Custom button
  /// </summary>
  class ProcMagnetButton : Button
  {
    static ProcMagnetButton()
    {
      // Allow this control to be styled just like a button
      DefaultStyleKeyProperty.OverrideMetadata(typeof(ProcMagnetButton),
        new FrameworkPropertyMetadata(typeof(Button)));
    }


    /// <summary>
    /// Property for holding the target process to attach
    /// </summary>
    public String TargetProcess { get; set; }


    public ProcMagnetButton()
      : base()
    {
      this.TargetProcess = "";
      this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      this.Margin = new Thickness(5);
      this.Click += ProcMagnetButton_Click;
    }


    /// <summary>
    /// Handles the click event, but forwards the real work on
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ProcMagnetButton_Click(object sender, RoutedEventArgs e)
    {
      List<dynamic> processes = ProcessHelper.FindProcesses(this.TargetProcess);

      switch (processes.Count)
      {
        case 0:
          MessageBox.Show(String.Format("Could not find \"{0}\"", this.TargetProcess));
          break;

        case 1:
          ProcessHelper.AttachProcess(processes[0]);
          break;

        default:
          // TODO: show a form here and let the user choose which process to attach
          break;
      }
    }
  }
}
