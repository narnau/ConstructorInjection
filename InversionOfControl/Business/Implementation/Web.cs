using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InversionOfControl.Business.Interfaces;

namespace InversionOfControl.Business.Implementation
{
    public class Web : IWeb
    {
        private readonly IPlayerPlugin playerPlugin;
        private readonly IFacebookPlugin facebookPlugin;

        public Web(IPlayerPlugin playerPlugin, IFacebookPlugin facebookPlugin)
        {
            this.playerPlugin = playerPlugin;
            this.facebookPlugin = facebookPlugin;
        }

        public void Run()
        {
            Console.WriteLine("Run web!");
        }
    }
}
