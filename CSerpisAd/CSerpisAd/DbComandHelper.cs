﻿using System;
namespace Serpis.Ad
{
    public partial class DbComandHelper : Gtk.ActionGroup
    {
		public static void AddParameter(IDbCommand dbCommand, string name, object value)
		{
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add(dbDataParameter);
		}

	}
}
 