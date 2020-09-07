using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class MyModel
    {
        
    }

    public class carinfo
    {
        public int id { get; set; }
        public string carname { get; set; }
        public string carimage { get; set; }
        public string status { get; set; }
    }


    public class userstory1
    {
        public int id { get; set; }
        public int carid { get; set; }
        
        public string hourlyrate { get; set; }
        public string Ondate { get; set; }
    }

    public class userstory2
    {
        public int id { get; set; }
        public int carid { get; set; }
        public string status { get; set; }
        public string Customername { get; set; }
        public string Ondate { get; set; }
    }

    public class userstory3
    {
        public int id { get; set; }
        public int carid { get; set; }
        //public string carimage { get; set; }
        public Boolean chkstatus { get; set; }
        public string Ondate { get; set; }
    }
}