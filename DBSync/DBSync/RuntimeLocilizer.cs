using DBSync.UIControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSync
{
    public static class RuntimeLocalizer
    {
        public static void ChangeCulture(Form frm, string cultureCode)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(cultureCode);

            Thread.CurrentThread.CurrentUICulture = culture;

            ComponentResourceManager resources = new ComponentResourceManager(frm.GetType());

            //resources.ApplyResources(frm, "$this", culture);
            frm.Text = resources.GetString("$this.Text", culture);
            ApplyResourceToControl(resources, frm, culture);
           
        }

        private static void ApplyResourceToControl(ComponentResourceManager res, Control control, CultureInfo lang)
        {
            if (control.GetType() == typeof(ListView))  // See if this is a menuStrip
            {
                ListView list = (ListView)control;
                ApplyResourceToListView(list, res, lang);
                return;      
            }

            if (control.GetType() == typeof(Ribbon))  // See if this is a menuStrip
            {
                Ribbon ribbon = (Ribbon)control;
                ApplyResourceToRibbon(ribbon, res, lang);
                return;
            }

            if (!( control is SplitContainer || control is Form ))
            {
                control.Text = res.GetString(control.Name + ".Text", lang);
            }
            if (control is ILocalizeControl)
            {
                ((ILocalizeControl)control).UpdateLocalization();
               
                return;
            }

                       

            foreach (Control c in control.Controls) // Apply to all sub-controls
            { 
                ApplyResourceToControl(res, c, lang);               
            }
        }

        private static void ApplyResourceToToolStripItemCollection(ToolStripItemCollection col, ComponentResourceManager res, CultureInfo lang)
        {
            for (int i = 0; i < col.Count; i++)     // Apply to all sub items
            {
                ToolStripItem item = (ToolStripMenuItem)col[i];

                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                    ApplyResourceToToolStripItemCollection(menuitem.DropDownItems, res, lang);
                }

                res.ApplyResources(item, item.Name, lang);
            }
        }

        private static void ApplyResourceToListView(ListView list, ComponentResourceManager res, CultureInfo lang)
        {
            foreach(ColumnHeader col in list.Columns)
            {
                col.Text = res.GetString(col.Name + ".Text", lang);
            }
        }

        private static void ApplyResourceToRibbon(Ribbon ribbon, ComponentResourceManager res, CultureInfo lang)
        {
            foreach (RibbonTab tab in ribbon.Tabs)
            {
                tab.Text = res.GetString(tab.Value + ".Text", lang);
            }
        }
    }
}
