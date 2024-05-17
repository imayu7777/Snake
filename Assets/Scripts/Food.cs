
using System;
using System.Drawing;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D grid;
    Bounds bounds;
    private Snake snake;

    void Start()
    {
        snake = FindObjectOfType<Snake>();
        bounds = grid.bounds;
        RandomPosition();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && this.gameObject.tag != "GreatFood")
        {
            RandomPosition();
        }
    }
    public void RandomPosition()
    {
        int x = Mathf.RoundToInt(UnityEngine.Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(UnityEngine.Random.Range(bounds.min.y, bounds.max.y));

        // 对齐网格
        Vector2Int coordinate = AlignFoodWithBody(x, y);

        // 防止生成在蛇身上
        while (snake.Occupies(coordinate.x, coordinate.y))
        {
            coordinate.x += 4; //+4 保持对齐

            if (coordinate.x > bounds.max.x)
            {
                coordinate.x = Mathf.RoundToInt(bounds.min.x);
                coordinate.y += 4;

                if (coordinate.y > bounds.max.y) {
                    coordinate.y = Mathf.RoundToInt(bounds.min.y);
                }
            }
        }

        this.transform.position = new Vector3(coordinate.x, coordinate.y, 0.0f);
    }
    private Vector2Int AlignFoodWithBody(int x, int y){
        // 因为snake的scale是2，所以它的面积实际上是乘以4
        // 当坐标不是4的整数时，食物无法与蛇头对齐，将坐标向中心适当移动
        if (x % 4 != 0)
        {
            if (x > bounds.center.x)
            {
                x -= x % 4;
            }
            else
            {
                x += 4 - x % 4;
            }
        }
        if (y % 4 != 0){
            if (y > bounds.center.y)
            {
                y -= y % 4;
            }
            else
            {
                y += 4 - y % 4;
            }
        }
        return new Vector2Int(x, y);
    }
}