// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeNode.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the TreeNode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The tree node.
    /// </summary>
    public partial class TreeNode : IEquatable<TreeNode>, IKeyComparable<TreeNode>, IScaffold, IEntity
    {
        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(TreeNode other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.TaxonomyId == other.TaxonomyId
                && this.TreeNodeId == other.TreeNodeId
                && this.ParentTreeNodeId == other.ParentTreeNodeId
                && this.NodeId == other.NodeId
                && this.IsScaffold.Equals(other.IsScaffold);
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
                var hashCode = this.TaxonomyId;
                hashCode = (hashCode * 397) ^ this.TreeNodeId;
                hashCode = (hashCode * 397) ^ this.ParentTreeNodeId.GetHashCode();
                hashCode = (hashCode * 397) ^ this.NodeId;
                hashCode = (hashCode * 397) ^ this.IsScaffold.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        /// <summary>
        /// The keys match.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool KeysMatch(TreeNode other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.TreeNodeId == other.TreeNodeId;
        }

        public int Key
        {
            get
            {
                return this.TreeNodeId;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((TreeNode)obj);
        }
    }
}
