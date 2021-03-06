﻿// -----------------------------------------------------------------------
// <copyright file="MicroLiteReadOnlyController.cs" company="Project Contributors">
// Copyright Project Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Web;
using System.Web.Mvc;
using MicroLite.Infrastructure;

namespace MicroLite.Extensions.Mvc
{
    /// <summary>
    /// Provides access to a MicroLite IReadOnlySession in addition to the base ASP.NET MVC controller.
    /// </summary>
    public abstract class MicroLiteReadOnlyController : Controller, IHaveReadOnlySession
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MicroLiteReadOnlyController"/> class.
        /// </summary>
        /// <param name="session">The <see cref="IReadOnlySession"/> for the current HTTP request.</param>
        /// <remarks>
        /// This constructor allows for an inheriting class to easily inject an <see cref="IReadOnlySession"/> via an IOC container.
        /// </remarks>
        protected MicroLiteReadOnlyController(IReadOnlySession session)
            => Session = session ?? throw new ArgumentNullException(nameof(session));

        /// <summary>
        /// Gets the System.Web.HttpSessionStateBase object for the current HTTP request.
        /// </summary>
        /// <remarks>This property replaces the Controller.Session property so that we can use it for our ISession.</remarks>
        public HttpSessionStateBase HttpSession => base.Session;

        /// <summary>
        /// Gets the <see cref="IReadOnlySession"/> for the current HTTP request.
        /// </summary>
        public new IReadOnlySession Session { get; }
    }
}
