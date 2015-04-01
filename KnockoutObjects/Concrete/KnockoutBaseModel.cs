// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnockoutBaseModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the BaseModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace KnockoutObjects
{
    /// <summary>
    /// The base model, provides dynamic validation for all ViewModels, Properties and Collections declared on a given View Model. 
    /// </summary>
    public abstract class KnockoutBaseModel
    {
        /// <summary>
        /// The my type, used for reflection
        /// </summary>
        private Type myType;

        /// <summary>
        /// The <see cref="PropertyInfo"/> collection of <see cref="KnockoutBaseModel"/>.
        /// </summary>
        private IEnumerable<PropertyInfo> models;

        /// <summary>
        /// The <see cref="PropertyInfo"/> collection of <see cref="IKnockoutProperty"/>.
        /// </summary>
        private IEnumerable<PropertyInfo> properties;

        /// <summary>
        /// The <see cref="PropertyInfo"/> collection of <see cref="IKnockoutCollection"/>.
        /// </summary>
        private IEnumerable<PropertyInfo> collections;

        /// <summary>
        /// Initialises a new instance of the <see cref="KnockoutBaseModel"/> class.
        /// </summary>
        protected KnockoutBaseModel()
        {
            this.GatherBaseData();
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether has changes.
        /// </summary>
        public bool HasChanges { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether is new.
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has been saved.
        /// </summary>
        public bool HasBeenSaved { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether is valid.
        /// </summary>
        public bool IsValid { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether is in edit.
        /// </summary>
        public bool IsInEdit { get; protected set; }

        /// <summary>
        /// The gather base data.
        /// </summary>
        public void GatherBaseData()
        {
            // sets the type of the view model for use.
            this.myType = this.GetType();
            
            // store PropertyInfo of each group of objects
            this.models = this.GetProperties<KnockoutBaseModel>().ToList();
            this.properties = this.GetProperties<IKnockoutProperty>().ToList();
            this.collections = this.GetProperties<IKnockoutCollection>().ToList();

            // Push annotations to properties
            this.PushDataAnnotationsToProperties();
        }
        
        /// <summary>
        /// The update model state.
        /// </summary>
        /// <param name="updateType">
        /// The update Type.
        /// </param>
        public void UpdateModelState(Enums.ModelUpdateType updateType)
        {
            // Retrieve the instances of the properties
            var modelInstances = this.GetPropertyInstance<KnockoutBaseModel>(this.models).ToList();
            var propertyInstances = this.GetPropertyInstance<IKnockoutProperty>(this.properties).ToList();
            var collectionInstances = this.GetPropertyInstance<IKnockoutCollection>(this.collections).ToList();

            if (updateType != Enums.ModelUpdateType.RefreshState)
            {
                if (updateType != Enums.ModelUpdateType.EnterEditMode && updateType != Enums.ModelUpdateType.ExitEditMode)
                {
                    // if we are entering and exiting edit mode it is only for THIS specific model and not for any children, this prevents chaining.
                    modelInstances.ForEach(mi => mi.UpdateModelState(updateType));
                    collectionInstances.ForEach(ci => ci.UpdateCollectionState(updateType));
                }

                switch (updateType)
                {
                    case Enums.ModelUpdateType.CancelAnyChanges:
                        propertyInstances.ForEach(pi => pi.ResetValue());
                        break;
                    case Enums.ModelUpdateType.UpdateValuesAndValidate:
                        propertyInstances.ForEach(pi => pi.UpdateValue());
                        break;
                    case Enums.ModelUpdateType.SetSavedState:
                        propertyInstances.ForEach(pi => pi.UpdateValue());
                        propertyInstances.ForEach(pi => pi.SaveValue());
                        break;
                    case Enums.ModelUpdateType.EnterEditMode:
                        propertyInstances.ForEach(pi => pi.EditProperty());
                        break;
                    case Enums.ModelUpdateType.ExitEditMode:
                        propertyInstances.ForEach(pi => pi.CancelEdit());
                        break;
                    default:
                        throw new KnockoutModelException("Unrecognised ModelUpdateType");
                }
            }

            // set flags
            this.IsInEdit = propertyInstances.Any(pi => pi.IsInEdit) || modelInstances.Any(m => m.IsInEdit) || collectionInstances.Any(c => c.IsInEdit);
            this.HasChanges = modelInstances.Any(m => m.HasChanges) || propertyInstances.Any(p => p.HasChanges) || collectionInstances.Any(p => p.HasChanges);
            this.IsValid = !(modelInstances.Any(m => !m.IsValid) || propertyInstances.Any(p => !p.IsValid) || collectionInstances.Any(p => !p.IsValid));
            this.HasBeenSaved = !(modelInstances.Any(m => !m.HasBeenSaved) || propertyInstances.Any(p => !p.HasBeenSaved) || collectionInstances.Any(p => !p.HasBeenSaved));
        }

        /// <summary>
        /// The push data annotations to properties, pushes annotations applied to each <see cref="KnockoutProperty{TValueType, TModelType}"/> into the object themselves. 
        /// </summary>
        private void PushDataAnnotationsToProperties()
        {
            this.properties.ToList().ForEach(p => this.SetAnnotations(this.GetDataAnnotations(p), this.GetPropertyInstance<IKnockoutProperty>(p)));
        }

        /// <summary>
        /// The get data annotations, retrieves all data annotations applied to a specified property. 
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{ValidationAttribute}"/>.
        /// </returns>
        private IEnumerable<ValidationAttribute> GetDataAnnotations(PropertyInfo property)
        {
            return this.myType.GetProperty(property.Name).GetCustomAttributes(false).OfType<ValidationAttribute>().ToArray();
        }

        /// <summary>
        /// The get properties, returns all property info's for a specific Type of property. 
        /// </summary>
        /// <typeparam name="TProperty">
        ///  the Type of property to return property info's for
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{PropertyInfo}"/>.
        /// </returns>
        private IEnumerable<PropertyInfo> GetProperties<TProperty>()
        {
            return (from prop in this.myType.GetProperties()
                    where typeof(TProperty).IsAssignableFrom(prop.PropertyType)
                    select prop).ToList();
        }

        /// <summary>
        /// The get property instance, gets the instances of a given property on this model from the property info. 
        /// </summary>
        /// <param name="propertiesToGet">
        /// The properties to get.
        /// </param>
        /// <typeparam name="TProperty">
        /// The Type of object to return
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{TProperty}"/>.
        /// </returns>
        private IEnumerable<TProperty> GetPropertyInstance<TProperty>(IEnumerable<PropertyInfo> propertiesToGet)
        {
            return (from prop in propertiesToGet
                    select prop.GetGetMethod() into get
                    where !get.IsStatic && get.GetParameters().Length == 0
                    select (TProperty)get.Invoke(this, null) into item
                    where item != null
                    select item).ToList();
        }

        /// <summary>
        /// The get property instance, gets the instance of a given property on this model from the property info. 
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <typeparam name="TProperty">
        /// The type of the property to get.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TProperty"/>.
        /// </returns>
        /// <exception cref="KnockoutModelException">
        /// Thrown when either the get method is parameterised or static, or when the get method returns null for the item
        /// </exception>
        private TProperty GetPropertyInstance<TProperty>(PropertyInfo property)
        {
            var get = property.GetGetMethod();
            if (!get.IsStatic && get.GetParameters().Length == 0)
            {
                var prop = (TProperty)get.Invoke(this,null);
                if (prop == null)
                {
                    throw new KnockoutModelException(string.Format("ViewModel: {0} | Unable to retrieve object {1} from PropertyInfo, please check the access modifier of the property.", this.myType.UnderlyingSystemType.Name, property.Name));
                }

                return prop;
            }

            throw new KnockoutModelException(string.Format("ViewModel: {0} | Property {1}'s Get method is either static or has 1 or more parameters on it's get method, please check the get method of the property.", this.myType.UnderlyingSystemType.Name, property.Name));
        }

        /// <summary>
        /// The set annotations.
        /// </summary>
        /// <param name="annotations">
        /// The annotations to apply to each <see cref="KnockoutProperty{TValueType, TModelType}"/>
        /// </param>
        /// <param name="property">
        /// The property.
        /// </param>
        private void SetAnnotations(IEnumerable<ValidationAttribute> annotations, IKnockoutProperty property)
        {
            property.SetAttributes(annotations, this.myType.UnderlyingSystemType.Name);
        }
    }
}
