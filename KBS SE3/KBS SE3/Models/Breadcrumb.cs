using KBS_SE3.Core;

namespace KBS_SE3.Models {
    class Breadcrumb {

        public IModule Content { get; set; }
        public IModule Parent { get; set; }
        public IModule Child { get; set; }
        public string Name { get; set; }

        public Breadcrumb(IModule content, string name) {
            Name = name;
            Content = content;
        }

        public Breadcrumb(IModule content, string name, IModule child) : this(content, name) {
            Child = child;
        }

        public Breadcrumb(IModule content, string name, IModule child, IModule parent) : this(content, name, child) {
            Parent = parent;
        }
    }
}
