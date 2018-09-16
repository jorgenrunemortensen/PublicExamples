using System.Collections.Generic;
using System.Linq;

namespace Model
{
    /// <summary>
    /// A generic implementation of a value node.
    /// The class is immutable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericValueNode<T> : IValueNode<T>
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Provides access to the child nodes.
        /// </summary>
        public IEnumerable<IValueNode<T>> ChildNodes { get; }

        /// <summary>
        /// Constructs an instance of the class with its value and child nodes.
        /// The constructor makes the instance reference the enumerable to as the child nodes.
        /// </summary>
        /// <param name="value">The value for the node.</param>
        /// <param name="childNodes">The childs nodes to the node.</param>
        public GenericValueNode(T value, IEnumerable<IValueNode<T>> childNodes)
        {
            Value = value;
            ChildNodes = childNodes;
        }

        /// <summary>
        /// Constructs an instance of the class with its value and child nodes.
        /// The child nodes are provided as an unlimited list of parameters to the constructor.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="childNodes">The child nodes to the node.</param>
        public GenericValueNode(T value, params IValueNode<T>[] childNodes)
        {
            Value = value;
            ChildNodes = childNodes;
        }

        /// <summary>
        /// Evaluates all child nodes and return the evaluated child nodes in an array.
        /// </summary>
        /// <returns>An array of the child nodes.</returns>
        public IValueNode<T>[] GetChildNodes()
        {
            return ChildNodes.ToArray();
        }
    }
}
