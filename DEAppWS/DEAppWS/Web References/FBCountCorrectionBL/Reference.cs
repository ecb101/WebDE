﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3615.
// 
#pragma warning disable 1591

namespace DEAppWS.FBCountCorrectionBL {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FBCountCorrectionBLSoap", Namespace="http://tempuri.org/")]
    public partial class FBCountCorrectionBL : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback selectBatchOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateFBCountCorrectionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServerDateOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public FBCountCorrectionBL() {
            this.Url = global::DEAppWS.Properties.Settings.Default.DEAppWS_FBCountCorrectionBL_FBCountCorrectionBL;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event selectBatchCompletedEventHandler selectBatchCompleted;
        
        /// <remarks/>
        public event UpdateFBCountCorrectionCompletedEventHandler UpdateFBCountCorrectionCompleted;
        
        /// <remarks/>
        public event GetServerDateCompletedEventHandler GetServerDateCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/selectBatch", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet selectBatch() {
            object[] results = this.Invoke("selectBatch", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void selectBatchAsync() {
            this.selectBatchAsync(null);
        }
        
        /// <remarks/>
        public void selectBatchAsync(object userState) {
            if ((this.selectBatchOperationCompleted == null)) {
                this.selectBatchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnselectBatchOperationCompleted);
            }
            this.InvokeAsync("selectBatch", new object[0], this.selectBatchOperationCompleted, userState);
        }
        
        private void OnselectBatchOperationCompleted(object arg) {
            if ((this.selectBatchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.selectBatchCompleted(this, new selectBatchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateFBCountCorrection", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UpdateFBCountCorrection(string Note, System.Data.DataTable batchNumber, string correctField, string systemUserName) {
            object[] results = this.Invoke("UpdateFBCountCorrection", new object[] {
                        Note,
                        batchNumber,
                        correctField,
                        systemUserName});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateFBCountCorrectionAsync(string Note, System.Data.DataTable batchNumber, string correctField, string systemUserName) {
            this.UpdateFBCountCorrectionAsync(Note, batchNumber, correctField, systemUserName, null);
        }
        
        /// <remarks/>
        public void UpdateFBCountCorrectionAsync(string Note, System.Data.DataTable batchNumber, string correctField, string systemUserName, object userState) {
            if ((this.UpdateFBCountCorrectionOperationCompleted == null)) {
                this.UpdateFBCountCorrectionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateFBCountCorrectionOperationCompleted);
            }
            this.InvokeAsync("UpdateFBCountCorrection", new object[] {
                        Note,
                        batchNumber,
                        correctField,
                        systemUserName}, this.UpdateFBCountCorrectionOperationCompleted, userState);
        }
        
        private void OnUpdateFBCountCorrectionOperationCompleted(object arg) {
            if ((this.UpdateFBCountCorrectionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateFBCountCorrectionCompleted(this, new UpdateFBCountCorrectionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServerDate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetServerDate() {
            object[] results = this.Invoke("GetServerDate", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void GetServerDateAsync() {
            this.GetServerDateAsync(null);
        }
        
        /// <remarks/>
        public void GetServerDateAsync(object userState) {
            if ((this.GetServerDateOperationCompleted == null)) {
                this.GetServerDateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServerDateOperationCompleted);
            }
            this.InvokeAsync("GetServerDate", new object[0], this.GetServerDateOperationCompleted, userState);
        }
        
        private void OnGetServerDateOperationCompleted(object arg) {
            if ((this.GetServerDateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServerDateCompleted(this, new GetServerDateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void selectBatchCompletedEventHandler(object sender, selectBatchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class selectBatchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal selectBatchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void UpdateFBCountCorrectionCompletedEventHandler(object sender, UpdateFBCountCorrectionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateFBCountCorrectionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateFBCountCorrectionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetServerDateCompletedEventHandler(object sender, GetServerDateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServerDateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServerDateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591