using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortTest : MonoBehaviour
{
    int[] values = {5,17,22,0,0,12,9};

    void Start()
    {
        int[] n = SelectionSort(values);
        string o = "";
        foreach(int i in n)
        {
            o += "" + i + " ";
        }
        Debug.Log(o);
    }

    void Update()
    {
        
    }

    int[] SelectionSort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i ++)
        {
            int lowestValue = int.MaxValue;
            int lowestIdx = -1;
            for(int j = i; j < arr.Length; j ++)
            {
                if(arr[j] < lowestValue)
                {
                    lowestValue = arr[j];
                    lowestIdx = j;
                }
            }

            for(int j = lowestIdx; j > i; j--)
            {
                arr[j]= arr[j-1];
            }
            arr[i] = lowestValue;
        }
        return arr;
    }
}
