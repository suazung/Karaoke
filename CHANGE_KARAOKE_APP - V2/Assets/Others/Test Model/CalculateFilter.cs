using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalculateFilter : MonoBehaviour {

	public float [,]_input = new float[,]{
//		{0f,0f,0f,0f,0f,0f,0f},
//		{0f,0f,0f,0f,0f,0f,0f},
//		{0f,0f,0f,0f,0f,0f,0f},
//		{0f,0f,0f,144f,0f,0f,0f},
//		{0f,0f,0f,0f,0f,0f,0f},
//		{0f,0f,0f,0f,0f,0f,0f},
//		{0f,0f,0f,0f,0f,0f,0f}

//		{5f,5f,5f,5f,5f},
//		{4f,4f,4f,4f,4f},
//		{3f,3f,13f,3f,3f},
//		{2f,2f,2f,2f,2f},
//		{1f,1f,1f,1f,1f}

		{0f,0f,10f,0f,0f},
		{0f,0f,10f,0f,0f},
		{0f,0f,10f,0f,0f},
		{0f,0f,10f,0f,0f},
		{0f,0f,10f,0f,0f},

	};
	public float [,]filter = new float[,]{
		{1f,1f,1f},
		{1f,1f,1f},
		{1f,1f,1f}
	 }; 

	 private float GetFilterAvg(){
	 	float sum = 0f;
	 	for(int x=0;x<3;++x)
	 	{
			for(int y=0;y<3;++y)
		 	{
				sum += filter[x,y];
		 	}
	 	}
	 	return 1f/sum;
	 }

	// Use this for initialization
	void Start () {
		//Debug.Log(""+GetFilterAvg());

		//Debug.Log(""+GetValue(2,2));

		string text = "";
		for(int x=0;x<3;++x)
	 	{
			text = "";
			for(int y=0;y<3;++y)
		 	{
				text += (" | "+GetValueMedianFilterCrossShapeMask(x,y) + " | ");
		 	}
		 	Debug.Log(text);
		 }

	}

	private float GetValueMedianFilterCrossShapeMask(int ix,int iy){
		List<float> inList = new List<float>();

		for(int x=0;x<3;++x)
	 	{
			for(int y=0;y<3;++y)
		 	{
		 		if(x == 0 && y == 0)
		 		{ continue; }

				if(x == 0 && y == 2)
		 		{ continue; }

				if(x == 2 && y == 0)
		 		{ continue; }

				if(x == 2 && y == 2)
		 		{ continue; }

				inList.Add( _input[ix+x,iy+y] );

		 	}
	 	}

	 	bool isQuit = false;
	 	while(!isQuit){
			isQuit = true;
	 		for(int i=1;i<inList.Count;++i)
	 		{
	 			if( inList[i] > inList[i-1] ){
					float tmp = inList[i-1];
					inList[i-1] = inList[i];
					inList[i] = tmp;
					isQuit = false;
	 			}
	 		}
	 	}

	 	return inList[2];

	}

	private float GetValueMedianFilter(int ix,int iy){
		List<float> inList = new List<float>();

		for(int x=0;x<3;++x)
	 	{
			for(int y=0;y<3;++y)
		 	{
				inList.Add( _input[ix+x,iy+y] );

		 	}
	 	}

	 	bool isQuit = false;
	 	while(!isQuit){
			isQuit = true;
	 		for(int i=1;i<inList.Count;++i)
	 		{
	 			if( inList[i] > inList[i-1] ){
					float tmp = inList[i-1];
					inList[i-1] = inList[i];
					inList[i] = tmp;
					isQuit = false;
	 			}
	 		}
	 	}

	 	return inList[4];

	}

	private float GetValueLowPassFilter(int ix,int iy){
		float result = 0f;

		float sumMul = 0f;

		for(int x=0;x<3;++x)
	 	{
			for(int y=0;y<3;++y)
		 	{
				sumMul += _input[ix+x,iy+y] * filter[x,y];

		 	}
	 	}

		result = 1f*GetFilterAvg()*sumMul;


		return result;
	}
}
