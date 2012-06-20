﻿// -----------------------------------------------------------------------
// <copyright file="ConfigurationExtensions.cs" company="MicroLite">
// Copyright 2012 Trevor Pilley
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace MicroLite.Configuration
{
    using MicroLite.Extensions.Mvc;
    using MicroLite.Logging;

    /// <summary>
    /// Extensions for the MicroLite configuration.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Configures the MicroLite ORM Framework to use log4net as the logging framework.
        /// </summary>
        /// <param name="configureExtensions">The interface to configure extensions.</param>
        /// <returns>The configure extensions.</returns>
        public static IConfigureExtensions WithMvc(this IConfigureExtensions configureExtensions)
        {
            MicroLiteSessionAttribute.SessionFactories = Configure.SessionFactories;

            return configureExtensions;
        }
    }
}