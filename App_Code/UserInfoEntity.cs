using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfoEntity
{
    public UserInfoEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public int ID{get;set;} 
	 public string UserID {get;set;}
	 public string UserType {get;set;}
	 public string Password{get;set;}
     public string	ConfirmPassword {get;set;}
     public  bool	Active {get;set;}
	 public string EmployeeID {get;set;}
	 public string CreateBy {get;set;}
     public string LastModifiedBy {get;set;}
	
}