using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankInformationEntity
/// </summary>
public class BankInformationEntity
{
	public BankInformationEntity()
	{
        
		//
		// TODO: Add constructor logic here
		//
	}
    int bankid;

    public int Bankid
    {
        get { return bankid; }
        set { bankid = value; }
    }
    string bankName;

    public string BankName
    {
        get { return bankName; }
        set { bankName = value; }
    }
    string bankRemarks;

    public string BankRemarks
    {
        get { return bankRemarks; }
        set { bankRemarks = value; }
    }
    int branchID;

    public int BranchID
    {
        get { return branchID; }
        set { branchID = value; }
    }
    string branchCode;

    public string BranchCode
    {
        get { return branchCode; }
        set { branchCode = value; }
    }
    string branchName;

    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
    }
    string branchAddress;

    public string BranchAddress
    {
        get { return branchAddress; }
        set { branchAddress = value; }
    }
    string branchRoutingCode;

    public string BranchRoutingCode
    {
        get { return branchRoutingCode; }
        set { branchRoutingCode = value; }
    }
    string branchRemarks;

    public string BranchRemarks
    {
        get { return branchRemarks; }
        set { branchRemarks = value; }
    }
    string branchCreateBy;

    public string BranchCreateBy
    {
        get { return branchCreateBy; }
        set { branchCreateBy = value; }
    }
    string branchLastModifieddBy;

    public string BranchLastModifieddBy
    {
        get { return branchLastModifieddBy; }
        set { branchLastModifieddBy = value; }
    }
}