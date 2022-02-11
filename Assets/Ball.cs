using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    public float damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(speed, Random.Range(-1, 1) * speed, Random.Range(-1, 1) * speed);
    }

    internal void OnWallCollide()
    {

    }
    internal void OnBrickCollide(Brick brick)
    {
        brick.Health = brick.Health - (int) Mathf.Ceil(damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");
        if(collision.collider.GetComponent<Brick>())
        {
            OnBrickCollide(collision.collider.GetComponent<Brick>());
        }
        else
        {
            OnWallCollide();
        }
    }
}
