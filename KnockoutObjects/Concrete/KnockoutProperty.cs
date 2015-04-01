// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnockoutProperty.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   validated property for use with KnockoutMVC provides base value and inline validation information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KnockoutObjects
{
    /// <summary>
    /// validated property for use with KnockoutMVC provides base value and inline validation information. 
    /// </summary>
    /// <typeparam name="TValueType"> the underlying data type of <see cref="ViewValue"/> and <see cref="OriginalValue"/></typeparam>
    /// <typeparam name="TModelType"> The view model the property is situated on, used for validation.</typeparam>
    public class KnockoutProperty<TValueType, TModelType> : IKnockoutProperty, ICloneable<KnockoutProperty<TValueType, TModelType>>, IEquatable<KnockoutProperty<TValueType, TModelType>>
        where TModelType : KnockoutBaseModel, IKnockoutModel<TModelType>, new()
        where TValueType : IComparable<TValueType>
    {
        /// <summary>
        /// The attributes.
        /// </summary>
        private IEnumerable<ValidationAttribute> validationAttributes;

        /// <summary>
        /// The parent model.
        /// </summary>
        private string parentModel = string.Empty;

        /// <summary>
        /// Initialises a new instance of the <see cref="KnockoutProperty{TValueType,TModelType}"/> class. 
        /// </summary>
        public KnockoutProperty()
        {
            this.MyErrors = new List<string>();
            this.IsInEdit = false;
            this.IsValid = true;
            this.HasBeenSaved = false;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="KnockoutProperty{TValueType,TModelType}"/> class.
        /// </summary>
        /// <param name="initialValue">
        /// The initial value.
        /// </param>
        public KnockoutProperty(TValueType initialValue)
            : this()
        {
            this.ViewValue = initialValue;
            this.OriginalValue = initialValue;
            this.EditValue = initialValue;
        }

        /// <summary>
        /// Gets a value indicating whether is in edit.
        /// </summary>
        public bool IsInEdit { get; private set; }

        /// <summary>
        /// Gets a value indicating whether has been saved.
        /// </summary>
        public bool HasBeenSaved { get; private set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TValueType OriginalValue { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TValueType ViewValue { get; set; }

        /// <summary>
        /// Gets or sets the edit value.
        /// </summary>
        public TValueType EditValue { get; set; }

        /// <summary>
        /// Gets or sets the my errors.
        /// </summary>
        public List<string> MyErrors { get; set; }

        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether has changes.
        /// </summary>
        public bool HasChanges
        {
            get
            {
                return !this.OriginalValue.Equals(this.ViewValue);
            }
        }

        /// <summary>
        /// Gets a value indicating whether can validate.
        /// </summary>
        private bool CanValidate
        {
            get
            {
                return this.validationAttributes != null;
            }
        }

        /// <summary>
        /// The set attributes.
        /// </summary>
        /// <param name="attributes">
        /// The attributes.
        /// </param>
        /// <param name="parent">
        /// The parent.
        /// </param>
        public void SetAttributes(IEnumerable<ValidationAttribute> attributes, string parent)
        {
            this.validationAttributes = attributes;
            this.parentModel = parent;
        }

        /// <summary>
        /// The save value.
        /// </summary>
        public void SaveValue()
        {
            if (this.IsValid && this.HasChanges)
            {
                this.OriginalValue = this.ViewValue;
                this.HasBeenSaved = true;
            }
        }

        #region Implementation of ICloneable

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public KnockoutProperty<TValueType, TModelType> Clone()
        {
            return new KnockoutProperty<TValueType, TModelType>
                       {
                           OriginalValue = this.OriginalValue,
                           ViewValue = this.ViewValue,
                           validationAttributes = this.validationAttributes,
                           parentModel = this.parentModel,
                           EditValue = this.EditValue
                       };
        }

        #endregion

        #region Implementation of IEquatable<ValidatedProperty<TValueType>>

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(KnockoutProperty<TValueType, TModelType> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.parentModel, other.parentModel)
                && this.IsInEdit.Equals(other.IsInEdit)
                && this.HasBeenSaved.Equals(other.HasBeenSaved)
                && EqualityComparer<TValueType>.Default.Equals(this.OriginalValue, other.OriginalValue)
                && EqualityComparer<TValueType>.Default.Equals(this.ViewValue, other.ViewValue)
                && EqualityComparer<TValueType>.Default.Equals(this.EditValue, other.EditValue)
                && this.IsValid.Equals(other.IsValid);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.IsInEdit.GetHashCode();
                hashCode = (hashCode * 397) ^ this.HasBeenSaved.GetHashCode();
                hashCode = (hashCode * 397) ^ EqualityComparer<TValueType>.Default.GetHashCode(this.OriginalValue);
                hashCode = (hashCode * 397) ^ EqualityComparer<TValueType>.Default.GetHashCode(this.ViewValue);
                hashCode = (hashCode * 397) ^ EqualityComparer<TValueType>.Default.GetHashCode(this.EditValue);
                hashCode = (hashCode * 397) ^ (this.MyErrors != null ? this.MyErrors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.IsValid.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            return other as KnockoutProperty<TValueType, TModelType> != null && this.Equals(other as KnockoutProperty<TValueType, TModelType>);
        }

        #endregion

        /// <summary>
        /// The edit value.
        /// </summary>
        public void EditProperty()
        {
            this.IsInEdit = true;
        }

        /// <summary>
        /// The update value.
        /// </summary>
        public void UpdateValue()
        {
            this.IsInEdit = false;
            if (this.EditValue.Equals(this.OriginalValue))
            {
                this.ViewValue = this.OriginalValue;
                return;
            }

            this.Validate();
            if (this.IsValid)
            {
                this.ViewValue = this.EditValue;
            }
            else
            {
                this.IsInEdit = true;
            }
        }

        /// <summary>
        /// The cancel edit.
        /// </summary>
        public void CancelEdit()
        {
            this.IsInEdit = false;
            if (!this.EditValue.Equals(this.ViewValue))
            {
                this.EditValue = this.ViewValue;
            }
        }

        /// <summary>
        /// The reset value.
        /// </summary>
        public void ResetValue()
        {
            this.IsInEdit = false;
            this.ViewValue = this.OriginalValue;
            this.EditValue = this.OriginalValue;
        }

        /// <summary>
        /// validates the property and stores the resulting messages in a list. 
        /// </summary>
        private void Validate()
        {
            if (!this.CanValidate)
            {
                throw new KnockoutModelException(string.Format("Attempting to validate a property on view model {{{0}}}, please ensure you are implementing the BaseModel model correctly", this.parentModel));
            }

            this.IsValid = true;
            var context = new ValidationContext(this.EditValue, null, null);
            var results = new List<ValidationResult>();

            this.validationAttributes.ToList().ForEach(a => Validator.TryValidateValue(this.EditValue, context, results, new List<ValidationAttribute> { a }));

            this.MyErrors = new List<string>();
            if (results.Any())
            {
                this.IsValid = false;
                results.Reverse();
                results.ForEach(error => this.MyErrors.Add(error.ErrorMessage.ToString(CultureInfo.InvariantCulture)));
            }
        }
    }
}