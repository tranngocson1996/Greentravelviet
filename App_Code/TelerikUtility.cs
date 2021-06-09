using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIC.Utils;
using Telerik.Web.UI;

/// <summary>
/// Summary description for TelerikUtility
/// </summary>
public class TelerikUtility
{
	public TelerikUtility()
	{
	}

	public string GetCheckedCombobox(RadComboBox radCombobox)
	{
		string value = string.Empty;
		foreach (RadComboBoxItem item in radCombobox.CheckedItems)
		{
			value += "," + item.Value.Trim();
		}
		return value;
	}

	public void SetCheckedCombobox(RadComboBox radCombobox, string value)
	{
		var valueItem = BicString.SplitComma(value);
		foreach (RadComboBoxItem item in radCombobox.Items)
		{
			foreach (var s in valueItem)
				if (item.Value == s)
					item.Checked = true;
		}
	}
}