// -----------------------------------------------------------------------
// <copyright file="ScaffoldWrapper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using TickBox.Business.Scaffold;
using TickBox.Objects;
using TickBox.Objects.Notifications;


namespace TickBox.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ScaffoldWrapper : WrapperBase, IScaffoldWrapper
    {
        #region Implementation of IScaffoldWrapper

        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        public ScaffoldWrapper(IComitable dataUnitOfWork, INotify notifier)
            : base(dataUnitOfWork, notifier)
        {
        }

        public void CreateDefaultScaffold()
        {
            try
            {
                if (this.AutoCreateScaffolding && !Scaffolding.ScaffoldExists(this.dataUnitOfWork))
                {
                    this.notifier.Add<DebugNotification>("Creating defualt data structures", "Item Create");

                    Scaffolding.CreateDefaultStructure(this.dataUnitOfWork);

                    this.Save(true, new SuccessNotification { Message = "Default data structures sucsessfully created.", Title = "Create" });

                }
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to create default data structures : " + e.Message, "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseException("Unable to create default scaffolding.", e);
            }
        }

        #endregion
    }
}
