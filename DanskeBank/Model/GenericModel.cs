namespace Model
{
    /// <summary>
    /// A generic model representing a generic data mode containing a value tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericModel<T> : IModel<T>
    {
        /// <summary>
        /// The root node of the tree in the model.
        /// </summary>
        public IValueNode<T> RootNode { get; }

        /// <summary>
        /// Creates an instance of the generic model by setting the root node of the tree.
        /// </summary>
        /// <param name="rootNode">The root node of the tree.</param>
        public GenericModel(IValueNode<T> rootNode)
        {
            RootNode = rootNode;
        }
    }
}
