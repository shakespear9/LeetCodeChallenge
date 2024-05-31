namespace LeetCode
{
    public class BinaryTree
    {
        class Node
        {

            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Level { get; set; }
            public int Order { get; set; }

            public Node(int data, int level, int order)
            {
                Data = data;
                Left = Right = null;
                // base 0 index
                Level = level;
                Order = order;
            }
        }

        class BinaryTreeBuilder
        {

            private static readonly int COUNT = 10;
            public static Node ConstructBinaryTree(int[][] arr)
            {
                if (arr == null || arr.Length == 0)
                {
                    return null;
                }

                // Root node is at index 0
                var root = new Node(arr[0][0], 0, 0);

                // Helper function to recursively build subtrees
                BuildSubtree(root, arr);

                return root;
            }

            private static void BuildSubtree(Node parent, int[][] arr)
            {
                if (parent is null)
                {
                    return;
                }

                var currentLevel = parent.Level + 1;
                var leftNodeOrder = parent.Order;
                var rightNodeOrder = parent.Order += 1;

                if (parent.Level >= arr.Length)
                {
                    return;
                }

                // Check if elements exist for left and right children
                if (currentLevel < arr.Length && arr[currentLevel].Length > 0)
                {
                    parent.Left = new Node(arr[currentLevel][leftNodeOrder], currentLevel, leftNodeOrder);

                    if (rightNodeOrder < arr[currentLevel].Length)
                    {
                        parent.Right = new Node(arr[currentLevel][rightNodeOrder], currentLevel, rightNodeOrder);
                    }
                }

                //if (parentIndex < arr.Length - 1 && arr[parentIndex + 1].Length > 0)
                //{
                //    parent.Right = new Node(arr[currentLevel][ rightNodeOrder], currentLevel, rightNodeOrder);
                //}

                // Recursively build left and right subtrees based on even/odd indices
                BuildSubtree(parent.Left, arr);
                BuildSubtree(parent.Right, arr);
            }

            public static void PrintTree(Node node, int level = 0)
            {
                if (node != null)
                {
                    string indent = "";
                    for (int i = 0; i < level; i++)
                    {
                        indent += "  "; // Two spaces per level
                    }
                    Console.WriteLine(indent + node.Data);
                    PrintTree(node.Left, level + 1);
                    PrintTree(node.Right, level + 1);
                }
            }

            public static void print2DUtil(Node root, int space)
            {
                // Base case
                if (root == null)
                    return;

                // Increase distance between levels
                space += COUNT;

                // Process right child first
                print2DUtil(root.Right, space);

                // Print current node after space
                // count
                Console.Write("\n");
                for (int i = COUNT; i < space; i++)
                    Console.Write(" ");
                Console.Write(root.Data + "\n");

                // Process left child
                print2DUtil(root.Left, space);
            }

            // Wrapper over print2DUtil()
            public static void print2D(Node root)
            {
                // Pass initial space count as 0
                print2DUtil(root, 0);
            }
        }

        public static class BinaryTreeTest
        {
            public static void Start()
            {

                string combined = Path.Combine(Directory.GetCurrentDirectory(), "hard.json");

                int[][] arr = new int[][] {
                        new int[] { 59 },
                        new int[] { 73, 41 },
                        new int[] { 52, 40, 53 },
                        new int[] { 26, 53, 6, 34 }
                        };

                var root = BinaryTreeBuilder.ConstructBinaryTree(arr);

                // Print the tree structure
                BinaryTreeBuilder.print2D(root);
            }
        }
    }

    // parent = i 
    // left child = i
    // right child = i + 1
}

