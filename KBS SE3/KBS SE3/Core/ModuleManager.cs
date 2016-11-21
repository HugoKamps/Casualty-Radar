using KBS_SE3.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS_SE3.Core {
    class ModuleManager {

        private static ModuleManager _instance;
        private IModule _defaultModule, _currentModule;
        private List<IModule> _registeredModules;

        private ModuleManager() {
            MessageBox.Show("modules");
            this._registeredModules = new List<IModule>();
            registerModules();
            this._defaultModule = ParseInstance(typeof(HomeModule));
        }

        /*
        * Returns an existing instance of the given Type
        * The Type should be an instance from IModule.
        */
        public IModule ParseInstance(Type type) {
            foreach(IModule mod in _registeredModules) {
                if (mod.GetType() == type) return mod;
            }
            return null;
        }

        /*
        * Registers all modules into cache so we can request them later.
        * This method will make sure all modules are loaded in once.
        */
        private void registerModules() {
            _registeredModules.AddRange( new IModule[] {
                new HomeModule(),
                new SettingsModule(),
                new NavigationModule()
            });
        }

        /*
        * Returns an instance of the ModuleManager class in singleton format
        * Creates the instance if it doesn't exist yet
        */
        public static ModuleManager GetInstance() {
            if (_instance == null) {
                _instance = new ModuleManager();
            }
            return _instance;
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
                this._currentModule = reInitialized;
                if (headerLabel != null) updateBreadcrumb(headerLabel, reInitialized);
                contentPanel.Controls.Clear();
                this._defaultModule = reInitialized;
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
