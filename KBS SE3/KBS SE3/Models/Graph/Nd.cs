using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
    public class Nd {
        private int _id;
        private string _reference;

        public Nd(int id, string reference) {
            _id = id;
            _reference = reference;
        }
    }
}
