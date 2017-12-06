using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel;
using System.Linq.Expressions;
using HuskyRescue.Core.ViewModel.Entity;

namespace HuskyRescue.Web.Infrastructure.Extensions
{
	public static class HtmlHelpers
	{
		public static IHtmlString LinkToRemoveNestedForm(this HtmlHelper htmlHelper, string linkText, string container, string deleteElement)
		{
			var js = string.Format("javascript:removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);
			var tb = new TagBuilder("a");
			tb.Attributes.Add("href", "#");
			tb.Attributes.Add("onclick", js);
			tb.InnerHtml = linkText;
			var tag = tb.ToString(TagRenderMode.Normal);
			return MvcHtmlString.Create(tag);
		}

		private static string JsEncode(this string s)
		{
			if (string.IsNullOrEmpty(s)) return "";
			int i;
			var len = s.Length;
			var sb = new StringBuilder(len + 4);

			for (i = 0; i < len; i += 1)
			{
				var c = s[i];
				switch (c)
				{
					case '>':
					case '"':
					case '\\':
						sb.Append('\\');
						sb.Append(c);
						break;
					case '\b':
						sb.Append("\\b");
						break;
					case '\t':
						sb.Append("\\t");
						break;
					case '\n':
						//sb.Append("\\n");
						break;
					case '\f':
						sb.Append("\\f");
						break;
					case '\r':
						//sb.Append("\\r");
						break;
					default:
						if (c < ' ')
						{
							//t = "000" + Integer.toHexString(c); 
							var tmp = new string(c, 1);
							var t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
							sb.Append("\\u" + t.Substring(t.Length - 4));
						}
						else
						{
							sb.Append(c);
						}
						break;
				}
			}
			return sb.ToString();
		}

		public static IHtmlString LinkToAddNestedForm<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText, string containerElement, string counterElement, string collectionProperty, Type nestedType)
		{
			var ticks = DateTime.UtcNow.Ticks;
			var nestedObject = Activator.CreateInstance(nestedType);
			var partial = htmlHelper.EditorFor(x => nestedObject).ToHtmlString().JsEncode();
			partial = partial.Replace("id=\\\"nestedObject", "id=\\\"" + collectionProperty + "_" + ticks + "_");
			partial = partial.Replace("name=\\\"nestedObject", "name=\\\"" + collectionProperty + "[" + ticks + "]");
			var js = string.Format("javascript:addNestedForm('{0}','{1}','{2}','{3}');return false;", containerElement, counterElement, ticks, partial);
			var tb = new TagBuilder("a");
			tb.Attributes.Add("href", "#");
			tb.Attributes.Add("onclick", js);
			tb.InnerHtml = linkText;
			var tag = tb.ToString(TagRenderMode.Normal);
			return MvcHtmlString.Create(tag);
		}

		// Extension method
		// http://stackoverflow.com/questions/4896439/action-image-mvc3-razor
		public static MvcHtmlString ActionImage(this HtmlHelper html, string action, object routeValues, string imagePath, string alt)
		{
			var url = new UrlHelper(html.ViewContext.RequestContext);

			// build the <img> tag
			var imgBuilder = new TagBuilder("img");
			imgBuilder.MergeAttribute("src", url.Content(imagePath));
			imgBuilder.MergeAttribute("alt", alt);
			var imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

			// build the <a> tag
			var anchorBuilder = new TagBuilder("a");
			anchorBuilder.MergeAttribute("href", url.Action(action, routeValues));
			anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
			var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

			return MvcHtmlString.Create(anchorHtml);
		}

		public static MvcHtmlString Button(this HtmlHelper helper, string text, IDictionary<string, object> htmlAttributes)
		{
			var builder = new TagBuilder("button") {InnerHtml = text};
			builder.MergeAttributes(htmlAttributes);
			return MvcHtmlString.Create(builder.ToString());
		}

		/// <summary>
		/// Begins a collection item by inserting either a previously used .Index hidden field value for it or a new one.
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <param name="html"></param>
		/// <param name="collectionName">The name of the collection property from the Model that owns this item.</param>
		/// <returns></returns>
		public static IDisposable BeginCollectionItem<TModel>(this HtmlHelper<TModel> html, string collectionName)
		{
			if (String.IsNullOrEmpty(collectionName))
				throw new ArgumentException("collectionName is null or empty.", "collectionName");

			var collectionIndexFieldName = String.Format("{0}.Index", collectionName);

			var itemIndex = html.ViewData.ContainsKey(JQueryTemplatingEnabledKey) ? "{{:index1}}" : GetCollectionItemIndex(collectionIndexFieldName);

			var collectionItemName = String.Format("{0}[{1}]", collectionName, itemIndex);

			var indexField = new TagBuilder("input");
			indexField.MergeAttributes(new Dictionary<string, string>
			                           {
                { "name", collectionIndexFieldName },
                { "value", itemIndex },
                { "type", "hidden" },
                { "autocomplete", "off" }
            });

			html.ViewContext.Writer.WriteLine(indexField.ToString(TagRenderMode.SelfClosing));
			return new CollectionItemNamePrefixScope(html.ViewData.TemplateInfo, collectionItemName);
		}

		private const string JQueryTemplatingEnabledKey = "__BeginCollectionItem_jQuery";

		public static MvcHtmlString CollectionItemJQueryTemplate<TModel, TCollectionItem>(this HtmlHelper<TModel> html, string partialViewName, TCollectionItem modelDefaultValues)
		{
			var viewData = new ViewDataDictionary<TCollectionItem>(modelDefaultValues) {{JQueryTemplatingEnabledKey, true}};
			return html.Partial(partialViewName, modelDefaultValues, viewData);
		}

		/// <summary>
		/// Tries to reuse old .Index values from the HttpRequest in order to keep the ModelState consistent
		/// across requests. If none are left returns a new one.
		/// </summary>
		/// <param name="collectionIndexFieldName"></param>
		/// <returns>a GUID string</returns>
		private static string GetCollectionItemIndex(string collectionIndexFieldName)
		{
			var previousIndices = (Queue<string>)HttpContext.Current.Items[collectionIndexFieldName];
			if (previousIndices != null)
				return previousIndices.Count > 0 ? previousIndices.Dequeue() : Guid.NewGuid().ToString();
			HttpContext.Current.Items[collectionIndexFieldName] = previousIndices = new Queue<string>();

			var previousIndicesValues = HttpContext.Current.Request[collectionIndexFieldName];
			if (String.IsNullOrWhiteSpace(previousIndicesValues))
				return previousIndices.Count > 0 ? previousIndices.Dequeue() : Guid.NewGuid().ToString();
			foreach (var index in previousIndicesValues.Split(','))
				previousIndices.Enqueue(index);

			return previousIndices.Count > 0 ? previousIndices.Dequeue() : Guid.NewGuid().ToString();
		}

		private class CollectionItemNamePrefixScope : IDisposable
		{
			private readonly TemplateInfo _templateInfo;
			private readonly string _previousPrefix;

			public CollectionItemNamePrefixScope(TemplateInfo templateInfo, string collectionItemName)
			{
				_templateInfo = templateInfo;

				_previousPrefix = templateInfo.HtmlFieldPrefix;
				templateInfo.HtmlFieldPrefix = collectionItemName;
			}

			public void Dispose()
			{
				_templateInfo.HtmlFieldPrefix = _previousPrefix;
			}
		}

		public static HtmlString OrderedList(IEnumerable<string> items)
		{
			var sb = new StringBuilder();
			var orderedList = new TagBuilder("ol");
			foreach (var item in items)
			{
				var listItem = new TagBuilder("li");
				listItem.SetInnerText(item);
				sb.AppendLine(listItem.ToString(TagRenderMode.Normal));
			}
			orderedList.InnerHtml = sb.ToString();
			return new HtmlString(orderedList.ToString(TagRenderMode.Normal));
		}

		public static MvcHtmlString Address(this HtmlHelper helper, Address address)
		{
			var span = new TagBuilder("span");
			if (address == null) return new MvcHtmlString(span.ToString(TagRenderMode.Normal));
			var link = new TagBuilder("a");

			link.MergeAttribute("href", "http://maps.google.com/?q=1200 " + address);
			link.SetInnerText(address.ToString());

			span.InnerHtml = link.ToString(TagRenderMode.Normal);
			return new MvcHtmlString(span.ToString(TagRenderMode.Normal));
		}

		public static MvcHtmlString CustomRadioButton(this HtmlHelper helper, string name, bool validate, IEnumerable<SelectListItem> radioList)
		{
			var radiobutton = new StringBuilder();
			var div = new TagBuilder("div");
			div.MergeAttribute("style", "display:inline-block;margin-left: 5px;margin-right: 5px");
			foreach (var item in radioList)
			{
				var id = name.Replace('[', '_').Replace(']', '_').Replace('.', '_') + item.Text;
				var radio = new TagBuilder("input");
				radio.Attributes.Add("type", "radio");
				radio.Attributes.Add("name", name);
				radio.Attributes.Add("id", id);
				radio.Attributes.Add("value", item.Value);
				radio.Attributes.Add("class", "regular-radio");
				radio.Attributes.Add("data-val", validate.ToString());
				radio.Attributes.Add("data-val-required", "Required");

				var labelRadio = new TagBuilder("label");
				labelRadio.MergeAttribute("for", id);

				var labelText = new TagBuilder("label");
				labelText.MergeAttribute("for", id);
				labelText.MergeAttribute("style", "display:inline-block");
				labelText.SetInnerText(item.Text);

				div.InnerHtml = radio + labelRadio.ToString() + labelText;

				radiobutton.Append(div);
			}
			return MvcHtmlString.Create(radiobutton.ToString());
		}

		public static MvcHtmlString ZurbRadioInput(this HtmlHelper helper, string name, string labelText, string optionText, object value, bool required, bool isChecked)
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

		public static MvcHtmlString CustomCheckBox(this HtmlHelper helper, string name, bool validate, string textLabel)
		{
			var checkboxInput = new StringBuilder();
			var checkbox = new TagBuilder("input");
			var div = new TagBuilder("div");
			div.MergeAttribute("style", "display:inline-block;margin-left: 5px;margin-right: 5px");

			var id = name.Replace('[', '_').Replace(']', '_').Replace('.', '_') + textLabel;

			checkbox.Attributes.Add("type", "checkbox");
			checkbox.Attributes.Add("name", name);
			checkbox.Attributes.Add("id", id);
			checkbox.Attributes.Add("value", "true");
			checkbox.Attributes.Add("class", "regular-checkbox");
			checkbox.Attributes.Add("data-val", validate.ToString());
			checkbox.Attributes.Add("data-val-required", "Required");

			var labelCheck = new TagBuilder("label");
			labelCheck.MergeAttribute("for", id);

			var labelText = new TagBuilder("label");
			labelText.MergeAttribute("for", id);
			labelText.MergeAttribute("style", "display:inline-block");
			labelText.SetInnerText(textLabel);

			div.InnerHtml = labelText + checkbox.ToString() + labelCheck;

			checkboxInput.Append(div);

			return MvcHtmlString.Create(checkboxInput.ToString());
		}

		public static IHtmlString DropDownListWithLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string label, IEnumerable<SelectListItem> items, string blankOption, object htmlAttributes = null)
		{
			var l = new TagBuilder("label");
			var br = new TagBuilder("br");

			var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
			var mergedAttributes = helper.GetUnobtrusiveValidationAttributes(ExpressionHelper.GetExpressionText(expression), metadata);

			if (htmlAttributes != null)
			{
				foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(htmlAttributes))
				{
					object value = descriptor.GetValue(htmlAttributes);
					mergedAttributes.Add(descriptor.Name, value);
				}
			}

			l.InnerHtml = label + br.ToString(TagRenderMode.SelfClosing) + helper.DropDownListFor(expression, items, blankOption, mergedAttributes);
			return MvcHtmlString.Create(l.ToString(TagRenderMode.Normal));
		}
	}
}
