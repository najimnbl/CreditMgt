using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChargeCategoryEntity
/// </summary>
public class ChargeCategoryEntity
{
	public ChargeCategoryEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int chargeCategoryID;

    public int ChargeCategoryID
    {
        get { return chargeCategoryID; }
        set { chargeCategoryID = value; }
    }
    string chargeCategoryCode;

    public string ChargeCategoryCode
    {
        get { return chargeCategoryCode; }
        set { chargeCategoryCode = value; }
    }
    string chargeCategoryName;

    public string ChargeCategoryName
    {
        get { return chargeCategoryName; }
        set { chargeCategoryName = value; }
    }
    string chargeCategoryRemarks;

    public string ChargeCategoryRemarks
    {
        get { return chargeCategoryRemarks; }
        set { chargeCategoryRemarks = value; }
    }
    string chargeCategoryCreatedBy;

    public string ChargeCategoryCreatedBy
    {
        get { return chargeCategoryCreatedBy; }
        set { chargeCategoryCreatedBy = value; }
    }
    string chargeCategoryLastModifiedBy;

    public string ChargeCategoryLastModifiedBy
    {
        get { return chargeCategoryLastModifiedBy; }
        set { chargeCategoryLastModifiedBy = value; }
    }
}