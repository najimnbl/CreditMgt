using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TransactionEntity
/// </summary>
public class TransactionEntity
{
	public TransactionEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public Int64 TranSL {get;set;}
   public string VoucherNo {get;set;}
   public DateTime VoucherDate { get; set; }
 public int BrSL {get;set;}
 public int TranTypeSL {get;set;}
 public string PartiCulars {get;set;}
 public Boolean Posted {get;set;}
 public Boolean Approved {get;set;}
 public int BillSL {get;set;}
 public Int64 RevTranSL{get;set;}
 public string CreateBy{get;set;}
 public string LastModifiedBy { get; set; }
}