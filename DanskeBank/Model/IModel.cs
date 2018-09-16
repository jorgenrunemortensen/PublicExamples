namespace Model
{
    /// <summary>
    /// The model of the exercise. I.e. a triangle tree having a root node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModel<T>
    {
        /// <summary>
        /// The root node of the triangle tree in the model.
        /// </summary>
        IValueNode<T> RootNode { get; }
    }
}
