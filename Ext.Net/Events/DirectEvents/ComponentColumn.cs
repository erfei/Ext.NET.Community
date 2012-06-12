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
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ComponentColumnDirectEvents : ColumnDirectEvents
    {
        public ComponentColumnDirectEvents() { }

        public ComponentColumnDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent pin;

        /// <summary>
        /// Fires when a over component is pinned
        /// Parameters:
        ///    - item
        ///         Current column
        ///    - cmp
        ///         Over component 
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cmp")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("pin", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a over component is pinned")]
        public virtual ComponentDirectEvent Pin
        {
            get
            {
                return this.pin ?? (this.pin = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent unpin;

        /// <summary>
        /// Fires when a over component is unpinned
        /// Parameters:
        ///    - item
        ///         Current column
        ///    - cmp
        ///         Over component 
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cmp")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("unpin", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a over component is unpinned")]
        public virtual ComponentDirectEvent Unpin
        {
            get
            {
                return this.unpin ?? (this.unpin = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent bind;

        /// <summary>
        /// Fires when a component is bound to a record. Return false to cancel component showing for this record
        /// Parameters:
        ///    - item
        ///         Current column
        ///    - cmp
        ///         Component 
        ///    - record
        ///    - rowIndex
        ///    - grid
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cmp")]
        [ListenerArgument(2, "record")]
        [ListenerArgument(3, "rowIndex")]
        [ListenerArgument(4, "grid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bind", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a component is bound to a record. Return false to cancel component showing for this record")]
        public virtual ComponentDirectEvent Bind
        {
            get
            {
                return this.bind ?? (this.bind = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent unbind;

        /// <summary>
        /// Fires when a component is unbound from a record.
        /// Parameters:
        ///    - item
        ///         Current column
        ///    - cmp
        ///         Component 
        ///    - record
        ///    - rowIndex
        ///    - grid
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cmp")]
        [ListenerArgument(2, "record")]
        [ListenerArgument(3, "rowIndex")]
        [ListenerArgument(4, "grid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("unbind", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a component is unbound from a record.")]
        public virtual ComponentDirectEvent Unbind
        {
            get
            {
                return this.unbind ?? (this.unbind = new ComponentDirectEvent(this));
            }
        }
    }
}
