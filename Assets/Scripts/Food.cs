
using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D grid;
    
    void Start()
    {
        RandomPosition();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.tag == "Player"){
            RandomPosition();
        }
    }
    private void RandomPosition(){
        Bounds bounds = grid.bounds;

        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
}