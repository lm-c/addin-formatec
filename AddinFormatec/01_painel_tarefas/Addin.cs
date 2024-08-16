using System;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AddinFormatec
{
  public class Addin : ISwAddin {
    [ComRegisterFunction()]
    private static void ComRegister(Type t) {
      string keyPath = string.Format(@"SOFTWARE\SolidWorks\AddIns\{0:b}", t.GUID);
      using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(keyPath)) {
        rk.SetValue(null, 1);
        rk.SetValue("Title", "Addin Formatec");
        rk.SetValue("Description", "Gerenciador de Projetos Formatec");
      }
    }

    [ComUnregisterFunction()]
    private static void ComUnregister(Type t) {
      string keyPath = string.Format(@"SOFTWARE\SolidWorks\AddIns\{0:b}", t.GUID);
      Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(keyPath);
    }

    public SldWorks mSWApplication;
    private int mSWCookie;

    public bool ConnectToSW(object ThisSW, int Cookie) {
      mSWApplication = (SldWorks)ThisSW;
      mSWCookie = Cookie;

      bool result = mSWApplication.SetAddinCallbackInfo(0, this, Cookie);

      UISetup();
      return true;
    }

    public bool DisconnectFromSW() {
      UITeardown();
      return true;
    }

    private TaskpaneView mTaskpaneView;
    private UcPainelTarefas mPainelTarefas;

    private void UISetup() {
      string icon = @"C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\01 - Addin Formatec\IconTaskpanel.png";
      mTaskpaneView = mSWApplication.CreateTaskpaneView2(icon, "Addin Formatec " + InfoAssembly.Version);
      mPainelTarefas = (UcPainelTarefas)mTaskpaneView.AddControl(UcPainelTarefas.SWTASKPANE_PROGID, "");
    }

    private void UITeardown() {
      mPainelTarefas = null;
      mTaskpaneView.DeleteView();
      Marshal.ReleaseComObject(mTaskpaneView);
      mTaskpaneView = null;
    }
  }
}
