using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_WaitAllOneByOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            int j = 0;
            int acumulador = 0;
            for (int i = 0; i < 5; i++,j++)
            {
                    
                    int a = 4 + j;
                    int b = 2 + j;
                     
                 
                tareas.Add(Task.Factory.StartNew(() => 
                {
                     return a + b;
                }));
                while(tareas.Count > 0)
                {
                    int indice = Task.WaitAny(tareas.ToArray());
                    Console.WriteLine(" {0} + {1}",a,b);
                    Console.WriteLine("el resultado de la tarea fue {0}",tareas[indice].Result);
                    acumulador += tareas[indice].Result;
                    tareas.RemoveAt(indice);
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("SUMA TOTAL: {0}",acumulador);
            Console.WriteLine("press key to exit...");
            Console.ReadLine();
        }
    }
}
