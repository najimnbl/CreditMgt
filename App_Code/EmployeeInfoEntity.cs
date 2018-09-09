using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeInfoEntity
/// </summary>
public class EmployeeInfoEntity
{
	public EmployeeInfoEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 ID { get; set; }
    public string EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string Designation { get; set; }
    public string RegistrationNo { get; set; }
    public string BranchCode { get; set; }
    public string MobileNo { get; set; }
    public string CreateBy { get; set; }
    public string LastModifiedBy { get; set; }



}