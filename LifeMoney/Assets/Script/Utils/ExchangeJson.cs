using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExchangeJson
{
	public Quote[] quotes;

	[System.Serializable]
	public class Quote
	{
		public string high;
		public string open;
		public string bid;
		public string currencyPairCode;
		public string ask;
		public string low;

	}
}
