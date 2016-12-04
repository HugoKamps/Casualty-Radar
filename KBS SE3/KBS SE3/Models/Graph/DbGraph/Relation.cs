using System.Collections.Generic;

namespace KBS_SE3.Models.Graph {
   public class Relation {
        private int _id;
        private List<Member> _memberList;
        private List<Tag> _tagList;

        public Relation(int id, List<Member> memberList, List<Tag> tagList) {
            _id = id;
            _memberList = memberList;
            _tagList = tagList;
        }
    }
}
