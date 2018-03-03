using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FieldEffect.Views;

namespace FieldEffect
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f = new BatterySettings();
            Application.Run(f);
        }
    }
}
