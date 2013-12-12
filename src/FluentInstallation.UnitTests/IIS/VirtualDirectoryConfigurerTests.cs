﻿using Microsoft.Web.Administration;
using Xunit;

namespace FluentInstallation.IIS
{
    public class VirtualDirectoryConfigurerTests
    {
        [Fact]
        public void UsingAlias_SetsThePath()
        {
            var virtualDirectory = WebAdministrationFactory.CreateVirtualDirectory();
            var sut = new VirtualDirectoryConfigurer(virtualDirectory);

            sut.UsingAlias("/mySite");

            Assert.Equal("/mySite", virtualDirectory.Path);
        }

        [Fact]
        public void OnPhysicalPath_SetsThePhysicalPath()
        {
            var virtualDirectory = WebAdministrationFactory.CreateVirtualDirectory();
            var sut = new VirtualDirectoryConfigurer(virtualDirectory);

            sut.OnPhysicalPath("X:\\mySite");

            Assert.Equal("X:\\mySite", virtualDirectory.PhysicalPath);
        }
        
   }
}