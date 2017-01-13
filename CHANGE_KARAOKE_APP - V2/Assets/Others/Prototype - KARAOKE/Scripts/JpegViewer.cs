using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JpegViewer : MonoBehaviour
{
//	public int numberOfFrames = 0;
	public float frameRate = 30;

	public Texture2D[] frames;
	private List<Texture2D> sortList;

//	public Material rightMat;
//	public Material leftMat;

	public Material mat;

	void Start ()
	{
		// load the frames
//		frames = new Texture2D[numberOfFrames];
//		for (int i = 0; i < numberOfFrames; ++i)
// 			frames[i] = (Texture2D)Resources.Load(string.Format("frame{0:d4}", i + 1));
		sortList = new List<Texture2D>();
		for(int i=0;i<frames.Length;++i){
			sortList.Add( frames[i] );
		}
		sortList.Sort(
			delegate(Texture2D p1, Texture2D p2)
		    {
		        return string.Compare(p1.name,p2.name);
		    }

		);
 	}



 	void Update () 	{
		int currentFrame = (int)(Time.time * frameRate) % sortList.Count;
		if (currentFrame >= sortList.Count)
			currentFrame = sortList.Count - 1;
//		leftMat.mainTexture = rightMat.mainTexture = frames[currentFrame];
		mat.mainTexture = sortList[currentFrame];
	}
}