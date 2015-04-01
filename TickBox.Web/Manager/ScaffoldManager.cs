using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TickBox.Objects;


namespace TickBox.Web.Manager
{
    public class ScaffoldManager : IScaffoldManager
    {
        private readonly IScaffoldWrapper scaffoldWrapper;

        public ScaffoldManager(IScaffoldWrapper scaffoldWrapper)
        {
            this.scaffoldWrapper = scaffoldWrapper;
        }

        #region Implementation of IScaffoldManager

        public void CreateDefaultScaffold()
        {
            this.scaffoldWrapper.CreateDefaultScaffold();
        }

        #endregion
    }
}