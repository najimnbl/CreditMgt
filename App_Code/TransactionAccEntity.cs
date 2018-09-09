using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TransactionAccEntity
/// </summary>
public class TransactionAccEntity
{
	public TransactionAccEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public Int64 TranAccSL {get;set;}
public string VoucherNo   {get;set;}
public string CoAccNo {get;set;}
public Boolean IsClient  {get;set;}
public string TMode  {get;set;}
public string BankName  {get;set;}
public string BranchName  {get;set;}
public string ChequeNo  {get;set;}
public string BankAccNo { get; set; }
public DateTime  ChequeDate {get;set;}
public string Tref  {get;set;}
public decimal BQty {get;set;}
public decimal SQty  {get;set;}
public decimal Debit {get;set;}
public decimal Credit  {get;set;}
public decimal Balance  {get;set;}
public Boolean Matured  {get;set;}
public string CreateBy  {get;set;}
public string LastModifiedBy  {get;set;}
}