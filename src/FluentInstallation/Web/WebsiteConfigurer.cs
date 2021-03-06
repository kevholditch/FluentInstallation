﻿using System;
using System.Linq;
using Microsoft.Web.Administration;

namespace FluentInstallation.Web
{
    public class WebsiteConfigurer : IWebsiteConfigurer
    {
        private readonly Site _website;

        public WebsiteConfigurer(Site website)
        {
            
            if (website == null)
            {
                throw new ArgumentNullException("website");
            }

            _website = website;
            
        }

        public IWebsiteConfigurer Named(string name)
        {
            return Configure(site => site.Name = name);
        }

        public IWebsiteConfigurer UseApplicationPool(string applicationPoolName)
        {
            return Configure(site => site.Applications.First().ApplicationPoolName = applicationPoolName);
        }

        public IWebsiteConfigurer OnPhysicalPath(string path)
        {
            return Configure(site => site.Application().VirtualDirectory().PhysicalPath = path);
        }

        public IWebsiteConfigurer AddBinding(Action<IBindingConfigurer> action)
        {
            return Configure(site =>
            {
                var configurer = new BindingConfigurer(site.Bindings.CreateDefaultBinding());
                action(configurer);
            });
        }

        public IWebsiteConfigurer RemoveApplication(string alias)
        {

            return Configure(site =>
            {
                var foundApplication = site.Applications.FirstOrDefault(x => x.Path.Equals(alias.ToPath()));

                if (foundApplication == null)
                {
                    throw Exceptions.ApplicationNotFoundInSite(site, alias);
                }

                site.Applications.Remove(foundApplication);

            });
        }

        public IWebsiteConfigurer RemoveVirtualDirectory(string alias)
        {
            return Configure(site =>
            {
                var foundVirtualDirectory = site.Application().VirtualDirectories.FirstOrDefault(x => x.Path.Equals(alias.ToPath()));

                if (foundVirtualDirectory == null)
                {
                    throw Exceptions.VirtualDirectoryNotFoundInSite(site, alias);
                }

                site.Application().VirtualDirectories.Remove(foundVirtualDirectory);

            });
        }

        public IWebsiteConfigurer AddApplication(Action<IApplicationConfigurer> application)
        {
            return Configure(site =>
            {
                var configurer = new ApplicationConfigurer(site.Applications.CreateDefaultApplication());
                application(configurer);
            });
        }

        public IWebsiteConfigurer AddVirtualDirectory(Action<IVirtualDirectoryConfigurer> virtualDirectory)
        {
            return Configure(site =>
            {
                var configurer = new VirtualDirectoryConfigurer(site.Application().VirtualDirectories.CreateDefaultVirtualDirectory());
                virtualDirectory(configurer);
            });
        }

        public IWebsiteConfigurer Configure(Action<Site> action)
        {
            action(_website);
            return this;
        }
    }
}