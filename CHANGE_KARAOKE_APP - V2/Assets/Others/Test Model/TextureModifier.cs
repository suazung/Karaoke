using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureModifier : MonoBehaviour {	

	public class Node{
		public TextureModifier parent;
		public Node(TextureModifier _parent){ parent = _parent; }
		public Node prevNode = null;
		public Node nextNode = null;

		public int x = -1;
		public int y = -1;

		public float _value = 1f;

		public void RadiateValue(Node fromNode){
			Node nodeToRadiate = null;
			if(fromNode == nextNode){
				nodeToRadiate = prevNode;
			}else if(fromNode == prevNode){
				nodeToRadiate = nextNode;
			}else{ return; }

			if(nodeToRadiate != null){
				nodeToRadiate._value -= (1f-_value)*TRANSMIT_RATE;
				//Debug.Log(""+nodeToRadiate.x+","+nodeToRadiate.y+" value:"+nodeToRadiate._value);
				parent.SetPixelFromNodeValue( nodeToRadiate );
				nodeToRadiate.RadiateValue(this);
			}
		}
	}

	public Node [,]nodes;

	private const int NUM_X = 128;
	private const int NUM_Y = 128;

	public Material mat;
	private Texture2D texture;

	private Color cacheCol;

	private const float TRANSMIT_RATE = 0.9f;

	// Use this for initialization
	void Start () {
		nodes = new Node[NUM_X,NUM_Y];

		texture = new Texture2D(NUM_X, NUM_Y);
		cacheCol = Color.white;
		mat.SetTexture("_Alpha",texture);

        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                //Color color = ((x & y) != 0 ? Color.white : Color.gray);
				//Color color = x > 64?  Color.white : new Color(0f,0f,0f,0.1f);

				Color color = Color.white;

                texture.SetPixel(x, y, color);

                Node newNode = new Node(this);
                newNode.x = x;
                newNode.y = y;
				if(y > 0){ 
					Node prevNode = nodes[x,y-1];
					newNode.prevNode = prevNode; 
					prevNode.nextNode = newNode; 
				}

				nodes[x,y] = newNode;
            }
        }


        for(int i=0;i<NUM_X;++i){
			Node nodeToRadiate = nodes[i,64];
			nodeToRadiate._value = 0f;
			nodeToRadiate.RadiateValue(nodeToRadiate.prevNode);
			nodeToRadiate.RadiateValue(nodeToRadiate.nextNode);
		}

        texture.Apply();
	}

	public void SetPixelFromNodeValue(Node _node){
		cacheCol.a = _node._value;

		texture.SetPixel(_node.x,_node.y,cacheCol);
	}


}
