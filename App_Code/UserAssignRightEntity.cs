using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAssignRightEntity
/// </summary>
public class UserAssignRightEntity
{
	public UserAssignRightEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string UserID { get; set; }
    public string MenuNo { get; set; }
    public string SubMenuNo { get; set; }
    public bool MenuRights { get; set; }
    public bool SubMenuRights { get; set; }
    public string CreateBy { get; set; }
    public string LastModifiedBy { get; set; }
	
}