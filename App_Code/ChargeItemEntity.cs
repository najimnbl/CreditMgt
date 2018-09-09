using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChargeItemEntity
/// </summary>
public class ChargeItemEntity
{
	public ChargeItemEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int chargeID;

    public int ChargeID
    {
        get { return chargeID; }
        set { chargeID = value; }
    }
    string chargeCode;

    public string ChargeCode
    {
        get { return chargeCode; }
        set { chargeCode = value; }
    }
    string chargeDetails;

    public string ChargeDetails
    {
        get { return chargeDetails; }
        set { chargeDetails = value; }
    }
    double chargeAmount;

    public double ChargeAmount
    {
        get { return chargeAmount; }
        set { chargeAmount = value; }
    }
    double cApplyLowerLimit;

    public double CApplyLowerLimit
    {
        get { return cApplyLowerLimit; }
        set { cApplyLowerLimit = value; }
    }
    double cApplyHigherLimit;

    public double CApplyHigherLimit
    {
        get { return cApplyHigherLimit; }
        set { cApplyHigherLimit = value; }
    }
    double chargePercentage;

    public double ChargePercentage
    {
        get { return chargePercentage; }
        set { chargePercentage = value; }
    }
    int chargeItemType;

    public int ChargeItemType
    {
        get { return chargeItemType; }
        set { chargeItemType = value; }
    }
    string chargeRemarks;

    public string ChargeRemarks
    {
        get { return chargeRemarks; }
        set { chargeRemarks = value; }
    }
    string chargeCreatedBy;

    public string ChargeCreatedBy
    {
        get { return chargeCreatedBy; }
        set { chargeCreatedBy = value; }
    }
    string chargeLastModifiedBy;

    public string ChargeLastModifiedBy
    {
        get { return chargeLastModifiedBy; }
        set { chargeLastModifiedBy = value; }
    }
}