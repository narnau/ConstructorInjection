using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InversionOfControl.Business.Interfaces;

namespace InversionOfControl.Business.Implementation
{
    public class FacebookPlugin : IFacebookPlugin
    {
        private readonly IFacebookService facebookService;

        public FacebookPlugin(IFacebookService facebookService)
        {
            this.facebookService = facebookService;
        }
    }
}