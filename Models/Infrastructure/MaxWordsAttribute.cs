namespace Infrastructure
{
	public class MaxWordsAttribute :
		System.ComponentModel.DataAnnotations.ValidationAttribute
	{
		//public MaxWordsAttribute() : base()
		//{
		//}

		public MaxWordsAttribute(int maxWords) : base()
		{
			MaxWords = maxWords;
		}

		protected virtual int MaxWords { get; set; }

		//protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid
		//	(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
		//{
		//	return base.IsValid(value, validationContext);
		//}

		protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid
			(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
		{
			string strErrorMessage = string.Empty;

			if (value == null)
			{
				return (System.ComponentModel.DataAnnotations.ValidationResult.Success);
			}

			string strValue =
				value.ToString().Trim();

			if (strValue == string.Empty)
			{
				return (System.ComponentModel.DataAnnotations.ValidationResult.Success);
			}

			while (strValue.Contains("  "))
			{
				strValue =
					strValue.Replace("  ", " ");
			}

			if (strValue.Split(' ').Length <= MaxWords)
			{
				return (System.ComponentModel.DataAnnotations.ValidationResult.Success);
			}

			if (string.IsNullOrWhiteSpace(ErrorMessage) == false)
			{
				ErrorMessage =
					string.Format(ErrorMessage, MaxWords);

				return (new System.ComponentModel.DataAnnotations.ValidationResult(ErrorMessage));
			}

			if (ErrorMessageResourceType == null)
			{
				strErrorMessage = "Too Many Words!";

				return (new System.ComponentModel.DataAnnotations.ValidationResult(strErrorMessage));
			}

			System.Resources.ResourceManager oResourceManager =
				new System.Resources.ResourceManager(ErrorMessageResourceType);

			oResourceManager.IgnoreCase = true;

			object oResult =
					oResourceManager.GetObject(ErrorMessageResourceName,
					System.Threading.Thread.CurrentThread.CurrentCulture);

			strErrorMessage =
				string.Format(oResult.ToString().Trim(), MaxWords);

			return (new System.ComponentModel.DataAnnotations.ValidationResult(strErrorMessage));
		}
	}
}
