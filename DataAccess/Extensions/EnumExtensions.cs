﻿using System;
using K9.DataAccessLayer.Attributes;
using K9.SharedLibrary.Extensions;

namespace K9.DataAccessLayer.Extensions
{
	public static class EnumExtensions
	{

		public static string GetLocalisedLanguageName(this Enum value)
		{
			var attr = value.GetAttribute<EnumDescriptionAttribute>();
			return attr.GetDescription();
		}

		public static string GetLanguageCode(this Enum value)
		{
			var attr = value.GetAttribute<EnumDescriptionAttribute>();
			return attr.LanguageCode;
		}

	}
}
