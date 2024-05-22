using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace MauiApp1.Model
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string ProfilePhotoUrl { get; }

        public User(int id, string name, string profilePhotoUrl)
        {
            this.Id = id;
            this.Name = name;
            this.ProfilePhotoUrl = profilePhotoUrl;
        }
    }
}


