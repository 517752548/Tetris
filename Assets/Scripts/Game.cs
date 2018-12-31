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



    public void Start()
    {
        if (width == 0) {
            width = (endX - startX) + 1;
        }
        if (height == 0) {
            height = 20;
        }
    }




    public void spawnNext() {

        int index = Random.Range(0, list.Length);
        Instantiate(list[index], new Vector3(5, 18, 0), Quaternion.identity);
    }

    public bool isInGrid(Vector3 pos) {

        if ((int)pos.x < startX || (int)pos.x > endX) {
            return false;//Retrurns false if outside of x bounds
        }
        if ((int)pos.y < 0) {
            return false;
        }

        return true;

    }




}
