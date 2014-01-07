using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacesTallGuy
{
    class TallGuy : IClown
    {
        public string Name;
        public int Height;
        public void TalkAboutYourself()
        {
            System.Windows.Forms.MessageBox.Show("My name is " + Name + " and im " + Height + " inches tall.");
        }

        public string FunnyThingIHave
        {
            get { return "big shoes"; }
        }

        public void Honk()
        {
            System.Windows.Forms.MessageBox.Show("Honk, honk!");
        }


    }
}
