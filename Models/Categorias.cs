using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRisk.Models
{
	public enum RiskCategory
	{
		EXPIRED,
		HIGHRISK,
		MEDIUMRISK,
		NORMAL // Categoria padrão para operações que não se encaixam em outras
	}
}
