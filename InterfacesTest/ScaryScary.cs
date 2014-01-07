using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfacesTallGuy
{
    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int numberOfScaryThings;
        public string ScaryThingIHave
        { get { return "i have " + numberOfScaryThings + " spiders"; } }

        public ScaryScary(string funnyThingIHave, int numberOfScaryThings)
            : base(funnyThingIHave)
        {
            this.numberOfScaryThings = numberOfScaryThings;
        }

        public void ScareLittleChildren()
        {
            MessageBox.Show("Boo, Gotchya!!");
        }
    }
}
