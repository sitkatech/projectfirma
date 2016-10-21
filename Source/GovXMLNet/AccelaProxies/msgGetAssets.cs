using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetAssets">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
          <xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
          <xsd:element ref="ReturnElements" minOccurs="0"/>
          <xsd:choice maxOccurs="unbounded">
            <xsd:group ref="AssetsSearchCollectionSelect"/>
          </xsd:choice>
          <xsd:element name="GISObjects" type="GISObjects" minOccurs="0"/>
          <xsd:element name ="recordStatus" type="xsd:string" minOccurs="0"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class msgGetAssets : clsOperationRequest
    {
        // Members
        private queryLogicEnum? _collectionsLevelQueryLogic = queryLogicEnum.OR;
        public queryLogicEnum? collectionsLevelQueryLogic
        {
            get
            {
                if (_collectionsLevelQueryLogic.HasValue)
                {
                    return _collectionsLevelQueryLogic.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _collectionsLevelQueryLogic = value; }
        }
        public bool collectionsLevelQueryLogicSpecified
        {
            get { return _collectionsLevelQueryLogic != null; }
        }

        private queryLogicEnum? _collectionLevelQueryLogic = queryLogicEnum.OR;
        public queryLogicEnum? collectionLevelQueryLogic
        {
            get
            {
                if (_collectionLevelQueryLogic.HasValue)
                {
                    return _collectionLevelQueryLogic.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _collectionLevelQueryLogic = value; }
        }
        public bool collectionLevelQueryLogicSpecified
        {
            get { return _collectionLevelQueryLogic != null; }
        }

        public undReturnElements ReturnElements { get; set; }

        // Start Choice
        // Start group AssetsSearchCollectionSelect
        private clsAssetIds _AssetIds = null;
        public clsAssetIds AssetIds
        {
            get { return _AssetIds; }
            set
            {
                _AssetIds = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scAssetIds);
            }
        }

        private clsStatus _Status = null;
        public clsStatus Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scStatus);
            }
        }

        private clsAssetTypes _AssetTypes = null;
        public clsAssetTypes AssetTypes
        {
            get { return _AssetTypes; }
            set
            {
                _AssetTypes = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scAssetTypes);
            }
        }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scDescription);
            }
        }

        [XmlIgnore]
        public DateTime? DateOfService { get; set; }
        [XmlElement("DateOfService")]
        public string DateOfServiceString
        {
            get
            {
                if (DateOfService.HasValue)
                {
                    return DateOfService.Value.ToString(Constants.cDateFormat); ;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    DateOfService = td;
                }
                else
                {
                    DateOfService = null;
                }
            }
        }
        public bool DateOfServiceStringSpecified
        {
            get { return DateOfService != null; }
        }

        private clsDateRanges _StatusDates = null;
        public clsDateRanges StatusDates
        {
            get { return _StatusDates; }
            set
            {
                _StatusDates = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scStatusDates);
            }
        }

        private clsValueRanges _CurrentValue = null;
        public clsValueRanges CurrentValue
        {
            get { return _CurrentValue; }
            set
            {
                _CurrentValue = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scCurrentValue);
            }
        }

        private string _Comments = null;
        public string Comments
        {
            get { return _Comments; }
            set
            {
                _Comments = value;
                ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect.scComments);
            }
        }

        // End group AssetsSearchCollectionSelect
        // End Choice

        public clsGISObjects GISObjects;

        private string mRecordStatus = null;
        public string recordStatus
        {
            get { return mRecordStatus; }
            set { mRecordStatus = value; }
        }

        // Constructors
        public msgGetAssets()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceAssetsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scAssetIds)
            {
                _AssetIds = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scStatus)
            {
                _Status = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scAssetTypes)
            {
                _AssetTypes = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scDescription)
            {
                _Description = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scDateOfService)
            {
                DateOfService = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scStatusDates)
            {
                _StatusDates = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scCurrentValue)
            {
                _CurrentValue = null;
            }
            if (pSelectedChoice != eChoiceAssetsSearchCollectionSelect.scComments)
            {
                _Comments = null;
            }

        }
    }
}
