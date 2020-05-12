using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Twinvision.BolRetailerApi.Test
{
    public class CsvConverter
    {
        public static List<T> ConvertToObjectList<T>(string csvContent)
        {
            var objectList = new List<T>();
            var objectType = typeof(T);
            var propertyCount = objectType.GetProperties().Length;
            var propertyMapping = new List<PropertyInfo>();
            var byteArray = Encoding.UTF8.GetBytes(csvContent);
            var stream = new MemoryStream(byteArray);
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool firstCycle = true;
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    int fieldCount = 0;
                    var newObject = (T)Activator.CreateInstance(typeof(T));
                    foreach (var field in fields)
                    {
                        if (firstCycle)
                        {
                            var propertyInfo = objectType.GetProperty(field.First().ToString().ToUpper() + field.Substring(1));
                            if (propertyInfo == null)
                            {
                                throw new Exception($"CSV could not map to Object Type, {field} property not found.");
                            }
                            propertyMapping.Add(propertyInfo);
                            if(fieldCount == fields.Length - 1)
                            {
                                firstCycle = false;
                            }
                        }
                        else
                        {
                            if (fieldCount == 0)
                            {
                                newObject = (T)Activator.CreateInstance(typeof(T));
                            }
                            var propertyInfo = propertyMapping[fieldCount];
                            var propertyValue = Parse(propertyInfo.PropertyType, field);
                            propertyInfo.SetValue(newObject, propertyValue);
                            if (fieldCount == fields.Length - 1)
                            {
                                objectList.Add(newObject);
                            }
                        }
                        fieldCount++;
                    }
                }
            }
            return objectList;
        }

        private static object Parse(Type type, string str)
        {
            var parse = type.GetMethod("Parse", new[] { typeof(string) });
            if (parse == null) return str;
            return parse.Invoke(null, new object[] { str });
        }
    }

    public class CsvOffer
    {
        public Guid OfferId { get; set; }
        public string Ean { get; set; }
        public string ConditionName { get; set; }
        public string ConditionCategory { get; set; }
        public string ConditionComment { get; set; }
        public string BundlePricesPrice { get; set; }
        public string FulfilmentDeliveryCode { get; set; }
        public int StockAmount { get; set; }
        public bool OnHoldByRetailer { get; set; }
        public string FulfilmentType { get; set; }
        public string MutationDateTime { get; set; }
        public string ReferenceCode { get; set; }
    }

    //offerId,ean,conditionName,conditionCategory,conditionComment,bundlePricesPrice,fulfilmentDeliveryCode,stockAmount,onHoldByRetailer,fulfilmentType,mutationDateTime,referenceCode
}
