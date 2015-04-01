// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextProvider.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The injected context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Common;
using TickBox.Data.Context;

namespace TickBox.Data
{
    /// <summary>
    /// The injected context.
    /// </summary>
    public class ContextProvider : IContextProvider, IDisposable
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TickBoxEntities context;

        /// <summary>
        /// Initialises a new instance of the <see cref="ContextProvider"/> class.
        /// </summary>
        public ContextProvider()
        {
            this.context = new TickBoxEntities();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ContextProvider"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection to the data base.
        /// </param>
        public ContextProvider(DbConnection connection)
        {
            this.context = new TickBoxEntities();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ContextProvider"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ContextProvider(TickBoxEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <returns>
        /// The <see cref="TickBoxEntities"/>.
        /// </returns>
        public TickBoxEntities GetContext()
        {
            return this.context;
        }

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this.context == null)
            {
                return;
            }

            this.context.Dispose();
        }
    }
}
