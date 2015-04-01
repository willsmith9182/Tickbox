// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnockoutCollection.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The View Model Collection, a class to hold and manipulate collections upon a view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace KnockoutObjects
{
    /// <summary>
    /// The View Model Collection, a class to hold and manipulate collections upon a view model.
    /// </summary>
    /// <typeparam name="T">
    /// The Type of view Model to store in a list
    /// </typeparam>
    public sealed class KnockoutCollection<T> : IEquatable<KnockoutCollection<T>>, ICloneable<KnockoutCollection<T>>, IKnockoutCollection where T : KnockoutBaseModel, IKnockoutModel<T>, new()
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="KnockoutCollection{T}"/> class.
        /// </summary>
        public KnockoutCollection()
        {
            this.Original = new List<T>();
            this.Current = new List<T>();
            this.NewItem = new T();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="KnockoutCollection{T}"/> class.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public KnockoutCollection(params T[] items)
            : this()
        {
            foreach (var item in items)
            {
                this.Original.Add(item);
                this.Current.Add(item.Clone());
            }
        }

        /// <summary>
        /// Gets or sets the original.
        /// </summary>
        public List<T> Original { get; set; }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        public List<T> Current { get; set; }

        /// <summary>
        /// Gets or sets the new item.
        /// </summary>
        public T NewItem { get; set; }

        /// <summary>
        /// Gets a value indicating whether has been saved.
        /// </summary>
        public bool HasBeenSaved { get; private set; }

        /// <summary>
        /// Gets a value indicating whether has changes.
        /// </summary>
        public bool HasChanges { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is in edit.
        /// </summary>
        public bool IsInEdit { get; private set; }

        /// <summary>
        /// Gets a value indicating whether has items.
        /// </summary>
        public bool HasItems
        {
            get
            {
                return this.Current.Any();
            }
        }

        /// <summary>
        /// The update collection state.
        /// </summary>
        /// <param name="updateType">
        /// The update Type.
        /// </param>
        public void UpdateCollectionState(Enums.ModelUpdateType updateType)
        {
            if (updateType != Enums.ModelUpdateType.RefreshState)
            {
                switch (updateType)
                {
                    case Enums.ModelUpdateType.CancelAnyChanges:
                        this.CancelChanges();
                        break;
                    case Enums.ModelUpdateType.UpdateValuesAndValidate:
                        this.Current.ForEach(t => t.UpdateModelState(updateType));
                        break;
                    case Enums.ModelUpdateType.SetSavedState:
                        this.Current.ForEach(t => t.UpdateModelState(updateType));
                        this.SaveChanges();
                        break;
                }
            }

            this.IsInEdit = this.Current.Any(t => t.IsInEdit);
            this.IsValid = this.Current.All(t => t.IsValid);
            this.HasChanges = this.Current.Any(t => t.HasChanges) || !this.Current.SequenceEqual(this.Original);
            this.HasBeenSaved = this.Current.SequenceEqual(this.Original) && this.Current.All(t => t.HasBeenSaved);
        }

        /// <summary>
        /// The add new item.
        /// </summary>
        public void AddNewItem()
        {
            this.NewItem.UpdateModelState(Enums.ModelUpdateType.UpdateValuesAndValidate);
            if (this.NewItem.IsValid)
            {
                this.Current.Add(this.NewItem);
                this.ResetNewItem();
            }
        }

        /// <summary>
        /// The remove item.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void RemoveItem(int index)
        {
            if (this.HasItems && (index >= 0 && index <= this.Current.Count()))
            {
                this.Current.RemoveAt(index);
            }
        }

        /// <summary>
        /// The reset new item.
        /// </summary>
        public void ResetNewItem()
        {
            this.NewItem = new T();
        }

        #region Implementation of IEquatable<ViewModelCollection<T>>

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(KnockoutCollection<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Original.SequenceEqual(other.Original)
                && this.Current.SequenceEqual(other.Current)
                && this.NewItem.Equals(other.NewItem);
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
            return other as KnockoutCollection<T> != null && this.Equals(other as KnockoutCollection<T>);
        }

        #region Equality members

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
                var hashCode = this.Original != null ? this.Original.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (this.Current != null ? this.Current.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(this.NewItem);
                return hashCode;
            }
        }

        #endregion

        #endregion

        #region Implementation of ICloneable<T>

        /// <summary>
        /// The clone (deep copy).
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public KnockoutCollection<T> Clone()
        {
            var newItem = new KnockoutCollection<T>();
            this.Original.ForEach(t => newItem.Original.Add(t.Clone()));
            this.Current.ForEach(t => newItem.Current.Add(t.Clone()));
            newItem.NewItem = this.NewItem.Clone();
            return newItem;
        }

        #endregion

        /// <summary>
        /// The save changes.
        /// </summary>
        private void SaveChanges()
        {
            this.Original.Clear();
            this.Current.ForEach(t => this.Original.Add((T)t.Clone()));
        }

        /// <summary>
        /// The cancel changes.
        /// </summary>
        private void CancelChanges()
        {
            this.Current.Clear();
            this.Original.ForEach(t => this.Current.Add((T)t.Clone()));
        }
    }
}
