﻿/* 
 * Copyright (c) 2020, Norsk Helsenett SF and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the MIT license
 * available at https://raw.githubusercontent.com/helsenorge/Helsenorge.Messaging/master/LICENSE
 */

using Helsenorge.Registries.Configuration;
using System;

namespace Helsenorge.Registries
{
    /// <summary>
    /// Information required when communicating with the collaboration protocol registry
    /// </summary>
    public class CollaborationProtocolRegistrySettings
    {
        /// <summary>
        /// The configuration containing WCF settings
        /// </summary>
        public WcfConfiguration WcfConfiguration { get; set; }

        /// <summary>
        /// The amount of time values should be cached
        /// </summary>
        public TimeSpan CachingInterval { get; set; } = new TimeSpan(1, 0, 0);

        /// <summary>
        /// Gets or sets the type of formatter to use when caching.
        /// </summary>
        public Utilities.CacheFormatterType CachingFormatter { get; set; } =
            Utilities.CacheFormatterType.BinaryFormatter;

        /// <summary>
        /// The HerId that belongs to me. In CPA operations, two communication parties may be returned, need to know which one is us
        /// </summary>
        public int MyHerId { get; set; }

        /// <summary>
        /// Use online certificate revocation list (CRL) check. Default true.
        /// </summary>
        public bool UseOnlineRevocationCheck { get; set; } = true;
    }
}
