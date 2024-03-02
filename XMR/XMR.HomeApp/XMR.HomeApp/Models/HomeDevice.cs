using System;
using System.Collections.Generic;
using System.Text;

namespace XMR.HomeApp.Models
{
    public class HomeDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public HomeDevice(string name, string image = null, string description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
            Description = description;
        }
    }
}
