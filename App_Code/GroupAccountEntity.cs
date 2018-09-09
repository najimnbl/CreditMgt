using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroupAccount
/// </summary>
public class GroupAccountEntity
{
    public GroupAccountEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   
    public int GrpAccSL {get; set;}
    public string  GrpAccNo {get; set;}
    public int AccGTSL {get;set;}
    public string GrpAccName {get;set;}
    public string Remarks {get;set;}
    public string CrateBy{get;set;}
    public string LastModifiedBy{get;set;}


}