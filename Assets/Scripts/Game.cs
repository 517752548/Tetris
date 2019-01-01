using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    
    public GameObject[] list;//Collection of all Tetrimos
    public int startX = 0;
    public int endX = 10;
    public int width = 0;
    public int height = 0;

    public Transform[,] grid;

    public void Start()
    {
        if (width == 0) {
            width = (endX - startX)+1;
        }
        if (height == 0) {
            height = 25;
        }

        grid = new Transform[width, height];

        spawnNextTetrimo();

    }



    public void updateGrid(Tetrimo tetrimo) {

        for (int y = 0; y < height; ++y) {
            for (int x = 0; x < width; ++x) {

                if (grid[x, y] != null) {
                    if (grid[x, y].parent == tetrimo.transform) {
                        grid[x, y] = null;
                    }
                }

            }
        }


        foreach (Transform minimo in tetrimo.transform) {
            Vector2 pos = tetrimo.round(minimo.position);
            Debug.Log((int)pos.x+","+(int)pos.y);
            grid[(int)pos.x, (int)pos.y] = minimo;
        }

    }


    public Transform getTransform(Vector2 input) {
        if (input.y >= height) {
            return null;
        }
        
        return grid[(int)input.x, (int)input.y];

    }

    public void spawnNextTetrimo() {

        int index = Random.Range(0, list.Length);
        Instantiate(list[1], new Vector3(5, 18, 0), Quaternion.identity);
    }

    public bool isInGrid(Vector2 pos) {

        if ((int)pos.x <= startX || (int)pos.x > endX) {
            return false;//Retrurns false if outside of x bounds
        }
        if ((int)pos.y < 0) {
            return false;
        }

        return true;

    }


    public bool isRowFull(int y) {
        
        for (int x = 1; x < width; ++x)
        {
            
            if (grid[x, y] == null) {
                return false;
            }
        }
        return true;

    }

    public void deleteRow(int y) {
        for (int x = 1; x < width; ++x) {
            
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
            int temp = y;
            while (temp + 1 < height) {
                if (grid[x, temp + 1] != null) {
                    grid[x, temp + 1].position += Vector3.down;
                    grid[x, temp] = grid[x, temp + 1];
                    grid[x, temp + 1] = null;
                }
                temp++;
                
            }
        }

    }

    public void clearRows() {
        
        for (int y = 0; y < height; ++y) {
            if (isRowFull(y)) {
                
                deleteRow(y);
                --y;
            }

        }
        
            
        

    }




}
