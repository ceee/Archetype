﻿using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;

namespace Archetype.Umbraco.Models
{
    public class Fieldset
    {
        public string Alias { get; set; }

		public IEnumerable<Property> Properties;

        public Fieldset()
        {
            Properties = new List<Property>();
        }

		#region Helper Methods

		public string GetValue(string propertyAlias)
        {
            return GetValue<string>(propertyAlias);
        }

        public T GetValue<T>(string propertyAlias)
        {
            var property = GetProperty(propertyAlias);

			if (property == null || string.IsNullOrEmpty(property.Value.ToString()))
				return default(T);

	        return property.GetValue<T>();
        }

        private Property GetProperty(string propertyAlias)
        {
            return Properties.FirstOrDefault(p => p.Alias.InvariantEquals(propertyAlias));
		}

		#endregion

    }
}
