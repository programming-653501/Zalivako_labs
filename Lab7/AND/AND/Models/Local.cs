using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AND.Class
{
    class Local
    {
        private string _type;
        private string _name;
        private string _address;
        private DateTime _open_time;
        private DateTime _close_time;
        private string _description;


        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public DateTime Open
        {
            get { return _open_time; }
            set { _open_time = value; }
        }

        public DateTime Close
        {
            get { return _close_time; }
            set { _close_time = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }



    }
}
