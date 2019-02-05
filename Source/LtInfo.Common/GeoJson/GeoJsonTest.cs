/*-----------------------------------------------------------------------
<copyright file="GeoJsonTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace LtInfo.Common.GeoJson
{
    [TestFixture]
    public class GeoJsonTest
    {        
        private List<TestGeospatialObject> _testGeospatialObjects;

        private class TestGeospatialObject
        {
            public TestGeospatialObject(int id, string name, string geometry)
            {
                ID = id;
                Name = name;
                Geometry = geometry;
            }

            public int ID { get; private set; }
            public string Name { get; private set; }
            public string Geometry { get; private set; }
        }

        [SetUp]
        public void Init()
        {
            _testGeospatialObjects = new List<TestGeospatialObject>
            {
                new TestGeospatialObject(1, "Test Point", "POINT (30 10)"),
                new TestGeospatialObject(2, "Test MultiPoint", "MULTIPOINT ((10 40), (40 30), (20 20), (30 10))"),
                new TestGeospatialObject(3, "Test Polygon", "POLYGON ((30 10, 10 20, 20 40, 40 40, 30 10))"),
                new TestGeospatialObject(4, "Test MultiPolygon", "MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)), ((20 35, 10 30, 10 10, 30 5, 45 20, 20 35), (30 20, 20 15, 20 25, 30 20)))"),
                new TestGeospatialObject(5, "Test LineString", "LINESTRING (30 10, 10 30, 40 40)"),
                new TestGeospatialObject(6, "Test MultiLineString", "MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")
            };
        }

        private FeatureCollection GetTestFeatureCollection()
        {
            var fc = new FeatureCollection();

            _testGeospatialObjects.ForEach(c =>
            {
                var geom = DbGeometry.FromText(c.Geometry);
                var f = DbGeometryToGeoJsonHelper.FromDbGeometry(geom);
                f.Properties.Add("Name", c.Name);
                fc.Features.Add(f);
            });
            return fc;
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanSerializeAFeatureCollectionTest()
        {
            var fc = GetTestFeatureCollection();
            var json = JsonConvert.SerializeObject(fc, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            Approvals.Verify(json);
        }

        [Test]
        public void CanSerializeAFeatureCollectionAndEnsureItIsValidTest()
        {
            var fc = GetTestFeatureCollection();
            var json = JsonConvert.SerializeObject(fc, Formatting.Indented,
    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            Assert.IsNotNull(json);
            Trace.WriteLine("You can download spatial maps via http://www.naturalearthdata.com/" + "\r\n" + "\r\n");
            Trace.WriteLine(json);

            var buffer = Encoding.UTF8.GetBytes(json);
            var webReq = (HttpWebRequest) WebRequest.Create("http://geojsonlint.com/validate");

            webReq.Method = "POST";
            webReq.ContentLength = buffer.Length;
            webReq.ContentType = "application/x-www-form-urlencoded";

            var reqStream = webReq.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

            var webRes = webReq.GetResponse();
            var resStream = webRes.GetResponseStream();
            // ReSharper disable once AssignNullToNotNullAttribute
            var resReader = new StreamReader(resStream);
            var resObj = JsonConvert.DeserializeObject<GeoJSONLintResult>(resReader.ReadToEnd());

            Assert.AreEqual(resObj.status, "ok");
        }

        protected class GeoJSONLintResult
        {
            // ReSharper disable once InconsistentNaming
            public string status { get; set; }
            // ReSharper disable once InconsistentNaming
            public string message { get; set; }
        }
    }
}
