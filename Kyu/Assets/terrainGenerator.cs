
using UnityEngine;

public class terrainGenerator : MonoBehaviour {

	public int depth = 20;

	public int width = 256;
	public int height = 256; //lenght


	public float scale = 20f;

	void Start()
	{
		Terrain terrain = GetComponent<Terrain>();
		terrain.terrainData = GenerateTerrain (terrain.terrainData);
	}


	TerrainData GenerateTerrain(TerrainData terrainData)
	{
		terrainData.size = new Vector3 (width, depth, height);

		//2 dim array of float, each float is the height of our terrain in a given point
		terrainData.SetHeights(0,0,GenerateHeights());

		return terrainData;
	}


	float[,] GenerateHeights()
	{
		float[,] heights = new float[width, height];//grid of floats
		for (int x = 0; x < width; x++) 
		{
			for (int y = 0; y < height; y++) 
			{
				heights[x, y] = CalculateHeight (x, y); //SOME PERLIN NOISE VALUE
			}
		}
		return heights;
	}


	float CalculateHeight (int x, int y)
	{
		float xCoord = x / width * scale;//we use scale for zooming
		float yCoord = y / height * scale;
		//Converts into NoiseCoord
		return Mathf.PerlinNoise (xCoord, yCoord);
	}




}
