using System;
using System.Linq;
using LtInfo.Common;
using NUnit.Framework;
using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    [TestFixture]
    public class ArcGisManagerTest
    {
        [Test]
        public void CanGetAllTownCenters()
        {
            // Act
            // ---

            var tcs = ArcGisManager.GetAllArcTownCenters();
            Assert.That(tcs.Count, Is.GreaterThan(0), "Should get some Town Center records");

            // Assert
            // ------

            var emptyNames = tcs.Select(x => x.Name).Where(string.IsNullOrWhiteSpace).ToList();
            Assert.That(emptyNames, Is.Empty, "All names should be present");

            var emptyDescriptions = tcs.Select(x => x.Description).Where(string.IsNullOrWhiteSpace).ToList();
            Assert.That(emptyDescriptions, Is.Empty, "All descriptions should be present");

            var nullFeatures = tcs.Select(x => x.TownCenterFeature).Where(x => x == null).ToList();
            Assert.That(nullFeatures, Is.Empty, "All geometries should be present");

            var distinctCount = tcs.GroupBy(x => new Tuple<string, string>(x.Name, x.Description)).Count();
            Assert.That(distinctCount, Is.EqualTo(tcs.Count), "Should be unique by name and description");
        }

        [Test]
        public void GivenValidApnCanFindIt()
        {
            AssertCustom.IgnoreUntil(DateTime.Parse("11/1/2016 10:00 AM"), "Ignoring while we sort out with Amy. The REST url still works, but the non-REST version returns Access Denied.");
            ArcParcel arcParcel;
            Assert.That(ArcGisManager.TryGetArcParcelByApn("1318-09-701-001", out arcParcel), Is.True);
            Assert.That(arcParcel, Is.Not.Null, "Should have found this parcel");
            Assert.That(arcParcel.ParcelFeature, Is.Not.Null, "This particular parcel should have a feature");
        }

        [Test]
        public void GivenNonExistantApnCantFind()
        {
            AssertCustom.IgnoreUntil(DateTime.Parse("11/1/2016 10:00 AM"), "Ignoring while we sort out with Amy. The REST url still works, but the non-REST version returns Access Denied.");
            ArcParcel arcParcel;
            Assert.That(ArcGisManager.TryGetArcParcelByApn("ApnThatIsDefinitelyNotThere", out arcParcel), Is.False);
            Assert.That(arcParcel, Is.Null, "Should have null object");
        }

        [Test]
        public void CanFindDistance()
        {
            var geometry1 = new PointN { X = 0, Y = 0 };
            var geometry2 = new PointN { X = 0, Y = 1609.344 };
            Assert.That(ArcGisManager.GetDistanceInMilesBetweenTwoGeometries(geometry2, geometry2), Is.EqualTo(0), "Same geom should get zero distance");
            Assert.That(ArcGisManager.GetDistanceInMilesBetweenTwoGeometries(geometry1, geometry2), Is.EqualTo(1).Within(0.1), "Should be about one mile (units of meters)");
        }
    }
}