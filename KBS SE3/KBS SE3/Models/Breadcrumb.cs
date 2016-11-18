using KBS_SE3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models {
    class Breadcrumb {

        public IModule Content { get; set; }
        public IModule Parent { get; set; }
        public IModule Child { get; set; }
        public String Name { get; set; }

        public Breadcrumb(IModule content, String name) {
            this.Name = name;
            this.Content = content;
        }

        public Breadcrumb(IModule content, String name, IModule child) : this(content, name) {
            this.Child = child;
        }

        public Breadcrumb(IModule content, String name, IModule child, IModule parent) : this(content, name, child) {
            this.Parent = parent;
        }
    }
}
