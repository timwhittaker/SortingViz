using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DropDown : MonoBehaviour
{
	public TextMeshProUGUI output;
	
	public string chosenAlgorithm = "QuickSort";
	
	public void HandleInputData(int value)
	{
		if(value == 0)
		{
			chosenAlgorithm="QuickSort";
			output.text=chosenAlgorithm;
		}
		if(value == 1)
		{
			chosenAlgorithm="BubbleSort";
			output.text=chosenAlgorithm;
		}
		if(value == 2)
		{
			chosenAlgorithm = "InsertionSort";
			output.text=chosenAlgorithm;
		}
	}    
}
