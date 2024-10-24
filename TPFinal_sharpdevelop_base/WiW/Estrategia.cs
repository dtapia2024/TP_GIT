using System;
using System.Collections.Generic;
using System.Numerics;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {

        public String Consulta1(List<Proceso> datos)
        {
          	//Retorna un texto con las hojas de las Heaps utilizadas
			//en los métodos anteriores construidas a partir de los datos de entrada.

        	MinHeap min_heap = new MinHeap();
           foreach (Proceso element in datos)
			{
            	min_heap.insert(element);           
			}
			
			// descarto nodos internos
			float cant = min_heap.cantidad() / 2;
			int cant_descartar = (int) cant;
			int i = 0;
			
			while(i < cant_descartar)
			{
				min_heap.deleteMin();
				i ++;
			}
			
			//concateno las hojas
			string rta = " hojas minheap: ";
			
			while(min_heap.cantidad() != 0)
			{
				rta = rta + "\n " + min_heap.getMin().ToString();
				min_heap.deleteMin();
			}
			
			rta = rta + "\n ";

        	MaxHeap max_heap = new MaxHeap();
           	foreach (Proceso element in datos)
			{
            	max_heap.insert(element);           
			}
			
			// descarto nodos internos
			cant = max_heap.cantidad() / 2;
			cant_descartar = (int) cant;
			i = 0;
			
			while(i < cant_descartar)
			{
				max_heap.deleteMax();
				i ++;
			}
			
			//concateno las hojas
			rta = rta +  " hojas maxheap: ";
			
			while(max_heap.cantidad() != 0)
			{
				rta = rta + "\n " + max_heap.getMax().ToString();
				max_heap.deleteMax();
			}
			
			return rta;

        }



        public String Consulta2(List<Proceso> datos)
        {
        	//Retorna un texto con las alturas de las Heaps
			//utilizadas en los métodos anteriores construidas a partir de los datos de entrada.
        	
        	int cant = datos.Count;			
        	int altura = (int) (Math.Log10(cant) / Math.Log10(2));
        	string alt = altura.ToString();        	
			
			string rta = "la altura de ambas heaps es: " +  alt;
			return rta;
           
        }



        public String Consulta3(List<Proceso> datos)
        {
            //Retorna un texto que contiene los datos de las Heaps
			//utilizadas en los métodos anteriores, explicitando en el texto resultado los niveles en los que se
			//encuentran ubicados cada uno de los datos.
        	
        	
        	string result = "Implementar";
           
            return result;
        }


        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
        	//Retorna en la variable collected los procesos ordenados 
        	//del de menor tiempo de uso de la CPU al de mayor de la lista
			//datos utilizando una MinHeap como estructura de datos soporte.
        	
           	MinHeap heap = new MinHeap();
			foreach (Proceso element in datos)
			{
            	heap.insert(element);           
			}
			
			while(heap.cantidad() != 0)
			{
				collected.Add(heap.getMin());
				heap.deleteMin();
			}
            
        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
           	//Retorna en la variable collected los procesos ordenados 
           	//del de mayor prioridad al de menor prioridad de la lista 
           	//datos utilizando una MaxHeap como estructura de datos soporte.
           	
        	MaxHeap heap = new MaxHeap();
			foreach (Proceso element in datos)
			{
            	heap.insert(element);           
			}
			
			while(heap.cantidad() != 0)
			{
				collected.Add(heap.getMax());
				heap.deleteMax();
			}
        	
        }

        





    }
}