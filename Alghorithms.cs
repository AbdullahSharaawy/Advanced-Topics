using System.Xml.Linq;

namespace Alghorithms
{
    public class Tree<T>
    {
        public TreeNode<T> root {  get; set; }
        public Tree(T value)
        {
           root=new TreeNode<T>(value);
        }
        public void PrintTree()
        {
            Print(this.root, "  ");
        }
        private static void Print(TreeNode<T>Node, string distance )
        {
            
            Console.WriteLine(distance+Node.Value);

            foreach (var child in Node.Childs)
                Print(child, distance + "  ");
        }
        public TreeNode<T>Find(T value)
            { return root?.Find(value); }
        
    }
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Childs { get; set; }
        public TreeNode(T value)
        {
            Value = value;
            Childs = new List<TreeNode<T>>();
        }
        public TreeNode<T> Find(T value)
        {
            if (EqualityComparer<T>.Default.Equals(Value, value))
                return this;

            foreach (var child in Childs)
            {
                var found = child.Find(value);
                if (found != null)
                    return found;
            }

            return null; // Not found
        }
    }
    class BinarySearch
    {
        public int BinarySearchAlgorithm(int[] arr, int target)
        {
            int Start = 0, End = arr.Length, Middle;
            while (Start <= End)
            {
                Middle = Start + (End - Start) / 2;

                if (target > arr[Middle])
                {
                    Start = Middle + 1;
                }
                else if (target < arr[Middle])
                {
                    End = Middle - 1;
                }
                else if (target == arr[Middle])
                    return Middle;
            }

            return -1;
        }
    }
    static class BuBoleSort
    {
        static private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static public void Sort(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j] < arr[j - 1])
                        Swap(ref arr[j], ref arr[j - 1]);
                }
            }
        }
    }
    static class SelectionSort
    {
        static public void Sort(ref int[] arr)
        {
           
            for (int i = 0; i < arr.Length; i++)
            {
                int MinIndex = i;
                for (int j = i+1; j < arr.Length-1; j++)
                {
                    if (arr[j] < arr[MinIndex])
                    {
                        MinIndex = j;
                    }
                        
                }
                int temp=arr[i];
                arr[i] = arr[MinIndex];
                arr[MinIndex] = temp;
               
            }
        }
    }
    static class InsertionSort
    {
        public static void Sort( int[] arr)
        {
            for(int i = 0;i < arr.Length-1;i++)
            {
                for(int j=i+1;j>0;j--)
                {
                    if(arr[j] < arr[j-1])
                    {
                        int tmep = arr[j];
                        arr[j] = arr[j-1];
                        arr[j-1] = tmep;
                        
                    }else break;
                }
            }
        }
    }
    public static class CountSort
    {
        public static void Sort(int[] arr,int mod=10,bool TurnOn=false)//TurnOn to use x lamda function ,if it is true
        {
            int K = 0;
            int[] Count;
            int[] Temp=new int[arr.Length];
            int Sum;// to calculate the comulative for the Count
            var x = (int n) => { return TurnOn ? (n % mod) / (mod / 10) : n; };

            foreach (int element in arr)
            {
                if(x(element) > K)
                    K = x(element);
            }
            
            Count = new int[K +1] ;

            foreach (int element in arr)// to calculate number of repeat for each number
            {
                Count[x(element)] +=1;
            }
            Sum = Count[0];

            for(int i=1;i<Count.Length;i++)// to calculate the comulative (position)
            {
                Sum += Count[i];
                Count[i] = Sum;
            }
            for (int i=arr.Length-1;i>=0;i--)//sort
            {
                int index = Count[x(arr[i])] - 1;
                Count[x(arr[i])] -= 1;// update the comulative (position)
                Temp[index] = arr[i];
            }
            for(int i=0;i<arr.Length;i++)// update arr
            {
                arr[i] =Temp[i];
            }
        }
    }
    public static class RadixSort
    {
        public static void Sort(int[] arr)
        {
            int MaxElement = 0;
            int d=0;// number of call the Count Sort
            int Mode = 10;
            foreach (int element in arr)
            {
                if (element > MaxElement)
                    MaxElement = element;
            }
            while(MaxElement>0)
            {
                d+=1;
                MaxElement /= 10;
            }
            
            while(d>0)
            {
               CountSort.Sort(arr,Mode,true);
                d--;
                Mode *= 10;
            }
        }
    }
    
    public class program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 2, 34, 45, 3, 6, 67, 5, 76, 43, 8, 9, 1, 6 };
            RadixSort.Sort(arr);
            foreach (int i in arr)
                Console.Write(i + " ");
            
            //Tree<string> Tree = new Tree<string>("Sharaawy");

            //TreeNode<string> Child1 = new TreeNode<string>("Zaki");
            //Tree.root.Childs.Add(Child1);
            //TreeNode<string> Child2 = new TreeNode<string>("Eid");
            //TreeNode<string> Child8 = new TreeNode<string>("Fawzy");
            //TreeNode<string> Child14= new TreeNode<string>("Fhim");
            //TreeNode<string> Child13= new TreeNode<string>("Essam");
            //TreeNode<string> Child12 = new TreeNode<string>("Ahmed");

            //Child1.Childs.Add(Child2);
            //Child1.Childs.Add(Child8);
            //TreeNode<string> Child3 = new TreeNode<string>("Adel");
            //Child2.Childs.Add(Child3);
            //Child2.Childs.Add(Child14);
            //Child2.Childs.Add(Child12);
            //Child2.Childs.Add(Child13);

            //TreeNode<string> Child9 = new TreeNode<string>("Hamdy");
            //TreeNode<string> Child10 = new TreeNode<string>("Khaled");
            //TreeNode<string> Child11 = new TreeNode<string>("Ahmed");
            //Child8.Childs.Add(Child9);
            //Child8.Childs.Add(Child11);
            //Child8.Childs.Add(Child10);
            //TreeNode<string> Child4 = new TreeNode<string>("Abdallah");
            //TreeNode<string> Child5 = new TreeNode<string>("Mena");
            //TreeNode<string> Child6 = new TreeNode<string>("Malak");
            //TreeNode<string> Child7 = new TreeNode<string>("Mariam");
            //Child3.Childs.Add(Child4);
            //Child3.Childs.Add(Child5);
            //Child3.Childs.Add(Child6);
            //Child3.Childs.Add(Child7);
            //Tree.PrintTree();
            //if(Tree.Find("Adel")!=null)
            //{
            //    Console.WriteLine("it is found");
            //}else Console.WriteLine("it is not found");
        }
    }
    
}
