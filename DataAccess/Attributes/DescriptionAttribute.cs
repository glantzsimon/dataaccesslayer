using System;

namespace K9.Base.DataAccessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
	public class DescriptionAttribute : Attribute
	{
	    public DescriptionAttribute()
	    {
	        DescriptionField = "Name";
	    }

		public string DescriptionField { get; set; }
        /// <summary>
        /// If true, the value of the DescriptionField will be looked up in the Dictionary
        /// </summary>
	    public bool UseLocalisedString { get; set; }
	}
}
