using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
    public class Member {
        private int _id;
        private string _type;
        private string _reference;
        private string _role;
        
        public Member(int id, string type, string reference, string role) {
            _id = id;
            _type = type;
            _reference = reference;
            _role = role;
        }
    }
}
