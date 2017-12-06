using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
	public class RoleRequiredAttribute : RequiredAttribute
	{
		public bool IsRequiredForRoles { get; set; }

		public bool IsAuthenticated
		{
			get
			{
				return HttpContext.Current.Request.IsAuthenticated;
			}
		}

		public override bool IsValid(object value)
		{
			if (!this.IsRequiredForRoles && this.IsAuthenticated)
			{
				// if the field is not required for auth'ed users...always return valid
				return true;
			}
			else
			{
				return base.IsValid(value);
			}
		}
	}


	/// <summary>Provides an adapter for the <see cref="T:System.Runtime.CompilerServices.RequiredAttributeAttribute" /> attribute.</summary>
	public class RoleRequiredAttributeAdapter : DataAnnotationsModelValidator<RoleRequiredAttribute>
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.RequiredAttributeAttribute" /> class.</summary>
		/// <param name="metadata">The model metadata.</param>
		/// <param name="context">The controller context.</param>
		/// <param name="attribute">The required attribute.</param>
		public RoleRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, RoleRequiredAttribute attribute)
			: base(metadata, context, attribute)
		{
		}
		/// <summary>Gets a list of required-value client validation rules.</summary>
		/// <returns>A list of required-value client validation rules.</returns>
		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
		{
			var rule = new ModelClientValidationRequiredRule(base.ErrorMessage);
			if (!base.Attribute.IsRequiredForRoles && base.Attribute.IsAuthenticated)
			{
				//setting "true" rather than bool true which is serialized as "True"
				rule.ValidationParameters["allowempty"] = "true";
			}

			return new ModelClientValidationRequiredRule[] { rule };
		}
	}
}
