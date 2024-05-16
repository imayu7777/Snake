
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
            // 碰到蛇头
            RandomPosition();
        }
        else if( other.tag == "Body"){
            // 碰到蛇身，即食物生成在蛇身上
            RandomPosition();
        }
    }
    private void RandomPosition(){
        Bounds bounds = grid.bounds;

        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        // 因为snake的scale是2，所以它的面积实际上是乘以4
        // 当坐标不是4的整数时，食物无法与蛇头对齐
        // 但我这样盲目减去余数，可能导致食物生成在墙外
        if (x % 4 != 0) x -= x % 4;
        if (y % 4 != 0) y -= y % 4;

        this.transform.position = new Vector3(x, y, 0.0f);
    }
}