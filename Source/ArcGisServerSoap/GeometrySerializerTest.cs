using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using NUnit.Framework;
using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    [TestFixture]
    public class GeometrySerializerTest
    {
        private readonly PointN _sample2PointN = new PointN {X = 1.251, Y = 2.231};
        private const string Sample2PointNXml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<PointN xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <X>1.251</X>
  <Y>2.231</Y>
</PointN>";

        private readonly Line _sample4Line = new Line {FromPoint = new PointN {X = 1.344, Y = 2.442}, ToPoint = new PointN {X = 2.344, Y = 3.442}};
        private const string Sample4Line = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Line xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <FromPoint xmlns:q1=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q1:PointN"">
    <X>1.344</X>
    <Y>2.442</Y>
  </FromPoint>
  <ToPoint xmlns:q2=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q2:PointN"">
    <X>2.344</X>
    <Y>3.442</Y>
  </ToPoint>
</Line>";

        private readonly EnvelopeN _sample3EnvelopeN = new EnvelopeN {XMin = 1234, YMin = 12345, XMax = 1235, YMax = 12346};
        private const string Sample3EnvelopeNXml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<EnvelopeN xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <XMin>1234</XMin>
  <YMin>12345</YMin>
  <XMax>1235</XMax>
  <YMax>12346</YMax>
</EnvelopeN>";

        private readonly PolygonN _sample1PolygonN = new PolygonN
        {
            HasID = false,
            HasZ = false,
            HasM = false,
            Extent = new EnvelopeN {XMin = 763175.8344, YMin = 4321238.9635000005, XMax = 763237.5560999997, YMax = 4321273.8512999993},
            RingArray =
                new[]
                {
                    new Ring
                    {
                        PointArray =
                            new Point[]
                            {
                                new PointN {X = 763228.70799999963, Y = 4321273.8512999993}, new PointN {X = 763237.5560999997, Y = 4321262.8285000008},
                                new PointN {X = 763193.14670000039, Y = 4321238.9635000005}, new PointN {X = 763175.8344, Y = 4321254.4119000006},
                                new PointN {X = 763176.66870000027, Y = 4321271.8054000009}, new PointN {X = 763228.70799999963, Y = 4321273.8512999993}
                            }
                    }
                }
        };

        private const string Sample1PolygonNXml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<PolygonN xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <HasID>false</HasID>
  <HasZ>false</HasZ>
  <HasM>false</HasM>
  <Extent xmlns:q1=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q1:EnvelopeN"">
    <XMin>763175.8344</XMin>
    <YMin>4321238.9635000005</YMin>
    <XMax>763237.5560999997</XMax>
    <YMax>4321273.8512999993</YMax>
  </Extent>
  <RingArray>
    <Ring>
      <PointArray>
        <Point xmlns:q2=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q2:PointN"">
          <X>763228.70799999963</X>
          <Y>4321273.8512999993</Y>
        </Point>
        <Point xmlns:q3=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q3:PointN"">
          <X>763237.5560999997</X>
          <Y>4321262.8285000008</Y>
        </Point>
        <Point xmlns:q4=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q4:PointN"">
          <X>763193.14670000039</X>
          <Y>4321238.9635000005</Y>
        </Point>
        <Point xmlns:q5=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q5:PointN"">
          <X>763175.8344</X>
          <Y>4321254.4119000006</Y>
        </Point>
        <Point xmlns:q6=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q6:PointN"">
          <X>763176.66870000027</X>
          <Y>4321271.8054000009</Y>
        </Point>
        <Point xmlns:q7=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q7:PointN"">
          <X>763228.70799999963</X>
          <Y>4321273.8512999993</Y>
        </Point>
      </PointArray>
    </Ring>
  </RingArray>
</PolygonN>";

        [Test]
        public void CanSerialize()
        {
            Assert.That(GeometrySerializer.SerializeGeometryToXml(_sample1PolygonN), Is.EqualTo(Sample1PolygonNXml));
            Assert.That(GeometrySerializer.SerializeGeometryToXml(_sample2PointN), Is.EqualTo(Sample2PointNXml));
            Assert.That(GeometrySerializer.SerializeGeometryToXml(_sample3EnvelopeN), Is.EqualTo(Sample3EnvelopeNXml));
            Assert.That(GeometrySerializer.SerializeGeometryToXml(_sample4Line), Is.EqualTo(Sample4Line));
        }

        [Test]
        public void CanDeserialize()
        {
            AreEqualByJson(GeometrySerializer.DeserializeXmlToGeometry(Sample1PolygonNXml), _sample1PolygonN);
            AreEqualByJson(GeometrySerializer.DeserializeXmlToGeometry(Sample2PointNXml), _sample2PointN);
            AreEqualByJson(GeometrySerializer.DeserializeXmlToGeometry(Sample3EnvelopeNXml), _sample3EnvelopeN);
            AreEqualByJson(GeometrySerializer.DeserializeXmlToGeometry(Sample4Line), _sample4Line);
        }

        private static void AreEqualByJson(object expected, object actual)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            var expectedJson = javaScriptSerializer.Serialize(expected);
            var actualJson = javaScriptSerializer.Serialize(actual);
            Assert.AreEqual(expectedJson,
                            actualJson,
                            String.Format("Object properties should be the same but were not for object type {0} and type {1}", expected.GetType().Name, actual.GetType().Name));
        }

        [Test]
        public void CanFindFirstXmlElementName()
        {
            Assert.That(GeometrySerializer.FirstXmlElementName("<MyFirstElement><MySecondElement></MySecondElement></MyFirstElement>"), Is.EqualTo("MyFirstElement"));
            Assert.That(GeometrySerializer.FirstXmlElementName(Sample1PolygonNXml), Is.EqualTo("PolygonN"));
            Assert.That(GeometrySerializer.FirstXmlElementName(Sample2PointNXml), Is.EqualTo("PointN"));

            Assert.Catch(() => GeometrySerializer.FirstXmlElementName(null), "null should not work");
            Assert.Catch(() => GeometrySerializer.FirstXmlElementName(String.Empty), "empty string should not work");
            Assert.Catch(() => GeometrySerializer.FirstXmlElementName("Some Bad xml"), "bad xml should not work");
            Assert.Catch(() => GeometrySerializer.FirstXmlElementName("<<&><><$bad"), "bad xml should not work");
        }

        [Test]
        public void CanFindAllInheritedTypes()
        {
            var inheritedTypes = GeometrySerializer.AllSubclassesForBaseTypeInBaseTypeAssembly(typeof(Geometry)).Select(x => x.Name).ToList();
            inheritedTypes.Sort();
            Trace.WriteLine("\"" + String.Join("\", \"", inheritedTypes) + "\"");
            var expected = new List<string>
            {
                "BezierCurve",
                "CircularArc",
                "Curve",
                "EllipticArc",
                "Envelope",
                "EnvelopeB",
                "EnvelopeN",
                "Line",
                "MultiPatch",
                "MultiPatchB",
                "MultiPatchN",
                "Multipoint",
                "MultipointB",
                "MultipointN",
                "Path",
                "Point",
                "PointB",
                "PointN",
                "Polycurve",
                "Polygon",
                "PolygonB",
                "PolygonN",
                "Polyline",
                "PolylineB",
                "PolylineN",
                "Ring",
                "Segment",
                "TriangleFan",
                "Triangles",
                "TriangleStrip"
            };
            Assert.That(inheritedTypes, Is.EquivalentTo(expected));
        }

        [Test]
        public void CanCalculateConcreteType()
        {
            var type1 = GeometrySerializer.CalculateConcreteTypeForXmlSerialization(typeof(Geometry), "<Geometry></Geometry>");
            Assert.That(type1, Is.EqualTo(typeof(Geometry)));

            var type2 = GeometrySerializer.CalculateConcreteTypeForXmlSerialization(typeof(Geometry), Sample2PointNXml);
            Assert.That(type2, Is.EqualTo(typeof(PointN)));
        }
    }
}