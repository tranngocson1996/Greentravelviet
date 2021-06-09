﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=1.1.4322.573.
// 
using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Services;


/// <remarks/>
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="GoogleSearchBinding", Namespace="urn:GoogleSearch")]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(ResultElement))]
public class GoogleSearchService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    /// <remarks/>
    public GoogleSearchService() {
        this.Url = "http://api.google.com/search/beta2";
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:GoogleSearchAction", RequestNamespace="urn:GoogleSearch", ResponseNamespace="urn:GoogleSearch")]
    [return: System.Xml.Serialization.SoapElementAttribute("return", DataType="base64Binary")]
    public System.Byte[] doGetCachedPage(string key, string url) {
        object[] results = this.Invoke("doGetCachedPage", new object[] {
                    key,
                    url});
        return ((System.Byte[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegindoGetCachedPage(string key, string url, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("doGetCachedPage", new object[] {
                    key,
                    url}, callback, asyncState);
    }
    
    /// <remarks/>
    public System.Byte[] EnddoGetCachedPage(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Byte[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:GoogleSearchAction", RequestNamespace="urn:GoogleSearch", ResponseNamespace="urn:GoogleSearch")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public string doSpellingSuggestion(string key, string phrase) {
        object[] results = this.Invoke("doSpellingSuggestion", new object[] {
                    key,
                    phrase});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegindoSpellingSuggestion(string key, string phrase, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("doSpellingSuggestion", new object[] {
                    key,
                    phrase}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EnddoSpellingSuggestion(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:GoogleSearchAction", RequestNamespace="urn:GoogleSearch", ResponseNamespace="urn:GoogleSearch")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public GoogleSearchResult doGoogleSearch(string key, string q, int start, int maxResults, bool filter, string restrict, bool safeSearch, string lr, string ie, string oe) {
        var results = this.Invoke("doGoogleSearch", new object[] {
                    key,
                    q,
                    start,
                    maxResults,
                    filter,
                    restrict,
                    safeSearch,
                    lr,
                    ie,
                    oe});
        return ((GoogleSearchResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegindoGoogleSearch(string key, string q, int start, int maxResults, bool filter, string restrict, bool safeSearch, string lr, string ie, string oe, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("doGoogleSearch", new object[] {
                    key,
                    q,
                    start,
                    maxResults,
                    filter,
                    restrict,
                    safeSearch,
                    lr,
                    ie,
                    oe}, callback, asyncState);
    }
    
    /// <remarks/>
    public GoogleSearchResult EnddoGoogleSearch(System.IAsyncResult asyncResult) {
        var results = this.EndInvoke(asyncResult);
        return ((GoogleSearchResult)(results[0]));
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapTypeAttribute("GoogleSearchResult", "urn:GoogleSearch")]
public class GoogleSearchResult {
    
    /// <remarks/>
    public bool documentFiltering;
    
    /// <remarks/>
    public string searchComments;
    
    /// <remarks/>
    public int estimatedTotalResultsCount;
    
    /// <remarks/>
    public bool estimateIsExact;
    
    /// <remarks/>
    public ResultElement[] resultElements;
    
    /// <remarks/>
    public string searchQuery;
    
    /// <remarks/>
    public int startIndex;
    
    /// <remarks/>
    public int endIndex;
    
    /// <remarks/>
    public string searchTips;
    
    /// <remarks/>
    public DirectoryCategory[] directoryCategories;
    
    /// <remarks/>
    public System.Double searchTime;
}

/// <remarks/>
[System.Xml.Serialization.SoapTypeAttribute("ResultElement", "urn:GoogleSearch")]
public class ResultElement {
    
    /// <remarks/>
    public string summary;
    
    /// <remarks/>
    public string URL;
    
    /// <remarks/>
    public string snippet;
    
    /// <remarks/>
    public string title;
    
    /// <remarks/>
    public string cachedSize;
    
    /// <remarks/>
    public bool relatedInformationPresent;
    
    /// <remarks/>
    public string hostName;
    
    /// <remarks/>
    public DirectoryCategory directoryCategory;
    
    /// <remarks/>
    public string directoryTitle;
}

/// <remarks/>
[System.Xml.Serialization.SoapTypeAttribute("DirectoryCategory", "urn:GoogleSearch")]
public class DirectoryCategory {
    
    /// <remarks/>
    public string fullViewableName;
    
    /// <remarks/>
    public string specialEncoding;
}