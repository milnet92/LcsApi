using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class ActionCenterDataViewModel
    {
        public string CardImage { get; set; }
        public string CardListTitle { get; set; }
        public string CardListDetail { get; set; }
        public CardActionLink[] CardActionLinks { get; set; }
    }
}
