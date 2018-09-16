using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Loads a model from a file as a binary, triangle tree.
    /// The first token in the file must represent the top-level node.The following lines each represent a level in the tree.
    /// </summary>
    /// <typeparam name="T">The type of value represented by the nodes in the tree.</typeparam>
    public class FileTriangleTreeModelLoader<T> : IModelLoader<T>
    {
        /// <summary>
        /// The name of the file from which the model is loaded.
        /// </summary>
        public string Filename { get; }

        private Func<string, IEnumerable<string>> _splitter;

        /// <summary>
        /// Creates an instance of the loader and prepares it for loading a model from the specified file.
        /// </summary>
        /// <param name="filename">The name of the file from which the model will be loaded.</param>
        /// <param name="splitter">A delegate, that specifies how each value in a line in the file is divided into value and nodes. If null
        /// then the default method is used, i.e. each value is separated by a whitespace character (' ').</param>
        public FileTriangleTreeModelLoader(string filename, Func<string, IEnumerable<string>> splitter = null)
        {
            Filename = filename;
            _splitter = splitter ?? (o => o.Split(' '));
        }

        /// <summary>
        /// Loads the model from the file specified in the constructor.
        /// </summary>
        /// <returns>The loaded model.</returns>
        public IModel<T> LoadModel()
        {
            using (var reader = new StreamReader(Filename))
            {
                var line = reader.ReadLine();
                if (line == null)
                    throw new Exception($"The file ({Filename}) does not contain any data.");

                var rootNode = ParseLinesFromHere(line, reader).Single();
                var model = new GenericModel<T>(rootNode);
                return model;
            }
        }

        private IValueNode<T>[] ParseLinesFromHere(string line, TextReader textReader)
        {
            var values = ParseLine(line);
            var lineBelow = textReader.ReadLine();
            if (lineBelow == null)
            {
                // No lines below => We are processing the last line.
                var nodes = values.Select(o => new GenericValueNode<T>(o, new IValueNode<T>[] { }));
                return nodes.ToArray();
            }
            else
            {
                var nodesBelow = ParseLinesFromHere(lineBelow, textReader);
                var nodes = new IValueNode<T>[nodesBelow.Length - 1]; // Remember, there is one more node in the row below this.

                {
                    var i = 0;
                    foreach (var value in values)
                    {
                        nodes[i] = new GenericValueNode<T>(value, new IValueNode<T>[] { nodesBelow[i], nodesBelow[i + 1] });
                        i++;
                    }
                }

                return nodes;
            }
        }

        private IEnumerable<T> ParseLine(string line)
        {
            var sValues = _splitter(line);
            var values = sValues.Select(o => (T)Convert.ChangeType(o, typeof(T)));
            return values;
        }
    }
}
