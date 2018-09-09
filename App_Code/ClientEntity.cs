
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientEntity
/// </summary>
public class ClientEntity
{
	public ClientEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    int clSL;

    public int  ClSL
{
  get { return clSL; }
  set { clSL = value; }
}

string clientID;

public string ClientID
{
    get { return clientID; }
    set { clientID = value; }
}
string clientBIO;

public string ClientBIO
{
    get { return clientBIO; }
    set { clientBIO = value; }
}
string mBHouseCode;

public string MBHouseCode
{
    get { return mBHouseCode; }
    set { mBHouseCode = value; }
}
string clientIntroducer;

public string ClientIntroducer
{
    get { return clientIntroducer; }
    set { clientIntroducer = value; }
}
string roleCode;

public string RoleCode
{
    get { return roleCode; }
    set { roleCode = value; }
}
string clientTypeCode;

public string ClientTypeCode
{
    get { return clientTypeCode; }
    set { clientTypeCode = value; }
}
string chargeCategoryCode;

public string ChargeCategoryCode
{
    get { return chargeCategoryCode; }
    set {chargeCategoryCode = value; }
}
string clientPowerAtonyDetais;

public string ClientPowerAtonyDetais
{
    get { return clientPowerAtonyDetais; }
    set { clientPowerAtonyDetais = value; }
}
string clientSpecialComissionRate;

public string ClientSpecialComissionRate
{
    get { return clientSpecialComissionRate; }
    set { clientSpecialComissionRate = value; }
}
string clientTransactionAccount;

public string ClientTransactionAccount
{
    get { return clientTransactionAccount; }
    set { clientTransactionAccount = value; }
}
string accountType;

public string AccountType
{
    get { return accountType; }
    set { accountType = value; }
}
string clientCreateBy;

public string ClientCreateBy
{
    get { return clientCreateBy; }
    set { clientCreateBy = value; }
}
string clientLastModified;

public string ClientLastModified
{
    get { return clientLastModified; }
    set { clientLastModified = value; }
}

DateTime acccountOpeningDate;

public DateTime AcccountOpeningDate
{
    get { return acccountOpeningDate; }
    set { acccountOpeningDate = value; }
} 
	
    //[MBHouseCode] [nvarchar](15) NULL,
    //[ClientIntroducer] [nvarchar](20) NULL,
    //[RoleCode] [nvarchar](25) NULL,
    //[ClientTypeCode] [nvarchar](25) NULL,
    //[ChargeCategoryCode] [nvarchar](15) NULL,
    //[ClientPowerAtonyDetais] [nvarchar](150) NULL,
    //[ClientSpecialComissionRate] [nvarchar](150) NULL,
    //[ClientTransactionAccount] [nvarchar](50) NULL,
    //[AccountType] [nvarchar](25) NULL,
    //[ClientCreateBy] [nvarchar](50) NULL,
    //[ClientLastModified] [nvarchar](50) NULL,

}