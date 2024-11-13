using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int startHp;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private int currHp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currHp = startHp;
    }

    void Update()
    {
        rb.velocity = Vector2.left * speed;
    }

    public void RemoveHp(int damage)
    {
        currHp -= damage;
        Debug.Log(currHp);
        if (currHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
