using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[m];
            int index = 0;

            for (int col = 0; col < m; col++) {
                int c = 0;
                for (int row = 0; row < n; row++)
                {
                    if(matrix[row, col] < 0) { c++; }
                }
                answer[index++] = c;
            }


            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for(int i = 0; i < n; i++)
            {
                int min = int.MaxValue;
                int min_j = 0;
                for(int j = 0; j < m; j++)
                {
                    if( matrix[i, j] < min) {  min = matrix[i,j];min_j = j; }
 
                }


                for (int k = min_j; k > 0; k--)
                {
                    matrix[i, k] = matrix[i,k - 1];
                }
                matrix[i,0] = min;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                int max_j = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; max_j = j; }
                }
                
                for(int k = 0; k < m; k++)
                {
                    if (k < max_j)
                    {
                        answer[i, k] = matrix[i, k];
                    }else if (k == max_j) { answer[i, k] = matrix[i, k]; answer[i, k+1] = matrix[i, k]; }
                    else if (k > max_j) {answer[i, k + 1] = matrix[i, k]; }
                }
            }




            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
 

            //Console.WriteLine();
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        Console.Write(matrix[i, j]);
            //        Console.Write("\t");
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 0; i < n; i++)
            {
       
                int max = int.MinValue;
                int max_j = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; max_j = j; }
                }

                if (max_j == m - 1) { continue; }
                if (max_j == 0) {  continue; }

                int pos_c = 0;
                int sm = 0;
                for (int k = max_j + 1 ; k < m; k++) 
                {

                    if ( matrix[i, k] > 0) {  pos_c++; sm += matrix[i, k]; }
                }
    
                if(pos_c == 0) {  continue; }

                int av = sm/pos_c;
                for (int t = 0; t < max_j; t++) 
                {
                    if(matrix[i, t] < 0) { matrix[i, t] = av;  }
                }

            }



            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (k > m-1) { return; }

            int[] maxs = new int[n];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j];}
                }
                maxs[index++] = max;
            }
            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = maxs[n-i-1];
            }
 

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int index = 0;
            if (array.Length != m) { return; }

            for (int col = 0; col < m; col++)
            {
                int max = int.MinValue;
                int max_row = 0;
                for (int row = 0; row < n; row++)
                {
                    if (matrix[row, col] > max) { max = matrix[row, col]; max_row = row;}
                }
                if(array[col] > max) { matrix[max_row,col] = array[col]; }


            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            //Console.WriteLine();
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        Console.Write(matrix[i, j]);
            //        Console.Write("\t");
            //    }
            //    Console.WriteLine();
            //}
            int[,] mins = new int[n,2];
            int index = 0;
            //Console.WriteLine("c");
            for (int i = 0; i < n; i++)
            {
                mins[index, 1] = i;
                int min = int.MaxValue;
                for(int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min) { min = matrix[i, j]; mins[index,0] = min;  }
                }
                index++;
            }
            //Console.WriteLine("b");
            for (int i = 0; i < n - 1; i++)
            {
                
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (mins[j,0] < mins[j + 1,0])
                    {  
                        (mins[j, 0], mins[j + 1, 0]) = (mins[j + 1, 0], mins[j, 0]);
                        (mins[j, 1], mins[j + 1, 1]) = (mins[j + 1, 1], mins[j, 1]);
                    } 
                }
            }
            //Console.WriteLine("a");
            int[,] temp = new int[n,m];
            for (int i = 0;i < n; i++)
            {
                int row = mins[i, 1];
                for(int j = 0; j < m; j++)
                {
                    temp[i, j] = matrix[row,j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = temp[i,j];

                }

            }


            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if(n!= m) { return answer; }

            int index = 0;
            answer = new int[2 * n - 1];
      

            for (int i = n - 1; i >= -(n - 1); i--)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    int k = j - i;
                    if (k >= 0 && k < n)
                        sum += matrix[j, k];
                }

                answer[index++] = sum;
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n!= matrix.GetLength(1)) { return; }





                var maxElem = matrix[0, 0];
                int rowMax = 0, colMax = 0;
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < n; j++)
                        if (Math.Abs(matrix[i, j]) > Math.Abs(maxElem))
                        {
                            maxElem = matrix[i, j];
                            (rowMax, colMax) = (i, j);
                        }
                }

                if (rowMax == k && colMax == k)
                    return;

                if (rowMax > k)
                {
                    for (int i = rowMax; i > k; i--)
                    {
                        for (int j = 0; j < n; j++)
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
                else if (rowMax < k)
                {
                    for (int i = rowMax; i < k; i++)
                    {
                        for (int j = 0; j < n; j++)
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }

                if (colMax > k)
                {
                    for (int j = colMax; j > k; j--)
                    {
                        for (int i = 0; i < n; i++)
                            (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
                else if (colMax < k)
                {
                    for (int j = colMax; j < k; j++)
                    {
                        for (int i = 0; i < n; i++)
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }



            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            // na*ma nb*mb
            int na = A.GetLength(0);

            int nb = B.GetLength(0);

            int ma = A.GetLength(1);

            int mb = B.GetLength(1);

            if (ma != nb) { return answer; }
            //n*m m*q
            int n = na;
            int m = ma;
            int q = mb;

            answer = new int[n, q];
  
      
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < q; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        answer[k, i] += A[k, j] * B[j, i];
                      
                    }
                    
                }
            }
            




            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for(int j = 0;j < m; j++)
                {
                    if(matrix[i,j] > 0) { c++; }
                }
                answer[i] = new int[c];
            }

            for (int i = 0; i < n; i++)
            {
                int index = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) { answer[i][index++] = matrix[i, j];} //Console.WriteLine(answer[i][index - 1]); }
                }
                
            }






            //int[] arrayCountNegativeAndZeroInRows = new int[matrix.GetLength(0)];
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //        if (matrix[row, col] <= 0)
            //            arrayCountNegativeAndZeroInRows[row]++;
            //}

            //answer = new int[matrix.GetLength(0)][];
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    var currentRow = new int[matrix.GetLength(1) - arrayCountNegativeAndZeroInRows[row]];
            //    int idxCurrentRow = 0;
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //        if (matrix[row, col] > 0)
            //            currentRow[idxCurrentRow++] = matrix[row, col];
            //    answer[row] = currentRow;
            //}
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int c = 0;
            for(int i = 0; i < array.Length;i++)
            {
                c += array[i].Length;
            }
            int n = (int)Math.Ceiling(Math.Sqrt(c));
            answer = new int[n, n];
            Console.WriteLine(n);

            int i_index = 0;
            int j_index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.WriteLine($"{i_index},{j_index}");
                    answer[i_index, j_index++] = array[i][j];
                    if (j_index  >= n) { j_index = 0; i_index++;}
                    if (i_index >= n) { return answer; }
                    
                }
            }
















            //int countElems = 0;
            //for (int row = 0; row < array.Length; row++)
            //    countElems += array[row].Length;

            //int n = (int)Math.Ceiling(Math.Sqrt(countElems));
            //answer = new int[n, n];
            //int[] allElements = new int[countElems];
            //int idx = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    for (int j = 0; j < array[i].Length; j++)
            //        allElements[idx++] = array[i][j];
            //}

            //idx = 0;
            //for (int row = 0; row < n; row++)
            //{
            //    for (int col = 0; col < n; col++)
            //        answer[row, col] = idx < countElems ? allElements[idx++] : 0;
            //}
            // end

            return answer;
        }
    }
}