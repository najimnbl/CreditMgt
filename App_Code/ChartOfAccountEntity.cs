using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChartOfAccountEntity
/// </summary>
public class ChartOfAccountEntity
{
	public ChartOfAccountEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CoAccSL { set; get; }
   public string CoAccNo { set; get; }
   public string	CoAccName{ set; get; }
	public DateTime OpenDate{ set; get; }
    public int GrpAccSL { set; get; }
    public int	AccGrpSLR{ set; get; }
    public int	AccTypeSL{ set; get; }
    public int 	SGrpAccSL{ set; get; }
public bool	Posted{ set; get; }
public decimal	OpenDayBalance{ set; get; }
 public decimal   ClossingBalance{ set; get; }
public decimal	AvailableBalance{ set; get; }
public decimal	CurrentBalance{ set; get; }
public string	CreateBy{ set; get; }
public string	LastModifiedBy{ set; get; }
}