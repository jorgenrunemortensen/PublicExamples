using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// An implementation of this interface represents a node having a value and a set of child nodes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValueNode<T>
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Accesses the underlaying enumeration to the child nodes.
        /// </summary>
        IEnumerable<IValueNode<T>> ChildNodes { get; }

        /// <summary>
        /// Evaluates the child nodes and returns them in an array.
        /// </summary>
        /// <returns></returns>
        IValueNode<T>[] GetChildNodes();
    }
}
