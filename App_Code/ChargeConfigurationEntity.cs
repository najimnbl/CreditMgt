using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChargeConfigurationEntity
/// </summary>
public class ChargeConfigurationEntity
{
	public ChargeConfigurationEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int chargeConfigurationID;

    public int ChargeConfigurationID
    {
        get { return chargeConfigurationID; }
        set { chargeConfigurationID = value; }
    }
    string chargeCategoryCode;

    public string ChargeCategoryCode
    {
        get { return chargeCategoryCode; }
        set { chargeCategoryCode = value; }
    }
    string chargeConfigurationDetails;

    public string ChargeConfigurationDetails
    {
        get { return chargeConfigurationDetails; }
        set { chargeConfigurationDetails = value; }
    }
    string chargeCode;

    public string ChargeCode
    {
        get { return chargeCode; }
        set { chargeCode = value; }
    }
    string chargeCRemarks;

    public string ChargeCRemarks
    {
        get { return chargeCRemarks; }
        set { chargeCRemarks = value; }
    }
    string chargeCCreatedBy;

    public string ChargeCCreatedBy
    {
        get { return chargeCCreatedBy; }
        set { chargeCCreatedBy = value; }
    }
    string chargeCLastModifiedBy;

    public string ChargeCLastModifiedBy
    {
        get { return chargeCLastModifiedBy; }
        set { chargeCLastModifiedBy = value; }

    }

    string chargeDetails;

    public string ChargeDetails
    {
        get { return chargeDetails; }
        set { chargeDetails = value; }
    }
    string chargeCategoryName;

    public string ChargeCategoryName
    {
        get { return chargeCategoryName; }
        set { chargeCategoryName = value; }
    }
}