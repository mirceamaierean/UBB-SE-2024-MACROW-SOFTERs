using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public class Chat
    {
        public int Id { get; private set; }

        public Chat(int id)
        {
            this.Id = id;
        }
    }
}
