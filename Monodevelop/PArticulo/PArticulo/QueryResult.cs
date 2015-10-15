using System;
using System.Collections;
using System.Collections.Generic;

namespace PArticulo
{
	public class QueryResult
	{
		private string[] columNames;
		public string[] ColumNames{
			get{return columNames;}
			set {columNames =value;}
		}
		private IEnumerable<IList> rows;
		public IEnumerable<IList> Rows{
			get{return rows;}
			set {rows=value;}
		
		}
	}
}

