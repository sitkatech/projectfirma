using NUnit.Framework;
using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    [TestFixture]
    public class DistanceCalculationSampleTest
    {
        [Test]
        public void SampleOfHowToUseArcGisSoapToDoDistanceCalculationTest()
        {
            // Sample of three APNs adjacent parcels to each other on shoreline at Zephyr Point allows comparing adjacent and different
            // apnNumber1 1318-09-810-001 <---> apnNumber2 1318-09-701-001 <---> apnNumber3 1318-09-701-002
            var shape1 = GeometrySerializer.DeserializeXmlToGeometry(Shape1Xml);
            var shape2 = GeometrySerializer.DeserializeXmlToGeometry(Shape2xml);
            var shape3 = GeometrySerializer.DeserializeXmlToGeometry(Shape3Xml);

            var spatialReference = GetSpatialReference();

            var geometryService = new GeometryServerPortClient();
            var linearUnitMiles = new LinearUnit { WKID = 9035, WKIDSpecified = true };

            var distance1 = geometryService.GetDistance(spatialReference, shape1, shape1, linearUnitMiles);
            Assert.That(distance1, Is.EqualTo(0), "Same shape - distance zero");

            var distance2 = geometryService.GetDistance(spatialReference, shape1, shape2, linearUnitMiles);
            Assert.That(distance2, Is.EqualTo(0), "Adjacent shapes - distance zero because the shapes are overlaping or share an edge");

            var distance3 = geometryService.GetDistance(spatialReference, shape1, shape3, linearUnitMiles);
            Assert.That(distance3, Is.EqualTo(0.25).Within(0.1), "These particular non-adjacent shapes are about 1/4 mile apart");
        }

        private static SpatialReference GetSpatialReference()
        {
            var mapservice = new MapServerPortClient();
            var mapname = mapservice.GetDefaultMapName();
            var mapinfo = mapservice.GetServerInfo(mapname);
            return mapinfo.SpatialReference;
        }

        private const string Shape1Xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
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

        private const string Shape2xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<PolygonN xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <HasID>false</HasID>
  <HasZ>false</HasZ>
  <HasM>false</HasM>
  <Extent xmlns:q1=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q1:EnvelopeN"">
    <XMin>763164.9868999999</XMin>
    <YMin>4321271.8054000009</YMin>
    <XMax>763643.45399999991</XMax>
    <YMax>4321687.0001</YMax>
  </Extent>
  <RingArray>
    <Ring>
      <PointArray>
        <Point xmlns:q2=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q2:PointN"">
          <X>763591.34700000007</X>
          <Y>4321675.0068999995</Y>
        </Point>
        <Point xmlns:q3=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q3:PointN"">
          <X>763598.44749999978</X>
          <Y>4321488.8993999995</Y>
        </Point>
        <Point xmlns:q4=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q4:PointN"">
          <X>763616.85869999975</X>
          <Y>4321489.4693</Y>
        </Point>
        <Point xmlns:q5=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q5:PointN"">
          <X>763643.45399999991</X>
          <Y>4321470.9611000009</Y>
        </Point>
        <Point xmlns:q6=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q6:PointN"">
          <X>763641.45029999968</X>
          <Y>4321468.9034</Y>
        </Point>
        <Point xmlns:q7=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q7:PointN"">
          <X>763639.48280000035</X>
          <Y>4321466.8092</Y>
        </Point>
        <Point xmlns:q8=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q8:PointN"">
          <X>763637.55229999963</X>
          <Y>4321464.6786</Y>
        </Point>
        <Point xmlns:q9=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q9:PointN"">
          <X>763635.65909999982</X>
          <Y>4321462.5166</Y>
        </Point>
        <Point xmlns:q10=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q10:PointN"">
          <X>763633.8041000003</X>
          <Y>4321460.3228999991</Y>
        </Point>
        <Point xmlns:q11=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q11:PointN"">
          <X>763631.9874</X>
          <Y>4321458.0978</Y>
        </Point>
        <Point xmlns:q12=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q12:PointN"">
          <X>763630.21019999962</X>
          <Y>4321455.8362000007</Y>
        </Point>
        <Point xmlns:q13=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q13:PointN"">
          <X>763628.47240000032</X>
          <Y>4321453.5481</Y>
        </Point>
        <Point xmlns:q14=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q14:PointN"">
          <X>763626.77489999961</X>
          <Y>4321451.2285999991</Y>
        </Point>
        <Point xmlns:q15=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q15:PointN"">
          <X>763625.11799999978</X>
          <Y>4321448.8824000005</Y>
        </Point>
        <Point xmlns:q16=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q16:PointN"">
          <X>763623.50250000041</X>
          <Y>4321446.5048999991</Y>
        </Point>
        <Point xmlns:q17=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q17:PointN"">
          <X>763621.9287</X>
          <Y>4321444.1006000005</Y>
        </Point>
        <Point xmlns:q18=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q18:PointN"">
          <X>763620.39709999971</X>
          <Y>4321441.6699</Y>
        </Point>
        <Point xmlns:q19=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q19:PointN"">
          <X>763618.90809999965</X>
          <Y>4321439.2125</Y>
        </Point>
        <Point xmlns:q20=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q20:PointN"">
          <X>763617.46229999978</X>
          <Y>4321436.7288000006</Y>
        </Point>
        <Point xmlns:q21=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q21:PointN"">
          <X>763616.06010000035</X>
          <Y>4321434.2184999995</Y>
        </Point>
        <Point xmlns:q22=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q22:PointN"">
          <X>763614.70179999992</X>
          <Y>4321431.6865</Y>
        </Point>
        <Point xmlns:q23=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q23:PointN"">
          <X>763613.3881000001</X>
          <Y>4321429.1280000005</Y>
        </Point>
        <Point xmlns:q24=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q24:PointN"">
          <X>763612.11890000012</X>
          <Y>4321426.5525</Y>
        </Point>
        <Point xmlns:q25=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q25:PointN"">
          <X>763610.89510000031</X>
          <Y>4321423.9507</Y>
        </Point>
        <Point xmlns:q26=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q26:PointN"">
          <X>763609.71669999976</X>
          <Y>4321421.332</Y>
        </Point>
        <Point xmlns:q27=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q27:PointN"">
          <X>763608.5844</X>
          <Y>4321418.6870000008</Y>
        </Point>
        <Point xmlns:q28=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q28:PointN"">
          <X>763607.49830000009</X>
          <Y>4321416.0298</Y>
        </Point>
        <Point xmlns:q29=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q29:PointN"">
          <X>763606.45870000031</X>
          <Y>4321413.3511</Y>
        </Point>
        <Point xmlns:q30=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q30:PointN"">
          <X>763605.46640000027</X>
          <Y>4321410.6508000009</Y>
        </Point>
        <Point xmlns:q31=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q31:PointN"">
          <X>763604.52089999989</X>
          <Y>4321407.9384</Y>
        </Point>
        <Point xmlns:q32=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q32:PointN"">
          <X>763603.62299999967</X>
          <Y>4321405.2093</Y>
        </Point>
        <Point xmlns:q33=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q33:PointN"">
          <X>763602.77290000021</X>
          <Y>4321402.4634000007</Y>
        </Point>
        <Point xmlns:q34=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q34:PointN"">
          <X>763601.97070000041</X>
          <Y>4321399.7056000009</Y>
        </Point>
        <Point xmlns:q35=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q35:PointN"">
          <X>763601.2171</X>
          <Y>4321396.9311</Y>
        </Point>
        <Point xmlns:q36=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q36:PointN"">
          <X>763600.51190000027</X>
          <Y>4321394.1446</Y>
        </Point>
        <Point xmlns:q37=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q37:PointN"">
          <X>763599.85539999977</X>
          <Y>4321391.3461000007</Y>
        </Point>
        <Point xmlns:q38=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q38:PointN"">
          <X>763599.24789999984</X>
          <Y>4321388.5357000008</Y>
        </Point>
        <Point xmlns:q39=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q39:PointN"">
          <X>763598.68939999957</X>
          <Y>4321385.7182</Y>
        </Point>
        <Point xmlns:q40=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q40:PointN"">
          <X>763598.18020000029</X>
          <Y>4321382.8888000008</Y>
        </Point>
        <Point xmlns:q41=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q41:PointN"">
          <X>763597.7204</X>
          <Y>4321380.0522000007</Y>
        </Point>
        <Point xmlns:q42=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q42:PointN"">
          <X>763597.3103</X>
          <Y>4321377.2085</Y>
        </Point>
        <Point xmlns:q43=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q43:PointN"">
          <X>763596.94969999976</X>
          <Y>4321374.3576</Y>
        </Point>
        <Point xmlns:q44=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q44:PointN"">
          <X>763596.63910000026</X>
          <Y>4321371.4996000007</Y>
        </Point>
        <Point xmlns:q45=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q45:PointN"">
          <X>763596.3783</X>
          <Y>4321368.6393</Y>
        </Point>
        <Point xmlns:q46=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q46:PointN"">
          <X>763596.16770000011</X>
          <Y>4321365.7718</Y>
        </Point>
        <Point xmlns:q47=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q47:PointN"">
          <X>763596.08739999961</X>
          <Y>4321364.4514000006</Y>
        </Point>
        <Point xmlns:q48=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q48:PointN"">
          <X>763595.69469999988</X>
          <Y>4321356.2756999992</Y>
        </Point>
        <Point xmlns:q49=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q49:PointN"">
          <X>763595.4450000003</X>
          <Y>4321348.0879</Y>
        </Point>
        <Point xmlns:q50=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q50:PointN"">
          <X>763595.33800000045</X>
          <Y>4321339.9023</Y>
        </Point>
        <Point xmlns:q51=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q51:PointN"">
          <X>763595.3739</X>
          <Y>4321331.7140999995</Y>
        </Point>
        <Point xmlns:q52=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q52:PointN"">
          <X>763595.55310000014</X>
          <Y>4321323.5232</Y>
        </Point>
        <Point xmlns:q53=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q53:PointN"">
          <X>763595.87469999958</X>
          <Y>4321315.3440000005</Y>
        </Point>
        <Point xmlns:q54=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q54:PointN"">
          <X>763596.33930000011</X>
          <Y>4321307.1670999993</Y>
        </Point>
        <Point xmlns:q55=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q55:PointN"">
          <X>763596.94639999978</X>
          <Y>4321299.0019000005</Y>
        </Point>
        <Point xmlns:q56=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q56:PointN"">
          <X>763597.69610000029</X>
          <Y>4321290.8434999995</Y>
        </Point>
        <Point xmlns:q57=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q57:PointN"">
          <X>763597.9467000002</X>
          <Y>4321288.4182999991</Y>
        </Point>
        <Point xmlns:q58=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q58:PointN"">
          <X>763584.88370000012</X>
          <Y>4321287.9030000009</Y>
        </Point>
        <Point xmlns:q59=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q59:PointN"">
          <X>763538.65799999982</X>
          <Y>4321286.0870999992</Y>
        </Point>
        <Point xmlns:q60=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q60:PointN"">
          <X>763499.60300000012</X>
          <Y>4321284.5478000008</Y>
        </Point>
        <Point xmlns:q61=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q61:PointN"">
          <X>763461.8531</X>
          <Y>4321283.0624</Y>
        </Point>
        <Point xmlns:q62=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q62:PointN"">
          <X>763431.53720000014</X>
          <Y>4321281.8714000005</Y>
        </Point>
        <Point xmlns:q63=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q63:PointN"">
          <X>763384.15940000024</X>
          <Y>4321280.009</Y>
        </Point>
        <Point xmlns:q64=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q64:PointN"">
          <X>763369.92179999966</X>
          <Y>4321279.4463</Y>
        </Point>
        <Point xmlns:q65=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q65:PointN"">
          <X>763336.7818</X>
          <Y>4321278.1417999994</Y>
        </Point>
        <Point xmlns:q66=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q66:PointN"">
          <X>763297.8311999999</X>
          <Y>4321276.6125000007</Y>
        </Point>
        <Point xmlns:q67=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q67:PointN"">
          <X>763271.5071</X>
          <Y>4321275.5724</Y>
        </Point>
        <Point xmlns:q68=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q68:PointN"">
          <X>763236.28830000013</X>
          <Y>4321274.1526999995</Y>
        </Point>
        <Point xmlns:q69=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q69:PointN"">
          <X>763228.70799999963</X>
          <Y>4321273.8512999993</Y>
        </Point>
        <Point xmlns:q70=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q70:PointN"">
          <X>763176.66870000027</X>
          <Y>4321271.8054000009</Y>
        </Point>
        <Point xmlns:q71=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q71:PointN"">
          <X>763166.14489999972</X>
          <Y>4321294.9865000006</Y>
        </Point>
        <Point xmlns:q72=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q72:PointN"">
          <X>763164.9868999999</X>
          <Y>4321318.8943000007</Y>
        </Point>
        <Point xmlns:q73=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q73:PointN"">
          <X>763171.25619999971</X>
          <Y>4321340.716</Y>
        </Point>
        <Point xmlns:q74=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q74:PointN"">
          <X>763177.68929999974</X>
          <Y>4321340.2653</Y>
        </Point>
        <Point xmlns:q75=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q75:PointN"">
          <X>763197.92040000018</X>
          <Y>4321351.1693999991</Y>
        </Point>
        <Point xmlns:q76=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q76:PointN"">
          <X>763218.95380000025</X>
          <Y>4321383.3244</Y>
        </Point>
        <Point xmlns:q77=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q77:PointN"">
          <X>763224.78610000014</X>
          <Y>4321382.6919</Y>
        </Point>
        <Point xmlns:q78=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q78:PointN"">
          <X>763227.99500000011</X>
          <Y>4321385.7477</Y>
        </Point>
        <Point xmlns:q79=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q79:PointN"">
          <X>763231.8348000003</X>
          <Y>4321382.1136000007</Y>
        </Point>
        <Point xmlns:q80=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q80:PointN"">
          <X>763234.2429</X>
          <Y>4321382.8411</Y>
        </Point>
        <Point xmlns:q81=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q81:PointN"">
          <X>763237.04449999984</X>
          <Y>4321388.0143</Y>
        </Point>
        <Point xmlns:q82=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q82:PointN"">
          <X>763248.04640000034</X>
          <Y>4321387.7854999993</Y>
        </Point>
        <Point xmlns:q83=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q83:PointN"">
          <X>763270.65309999976</X>
          <Y>4321393.7631</Y>
        </Point>
        <Point xmlns:q84=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q84:PointN"">
          <X>763277.53039999958</X>
          <Y>4321390.4339000005</Y>
        </Point>
        <Point xmlns:q85=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q85:PointN"">
          <X>763281.3794</X>
          <Y>4321392.9103999995</Y>
        </Point>
        <Point xmlns:q86=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q86:PointN"">
          <X>763286.48460000008</X>
          <Y>4321400.9429</Y>
        </Point>
        <Point xmlns:q87=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q87:PointN"">
          <X>763299.256</X>
          <Y>4321408.2744999994</Y>
        </Point>
        <Point xmlns:q88=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q88:PointN"">
          <X>763301.85400000028</X>
          <Y>4321414.5062000006</Y>
        </Point>
        <Point xmlns:q89=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q89:PointN"">
          <X>763316.75679999962</X>
          <Y>4321431.4097000007</Y>
        </Point>
        <Point xmlns:q90=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q90:PointN"">
          <X>763329.30769999977</X>
          <Y>4321443.3098000009</Y>
        </Point>
        <Point xmlns:q91=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q91:PointN"">
          <X>763332.9183</X>
          <Y>4321444.4010000005</Y>
        </Point>
        <Point xmlns:q92=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q92:PointN"">
          <X>763333.2324000001</X>
          <Y>4321450.5218</Y>
        </Point>
        <Point xmlns:q93=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q93:PointN"">
          <X>763341.05630000029</X>
          <Y>4321459.1443000007</Y>
        </Point>
        <Point xmlns:q94=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q94:PointN"">
          <X>763347.89360000007</X>
          <Y>4321469.2452000007</Y>
        </Point>
        <Point xmlns:q95=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q95:PointN"">
          <X>763362.59449999966</X>
          <Y>4321474.5336000007</Y>
        </Point>
        <Point xmlns:q96=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q96:PointN"">
          <X>763370.06209999975</X>
          <Y>4321477.9491000008</Y>
        </Point>
        <Point xmlns:q97=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q97:PointN"">
          <X>763381.97790000029</X>
          <Y>4321484.0229</Y>
        </Point>
        <Point xmlns:q98=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q98:PointN"">
          <X>763393.99299999978</X>
          <Y>4321494.3705</Y>
        </Point>
        <Point xmlns:q99=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q99:PointN"">
          <X>763401.73570000008</X>
          <Y>4321498.4099</Y>
        </Point>
        <Point xmlns:q100=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q100:PointN"">
          <X>763409.94440000039</X>
          <Y>4321499.1139</Y>
        </Point>
        <Point xmlns:q101=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q101:PointN"">
          <X>763416.17879999988</X>
          <Y>4321502.7748000007</Y>
        </Point>
        <Point xmlns:q102=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q102:PointN"">
          <X>763420.95849999972</X>
          <Y>4321511.2492999993</Y>
        </Point>
        <Point xmlns:q103=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q103:PointN"">
          <X>763446.04470000044</X>
          <Y>4321516.4318</Y>
        </Point>
        <Point xmlns:q104=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q104:PointN"">
          <X>763450.80489999987</X>
          <Y>4321512.6943999995</Y>
        </Point>
        <Point xmlns:q105=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q105:PointN"">
          <X>763459.8975</X>
          <Y>4321514.0518999994</Y>
        </Point>
        <Point xmlns:q106=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q106:PointN"">
          <X>763471.56350000016</X>
          <Y>4321525.2985</Y>
        </Point>
        <Point xmlns:q107=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q107:PointN"">
          <X>763479.12289999984</X>
          <Y>4321539.4030000009</Y>
        </Point>
        <Point xmlns:q108=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q108:PointN"">
          <X>763489.04270000011</X>
          <Y>4321558.3541</Y>
        </Point>
        <Point xmlns:q109=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q109:PointN"">
          <X>763489.07919999957</X>
          <Y>4321567.0561</Y>
        </Point>
        <Point xmlns:q110=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q110:PointN"">
          <X>763493.56869999971</X>
          <Y>4321575.2115</Y>
        </Point>
        <Point xmlns:q111=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q111:PointN"">
          <X>763492.21190000046</X>
          <Y>4321593.7674</Y>
        </Point>
        <Point xmlns:q112=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q112:PointN"">
          <X>763485.32380000036</X>
          <Y>4321609.9178</Y>
        </Point>
        <Point xmlns:q113=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q113:PointN"">
          <X>763482.3870000001</X>
          <Y>4321610.691</Y>
        </Point>
        <Point xmlns:q114=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q114:PointN"">
          <X>763483.60020000022</X>
          <Y>4321617.1607000008</Y>
        </Point>
        <Point xmlns:q115=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q115:PointN"">
          <X>763481.3256000001</X>
          <Y>4321623.1557</Y>
        </Point>
        <Point xmlns:q116=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q116:PointN"">
          <X>763486.14869999979</X>
          <Y>4321630.7164999992</Y>
        </Point>
        <Point xmlns:q117=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q117:PointN"">
          <X>763486.61529999971</X>
          <Y>4321636.8447999991</Y>
        </Point>
        <Point xmlns:q118=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q118:PointN"">
          <X>763482.53899999987</X>
          <Y>4321639.0889</Y>
        </Point>
        <Point xmlns:q119=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q119:PointN"">
          <X>763481.65969999973</X>
          <Y>4321641.4885000009</Y>
        </Point>
        <Point xmlns:q120=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q120:PointN"">
          <X>763483.5429999996</X>
          <Y>4321643.5643000007</Y>
        </Point>
        <Point xmlns:q121=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q121:PointN"">
          <X>763485.89879999962</X>
          <Y>4321645.3577</Y>
        </Point>
        <Point xmlns:q122=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q122:PointN"">
          <X>763484.80800000019</X>
          <Y>4321648.968</Y>
        </Point>
        <Point xmlns:q123=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q123:PointN"">
          <X>763488.98280000035</X>
          <Y>4321651.0024999995</Y>
        </Point>
        <Point xmlns:q124=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q124:PointN"">
          <X>763489.4446</X>
          <Y>4321654.0776</Y>
        </Point>
        <Point xmlns:q125=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q125:PointN"">
          <X>763493.63580000028</X>
          <Y>4321655.8076000009</Y>
        </Point>
        <Point xmlns:q126=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q126:PointN"">
          <X>763499.4309</X>
          <Y>4321662.1947000008</Y>
        </Point>
        <Point xmlns:q127=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q127:PointN"">
          <X>763506.72009999957</X>
          <Y>4321669.2601</Y>
        </Point>
        <Point xmlns:q128=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q128:PointN"">
          <X>763509.11110000033</X>
          <Y>4321670.2919999994</Y>
        </Point>
        <Point xmlns:q129=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q129:PointN"">
          <X>763529.27570000011</X>
          <Y>4321663.6395</Y>
        </Point>
        <Point xmlns:q130=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q130:PointN"">
          <X>763533.48550000042</X>
          <Y>4321658.6544</Y>
        </Point>
        <Point xmlns:q131=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q131:PointN"">
          <X>763537.66629999969</X>
          <Y>4321654.2784</Y>
        </Point>
        <Point xmlns:q132=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q132:PointN"">
          <X>763539.9254999999</X>
          <Y>4321658.0465999991</Y>
        </Point>
        <Point xmlns:q133=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q133:PointN"">
          <X>763544.8713999996</X>
          <Y>4321656.7605000008</Y>
        </Point>
        <Point xmlns:q134=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q134:PointN"">
          <X>763550.9046</X>
          <Y>4321658.2747000009</Y>
        </Point>
        <Point xmlns:q135=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q135:PointN"">
          <X>763581.33430000022</X>
          <Y>4321672.8749</Y>
        </Point>
        <Point xmlns:q136=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q136:PointN"">
          <X>763590.88939999975</X>
          <Y>4321687.0001</Y>
        </Point>
        <Point xmlns:q137=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q137:PointN"">
          <X>763591.34700000007</X>
          <Y>4321675.0068999995</Y>
        </Point>
      </PointArray>
    </Ring>
  </RingArray>
</PolygonN>";

        private const string Shape3Xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<PolygonN xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <HasID>false</HasID>
  <HasZ>false</HasZ>
  <HasM>false</HasM>
  <Extent xmlns:q1=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q1:EnvelopeN"">
    <XMin>763591.34700000007</XMin>
    <YMin>4321470.9611000009</YMin>
    <XMax>763719.11050000042</XMax>
    <YMax>4321675.0068999995</YMax>
  </Extent>
  <RingArray>
    <Ring>
      <PointArray>
        <Point xmlns:q2=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q2:PointN"">
          <X>763591.34700000007</X>
          <Y>4321675.0068999995</Y>
        </Point>
        <Point xmlns:q3=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q3:PointN"">
          <X>763713.37150000036</X>
          <Y>4321668.9569000006</Y>
        </Point>
        <Point xmlns:q4=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q4:PointN"">
          <X>763718.5429999996</X>
          <Y>4321530.1117</Y>
        </Point>
        <Point xmlns:q5=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q5:PointN"">
          <X>763719.11050000042</X>
          <Y>4321514.8752999995</Y>
        </Point>
        <Point xmlns:q6=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q6:PointN"">
          <X>763716.3547</X>
          <Y>4321514.1308999993</Y>
        </Point>
        <Point xmlns:q7=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q7:PointN"">
          <X>763713.6124</X>
          <Y>4321513.3395000007</Y>
        </Point>
        <Point xmlns:q8=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q8:PointN"">
          <X>763710.88449999969</X>
          <Y>4321512.4963000007</Y>
        </Point>
        <Point xmlns:q9=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q9:PointN"">
          <X>763708.17140000034</X>
          <Y>4321511.6108</Y>
        </Point>
        <Point xmlns:q10=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q10:PointN"">
          <X>763705.47439999972</X>
          <Y>4321510.6736999992</Y>
        </Point>
        <Point xmlns:q11=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q11:PointN"">
          <X>763702.79399999976</X>
          <Y>4321509.6943999995</Y>
        </Point>
        <Point xmlns:q12=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q12:PointN"">
          <X>763700.13119999971</X>
          <Y>4321508.6635</Y>
        </Point>
        <Point xmlns:q13=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q13:PointN"">
          <X>763697.48680000007</X>
          <Y>4321507.5907000005</Y>
        </Point>
        <Point xmlns:q14=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q14:PointN"">
          <X>763694.86170000024</X>
          <Y>4321506.4662</Y>
        </Point>
        <Point xmlns:q15=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q15:PointN"">
          <X>763692.25629999954</X>
          <Y>4321505.2999000009</Y>
        </Point>
        <Point xmlns:q16=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q16:PointN"">
          <X>763689.6716</X>
          <Y>4321504.0914999992</Y>
        </Point>
        <Point xmlns:q17=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q17:PointN"">
          <X>763687.10869999975</X>
          <Y>4321502.8317000009</Y>
        </Point>
        <Point xmlns:q18=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q18:PointN"">
          <X>763684.5680999998</X>
          <Y>4321501.5302000009</Y>
        </Point>
        <Point xmlns:q19=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q19:PointN"">
          <X>763682.0504999999</X>
          <Y>4321500.1866999995</Y>
        </Point>
        <Point xmlns:q20=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q20:PointN"">
          <X>763679.55680000037</X>
          <Y>4321498.7968000006</Y>
        </Point>
        <Point xmlns:q21=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q21:PointN"">
          <X>763677.0876000002</X>
          <Y>4321497.3651</Y>
        </Point>
        <Point xmlns:q22=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q22:PointN"">
          <X>763674.64400000032</X>
          <Y>4321495.887</Y>
        </Point>
        <Point xmlns:q23=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q23:PointN"">
          <X>763672.2264</X>
          <Y>4321494.3719999995</Y>
        </Point>
        <Point xmlns:q24=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q24:PointN"">
          <X>763669.83579999954</X>
          <Y>4321492.8105999995</Y>
        </Point>
        <Point xmlns:q25=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q25:PointN"">
          <X>763667.47269999981</X>
          <Y>4321491.2075999994</Y>
        </Point>
        <Point xmlns:q26=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q26:PointN"">
          <X>763665.13769999985</X>
          <Y>4321489.5678</Y>
        </Point>
        <Point xmlns:q27=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q27:PointN"">
          <X>763662.83189999964</X>
          <Y>4321487.8863999993</Y>
        </Point>
        <Point xmlns:q28=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q28:PointN"">
          <X>763660.55580000021</X>
          <Y>4321486.1636999995</Y>
        </Point>
        <Point xmlns:q29=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q29:PointN"">
          <X>763658.31010000035</X>
          <Y>4321484.3994999994</Y>
        </Point>
        <Point xmlns:q30=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q30:PointN"">
          <X>763656.09549999982</X>
          <Y>4321482.5985</Y>
        </Point>
        <Point xmlns:q31=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q31:PointN"">
          <X>763653.91260000039</X>
          <Y>4321480.7611</Y>
        </Point>
        <Point xmlns:q32=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q32:PointN"">
          <X>763651.76240000036</X>
          <Y>4321478.8822000008</Y>
        </Point>
        <Point xmlns:q33=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q33:PointN"">
          <X>763649.64510000031</X>
          <Y>4321476.9668000005</Y>
        </Point>
        <Point xmlns:q34=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q34:PointN"">
          <X>763647.56170000043</X>
          <Y>4321475.0147999991</Y>
        </Point>
        <Point xmlns:q35=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q35:PointN"">
          <X>763645.51240000036</X>
          <Y>4321473.0263</Y>
        </Point>
        <Point xmlns:q36=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q36:PointN"">
          <X>763643.49810000043</X>
          <Y>4321471.0062000006</Y>
        </Point>
        <Point xmlns:q37=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q37:PointN"">
          <X>763643.45399999991</X>
          <Y>4321470.9611000009</Y>
        </Point>
        <Point xmlns:q38=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q38:PointN"">
          <X>763616.85869999975</X>
          <Y>4321489.4693</Y>
        </Point>
        <Point xmlns:q39=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q39:PointN"">
          <X>763598.44749999978</X>
          <Y>4321488.8993999995</Y>
        </Point>
        <Point xmlns:q40=""http://www.esri.com/schemas/ArcGIS/10.1"" xsi:type=""q40:PointN"">
          <X>763591.34700000007</X>
          <Y>4321675.0068999995</Y>
        </Point>
      </PointArray>
    </Ring>
  </RingArray>
</PolygonN>";
    }
}
