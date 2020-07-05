using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp31;

static class Program
{
    static bool IsSingleInstance()
    {
        try
        {
            Mutex.OpenExisting("UNIQUE");
        }
        catch
        {
            Mutex mutex = new Mutex(true, "UNIQUE");
            return true;
        }
        MessageBox.Show("Приложение уже запущено!!!", "Дубликат!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }


    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
        if (IsSingleInstance())
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}