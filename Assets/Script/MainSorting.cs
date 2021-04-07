using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainSorting : MonoBehaviour
{
	int sortAlgo = 0; // Int to tell us which algorithm to use
	static int lenList = 50; // How many objects to sort? 
	float[] values = new float[50]; // Values to sort
	float maxValue;
	GameObject[] CubeArray = new GameObject[lenList]; // List of cubes
	
	
	// Get sorting algorithm from dropdown
	public void getSortingAlgo(int value)
	{
		sortAlgo = value;
	}
	
	//---------------------------------------------------------
	// Implementation of quick sort
	void quickSort(float[] arr, int low, int high)
	{
		
		if(low<high)
		{
			int partIndex = partition(arr,low,high);

			quickSort(arr,low,partIndex-1);
			quickSort(arr,partIndex+1,high);
			
		}
	}
	
	int partition(float[] arr, int low, int high)
	{
	
		// Select Pivot
		float pivot = arr[high];		
		
		int lowIndex = (low-1);
		
		//CubeArray[lowIndex].GetComponent<Renderer>().material.SetColor("_Color",Color.green);
		
		// Reorder
		for (int i = low; i < high; i++)
		{
		
			if(arr[i] <= pivot)
			{
				lowIndex++;
				
				float temp = arr[lowIndex];
				arr[lowIndex] = arr[i];
				arr[i] = temp;
			}
		}
		
		float temp1 = arr[lowIndex+1];
		arr[lowIndex+1] = arr[high];
		arr[high] = temp1;
		
		return lowIndex+1;
	}
	
	//---------------------------------------------------------
	// Implementation of bubble sort
	void bubbleSort(float[] arr)
	{
		int len = arr.Length;
		for (int i = 0; i < len; i++)
		{
			for(int j = 0; j < len-1; j++)
			{
				if(arr[j]>arr[j+1])
				{
					float temp = arr[j];
					arr[j] = arr[j+1];
					arr[j+1] = temp; 
				}
			}
			CubeArray[i].transform.position = new Vector3((float)(i-lenList/2)/5, 2.5f*arr[i]/maxValue-5.0f/2, 0);
        		CubeArray[i].transform.localScale = new Vector3(0.1f, 5.0f*arr[i]/maxValue, 1.0f);
		}
	}
	
	//---------------------------------------------------------
	// Implementation of insertion sort
	void insertionSort()
	{}

	//---------------------------------------------------------
	
	private void UpdatePositionsDelay()
	{
		for (int i = 0; i < lenList; i ++)
		{
			CubeArray[i].transform.position = new Vector3((float)(i-lenList/2)/5, 2.5f*values[i]/maxValue-5.0f/2, 0);
        		CubeArray[i].transform.localScale = new Vector3(0.1f, 5.0f*values[i]/maxValue, 1.0f);
        	}
	}
	
	
	public void startSorting()
	{
		// Generate random values
		for (int i = 0; i < lenList; i++)
		{
			values[i] = UnityEngine.Random.Range(10.0f, 100.0f);
		}
		
		maxValue = Mathf.Max(values);
		
		// display blocks
		for (int i = 0; i < lenList; i++)
		{
			CubeArray[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			CubeArray[i].transform.position = new Vector3((float)(i-lenList/2)/5, 2.5f*values[i]/maxValue-5.0f/2, 0);
        		CubeArray[i].transform.localScale = new Vector3(0.1f, 5.0f*values[i]/maxValue, 1.0f);
		}
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		
		// Call appropriate sorting algorithm
		if(sortAlgo==0)
		{
			quickSort(values,0,lenList-1);
			Invoke("UpdatePositionsDelay",1.0f);
		}
		if(sortAlgo==1)
		{
			//bubbleSort(values);
			for (int i = 0; i < lenList; i++)
			{
				for(int j = 0; j < lenList-1; j++)
				{
					if(values[j]>values[j+1])
					{
						float temp = values[j];
						values[j] = values[j+1];
						values[j+1] = temp; 
					}
				}
				
				Invoke("UpdatePositionsDelay",15.0f);
			}
			Invoke("UpdatePositionsDelay",1.0f);
		}
		if(sortAlgo==2)
		{
			insertionSort();
		}
	}
}
