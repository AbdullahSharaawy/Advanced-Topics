using BT;
using System.Security.Cryptography.X509Certificates;

namespace BT
{

    public class TreeNodeBinary<T>
    {
        public T Value { get; set; }
        public TreeNodeBinary<T> Left { get; set; }
        public TreeNodeBinary<T> Right { get; set; }
        public TreeNodeBinary(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BinarySearchTree<T>:BinaryTree<T>
    {
        
        public void Insert(T value)
        {
            var NewNode = new TreeNodeBinary<T>(value);
            if (root == null)
            {
                root = NewNode;
                return;
            }

            Queue<TreeNodeBinary<T>> queue = new Queue<TreeNodeBinary<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var TreeNode = queue.Dequeue();
                if (TreeNode.Left == null && Comparer<T>.Default.Compare(value, TreeNode.Value )<0)
                {
                    TreeNode.Left = NewNode;
                    break;
                }
                else if(TreeNode.Left!= null && Comparer<T>.Default.Compare(value, TreeNode.Value) < 0)
                    queue.Enqueue(TreeNode.Left);
                if (TreeNode.Right == null && Comparer<T>.Default.Compare(value, TreeNode.Value) > 0)
                {
                    TreeNode.Right = NewNode;
                    break;
                }
                else if (TreeNode.Right != null && Comparer<T>.Default.Compare(value, TreeNode.Value) > 0)
                    queue.Enqueue(TreeNode.Right);

            }
        }
      
        public TreeNodeBinary<T> Search(T value)
        {
            if (root == null)
            {
                return null;
            }

            Queue<TreeNodeBinary<T>> queue = new Queue<TreeNodeBinary<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                
                var TreeNode = queue.Dequeue();
                if (EqualityComparer<T>.Default.Equals(TreeNode.Value, value))
                    return TreeNode;

                if (TreeNode.Left != null && Comparer<T>.Default.Compare(value, TreeNode.Value) < 0)
                {
                    queue.Enqueue(TreeNode.Left);
                }
                else if (TreeNode.Left == null && Comparer<T>.Default.Compare(value, TreeNode.Value) < 0)
                    return null;

                if (TreeNode.Right != null && Comparer<T>.Default.Compare(value, TreeNode.Value) > 0)
                {
                    queue.Enqueue(TreeNode.Right);
                }
                else if (TreeNode.Right == null && Comparer<T>.Default.Compare(value, TreeNode.Value) > 0)
                    return null;

            }
            return null;

        }


    }
    public class BinaryTree<T>
    {
       public TreeNodeBinary<T> root {  get; set; }
        
        public void Insert(T value)
        {
            var NewNode = new TreeNodeBinary<T>(value);
            if (root == null)
            {
                root = NewNode;
                return;
            }
                
            Queue<TreeNodeBinary<T>> queue = new Queue<TreeNodeBinary<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var TreeNode = queue.Dequeue();
                if(TreeNode.Left==null)
                {
                    TreeNode.Left = NewNode;
                    break;
                }
                else queue.Enqueue(TreeNode.Left);
                if (TreeNode.Right == null)
                {
                    TreeNode.Right = NewNode;
                    break;
                }
                else queue.Enqueue(TreeNode.Right);

            }
        }

        public void PrintTree()
        {
            Print(root, 10 );
        }
        public void Print(TreeNodeBinary<T> Node,int count)
        {
            if(Node==null)
                return;
            
            Print(Node.Right, count + 10);
            string Distance="";
            for (int i = 0; i < count; i++)
            {
                Distance+=" ";
            }
            Console.WriteLine(Distance+Node.Value);
             Console.WriteLine();
            Print(Node.Left, count + 10);

        }
        public void PostOrderTraversal()
        {
            PrintPostOrderTraversal(root);
        }
        public void PrintPostOrderTraversal(TreeNodeBinary<T> Node)
        {
            if (Node == null)
            {     
                return;
            }
            PrintInOrder(Node.Left);
            PrintInOrder(Node.Right);
            Console.Write(Node.Value + " ");

        }

        public void PreOrderTraversal()
        {
            PrintPreOrderTraversal(root);
        }
        private void PrintPreOrderTraversal(TreeNodeBinary<T> Node)
        {
            if (Node == null)
            {
                return;
            }
            Console.Write(Node.Value+" ");
            PrintPreOrderTraversal(Node.Left);
            PrintPreOrderTraversal(Node.Right);
            //Console.WriteLine(Node.Value);

        }
        public void LevelOrderTraversal()
        {
                 PrintLevelOrderTraversal(root);
        }
        

        public void PrintLevelOrderTraversal(TreeNodeBinary<T>Node)
        {
            Queue<TreeNodeBinary<T>> queue = new Queue<TreeNodeBinary<T>>();
            queue.Enqueue(Node);
            
            while (queue.Count > 0)
            {
                var TreeNode = queue.Dequeue();
                Console.Write(TreeNode.Value+" ");
                if (TreeNode.Left != null)
                {
                   queue.Enqueue(TreeNode.Left);
                }
               
               
                if (TreeNode.Right != null)
                {
                    queue.Enqueue(TreeNode.Right);
                }
                

            }
        }
        
        public void InOrderTraversal()
        {
            PrintInOrder(root);
        }
        public void PrintInOrder(TreeNodeBinary<T>Node)
        {
            if(Node==null)
            {
                return;
            }
            PrintInOrder(Node.Left);
            Console.Write(Node.Value+" ");
            PrintInOrder(Node.Right);
        }
    }

    }

    public class Program
    {
        static void Main(string[] args)
        {
        var binaryTree = new BinarySearchTree<int>();
        Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9,12,14,45,67\n");


        binaryTree.Insert(5);
        binaryTree.Insert(3);
        //binaryTree.Insert(5);
        binaryTree.Insert(8);
        binaryTree.Insert(1);
        binaryTree.Insert(4);
        binaryTree.Insert(6);
        binaryTree.Insert(9);
        binaryTree.Insert(5);
        binaryTree.Insert(6);
        binaryTree.Insert(3);
        binaryTree.Insert(4);   
        binaryTree.Insert(12);
        binaryTree.Insert(14);
        binaryTree.Insert(45);
        binaryTree.Insert(40);
        binaryTree.Insert(67);
        binaryTree.PrintTree();
        Console.WriteLine();
        binaryTree.InOrderTraversal();
        Console.WriteLine();
        binaryTree.LevelOrderTraversal();
        TreeNodeBinary<int>? FindNode= binaryTree.Search(12);
        
        Console.WriteLine(FindNode.Right.Value);
        
        Console.ReadKey();
    }
    }
