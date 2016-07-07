using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InversionOfControl.Business.Implementation;
using InversionOfControl.Business.Interfaces;

namespace InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicContainer container = new BasicContainer();
            //registering dependecies
            container.Register<IWeb, Web>();
            container.Register<IFacebookService, FacebookService>();
            container.Register<IFacebookPlugin, FacebookPlugin>();
            container.Register<IPlayerPlugin, PlayerPlugin>();

            // instantiate web
            IWeb web = container.Create<IWeb>();
            web.Run();
        }
    }
}
