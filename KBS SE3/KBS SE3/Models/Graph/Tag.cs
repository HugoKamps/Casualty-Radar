using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
   public class Tag {
        private int _id;
        private string _key;
        private string _value;

        public Tag(int id, string key, string value) {
            _id = id;
            _key = key;
            _value = value;
        }
    }
}
