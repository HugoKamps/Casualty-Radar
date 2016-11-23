using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
    public class Way {
        private int _id;
        private List<Nd> _ndList;
        private List<Tag> _tagList;

        public Way(int id, List<Nd> ndList, List<Tag> tagList) {
            _id = id;
            _ndList = ndList;
            _tagList = tagList;
        }
    }
}
