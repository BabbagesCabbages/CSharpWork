using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace interfacesTallGuy
{
    class FunnyFunny : IClown
    {
        private string funnyThingIHave;
        public string FunnyThingIHave {
            get { return "Honk Honk! I have a " + funnyThingIHave; }
        }

        public FunnyFunny(string funnyThingIHave)
        { this.funnyThingIHave = funnyThingIHave; }

        public void Honk()
        {
            MessageBox.Show("Honk Honk! I have a " + funnyThingIHave);
        }


    }
}
