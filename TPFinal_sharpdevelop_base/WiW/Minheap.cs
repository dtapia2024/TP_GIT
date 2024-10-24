using System;
using System.Collections.Generic;
using System.Numerics;
using tp1;


namespace tpfinal
{

 public class MinHeap{
    private Proceso[] ar;
    private int count;
    
    //public StringBuilder sb;
    public MinHeap(){
        ar = new Proceso[500];
        count = 0;
       //sb = new StringBuilder("");
    }
    public int left(int i){
        return 2*i + 1;
    }
    public int right(int i){
        return 2*i + 2;
    }
    public int parent(int i){
        return (i-1)/2;
    }
    public void insert(Proceso n){
        count++;
        int i = count-1;
        ar[i] = n;
        percolateUp(count-1);
    }
    public void percolateUp(int i){
        if(i <= 0){
            return;
        }
        if(ar[i].tiempo < ar[parent(i)].tiempo){
            Proceso temp = ar[i];
            ar[i] = ar[parent(i)];
            ar[parent(i)] = temp;
            percolateUp(parent(i));
        }
    }
    public void percolateDown(int i){
        int l = left(i);
        int r = right(i);
        int min = i;
        bool flag = false;
        if(l < count && ar[i].tiempo > ar[l].tiempo){
            min = l;
            flag = true;
        }
        if(r < count && ar[r].tiempo < ar[min].tiempo){
            min = r;
            flag = true;
        }
        if(flag){
            Proceso temp = ar[i];
            ar[i] = ar[min];
            ar[min] = temp;
            percolateDown(min);
        }
    }
    public void deleteMin(){
        if(count == 0){
            return;
        }
        if(count == 1){
            count--;
            return;
        }
        ar[0] = ar[count-1];
        count--;
        percolateDown(0);
    }
 
    public Proceso getMin(){
    	return ar[0];
    }

     public int cantidad(){
         return this.count;
    }   
    
//    public void process(string str){
//        string[] s = str.Split(' ');
//        if(s[0].Equals("getMin")){
//            Console.WriteLine(getMin());
//        }
//        else if(s[0].Equals("delMin")){
//            deleteMin();
//        }
//        else if(s[0].Equals("insert")){
//            insert(Convert.ToInt32(s[1]));
//        }
//    }
//    public static void Main(string[] args){
//        MinHeap ob = new MinHeap();
//        for(int i=0;i<100;i++){
//            ob.insert(i+1);
//        }
//        for(int i=0;i<100;i++){
//            Console.WriteLine(ob.getMin());
//            ob.deleteMin();
//        }
//    }
}
}
