using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Payment">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="amount" type="monetaryMeasure" form="qualified"/>
          <xsd:element name="currency" type="ifc:CurrencyEnum" form="qualified" minOccurs="0"/>
          <xsd:element name="method" type="paymentMethodEnum" form="qualified"/>
          <xsd:element name="transactionAuthorizationCode" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="transactionReferenceCode" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="transactionVendor" type="paymentTransactionVendorEnum" form="qualified" minOccurs="0"/>
          <xsd:choice minOccurs="0">
            <xsd:group ref="PaymentTypeSelect"/>
          </xsd:choice>
          <xsd:element ref="Date" minOccurs="0"/>
          <xsd:element ref="Time" minOccurs="0"/>
          <xsd:element name="Text" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="InvoiceIds" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
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
    public class clsPayment : clsAttachment
    {
        enum eChoicePayment
        {
            scACH,
            scCard,
            scCheck
        }

        // Members
        private decimal _amount = 0;
        public decimal amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private CurrencyEnum? _currency = null;
        public CurrencyEnum? currency
        {
            get
            {
                if (_currency.HasValue)
                {
                    return _currency.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _currency = value; }
        }
        public bool currencySpecified
        {
            get { return _currency != null; }
        }

        private paymentMethodEnum _method;
        public paymentMethodEnum method
        {
            get { return _method; }
            set { _method = value; }
        }

        private string _transactionAuthorizationCode = null;
        public string transactionAuthorizationCode
        {
            get { return _transactionAuthorizationCode; }
            set { _transactionAuthorizationCode = value; }
        }

        private string _transactionReferenceCode = null;
        public string transactionReferenceCode
        {
            get { return _transactionReferenceCode; }
            set { _transactionReferenceCode = value; }
        }

        private paymentTransactionVendorEnum? _transactionVendor = null;
        public paymentTransactionVendorEnum? transactionVendor
        {
            get
            {
                if (_transactionVendor.HasValue)
                {
                    return _transactionVendor.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _transactionVendor = value; }
        }
        public bool transactionVendorSpecified
        {
            get { return _transactionVendor != null; }
        }

        // Start PaymentTypeSelect group  TODO There are no definitions so need example
        // Start Choice
        private string _ACH = null;
        public string ACH
        {
            get { return _ACH; }
            set
            {
                _ACH = value;
                ChoiceClearAllBut(eChoicePayment.scACH);
            }
        }

        private string _Card = null;
        public string Card
        {
            get { return _Card; }
            set
            {
                _Card = value;
                ChoiceClearAllBut(eChoicePayment.scCard);
            }
        }

        private string _Check = null;
        public string Check
        {
            get { return _Check; }
            set
            {
                _Check = value;
                ChoiceClearAllBut(eChoicePayment.scCheck);
            }
        }
        // End Choice
        // End PaymentTypeSelect group

        [XmlIgnore]
        public DateTime? dateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("Date")]
        public string DateString
        {
            get
            {
                if (dateTime.HasValue)
                {
                    return dateTime.Value.ToString(Constants.cDateFormat);
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
                    if (dateTime != null)
                    {
                        dateTime = td + dateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        dateTime = td;
                    }
                }
            }
        }
        public bool DateStringSpecified
        {
            get { return dateTime != null; }
        }

        [XmlElement("Time")]
        public string TimeString
        {
            get
            {
                if (dateTime.HasValue)
                {
                    return dateTime.Value.ToString(Constants.cTimeFormat);
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
                    if (dateTime != null)
                    {
                        dateTime = dateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        dateTime = td;
                    }
                }

            }
        }
        public bool TimeStringSpecified
        {
            get { return dateTime != null; }
        }


        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public clsInvoiceIds InvoiceIds { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsPayment()
        {
        }

         // Methods
        private void ChoiceClearAllBut(eChoicePayment pSelectedChoice)
        {
            if (pSelectedChoice != eChoicePayment.scACH)
            {
                _ACH = null;
            }
            if (pSelectedChoice != eChoicePayment.scCheck)
            {
                _Check = null;
            }
            if (pSelectedChoice != eChoicePayment.scCard)
            {
                _Card = null;
            }
        }
    }
}
