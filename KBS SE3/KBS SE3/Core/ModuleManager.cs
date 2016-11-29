using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KBS_SE3.Modules;
using KBS_SE3.Properties;
using KBS_SE3.Utils;
using static System.String;

namespace KBS_SE3.Core {
    class ModuleManager {

        private static ModuleManager _instance;
        private IModule _defaultModule, _currentModule;
        private readonly List<IModule> _registeredModules;

        private ModuleManager() {
            _registeredModules = new List<IModule>();
            registerModules();
            if (ConnectionUtil.HasInternetConnection()) {
                this._defaultModule = ParseInstance(Settings.Default.userLocation == "" ? typeof(GetStartedModule) : typeof(HomeModule));
            } else {
                this._defaultModule = ParseInstance(typeof(NoConnectionModule));
            }
        }

        /*
        * Returns an existing instance of the given Type
        * The Type should be an instance from IModule.
        */
        public IModule ParseInstance(Type type) {
            return _registeredModules.FirstOrDefault(mod => mod.GetType() == type);
        }

        /*
        * Registers all modules into cache so we can request them later.
        * This method will make sure all modules are loaded in once.
        */
        private void registerModules() {
            _registeredModules.AddRange( new IModule[] {
                new HomeModule(),
                new SettingsModule(),
                new NavigationModule(),
                new GetStartedModule(),
                new NoConnectionModule() 
            });
        }

        /*
        * Returns an instance of the ModuleManager class in singleton format
        * Creates the instance if it doesn't exist yet
        */
        public static ModuleManager GetInstance() {
            return _instance ?? (_instance = new ModuleManager());
        }

        /*
        * Updates the content from the main container with the given Module (IModule)
        * Each button has an instance of the IModule interface bound to it.
        * First the instance gets reinitialized incase the object-data changed using the microsoft Activator class.
        * After that the contentpanel (in the container form) will be cleared resulting in an empty panel. Finally the given newly initialized module will
        * be added to the panel.
        *
        * An header label inside the main container (if existent) will be renamed to the module name.
        */
        public void UpdateModule(Label headerLabel, Panel contentPanel, Object module) {
            if(module != null) {
                IModule reInitialized = ParseInstance(module.GetType());
                _currentModule = reInitialized;
                if (headerLabel != null) updateBreadcrumb(headerLabel, reInitialized);
                contentPanel.Controls.Clear();
                _defaultModule = reInitialized;
                contentPanel.Controls.Add((UserControl) module);
            }
        }

        /*
        * Returns the current module that is active in the container.
        * If there is no active module it returns null
        */
        public IModule GetCurrentModule() {
            return _currentModule;
        }

        /*
        * Returns the top level page based on the given IModule.
        * If you're currently active in 'Home > Subpage1 > Subpage2' and request the top Level of Subpage2 you'll
        * get the Home module. 
        */
        private IModule getTopLevel(IModule current) {
            IModule topLevel = current;
            while (topLevel.GetBreadcrumb().Parent != null) {
                topLevel = topLevel.GetBreadcrumb().Parent;
            }
            return topLevel;
        }
        
        /*
        * Updates the breadcrumb label in top of the content panel.
        */
        private void updateBreadcrumb(Label origin, IModule content) {
            IModule current = getTopLevel(content);
            String crumbText = current.GetBreadcrumb().Name;
            while (current.GetType() != content.GetType()) {
                current = current.GetBreadcrumb().Child;
                crumbText += " > " + current.GetBreadcrumb().Name;
            }
            origin.Text = crumbText;
        }

        /*
        * Returns the default module that will be shown when the app starts.
        */
        public IModule GetDefaultModule() {
            return _defaultModule;
        }
    }
}
