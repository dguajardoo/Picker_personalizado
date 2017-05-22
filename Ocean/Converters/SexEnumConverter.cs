﻿using System;
using System.Globalization;
using Ocean.Model;
using Xamarin.Forms;

namespace Ocean.Converters
{
	public class SexEnumConverter : IValueConverter
	{

		public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			return ((Sex)value).ToString();
		}

		public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			// the null check is required.  when the data template selector is being changed dynamically,
			//   this method gets called with the value set to null.
			return value == null ? null : Enum.Parse(typeof(Sex), value.ToString());
		}

	}
}
