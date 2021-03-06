﻿using System;
using Microsoft.Web.Administration;

namespace FluentInstallation.Web
{
    public interface IApplicationConfigurer : IFluentSyntax
    {
        IApplicationConfigurer UseAlias(string alias);
        IApplicationConfigurer OnPhysicalPath(string path);
        IApplicationConfigurer UseApplicationPool(string applicationPoolName);
        IApplicationConfigurer Configure(Action<Application> application);
    }
}