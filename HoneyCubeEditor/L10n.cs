#region Using Statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// Enumerates all available resource types.
    /// </summary>
    public enum L10nResourceType : int
    {
        /// <summary>
        /// String resources that do not belong to any of the other category.
        /// </summary>
        General = 0,

        /// <summary>
        /// Strings for control elements.
        /// </summary>
        Controls = 1,

        /// <summary>
        /// Strings for messages.
        /// </summary>
        Messages = 2,

        /// <summary>
        /// Interface icons.
        /// </summary>
        Icons = 3
    }

    /// <summary>
    /// A static class used for string localization.
    /// TODO: Report if translation for current language is missing entirely
    /// </summary>
    public static class L10n
    {
        #region Static Fields

        private static readonly Dictionary<string, string> _missing = new Dictionary<string, string>();
        private static readonly ResourceManager[] _l10nResources;

        #endregion

        #region Static Constructor

        /// <summary>
        /// Static constructor. Creates a resource manager for each resource type.
        /// This way we can avoid that the Designer needs to generate a public or 
        /// internal property for each string used within the resource file.
        /// </summary>
        static L10n()
        {
            string[] types = Enum.GetNames(typeof(L10nResourceType));
            _l10nResources = new ResourceManager[types.Length];
            
            Assembly assembly = typeof(L10n).Assembly;
            for (int i = 0, l = types.Length - 1; i < l; i++)
            {
                _l10nResources[i] = new ResourceManager("HoneyCube.Editor.Resources.Strings." + types[i], assembly);
                _l10nResources[i].IgnoreCase = true;
            }

            _l10nResources[_l10nResources.Length - 1] = new ResourceManager("HoneyCube.Editor.Resources.Icons", assembly);
        }

        #endregion

        #region Report

        /// <summary>
        /// Indicates whether a translation is missing for the given string 
        /// identifier within the current culture context.
        /// </summary>
        /// <param name="key">The id of the string.</param>
        /// <returns>True if a translation is missing. False if not.</returns>
        public static bool IsMissingTranslation(string key)
        {
            return _missing.ContainsKey(key);
        }

        /// <summary>
        /// Generates a log file holding informations about all missing 
        /// translations.
        /// </summary>
        public static void ReportMissingTranslations()
        {
            string path = Application.UserAppDataPath + "\\logs\\";
            string filepath = path + "l10n.log";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(filepath))
                File.Delete(filepath);

            using (StreamWriter stream = new StreamWriter(filepath))
            {
                foreach (KeyValuePair<string, string> entry in _missing)
                    stream.WriteLine("{0,-40}{1}", entry.Key, entry.Value);
                stream.Close();
            }
        }

        #endregion

        #region String Localization

        /// <summary>
        /// Localizes the text property of the current control and all its child nodes.
        /// </summary>
        /// <param name="control">The control to localize.</param>
        public static void LocalizeControl(Control control)
        {
            LocalizeControl(control, string.Empty, true);
        }

        /// <summary>
        /// Localizes the text property of the current control and all its child nodes.
        /// </summary>
        /// <param name="control">The control to localize.</param>
        /// <param name="prefix">A string value which is prepended to the controls name. Helps to avoid naming conflicts.</param>
        public static void LocalizeControl(Control control, string prefix)
        {
            LocalizeControl(control, prefix, true);
        }

        /// <summary>
        /// Localizes the text property of the current control and all its child nodes
        /// (if includeChildren is set to true).
        /// </summary>
        /// <param name="control">The control to localize.</param>
        /// <param name="prefix">A string value which is prepended to the controls name. Helps to avoid naming conflicts.</param>
        /// <param name="includeChildren">Whether to process all child nodes of the current control.</param>
        public static void LocalizeControl(Control control, string prefix, bool includeChildren)
        {
            string controlName = string.IsNullOrWhiteSpace(prefix) ? control.Name : prefix + control.Name;

            if (!string.IsNullOrWhiteSpace(controlName))
            {
                string localized = LookUp(controlName, L10nResourceType.Controls);

                // If no value is returned, register as missing translation
                if (string.IsNullOrWhiteSpace(localized))
                {
                    string text = control.Text;
                    _missing[controlName] = string.IsNullOrWhiteSpace(text) ? "<Empt>" : text;
                }

                // Otherwise assign the translation to the control element
                else
                {
                    control.Text = localized;
                }
            }

            if (includeChildren)
                LocalizeChildControls(control, prefix);
        }

        /// <summary>
        /// Tries to retrieve a translated string with respect the currently active 
        /// application language.
        /// </summary>
        /// <param name="key">The unique identifier of the string to lookup.</param>
        /// <returns>The translated string, or null if no tranlation available.</returns>
        private static string LookUp(string key)
        {
            return LookUp(key, L10nResourceType.General);
        }

        /// <summary>
        /// Tries to retrieve a translated string with respect the currently active 
        /// application language.
        /// </summary>
        /// <param name="key">The unique identifier of the string to lookup.</param>
        /// <param name="type">The resource file to use for the lookup process.</param>
        /// <returns>The translated string, or null if no tranlation available.</returns>
        private static string LookUp(string key, L10nResourceType type)
        {
            // Handle: No key value given
            if (string.IsNullOrWhiteSpace(key))
                return string.Empty;

            ResourceManager resx = _l10nResources[(int)type];
            string value = string.Empty;

            if (resx != null)
                value = resx.GetString(key, Application.CurrentCulture);

            return !string.IsNullOrWhiteSpace(value) ? value : null;
        }

        /// <summary>
        /// Determines the type of the current control and process their child 
        /// nodes if any exist.
        /// </summary>
        /// <param name="control">The control to process the child nodes of.</param>
        /// <param name="prefix">A string value which is prepended to the controls name. Helps to avoid naming conflicts.</param>
        private static void LocalizeChildControls(Control control, string prefix)
        {
            // Process all child nodes
            foreach (Control child in control.Controls)
                LocalizeControl(child, prefix);

            // Process strip items
            ToolStrip strip = control as ToolStrip;
            if (strip != null)
                foreach (ToolStripItem item in strip.Items)
                    LocalizeToolStripItem(item, prefix);

            // Process buttons
            ToolBar bar = control as ToolBar;
            if (bar != null)
                foreach (ToolBarButton button in bar.Buttons)
                    LocalizeToolBarButton(button, prefix);
        }

        #endregion

        #region Media Localization

        /// <summary>
        /// Assigns an icon to the specified form if available in the corresponding 
        /// resource file. The icon retrieved can be overwritten on a per language 
        /// basis.
        /// </summary>
        /// <param name="form">The form to assign an icon to.</param>
        /// <param name="file">The file name of the icon to assign.</param>
        public static void AssignIcon(Form form, string file)
        {
            //ResourceManager resx = _l10nResources[(int)L10nResourceType.Icon];
            //Icon icon = resx.GetObject(file, Application.CurrentCulture) as Icon;

            //if (icon != null)
            //    form.Icon = icon;
        }

        /// <summary>
        /// Assigns an image to the specified tool strip item if available in the 
        /// corresponding resource file. The image retrieved can be overwritten 
        /// on a per language basis.
        /// </summary>
        /// <param name="item">The tool strip item to assign an image to.</param>
        /// <param name="file">The file name of the icon to assign.</param>
        public static void AssignIcon(ToolStripItem item, string file)
        {
            ResourceManager resx = _l10nResources[(int)L10nResourceType.Icons];
            Image image = resx.GetObject(file, Application.CurrentCulture) as Image;

            if (image != null)
                item.Image = image;
        }

        #endregion

        #region ToolStripItem & ToolStripDropDownItem

        /// <summary>
        /// ToolStripItems behave a bit different than generic controls as they 
        /// do not inherit from Windows Forms Control class, still they provide
        /// a text property than should be translated.
        /// </summary>
        /// <param name="item">The tool strip item to localize.</param>
        /// <param name="prefix">A prefix to use for the lookup process.</param>
        private static void LocalizeToolStripItem(ToolStripItem item, string prefix)
        {
            // Skip seperators
            if (item is ToolStripSeparator)
                return;

            // Allow to prefix given component names
            string itemName = string.IsNullOrWhiteSpace(prefix) ? item.Name : prefix + item.Name;

            if (!string.IsNullOrWhiteSpace(itemName))
            {
                string localized = LookUp(itemName, L10nResourceType.Controls);

                // If no value is returned, register as missing translation
                if (string.IsNullOrWhiteSpace(localized))
                {
                    string text = item.Text;
                    _missing[itemName] = string.IsNullOrWhiteSpace(text) ? "<Empt>" : text;
                }

                // Otherwise assign the translation to the control element
                else
                {
                    item.Text = localized;
                }
            }

            // Process dropdown items as well
            ToolStripDropDownItem dropdown = item as ToolStripDropDownItem;
            if (dropdown != null)
                foreach (ToolStripItem dropdownItem in dropdown.DropDownItems)
                    LocalizeToolStripItem(dropdownItem, prefix);
        }

        #endregion

        #region ToolBarButton

        /// <summary>
        /// ToolBarButtons behave a bit different than generic controls as they 
        /// do not inherit from Windows Forms Control class, still they provide
        /// a text property than should be translated.
        /// </summary>
        /// <param name="button">The tool bar button to localize.</param>
        /// <param name="prefix">A prefix to use for the lookup process.</param>
        private static void LocalizeToolBarButton(ToolBarButton button, string prefix)
        {
            string buttonName = string.IsNullOrWhiteSpace(prefix) ? button.Name : prefix + button.Name;

            if (!string.IsNullOrWhiteSpace(buttonName))
            {
                string localized = LookUp(buttonName, L10nResourceType.Controls);

                // If no value is returned, register as missing translation
                if (string.IsNullOrWhiteSpace(localized))
                {
                    string text = button.Text;
                    _missing[buttonName] = string.IsNullOrWhiteSpace(text) ? "<Empt>" : text;
                }

                // Otherwise assign the translation to the control element
                else
                {
                    button.Text = localized;
                }
            }
        }

        #endregion
    }
}
