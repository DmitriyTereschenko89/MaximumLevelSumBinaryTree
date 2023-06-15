namespace MaximumLevelSumBinaryTree
{
	internal class Program
	{
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
			{
				this.val = val;
				this.left = left;
				this.right = right;
		    }
		}

		public class MaximumLevelSumBinaryTree
		{
			public int MaxLevelSum(TreeNode root)
			{
				if (root is null)
				{
					return 0;
				}
				int maxLevelSum = int.MinValue;
				int maxLevel = 1;
				int curLevel = 1;
				Queue<TreeNode> queue = new();
				queue.Enqueue(root);
				while (queue.Count > 0)
				{
					int sumLevel = 0;
					for (int node = queue.Count; node > 0; --node)
					{
						TreeNode curNode = queue.Dequeue();
						sumLevel += curNode.val;
						if (curNode.left != null)
						{
							queue.Enqueue(curNode.left);
						}
						if (curNode.right != null)
						{
							queue.Enqueue(curNode.right);
						}
					}
					if (sumLevel > maxLevelSum)
					{
						maxLevelSum = sumLevel;
						maxLevel = curLevel;
					}
					++curLevel;
				}
				return maxLevel;
			}
		}
		static void Main(string[] args)
		{
			MaximumLevelSumBinaryTree maximumLevelSumBinaryTree = new();
			TreeNode root = new TreeNode(1, new TreeNode(7, new TreeNode(7), new TreeNode(-8)), new TreeNode(0));
            Console.WriteLine(maximumLevelSumBinaryTree.MaxLevelSum(root));
        }
	}
}