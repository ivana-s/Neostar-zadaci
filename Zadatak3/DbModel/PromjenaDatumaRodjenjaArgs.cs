using System;

namespace Zadatak3
{
	public class PromjenaDatumaRodjenjaArgs : EventArgs
	{
		public double Starost { get; set; }

		public PromjenaDatumaRodjenjaArgs(double starost)
		{
			Starost = starost;
		}
	}
}
