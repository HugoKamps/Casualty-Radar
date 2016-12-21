using KBS_SE3.Core;

namespace KBS_SE3.Models {
    public class Breadcrumb {

        public IModule Content { get; set; }
        public IModule Parent { get; set; }
        public IModule Child { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content">The IModule that represents the content of the breadcrumb</param>
        /// <param name="name">The name of breadcrumb</param>
        public Breadcrumb(IModule content, string name) {
            Name = name;
            Content = content;
        }

        /// <summary>
        /// Creates a new instance of breadcrumb with a given child module
        /// </summary>
        /// <param name="content">The IModule that represents the content of the breadcrumb</param>
        /// <param name="name">The name of breadcrumb</param>
        /// <param name="child">The child from the breadcrumb</param>
        public Breadcrumb(IModule content, string name, IModule child) : this(content, name) {
            Child = child;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content">The IModule that represents the content of the breadcrumb</param>
        /// <param name="name">The name of breadcrumb</param>
        /// <param name="child">The child from the breadcrumb</param>
        /// <param name="parent">The parent of the breadcrumb</param>
        public Breadcrumb(IModule content, string name, IModule child, IModule parent) : this(content, name, child) {
            Parent = parent;
        }
    }
}
