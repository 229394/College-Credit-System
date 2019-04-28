using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    class Admin
    {
        private int AdminID;
        private string AdminNumber;
        private string AdminPwd;
        private string AdminName;

       
        
        public string AdminPwd1 { get => AdminPwd; set => AdminPwd = value; }
        public string AdminName1 { get => AdminName; set => AdminName = value; }
        public int AdminID1 { get => AdminID; set => AdminID = value; }
        public string AdminNumber1 { get => AdminNumber; set => AdminNumber = value; }
    }
}
