using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tianyue.Utility.Common;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// Cache helper class for Control
    /// Author: Minghua
    /// </summary>
    public class PluginCacheHelper
    {
        public static List<PluginData> Plugins
        {
            get
            {
                return CommonCacheManager.PluginCache;
            }
        }

        public static Control GetCachedPlugin(string applicationType, Func<Control> creator)
        {
            Control control = null;

            if (CommonCacheManager.PluginCache.Exists(x => x.PluginKey == applicationType))
            {
                var pluginData = CommonCacheManager.PluginCache.Find(x => x.PluginKey == applicationType);
                return pluginData == null ? null : pluginData.Plugin;
            }
            else
            {
                if (!string.IsNullOrEmpty(applicationType))
                {
                    using (new CodeTimer(string.Format("Plugin: [{0}] Add to Cache", applicationType)))
                    {
                        control = creator();
                        if (control != null)
                        {
                            CommonCacheManager.PluginCache.Add(new PluginData() { PluginKey = applicationType, Plugin = control });
                        }
                    }
                }
            }
            return control;
        }

        public static Control FindPlugin(string applicationType)
        {
            if (!CommonCacheManager.PluginCache.Exists(x => x.PluginKey == applicationType))
            {
                return null;
            }

            var pluginData = CommonCacheManager.PluginCache.Find(x => x.PluginKey == applicationType);
            return pluginData == null ? null : pluginData.Plugin;
        }

        /// <summary>
        /// 释放内存
        /// </summary>
        public static void Dispose()
        {
            CommonCacheManager.PluginCache.Clear();
        }
    }

    public class PluginData
    {
        public string PluginKey { get; set; }

        public Control Plugin { get; set; }
    }
}
