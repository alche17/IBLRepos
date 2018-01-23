using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalienceThemes.Models
{
    class Path
    {
        string _licensePath;
        string _dataPath;

        public string LicensePath
        {
            get { return _licensePath; }
            set { _licensePath = value; }
        }

        public string DataPath
        {
            get { return _dataPath; }
            set { _dataPath = value; }
        }
    }
}
