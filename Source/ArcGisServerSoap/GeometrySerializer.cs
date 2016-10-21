using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    public class GeometrySerializer
    {
        public static string SerializeGeometryToXml(Geometry geometry)
        {
            return SerializeObject(geometry);
        }

        public static Geometry DeserializeXmlToGeometry(string geometryXml)
        {
            return DeserializeObject<Geometry>(geometryXml);
        }

        internal static string SerializeObject<T>(T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        private static T DeserializeObject<T>(string xmlString)
        {
            T result;
            var concreteType = CalculateConcreteTypeForXmlSerialization(typeof(T), xmlString);
            var ser = new XmlSerializer(concreteType);
            using (TextReader tr = new StringReader(xmlString))
            {
                result = (T) ser.Deserialize(tr);
            }
            return result;
        }

        private static T DeserializeFromXmlStringUsingFirstElementAsRoot<T>(string xmlString) where T : class
        {
            var firstXmlElement = FirstXmlElementName(xmlString);
            var ser = new XmlSerializer(typeof(T), new XmlRootAttribute(firstXmlElement));
            using (var sr = new StringReader(xmlString))
            {
                return (T) ser.Deserialize(sr);
            }
        }

        internal static Type CalculateConcreteTypeForXmlSerialization(Type type, string xmlString)
        {
            var firstElementName = FirstXmlElementName(xmlString);
            return type.Name == firstElementName ? type : AllSubclassesForBaseTypeInBaseTypeAssembly(type).Single(t => t.Name == firstElementName);
        }

        internal static IEnumerable<Type> AllSubclassesForBaseTypeInBaseTypeAssembly(Type baseType)
        {
            var assembly = baseType.Assembly;
            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }

        internal static string FirstXmlElementName(string xmlString)
        {
            if (xmlString == null)
            {
                throw new ArgumentNullException("xmlString");
            }

            if (String.IsNullOrWhiteSpace(xmlString))
            {
                throw new ArgumentException("Xml string is invalid, blank or only whitespace");
            }

            using (var stringReader = new StringReader(xmlString))
            {
                using (var reader = XmlReader.Create(stringReader))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            return reader.Name;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Could not find element in entire document: {0}", xmlString));
        }
    }
}