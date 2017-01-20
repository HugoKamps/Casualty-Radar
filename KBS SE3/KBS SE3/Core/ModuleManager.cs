using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Casualty_Radar.Modules;
using Casualty_Radar.Properties;

namespace Casualty_Radar.Core {
    /// <summary>
    /// Nog in te vullen door Eelco
    /// </summary>
    public class ModuleManager {

        private static ModuleManager _instance;
        private IModule _defaultModule, _currentModule;
        private readonly List<IModule> _registeredModules;

        private ModuleManager() {
            _registeredModules = new List<IModule>();
            RegisterModules();
            if (ConnectionUtil.HasInternetConnection()) {
                _defaultModule = ParseInstance(Settings.Default.userLocation == "" ? typeof(GetStartedModule) : typeof(HomeModule));
            } else {
                _defaultModule = ParseInstance(typeof(NoConnectionModule));
            }
        }

        /// <summary>
        /// Returns an existing instance of the given Type
        /// The Type should be an instance from IModule.
        /// </summary>
        /// <param name="type">The original Type of the IModule instance</param>
        /// <returns>An IModule instance</returns>
        public IModule ParseInstance(Type type) {
            return _registeredModules.FirstOrDefault(mod => mod.GetType() == type);
        }

        /// <summary>
        /// Registers all modules into cache so we can request them later.
        /// This method will make sure all modules are loaded in once.
        /// </summary>
        private void RegisterModules() {
            _registeredModules.AddRange( new IModule[] {
                new HomeModule(),
                new SettingsModule(),
                new NavigationModule(),
                new GetStartedModule(),
                new NoConnectionModule(),
                new TestModule()
            });
        }

        /// <summary>
        /// Returns an instance of the ModuleManager class in singleton format
        /// Creates the instance if it doesn't exist yet
        /// </summary>
        /// <returns>An instance of ModuleManager</returns>
        public static ModuleManager GetInstance() {
            return _instance ?? (_instance = new ModuleManager());
        }


        /// <summary>
        /// Updates the content from the main container with the given Module (IModule)
        /// Each button has an instance of the IModule interface bound to it.
        /// First the instance gets reinitialized incase the object-data changed using the microsoft Activator class.
        /// After that the contentpanel(in the container form) will be cleared resulting in an empty panel.Finally the given newly initialized module will
        /// be added to the panel.
        /// An header label inside the main container (if existent) will be renamed to the module name.
        /// </summary>
        /// <param name="module">The instance from the new (requested) module</param>
        public void UpdateModule(Object module) {
            Label headerLabel = Container.GetInstance().breadCrumbStart;
            Panel contentPanel = Container.GetInstance().contentPanel;
            if(module != null) {
                IModule reInitialized = ParseInstance(module.GetType());
                _currentModule = reInitialized;
                if (headerLabel != null) UpdateBreadcrumb(headerLabel, reInitialized);
                contentPanel.Controls.Clear();
                _defaultModule = reInitialized;
                contentPanel.Controls.Add((UserControl) module);
            }
        }

        /// <summary>
        /// Returns the current module that is active in the container.
        /// If there is no active module it returns null
        /// </summary>
        /// <returns>An instance of the IModule interface</returns>
        public IModule GetCurrentModule() {
            return _currentModule;
        }

        /// <summary>
        /// Returns the top level page based on the given IModule.
        /// If you're currently active in 'Home > Subpage1 > Subpage2' and request the 
        /// top Level of Subpage2 you'll get the Home module. 
        /// </summary>
        /// <param name="current">The IModule that you want to get the toplevel off</param>
        /// <returns>An IModule instance that is considered the top level based on the given IModule</returns>
        private IModule GetTopLevel(IModule current) {
            IModule topLevel = current;
            while (topLevel.GetBreadcrumb().Parent != null) {
                topLevel = topLevel.GetBreadcrumb().Parent;
            }
            return topLevel;
        }

        /// <summary>
        /// Updates the breadcrumb label in top of the content panel.
        /// </summary>
        /// <param name="origin">The original label that will be updated</param>
        /// <param name="content">The new IModule content</param>
        private void UpdateBreadcrumb(Label origin, IModule content) {
            IModule current = GetTopLevel(content);
            string crumbText = current.GetBreadcrumb().Name;
            while (current.GetType() != content.GetType()) {
                current = current.GetBreadcrumb().Child;
                crumbText += " > " + current.GetBreadcrumb().Name;
            }
            origin.Text = crumbText;
        }

        /// <summary>
        /// Returns the default module that will be shown when the app starts.
        /// </summary>
        /// <returns>An IModule instance</returns>
        public IModule GetDefaultModule() {
            return _defaultModule;
        }
    }
}
