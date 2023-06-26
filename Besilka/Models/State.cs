using Besilka.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Besilka.Models
{
    public class State
    {
        public State()
        {
            Letters = new List<Label>();
            HangState = HangState.None;
            HelpLeft = 2;
        }

        public List<Label> Letters { get; set; }

        public string Word { get; set; }

        public string EmptyChar => "__";

        public HangState HangState { get; set; }

        public int InitialChoicesLeft => Enum.GetValues(typeof(HangState)).Length - 1;

        public int HelpLeft { get; set; }
    }
}
