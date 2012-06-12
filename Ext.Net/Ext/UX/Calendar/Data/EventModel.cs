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
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ext.Net
{
    
    /// <summary>
    /// This is the specification for calendar event data used by the CalendarPanel's underlying store.
    /// It can be overridden as necessary to customize the fields supported by events, 
    /// although the existing column names should not be altered. If your model fields are named differently
    /// you should update the mapping configs accordingly.
    /// The only required fields when creating a new event record instance are StartDate and
    /// EndDate.  All other fields are either optional are will be defaulted if blank.
    /// </summary>
    public partial class EventModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int? EventId 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int? CalendarId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual DateTime? StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual DateTime? EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Location
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Notes
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Url
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool? IsAllDay
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Reminder
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EventMappingsContractResolver : DefaultContractResolver
    {
        Dictionary<string, string> mappings = new Dictionary<string, string>(12);

        public EventMappingsContractResolver()
        {
            mappings["EventId"] = "id";
            mappings["CalendarId"] = "cid";
            mappings["Title"] = "title";
            mappings["StartDate"] = "start";
            mappings["EndDate"] = "end";
            mappings["Location"] = "loc";
            mappings["Notes"] = "notes";
            mappings["Url"] = "url";
            mappings["IsAllDay"] = "ad";
            mappings["Reminder"] = "rem";
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return this.mappings.ContainsKey(propertyName) ? this.mappings[propertyName] : propertyName;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class EventModelCollection : List<EventModel> 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Serialize(bool mapping)
        {
            return JSON.Serialize(this, mapping ? new EventMappingsContractResolver() : null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static EventModelCollection Deserialize(string json)
        {
            return EventModelCollection.Deserialize(json, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        public static EventModelCollection Deserialize(string json, bool mapping)
        {
            return JSON.Deserialize<EventModelCollection>(json, mapping ? new EventMappingsContractResolver() : null);
        }
    }
}