﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3625
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIPV.Windows.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sqldelta1;Initial Catalog=Estadistica;Integrated Security=True")]
        public string EstadisticaConnectionString {
            get {
                return ((string)(this["EstadisticaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:51642/SIPV.Web/UI_WS_CARGA_DATOS.asmx")]
        public string SIPV_Windows_ws_SIPV_SIPV_UI_WS_CARGA_DATOS {
            get {
                return ((string)(this["SIPV_Windows_ws_SIPV_SIPV_UI_WS_CARGA_DATOS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQLDELTA1;Initial Catalog=Estadistica;User ID=SA;Password=ARMAGEDON")]
        public string EstadisticaConnectionString1 {
            get {
                return ((string)(this["EstadisticaConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:51642/SIPV.Web/UI_WS_CARGA_DATOS.asmx")]
        public string Estadisticas_Windows_ws_estadisticas_SIPV_UI_WS_CARGA_DATOS {
            get {
                return ((string)(this["Estadisticas_Windows_ws_estadisticas_SIPV_UI_WS_CARGA_DATOS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=XYLON;Initial Catalog=SIPV;Integrated Security=True")]
        public string SIPVConnectionString {
            get {
                return ((string)(this["SIPVConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=TI-EP-06\\SQL_2008;Initial Catalog=SIPV;Integrated Security=True")]
        public string SIPVConnectionString1 {
            get {
                return ((string)(this["SIPVConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=TI-EP-06\\SQL_2008;Initial Catalog=SIPV2;Integrated Security=True")]
        public string SIPV2ConnectionString {
            get {
                return ((string)(this["SIPV2ConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=XYLON;Initial Catalog=SIPV2;Integrated Security=True")]
        public string SIPV2ConnectionString1 {
            get {
                return ((string)(this["SIPV2ConnectionString1"]));
            }
        }
    }
}
