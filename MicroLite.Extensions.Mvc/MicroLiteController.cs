﻿// -----------------------------------------------------------------------
// <copyright file="MicroLiteController.cs" company="MicroLite">
// Copyright 2012 - 2017 Project Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace MicroLite.Extensions.Mvc
{
    using System.Web;
    using System.Web.Mvc;
    using MicroLite.Infrastructure;

    /// <summary>
    /// Provides access to a MicroLite ISession in addition to the base ASP.NET MVC controller.
    /// </summary>
    public abstract class MicroLiteController : Controller, IHaveAsyncSession
    {
        private IAsyncSession session;

        /// <summary>
        /// Initialises a new instance of the MicroLiteController class.
        /// </summary>
        protected MicroLiteController()
            : this(null)
        {
        }

        /// <summary>
        /// Initialises a new instance of the MicroLiteController class with an ISession.
        /// </summary>
        /// <param name="session">The ISession for the current HTTP request.</param>
        /// <remarks>
        /// This constructor allows for an inheriting class to easily inject an ISession via an IOC container.
        /// </remarks>
        protected MicroLiteController(IAsyncSession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Gets the System.Web.HttpSessionStateBase object for the current HTTP request.
        /// </summary>
        /// <remarks>This property replaces the Controller.Session property so that we can use it for our ISession.</remarks>
        public HttpSessionStateBase HttpSession
        {
            get
            {
                return base.Session;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ISession"/> for the current HTTP request.
        /// </summary>
        public new IAsyncSession Session
        {
            get
            {
                return this.session;
            }

            set
            {
                this.session = value;
            }
        }
    }
}