using Casualty_Radar.Core;

namespace Casualty_Radar.Models {
    public class Breadcrumb {
        public IModule Content { get; set; }
        public IModule Parent { get; set; }
        public IModule Child { get; set; }
        public string Name { get; set; }

        /// <summary>
        ///  Creates a new instance of breadcrumb
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
        /// Creates a new instance of breadcrumb with a given child module and a given parent module
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