﻿using System.Collections.Generic;
using System.Linq;
using K9.SharedLibrary.Models;

namespace K9.Base.DataAccessLayer.Config
{
	public class ColumnsConfig : IColumnsConfig
	{
		public List<string> ColumnsToIgnore
		{
			get
			{
				return 
					typeof(IAuditable).GetProperties().Select(p => p.Name).Concat(
					typeof(IPermissable).GetProperties().Select(p => p.Name)).ToList();
			}
		}
	}
}
