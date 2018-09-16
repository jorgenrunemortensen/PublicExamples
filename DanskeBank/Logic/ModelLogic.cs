using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    /// <summary>
    /// This class is meant for applying logic on a data model.
    /// </summary>
    public static class ModelLogic
    {
        /// <summary>
        /// Finds the maximum sum of the node values passed in a path in a tree.
        /// The method will traverse through the tree using the rule in isValidChildPath and return the sum of the node values on the path 
        /// giving the maximum value.
        /// </summary>
        /// <param name="model">The model must be an integer implementation of an IModel. The method uses the RootNode of the model as the 
        /// entry to the binary tree.</param>
        /// <param name="isValidChildPath">Delegate that determines whether the logic can use the path to the child node (second parameter) 
        /// from a parent node (first parameter).</param>
        /// <returns>The maximum sum.</returns>
        public static int GetMaxSum(IModel<int> model, Func<IValueNode<int>, IValueNode<int>, bool> isValidChildPath)
        {
            return GetMaxSum(model.RootNode, isValidChildPath, out string path);
        }

        /// <summary>
        /// Finds the maximum sum of the node values passed in a path in a tree.
        /// The method will traverse through the tree using the rule in isValidChildPath and return the sum of the node values on the path 
        /// giving the maximum value. During the traversing the path is collected into a string.
        /// </summary>
        /// <param name="model">The model must be an integer implementation of an IModel. The method uses the RootNode of the model as the 
        /// entry to the binary tree.</param>
        /// <param name="isValidChildPath">Delegate that determines whether the logic can use the path to the child node (second parameter) 
        /// from a parent node (first parameter).</param>
        /// <param name="path">The string into which the path of the traversing is returned.</param>
        /// <returns>The maximum sum.</returns>
        public static int GetMaxSum(IModel<int> model, Func<IValueNode<int>, IValueNode<int>, bool> isValidChild, out string path)
        {
            var pathAccumulator = new StringBuilder();
            var rootNode = model.RootNode;
            var maxSum = GetMaxSum(rootNode, isValidChild, out path);
            return maxSum;
        }

        private static int GetSubValue(IValueNode<int> node, IValueNode<int> child, Func<IValueNode<int>, IValueNode<int>, bool> isValidChild, out string path)
        {
            if (child == null || !isValidChild(node, child))
            {
                path = string.Empty;
                return 0;
            }

            return GetMaxSum(child, isValidChild, out path);
        }

        private static int GetMaxSum(IValueNode<int> node, Func<IValueNode<int>, IValueNode<int>, bool> isValidChild, out string path)
        {
            var valuePathes = new List<Tuple<int, string>>();
            foreach (var childNode in node.ChildNodes)
            {
                var value = GetSubValue(node, childNode, isValidChild, out string childPath);
                valuePathes.Add(new Tuple<int, string>(value, childPath));
            }

            var maxChild = valuePathes.OrderByDescending(o => o.Item1).FirstOrDefault();
            if (maxChild == null)
            {
                path = node.Value.ToString();
                return node.Value;
            }

            var maxSum = maxChild.Item1;
            path = $"{node.Value.ToString()} -> {maxChild.Item2}";

            return node.Value + maxSum;
        }
    }
}
