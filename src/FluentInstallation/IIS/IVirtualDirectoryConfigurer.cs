﻿using System;
using Microsoft.Web.Administration;

namespace FluentInstallation.IIS
{
    public interface IVirtualDirectoryConfigurer : IFluentSyntax
    {
        IVirtualDirectoryConfigurer UsingAlias(string alias);
        IVirtualDirectoryConfigurer OnPhysicalPath(string path);        
        IVirtualDirectoryConfigurer ConfigureAdvancedOptions(Action<VirtualDirectory> options);
    }


}


