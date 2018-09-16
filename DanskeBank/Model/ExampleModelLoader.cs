namespace Model
{
    /// <summary>
    /// An implementation of the <see cref="IModelLoader{T}"/>, that loads the simple example from the exercise.
    /// </summary>
    public class ExampleModelLoader : IModelLoader<int>
    {
        /// <summary>
        /// When loading the hardcoded values of the simple example are added to the model and returned.
        /// </summary>
        /// <returns>The loaded model.</returns>
        public IModel<int> LoadModel()
        {
            var node14 = new GenericValueNode<int>(4);
            var node24 = new GenericValueNode<int>(5);
            var node34 = new GenericValueNode<int>(2);
            var node44 = new GenericValueNode<int>(3);

            var node13 = new GenericValueNode<int>(1, node14, node24);
            var node23 = new GenericValueNode<int>(5, node24, node34);
            var node33 = new GenericValueNode<int>(9, node34, node44);

            var node12 = new GenericValueNode<int>(8, node13, node23);
            var node22 = new GenericValueNode<int>(9, node23, node33);

            var node11 = new GenericValueNode<int>(1, node12, node22);

            var model = new GenericModel<int>(node11);

            return model;
        }
    }
}
