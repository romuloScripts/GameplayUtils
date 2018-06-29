using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate bool compare<T>(T t1,T t2);

public class OrdinationMethods<T>{
	
	public static void StartQuickSort(List<T>v,compare<T> compareMethod){
		QuickSort(v,0,v.Count-1,compareMethod);
	}
	
	public static void QuickSort(List<T>v,int esq,int dir, compare<T> method){
		int esq2 = esq;
		int dir2 = dir;
		Partition(v,ref esq2,ref dir2,method);
		if(dir > esq2){
			QuickSort(v,esq2,dir,method);
		}
		if(esq < dir2){
			QuickSort(v,esq,dir2,method);
		}
	}
	
	private static void Partition(List<T>v, ref int esq, ref int dir, compare<T> method){
		T pivot = v[(esq+dir)/2];
		do {
			while (method(pivot,v[esq])){
				esq++;
			}
			while (method(v[dir],pivot)) {
				dir--;
			}
			if(esq <= dir){
				T aux = v[esq];
				v[esq] = v[dir];
				v[dir] = aux;
				esq++; dir--;
			}
			
		} while (esq < dir);	
	}
	
	
}


