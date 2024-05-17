
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;
    public List<Transform> bodys = new List<Transform>();
    public Transform bodyPrefab;    //用prefab初始化即可
    public int initalSize = 4;
    public float fixedTimeIncreasement = 0.0001f;
    public GameManager manager;
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
            Mathf.Round(transform.position.x + direction.x * transform.localScale.x),
            Mathf.Round(transform.position.y + direction.y * transform.localScale.y),
            0.0f
        );
        if(Time.fixedDeltaTime > 0){
            Time.fixedDeltaTime -= fixedTimeIncreasement;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            manager.Eat(1);
            Grow();
        }
        else if (direction != Vector2.zero && (other.tag == "Wall" || other.tag == "Body"))
        {
            manager.GameOver();
        }
        else if(other.tag == "GreatFood"){
            manager.Eat(5);
            manager.DisableGreatFood();
        }
    }
    private void Grow()
    {
        Debug.Log("GROW");
        Transform body = Instantiate(this.bodyPrefab);
        body.position = bodys[bodys.Count - 1].position;
        bodys.Add(body);
    }
    public void Reset()
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

        for (int i = 1; i < initalSize; i++)
        {
            bodys.Add(Instantiate(bodyPrefab));
        }

        direction = Vector2.zero;
        Time.fixedDeltaTime = 0.2f;
    }
    public bool Occupies(int x, int y)
    {
        foreach (Transform body in bodys)
        {
            if (Mathf.RoundToInt(body.position.x) == x &&
                Mathf.RoundToInt(body.position.y) == y) {
                return true;
            }
        }

        return false;
    }
}
