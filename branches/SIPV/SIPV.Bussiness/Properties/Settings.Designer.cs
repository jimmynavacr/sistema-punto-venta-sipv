﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3625
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIPV.Bussiness.Properties {
    
    
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
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:51642/SIPV.Web/UI_WS_CARGA_DATOS.asmx")]
        public string SIPV_Bussiness_ws_SIPV_SIPV_UI_WS_CARGA_DATOS {
            get {
                return ((string)(this["SIPV_Bussiness_ws_SIPV_SIPV_UI_WS_CARGA_DATOS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.puertodecaldera.com/app_operaciones/SIPV_SIPV.asmx")]
        public string SIPV_Bussiness_SIPV_SIPV_SIPV_SIPV {
            get {
                return ((string)(this["SIPV_Bussiness_SIPV_SIPV_SIPV_SIPV"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.puertodecaldera.com/app_operaciones/Estadisticas_SIPV.asmx")]
        public string Estadisticas_Bussiness_Estadisticas_SIPV_Estadisticas_SIPV {
            get {
                return ((string)(this["Estadisticas_Bussiness_Estadisticas_SIPV_Estadisticas_SIPV"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:51642/SIPV.Web/UI_WS_CARGA_DATOS.asmx")]
        public string Estadisticas_Bussiness_ws_estadisticas_SIPV_UI_WS_CARGA_DATOS {
            get {
                return ((string)(this["Estadisticas_Bussiness_ws_estadisticas_SIPV_UI_WS_CARGA_DATOS"]));
            }
        }
    }
}
