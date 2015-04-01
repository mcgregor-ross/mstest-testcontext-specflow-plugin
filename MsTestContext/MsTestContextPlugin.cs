using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using MsTestContext;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;

[assembly: GeneratorPlugin(typeof(MsTestContextPlugin))]

namespace MsTestContext
{
    public class MsTestContextPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {
        }

        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<CustomGeneratorProvider, IUnitTestGeneratorProvider>();
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
        }
    }
}
