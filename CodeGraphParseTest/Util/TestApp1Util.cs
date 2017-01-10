using CodeGraphParseTest.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace CodeGraphParseTest.Util
{
    public class TestApp1Util
    {
        public static void executeFunction()
        {
            var descriptionValue = GetDisplayValue(CodeGraphEnum.ROW);
            if (!string.IsNullOrWhiteSpace(descriptionValue))
            {
                Debug.WriteLine("Description for the ROW value: " + descriptionValue);
            }
        }

        public static string GetDisplayValue(CodeGraphEnum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
            {
                return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Description);
            }
            
            if (descriptionAttributes == null)
            {
                return string.Empty;
            }
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Description : value.ToString();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }
    }
}
