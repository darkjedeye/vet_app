using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Routing;
using Fabrik.Common;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Web.Infrastructure.Extensions
{
	// How to get Model Property Attributes and use them http://stackoverflow.com/questions/10970184/accessing-attributes-from-custom-html-helpers-in-asp-net-mvc-4-razor
	public static class FoundationHtmlHelpers
	{
		#region TextBox Input
		public static MvcHtmlString FoundationTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return html.FoundationTextBoxFor(modelProperty, htmlAttributes);
		}

		public static MvcHtmlString FoundationTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, bool includeLabel)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return html.FoundationTextBoxFor(modelProperty, htmlAttributes, includeLabel);
		}

		public static MvcHtmlString FoundationTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, object htmlAttributes)
		{
			return html.FoundationTextBoxFor(modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString FoundationTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, object htmlAttributes, bool includeLabel)
		{
			return html.FoundationTextBoxFor(modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), includeLabel);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TModel">Type of the Model object</typeparam>
		/// <typeparam name="TValue">Value of the Model object</typeparam>
		/// <param name="html">class this method extends</param>
		/// <param name="modelProperty">An modelProperty (linq) that identifies the Model</param>
		/// <param name="htmlAttributes">dictionary of html attributes for the Model in the modelProperty</param>
		/// <param name="includeLabel"></param>
		/// <returns></returns>
		private static MvcHtmlString FoundationTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, IDictionary<string, object> htmlAttributes, bool includeLabel = true)
		{
			// Returns the modelPropertyMetaData from the Expression parameter for the model
			var modelPropertyMetaData = ModelMetadata.FromLambdaExpression(modelProperty, html.ViewData);

			// Value of the "name" attribute
			var htmlFieldName = ExpressionHelper.GetExpressionText(modelProperty);

			// used to retrieve RequiredAttribute from Model/Property if there is one
			var modelPropertyMemberExpression = (modelProperty.Body as MemberExpression);

			var isNotRequired = htmlAttributes.ContainsKey("notrequired");

			DataTypeAttribute dataTypeAttribute = null;
			string requiredMessage = null;
			RequiredAttribute requiredAttribute = null;
			FoundationAbidePatternAttribute abidePatternAttribute = null;
			if (!isNotRequired)
			{
				requiredAttribute = FoundationInputModelRequiredAttributeReader(ref htmlAttributes, modelPropertyMemberExpression,
																		ref requiredMessage, ref dataTypeAttribute, ref abidePatternAttribute);
			}

			// retrieve the text used for the label: use the DisplayNameAttribute, then the Property's name, then the html name attribute string
			var labelText = html.Encode(modelPropertyMetaData.DisplayName ?? modelPropertyMetaData.PropertyName ?? htmlFieldName.Split('.').Last());

			// create label
			var label = FoundationInputLabelBuilder(includeLabel, labelText, htmlFieldName, requiredAttribute);

			// add maxlength property to input to prevent adding too many characters to input field
			if (abidePatternAttribute != null)
			{
				var pattern = abidePatternAttribute.AbidePattern.Split('_');
				if (pattern.Length > 0)
				{
					if (pattern[0] == "length")
					{
						htmlAttributes.Add(new KeyValuePair<string, object>("maxlength", pattern[1]));
					}
				}
			}

			// create text box input
			var textBoxFor = html.TextBoxFor(modelProperty, htmlAttributes);

			// check if htmlAttributes contains "name=''" and if so set the name property to blank - used to prevent field from posting with for security issues such as credit card information
			if (htmlAttributes.ContainsKey("name"))
			{
				var index1 = textBoxFor.ToString().IndexOf(" name=\"", StringComparison.Ordinal) + 7;
				var index2 = textBoxFor.ToString().IndexOf("\"", index1, StringComparison.Ordinal);
				var newText = textBoxFor.ToString().Remove(index1, index2 - index1);
				textBoxFor = new MvcHtmlString(newText);
			}

			// if the "notrequired" attribute was provided then remove the auto-generated "required" attribute from the input
			if (isNotRequired)
			{
				textBoxFor = new MvcHtmlString(textBoxFor.ToString().Replace(" required ", " "));
			}

			// return html if the required attribute is not required or their is no required field message
			if (requiredAttribute == null && requiredMessage.IsNullOrEmpty())
			{
				// place the input inside the <label> tag after the label text
				label.InnerHtml += textBoxFor.ToHtmlString();
				return includeLabel ? new MvcHtmlString(label.ToString()) : new MvcHtmlString(textBoxFor.ToHtmlString());
			}

			// create error small if needed
			var errorTextSmall = FoundationInputErrorBuilder(requiredMessage, labelText, dataTypeAttribute, abidePatternAttribute);
			// place the input inside the <label> tag after the label text
			label.InnerHtml += textBoxFor.ToHtmlString();
			return new MvcHtmlString(label.ToString() + errorTextSmall);
		}
		#endregion

		#region TextArea Input
		public static MvcHtmlString FoundationTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return html.FoundationTextAreaFor(modelProperty, htmlAttributes);
		}

		public static MvcHtmlString FoundationTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, bool includeLabel)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return html.FoundationTextAreaFor(modelProperty, htmlAttributes, includeLabel);
		}

		public static MvcHtmlString FoundationTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, object htmlAttributes)
		{
			var dict = new RouteValueDictionary(htmlAttributes);
			return html.FoundationTextAreaFor(modelProperty, dict);
		}

		public static MvcHtmlString FoundationTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, object htmlAttributes, bool includeLabel)
		{
			var dict = new RouteValueDictionary(htmlAttributes);
			return html.FoundationTextAreaFor(modelProperty, dict, includeLabel);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TModel">Type of the Model object</typeparam>
		/// <typeparam name="TValue">Value of the Model object</typeparam>
		/// <param name="html">class this method extends</param>
		/// <param name="modelProperty">An modelProperty (linq) that identifies the Model</param>
		/// <param name="htmlAttributes">dictionary of html attributes for the Model in the modelProperty</param>
		/// <param name="includeLabel"></param>
		/// <returns></returns>
		private static MvcHtmlString FoundationTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, IDictionary<string, object> htmlAttributes, bool includeLabel = true)
		{
			// Returns the modelPropertyMetaData from the Expression parameter for the model
			var modelPropertyMetaData = ModelMetadata.FromLambdaExpression(modelProperty, html.ViewData);

			// Value of the "name" attribute
			var htmlFieldName = ExpressionHelper.GetExpressionText(modelProperty);

			// used to retrieve RequiredAttribute from Model/Property if there is one
			var modelPropertyMemberExpression = (modelProperty.Body as MemberExpression);
			DataTypeAttribute dataTypeAttribute = null;
			string requiredMessage = null;
			FoundationAbidePatternAttribute abidePatternAttribute = null;
			var requiredAttribute = FoundationInputModelRequiredAttributeReader(ref htmlAttributes, modelPropertyMemberExpression,
																		ref requiredMessage, ref dataTypeAttribute, ref abidePatternAttribute);

			// retrieve the text used for the label: use the DisplayNameAttribute, then the Property's name, then the html name attribute string
			var labelText = html.Encode(modelPropertyMetaData.DisplayName ?? modelPropertyMetaData.PropertyName ?? htmlFieldName.Split('.').Last());

			// create label
			var label = FoundationInputLabelBuilder(includeLabel, labelText, htmlFieldName, requiredAttribute);

			// add maxlength property to input to prevent adding too many characters to input field
			if (abidePatternAttribute != null)
			{
				var pattern = abidePatternAttribute.AbidePattern.Split('_');
				if (pattern.Length > 0)
				{
					if (pattern[0] == "length")
					{
						htmlAttributes.Add(new KeyValuePair<string, object>("maxlength", pattern[1]));
					}
				}
			}

			// create text box input
			var textAreaFor = html.TextAreaFor(modelProperty, htmlAttributes);

			if (requiredAttribute == null)
			{
				// place the input inside the <label> tag after the label text
				label.InnerHtml += textAreaFor.ToHtmlString();

				return includeLabel ? new MvcHtmlString(label.ToString()) : new MvcHtmlString(textAreaFor.ToHtmlString());
			}

			// create error small if needed
			var errorTextSmall = FoundationInputErrorBuilder(requiredMessage, labelText, dataTypeAttribute, abidePatternAttribute);

			// place the input inside the <label> tag after the label text
			label.InnerHtml += textAreaFor.ToHtmlString();

			return new MvcHtmlString(label.ToString() + errorTextSmall);
		}
		#endregion

		#region Radio Input
		public static MvcHtmlString FoundationRadioButtonFor<TModel, TValue>(
			this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty,
			IEnumerable<KeyValuePair<string, object>> valuesLabels,
			Expression<Func<TModel, TValue>> labelModelExpression, string labelText, bool includeLabel)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return html.FoundationRadioButtonFor(modelProperty, htmlAttributes, valuesLabels, labelModelExpression, labelText, includeLabel);
		}

		public static MvcHtmlString FoundationRadioButtonFor<TModel, TValue>(
			this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty,
			object htmlAttributes, IEnumerable<KeyValuePair<string, object>> valuesLabels,
			Expression<Func<TModel, TValue>> labelModelExpression, string labelText, bool includeLabel)
		{
			return html.FoundationRadioButtonFor(modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), valuesLabels, labelModelExpression, labelText, includeLabel);
		}

		private static MvcHtmlString FoundationRadioButtonFor<TModel, TValue>(
			this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty,
			IDictionary<string, object> htmlAttributes, IEnumerable<KeyValuePair<string, object>> valuesLabels,
			Expression<Func<TModel, TValue>> labelModelExpression, string labelText, bool includeLabel)
		{
			if (htmlAttributes == null) htmlAttributes = new Dictionary<string, object>();

			// Returns the modelPropertyMetaData from the Expression parameter for the model
			var modelPropertyMetaData = ModelMetadata.FromLambdaExpression(modelProperty, html.ViewData);

			// Value of the "name" attribute
			var htmlFieldName = ExpressionHelper.GetExpressionText(modelProperty);

			// used to retrieve RequiredAttribute from Model/Property if there is one
			var modelPropertyMemberExpression = (modelProperty.Body as MemberExpression);
			DataTypeAttribute dataTypeAttribute = null;
			string requiredMessage = null;
			FoundationAbidePatternAttribute abidePatternAttribute = null;
			var requiredAttribute = FoundationInputModelRequiredAttributeReader(ref htmlAttributes, modelPropertyMemberExpression,
																		ref requiredMessage, ref dataTypeAttribute, ref abidePatternAttribute);

			// retrieve the text used for the label: use the DisplayNameAttribute, then the Property's name, then the html name attribute string
			string label = null;
			if (includeLabel)
			{
				// create label
				if (labelModelExpression != null)
				{
					label = html.LabelFor(labelModelExpression).ToHtmlString();
				}
				else if (labelText.IsNotNullOrEmpty())
				{
					label = FoundationInputLabelBuilder(true, labelText, htmlFieldName, null).ToString();
				}
				else
				{
					labelText = modelPropertyMetaData.DisplayName ?? modelPropertyMetaData.PropertyName ?? htmlFieldName.Split('.').Last();
					label = FoundationInputLabelBuilder(true, labelText, htmlFieldName, requiredAttribute).ToString();
				}
			}

			object noCustom;
			htmlAttributes.TryGetValue("class", out noCustom);
			object labelAttributes = noCustom == null ? new { @class = "label-radio" } : new { @class = "label-radio no-custom" };

			// create all of the radio button inputs with labels into a string
			var radioInputs = string.Empty;
			foreach (var item in valuesLabels)
			{
				// set the id value to be prefixed with the radio value to provide a unique value for the radio's label
				var radioInput = html.RadioButtonFor(modelProperty, item.Value).ToHtmlString();
				// start of id tag value
				var index1 = radioInput.IndexOf(" id=\"", StringComparison.Ordinal) + 5;
				// end of id tag value
				var index2 = radioInput.IndexOf("\"", index1, StringComparison.Ordinal);
				// id tag value
				radioInput = radioInput.Insert(index2, item.Key);

				var radioInputLabel = html.LabelFor(modelProperty, item.Key, labelAttributes).ToHtmlString();
				// start of for tag value
				index1 = radioInputLabel.IndexOf(" for=\"", StringComparison.Ordinal) + 6;
				// end of for tag value
				index2 = radioInputLabel.IndexOf("\"", index1, StringComparison.Ordinal);
				// id tag value
				radioInputLabel = radioInputLabel.Insert(index2, item.Key);

				radioInputs += radioInput + " " + radioInputLabel + " ";
			}

			if (requiredAttribute == null)
			{
				return includeLabel ? new MvcHtmlString(label + radioInputs) : new MvcHtmlString(radioInputs);
			}

			// create error small if needed
			var errorTextSmall = FoundationInputErrorBuilder(requiredMessage, labelText, dataTypeAttribute, abidePatternAttribute);

			return new MvcHtmlString(label + radioInputs + errorTextSmall);
		}

		public static MvcHtmlString FoundationRadioButtonFor(this HtmlHelper helper, string name, string labelText, string optionText, object value, bool required, bool isChecked)
		{
			var id = name.Replace('[', '_').Replace(']', '_').Replace('.', '_');

			var radio = new TagBuilder("input");
			radio.Attributes.Add("type", "radio");
			radio.Attributes.Add("name", name);
			radio.Attributes.Add("id", id);
			radio.Attributes.Add("value", value.ToString());
			radio.Attributes.Add("style", "display: none;");
			if (required) { radio.Attributes.Add("required", ""); }
			if (isChecked) { radio.Attributes.Add("checked", "checked"); }

			var span = new TagBuilder("span");
			span.Attributes.Add("class", "custom radio");

			var label = new TagBuilder("label");
			label.Attributes.Add("for", name);
			label.Attributes.Add("style", "margin-right: 10px;");
			label.InnerHtml = radio + span.ToString() + " " + optionText;

			return MvcHtmlString.Create(label.ToString());
		}
		#endregion

		#region Drop Down List Input
		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, null);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   bool includeLabel)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, null, includeLabel);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   string optionLabel)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, optionLabel);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   string optionLabel,
																		   bool includeLabel)
		{
			var htmlAttributes = new Dictionary<string, object>();
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, optionLabel, includeLabel);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   object htmlAttributes)
		{
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, null);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   bool includeLabel, object htmlAttributes)
		{
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, null, includeLabel);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   string optionLabel, object htmlAttributes)
		{
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, optionLabel);
		}

		public static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																		   Expression<Func<TModel, TValue>> modelProperty,
																		   IEnumerable<SelectListItem> selectList,
																		   string optionLabel,
																		   bool includeLabel, object htmlAttributes)
		{
			return FoundationDropDownListFor(html, modelProperty, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
											 selectList, optionLabel, includeLabel);
		}

		private static MvcHtmlString FoundationDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
																			 Expression<Func<TModel, TValue>> modelProperty,
																			 IDictionary<string, object> htmlAttributes,
																			 IEnumerable<SelectListItem> selectList,
																			 string optionLabel,
																			 bool includeLabel = true)
		{
			// Returns the modelPropertyMetaData from the Expression parameter for the model
			var modelPropertyMetaData = ModelMetadata.FromLambdaExpression(modelProperty, html.ViewData);

			// Value of the "name" attribute
			var htmlFieldName = ExpressionHelper.GetExpressionText(modelProperty);

			// used to retrieve RequiredAttribute from Model/Property if there is one
			var modelPropertyMemberExpression = (modelProperty.Body as MemberExpression);

			var isNotRequired = htmlAttributes.ContainsKey("notrequired");

			DataTypeAttribute dataTypeAttribute = null;
			string requiredMessage = null;
			RequiredAttribute requiredAttribute = null;
			FoundationAbidePatternAttribute abidePatternAttribute = null;
			if (!isNotRequired)
			{
				requiredAttribute = FoundationInputModelRequiredAttributeReader(ref htmlAttributes, modelPropertyMemberExpression,
																			ref requiredMessage, ref dataTypeAttribute, ref abidePatternAttribute);
			}

			// retrieve the text used for the label: use the DisplayNameAttribute, then the Property's name, then the html name attribute string
			var labelText = html.Encode(modelPropertyMetaData.DisplayName ?? modelPropertyMetaData.PropertyName ?? htmlFieldName.Split('.').Last());

			// create label
			var label = FoundationInputLabelBuilder(includeLabel, labelText, htmlFieldName, requiredAttribute);

			// create text box input
			var selectInputFor = html.DropDownListFor(modelProperty, selectList, optionLabel, htmlAttributes);

			// check if htmlAttributes contains "name=''" and if so set the name property to blank - used to prevent field from posting with for security issues such as credit card information
			if (htmlAttributes.ContainsKey("name"))
			{
				var index1 = selectInputFor.ToString().IndexOf(" name=\"", StringComparison.Ordinal) + 7;
				var index2 = selectInputFor.ToString().IndexOf("\"", index1, StringComparison.Ordinal);
				var newText = selectInputFor.ToString().Remove(index1, index2 - index1);
				selectInputFor = new MvcHtmlString(newText);
			}

			// if the "notrequired" attribute was provided then remove the auto-generated "required" attribute from the input
			if (isNotRequired)
			{
				selectInputFor = new MvcHtmlString(selectInputFor.ToString().Replace(" required ", " "));
			}

			// return html if the required attribute is not required or their is no required field message
			if (requiredAttribute == null && requiredMessage.IsNullOrEmpty())
			{
				// place the input inside the <label> tag after the label text
				label.InnerHtml += selectInputFor.ToHtmlString();
				return includeLabel ? new MvcHtmlString(label.ToString()) : new MvcHtmlString(selectInputFor.ToHtmlString());
			}

			// create error small if needed
			var errorTextSmall = FoundationInputErrorBuilder(requiredMessage, labelText, dataTypeAttribute, abidePatternAttribute);
			// place the input inside the <label> tag after the label text
			label.InnerHtml += selectInputFor.ToHtmlString();
			return new MvcHtmlString(label.ToString() + errorTextSmall);
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Create HTML for label above an input
		/// </summary>
		/// <param name="includeLabel">Determine if the label should be included in the output HTML</param>
		/// <param name="labelText">Text of the label</param>
		/// <param name="htmlFieldName">name of the input the label goes to</param>
		/// <param name="requiredAttribute">determine if "required" should be shown next to label</param>
		/// <returns>TagBuilder object for label HTML</returns>
		private static TagBuilder FoundationInputLabelBuilder(bool includeLabel, string labelText, string htmlFieldName, RequiredAttribute requiredAttribute)
		{
			var label = new TagBuilder("label");
			label.SetInnerText(labelText);
			label.Attributes.Add("for", htmlFieldName);
			// Add required text to label if the property is required
			if (requiredAttribute == null || !includeLabel) return label;
			var requiredSmall = new TagBuilder("small");
			requiredSmall.SetInnerText(" required");

			label.InnerHtml += requiredSmall.ToString();
			return label;
		}

		/// <summary>
		/// Create HTML for error below input to show from Abide javascript code
		/// </summary>
		/// <param name="requiredMessage">optional message to show inside the error HTML</param>
		/// <param name="labelText">label of the input the error is for</param>
		/// <param name="dataTypeAttribute">type of data the field should have</param>
		/// <param name="abidePatternAttribute"></param>
		/// <returns>TagBuilder object of error HTML</returns>
		private static TagBuilder FoundationInputErrorBuilder(string requiredMessage, string labelText, DataTypeAttribute dataTypeAttribute, FoundationAbidePatternAttribute abidePatternAttribute)
		{
			var errorTextSmall = new TagBuilder("small");
			errorTextSmall.AddCssClass("error");
			if (requiredMessage.IsNotNullOrEmpty())
			{
				errorTextSmall.SetInnerText(requiredMessage);
			}
			else
			{
				var message = new StringBuilder();
				message.Append(labelText).Append(" is required");
				
				if (dataTypeAttribute != null)
				{
					message.Append(" and must be ");
					switch (dataTypeAttribute.DataType)
					{
						case DataType.CreditCard:
							message.Append("a valid credit card number");
							break;
						case DataType.Currency:
							message.Append("a valid dollar amount");
							break;
						case DataType.Custom:
							message.Append("");
							break;
						case DataType.Date:
							message.Append("a valid date: MM-DD-YYYY");
							break;
						case DataType.DateTime:
							message.Append("a valid date and time: MM-DD-YYYY HH:MM:SS");
							break;
						case DataType.Duration:
							break;
						case DataType.EmailAddress:
							message.Append("a valid email address");
							break;
						case DataType.Html:
							break;
						case DataType.ImageUrl:
							break;
						case DataType.MultilineText:
							message.Append("text");
							break;
						case DataType.Password:
							break;
						case DataType.PhoneNumber:
							message.Append("a valid phone number");
							break;
						case DataType.PostalCode:
							message.Append("a valid postal (ZIP) code");
							break;
						case DataType.Text:
							message.Append("text");
							break;
						case DataType.Time:
							message.Append("a valid time: HH:MM:SS");
							break;
						case DataType.Upload:
							break;
						case DataType.Url:
							message.Append("a valid URL");
							break;
					}
				}

				if (abidePatternAttribute != null)
				{
					var pattern = abidePatternAttribute.AbidePattern.Split('_');
					if (pattern.Length > 0)
					{
						if (pattern[0] == "length")
						{
							message.Append(" and cannot be longer than ").Append(pattern[1]).Append(" characters");
						}
					}
				}

				errorTextSmall.SetInnerText(message.ToString());
			}
			return errorTextSmall;
		}

		/// <summary>
		/// Read attributes associated with the Model object
		/// </summary>
		/// <param name="htmlAttributes">Dictionary of htmlAttributes to add to based on Model Attributes</param>
		/// <param name="modelPropertyMemberExpression">MemberExpression used to read Model attributes</param>
		/// <param name="requiredMessage">reference to RequredMessage object, may return null</param>
		/// <param name="dataTypeAttribute">reference to DataType attribute to get the type of data the Model is</param>
		/// <param name="abidePatternAttribute"></param>
		/// <returns>RequiredAttribute object, may be null</returns>
		private static RequiredAttribute FoundationInputModelRequiredAttributeReader(
			ref IDictionary<string, object> htmlAttributes, MemberExpression modelPropertyMemberExpression,
			ref string requiredMessage, ref DataTypeAttribute dataTypeAttribute, ref FoundationAbidePatternAttribute abidePatternAttribute)
		{
			if (modelPropertyMemberExpression == null) return null;
			var requiredAttribute =
				modelPropertyMemberExpression.Member.GetCustomAttributes(typeof(RequiredAttribute), false)
											 .Cast<RequiredAttribute>()
											 .FirstOrDefault();

			if (requiredAttribute != null)
			{
				requiredMessage = requiredAttribute.ErrorMessage.IsNotNullOrEmpty() ? requiredAttribute.ErrorMessage : null;
				htmlAttributes.Add("required", "");
			}

			// if the Model (property) has the FoundationAbidePatternAttribute then add it to the html attributes on in the text input
			abidePatternAttribute =
				modelPropertyMemberExpression.Member.GetCustomAttributes(typeof(FoundationAbidePatternAttribute), false)
								.Cast<FoundationAbidePatternAttribute>()
								.FirstOrDefault();
			if (abidePatternAttribute != null)
			{
				htmlAttributes.Add("pattern", abidePatternAttribute.AbidePattern);
				if (requiredMessage.IsNullOrEmpty() && abidePatternAttribute.ValidationMessage.IsNotNullOrEmpty())
				{
					requiredMessage = abidePatternAttribute.ValidationMessage;
				}
			}

			dataTypeAttribute = modelPropertyMemberExpression.Member.GetCustomAttributes(typeof(DataTypeAttribute), false)
												.Cast<DataTypeAttribute>()
												.FirstOrDefault();
			return requiredAttribute;
		}
		#endregion
	}
}