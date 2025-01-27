using AppRisk.Interface;
using AppRisk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRisk.Services
{
	public class RiskClassificacao
	{
		private DateTime _referenceDate;

		public RiskClassificacao(DateTime referenceDate)
		{
			_referenceDate = referenceDate;
		}

		public RiskCategory Classificar(ITrade trade)
		{
			// Verificar se a operação está atrasada
			if ((trade.NextPaymentDate - _referenceDate).Days < -30)
			{
				return RiskCategory.EXPIRED;
			}

			// Verificar operações de risco alto no setor privado
			if (trade.Value > 1000000 && trade.ClientSector == "Private")
			{
				return RiskCategory.HIGHRISK;
			}

			// Verificar operações de risco médio no setor público
			if (trade.Value > 1000000 && trade.ClientSector == "Public")
			{
				return RiskCategory.MEDIUMRISK;
			}

			// Caso a operação não se encaixe em nenhuma categoria acima, é classificada como NORMAL
			return RiskCategory.NORMAL;
		}
	}
}
