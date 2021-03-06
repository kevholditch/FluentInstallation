﻿using System;
using Microsoft.Web.Administration;

namespace FluentInstallation.Web
{
    public interface IWebsiteConfigurer : IFluentSyntax
    {
        IWebsiteConfigurer Named(string name);

        IWebsiteConfigurer UseApplicationPool(string applicationPoolName);

        IWebsiteConfigurer OnPhysicalPath(string path);

        IWebsiteConfigurer AddBinding(Action<IBindingConfigurer> action);

        IWebsiteConfigurer RemoveApplication(string alias);
        
        IWebsiteConfigurer RemoveVirtualDirectory(string alias);

        IWebsiteConfigurer AddApplication(Action<IApplicationConfigurer> application);
        
        IWebsiteConfigurer AddVirtualDirectory(Action<IVirtualDirectoryConfigurer> virtualDirectory);
        
        IWebsiteConfigurer Configure(Action<Site> action);

      
    }
}