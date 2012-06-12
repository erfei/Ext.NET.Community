/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/using System;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class CustomIdGenerator : ModelIdGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomIdGenerator() 
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        protected override string Type
        {
            get
            {
                return "default";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("isGenerator")]
        protected virtual bool IsGenerator
        {
            get
            {
                return true;
            }
        }

        private JFunction generate;
        /// <summary>
        /// Generates and returns the next id. This method must be implemented by the derived class.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual JFunction Generate
        {
            get
            {
                if (this.generate == null)
                {
                    this.generate = new JFunction();
                }

                return this.generate;
            }
        }
    }
}