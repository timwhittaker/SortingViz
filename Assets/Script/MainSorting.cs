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
	public Material blueMat;
	public Material yellowMat;
	public Material redMat;
	
	
	// Get sorting algorithm from dropdown
	public void getSortingAlgo(int value)
	{
		sortAlgo = value;
	}
	
	//---------------------------------------------------------
	
	// Swap 
	private static void Swap(ref float[] arr, int left, int right)
	{
		float temp = arr[left];
            	arr[left] = arr[right];
            	arr[right] = temp;
	}
	
	// Implementation of quick sort
	IEnumerator quickSort(float[] arr)
	{
		System.Collections.Stack stack = new System.Collections.Stack();
            	float pivot;
            	int pivotIndex = 0;
            	int leftIndex = pivotIndex + 1;
            	int rightIndex = arr.Length - 1;

            	stack.Push(pivotIndex);//Push always with left and right
            	stack.Push(rightIndex);

            	int leftIndexOfSubSet, rightIndexOfSubset;
		
			
            	while (stack.Count > 0)
            	{
			// Update positions
			yield return new WaitForSeconds(0.2f);
			for (int k = 0; k < lenList; k++)
			{
				CubeArray[k].transform.position = new Vector3((float)(k-lenList/2)/5, 2.5f*arr[k]/maxValue-5.0f/2, 0);
        			CubeArray[k].transform.localScale = new Vector3(0.1f, 5.0f*arr[k]/maxValue, 1.0f);
			}
			CubeArray[pivotIndex].GetComponent<MeshRenderer>().material = yellowMat;

                	rightIndexOfSubset = (int)stack.Pop();//pop always with right and left
                	leftIndexOfSubSet = (int)stack.Pop();

                	leftIndex = leftIndexOfSubSet + 1;
                	pivotIndex = leftIndexOfSubSet;
                	rightIndex = rightIndexOfSubset;

                	pivot = arr[pivotIndex];

              		if (leftIndex > rightIndex)
               		continue;

                	while (leftIndex < rightIndex)
                	{
                    		while ((leftIndex <= rightIndex) && (arr[leftIndex] <= pivot))
                        		leftIndex++;	

                    		while ((leftIndex <= rightIndex) && (arr[rightIndex] >= pivot))
                        		rightIndex--;

                    		if (rightIndex >= leftIndex)
                    		{
                    			// Change color of swap
					CubeArray[leftIndex].GetComponent<MeshRenderer>().material = redMat;
        				CubeArray[rightIndex].GetComponent<MeshRenderer>().material = redMat;
					
                    			Swap(ref arr, leftIndex, rightIndex);
                    			yield return new WaitForSeconds(0.2f);
					for (int k = 0; k < lenList; k++)
					{
						CubeArray[k].transform.position = new Vector3((float)(k-lenList/2)/5, 2.5f*arr[k]/maxValue-5.0f/2, 0);
        					CubeArray[k].transform.localScale = new Vector3(0.1f, 5.0f*arr[k]/maxValue, 1.0f);
        					// Reset Color
        					if (k!=pivot)
        					{
        						CubeArray[k].GetComponent<MeshRenderer>().material = blueMat;
        					}
					}
                    		}
                        		
                	}

                	if (pivotIndex <= rightIndex)
                    		if( arr[pivotIndex] > arr[rightIndex])
                    		{
                    			// Change color of swap
					CubeArray[leftIndex].GetComponent<MeshRenderer>().material = redMat;
        				CubeArray[rightIndex].GetComponent<MeshRenderer>().material = redMat;
        				
                    			Swap(ref arr, pivotIndex, rightIndex);
                    			yield return new WaitForSeconds(0.2f);
					for (int k = 0; k < lenList; k++)
					{
						CubeArray[k].transform.position = new Vector3((float)(k-lenList/2)/5, 2.5f*arr[k]/maxValue-5.0f/2, 0);
        					CubeArray[k].transform.localScale = new Vector3(0.1f, 5.0f*arr[k]/maxValue, 1.0f);
        					// Reset Color
        					if (k!=pivot)
        					{
        						CubeArray[k].GetComponent<MeshRenderer>().material = blueMat;
        					}
					}
                    		}
                       
                	if (leftIndexOfSubSet < rightIndex)
                	{
                    		stack.Push(leftIndexOfSubSet);
                    		stack.Push(rightIndex - 1);
                	}

                	if (rightIndexOfSubset > rightIndex)
                	{
                    		stack.Push(rightIndex + 1);
                 	   	stack.Push(rightIndexOfSubset);
                	}
            	}
        }

	//---------------------------------------------------------
	// Implementation of bubble sort
	IEnumerator bubbleSort(float[] arr)
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
			yield return new WaitForSeconds(0.2f);
			for (int k = 0; k < len; k++)
			{
				CubeArray[k].transform.position = new Vector3((float)(k-lenList/2)/5, 2.5f*arr[k]/maxValue-5.0f/2, 0);
        			CubeArray[k].transform.localScale = new Vector3(0.1f, 5.0f*arr[k]/maxValue, 1.0f);
			}
		}
	}
	
	//---------------------------------------------------------
	// Implementation of insertion sort
	void insertionSort()
	{}

	//---------------------------------------------------------
	
	
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
        		CubeArray[i].GetComponent<MeshRenderer>().material = blueMat;
		}
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		
		// Call appropriate sorting algorithm
		if(sortAlgo==0)
		{
			StartCoroutine(quickSort(values));
		}
		if(sortAlgo==1)
		{
			StartCoroutine(bubbleSort(values));
		}
		if(sortAlgo==2)
		{
			insertionSort();
		}
	}
}
