using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientTypeEntity
/// </summary>
public class ClientTypeEntity
{
	public ClientTypeEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int clientTypeID;

    public int ClientTypeID
    {
        get { return clientTypeID; }
        set { clientTypeID = value; }
    }

    string clientTypeCode;

    public string ClientTypeCode
    {
        get { return clientTypeCode; }
        set { clientTypeCode = value; }
    }

    string clientTypeDetais;

    public string ClientTypeDetais
    {
        get { return clientTypeDetais; }
        set { clientTypeDetais = value; }
    }
    
    
    float clientTypeChargePercentage;

    public float ClientTypeChargePercentage
    {
        get { return clientTypeChargePercentage; }
        set { clientTypeChargePercentage = value; }
    }
    string clientTypeRemarks;

    public string ClientTypeRemarks
    {
        get { return clientTypeRemarks; }
        set { clientTypeRemarks = value; }
    }
    string clientTypeCreateBy;

    public string ClientTypeCreateBy
    {
        get { return clientTypeCreateBy; }
        set { clientTypeCreateBy = value; }
    }
    string clientTypeLastModifiedBy;

    public string ClientTypeLastModifiedBy
    {
        get { return clientTypeLastModifiedBy; }
        set { clientTypeLastModifiedBy = value; }
    }

}