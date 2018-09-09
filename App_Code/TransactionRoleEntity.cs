using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TransactionRoleEntity
/// </summary>
public class TransactionRoleEntity
{
	public TransactionRoleEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    int roleId;

    public int RoleId
    {
        get { return roleId; }
        set { roleId = value; }
    }


    string  roleCode;
    public string RoleCode
    {
        get { return roleCode; }
        set { roleCode = value; }
    }

    string roleDetails;

    public string RoleDetails
    {
        get { return roleDetails; }
        set { roleDetails = value; }
    }

    string roleRemarks;

    public string RoleRemarks
    {
        get { return roleRemarks; }
        set { roleRemarks = value; }
    }
    string roleCreateBy;

    public string RoleCreateBy
    {
        get { return roleCreateBy; }
        set { roleCreateBy = value; }
    }
    string roleLastModifiedBy;

    public string RoleLastModifiedBy
    {
        get { return roleLastModifiedBy; }
        set { roleLastModifiedBy = value; }
    }


}