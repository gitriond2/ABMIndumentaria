﻿#pragma checksum "..\..\..\Formularios\AgregarC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5627E35737F2BB3EC02AF43B7E61DB06E633C23DD09876223AD8F03B8A9B5AE9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using IndumentariaIntimaWPF.Formularios;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace IndumentariaIntimaWPF.Formularios {
    
    
    /// <summary>
    /// AgregarC
    /// </summary>
    public partial class AgregarC : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Formularios\AgregarC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ClienteIDLabel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Formularios\AgregarC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NombreTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Formularios\AgregarC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ApellidoTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Formularios\AgregarC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DireccionTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Formularios\AgregarC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LocalidadTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IndumentariaIntimaWPF;component/formularios/agregarc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Formularios\AgregarC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ClienteIDLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.NombreTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\Formularios\AgregarC.xaml"
            this.NombreTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NombreTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ApellidoTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\Formularios\AgregarC.xaml"
            this.ApellidoTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.ApellidoTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DireccionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.LocalidadTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 25 "..\..\..\Formularios\AgregarC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAgregarC_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\..\Formularios\AgregarC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

