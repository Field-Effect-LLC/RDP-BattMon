using FieldEffect.Classes;
using FieldEffect.Interfaces;
using System.Windows.Forms;

namespace FieldEffect
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize();
            using (var presenter = (IBatteryDetailPresenter)NinjectConfig.Instance.GetService(typeof(IBatteryDetailPresenter)))
            {
                Application.Run((Form)presenter.BatteryDetailView);
            }
        }
    }
}
