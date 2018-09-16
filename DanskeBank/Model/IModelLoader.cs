namespace Model
{
    /// <summary>
    /// An implementation of this interface can load a model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelLoader<T>
    {
        /// <summary>
        /// When this model is invoked, then the model is loaded.
        /// </summary>
        /// <returns>The loaded model.</returns>
        IModel<T> LoadModel();
    }
}
