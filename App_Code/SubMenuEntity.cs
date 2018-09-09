using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubMenuEntity
/// </summary>
public class SubMenuEntity
{
	public SubMenuEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string MenuNo { get; set; }
    public string SubMenuNo { get; set; }
    public string SubMenuName { get; set; }
    public string CreateBy { get; set; }
    public string LastModifiedBy { get; set; }
}