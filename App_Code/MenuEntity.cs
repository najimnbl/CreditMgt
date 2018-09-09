using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuEntity
/// </summary>
public class MenuEntity
{
	public MenuEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string MenuNo { get; set; }
    public string MenuName { get; set; }
    public string CreateBy { get; set; }
    public string LastModifiedBy { get; set; }
    //public bool Active { get; set; }
    //public string EmployeeID { get; set; }
    //public string CreateBy { get; set; }
    //public string LastModifiedBy { get; set; }
}