
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;
    public List<Transform> bodys = new List<Transform>();
    public Transform bodyPrefab;    //用prefab初始化即可
    public int initalSize = 4;
    void Start()
    {
        Reset();
    }
    private void Update()
    // 按帧调用
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    // 按固定时间间隔调用，多用于处理物理行为
    {
        for (int i = bodys.Count - 1; i > 0; i--)
        {
            //倒序遍历，每一节都等于前一节的位置
            bodys[i].position = bodys[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round((this.transform.position.x) + direction.x*transform.localScale.x),
            Mathf.Round((this.transform.position.y) + direction.y*transform.localScale.y),
            0.0f
        );
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (direction != Vector2.zero && other.tag == "Obstacle")
        {
            Reset();
        }
    }
    private void Grow()
    {
        Debug.Log("GROW");
        Transform body = Instantiate(this.bodyPrefab);
        body.position = bodys[bodys.Count - 1].position;
        bodys.Add(body);
    }
    private void Reset()
    {
        Debug.Log("RESET");
        // 删除身体
        for (int i = 1; i < bodys.Count; i++)
        {
            Destroy(bodys[i].gameObject);
        }
        bodys.Clear();

        this.transform.position = Vector3.zero;
        bodys.Add(this.transform);

        for(int i=1; i<initalSize; i++){
            bodys.Add(Instantiate(bodyPrefab));
        }

        direction = Vector2.zero;
    }
    public bool inBody(float x, float y)
    {
        for (int i = 0; i < bodys.Count; i++){
            if(bodys[i].transform.position.x == x && bodys[i].transform.position.y == y){
                return true;
            }
        }
        return false;
    }
}
