/*
   Copyright 2011 - 2016 Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Xml;
using System.Xml.Serialization;
using Redmine.Net.Api.Internals;

namespace Redmine.Net.Api.Types
{
    /// <summary>
    /// Availability 2.2
    /// </summary>
    [XmlRoot(RedmineKeys.TIME_ENTRY_ACTIVITY)]
    public class TimeEntryActivity : IdentifiableName, IEquatable<TimeEntryActivity>
    {
        [XmlElement(RedmineKeys.IS_DEFAULT)]
        public bool IsDefault { get; set; }

        #region Implementation of IXmlSerializable

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
        {
            reader.Read();
            while (!reader.EOF)
            {
                if (reader.IsEmptyElement && !reader.HasAttributes)
                {
                    reader.Read();
                    continue;
                }

                switch (reader.Name)
                {
                    case RedmineKeys.ID: Id = reader.ReadElementContentAsInt(); break;

                    case RedmineKeys.NAME: Name = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.IS_DEFAULT: IsDefault = reader.ReadElementContentAsBoolean(); break;

                    default: reader.Read(); break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer) { }

        #endregion

        #region Implementation of IEquatable<TimeEntryActivity>

        public bool Equals(TimeEntryActivity other)
        {
            if (other == null) return false;

            return Id == other.Id && Name == other.Name && IsDefault == other.IsDefault;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as TimeEntryActivity);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = Utils.GetHashCode(Id, hashCode);
                hashCode = Utils.GetHashCode(Name, hashCode);
                hashCode = Utils.GetHashCode(IsDefault, hashCode);
                return hashCode;
            }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("[TimeEntryActivity: Id={0}, Name={1}, IsDefault={2}]", Id, Name, IsDefault);
        }
    }
}