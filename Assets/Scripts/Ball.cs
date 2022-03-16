using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    public float speed = 5;
    public float damage = 1;
    public Vector3 vector = Vector3.zero;
    // Start is called before the first frame update
    public void Start()
    {
        vector = getRandomVector();
    }
    internal void Update()
    {
        transform.position += vector * speed * Time.deltaTime;
        if(Mathf.Abs(transform.position.x) > 23 || Mathf.Abs(transform.position.y) > 23 || Mathf.Abs(transform.position.z) > 23)
        {
            transform.position = Vector3.zero;
        }
    }
    public Brick GetClosestBrick(Vector3 pos)
    {
        BrickLoader loader = GameObject.Find("Inverted Cube").GetComponent<BrickLoader>();
        List<Brick> bricks = new List<Brick>(loader.GetComponentsInChildren<Brick>());
        Brick closest = null;
        foreach (Brick brick in bricks)
        {
            if (closest == null)
            {
                closest = brick;
                continue;
            }
            if (Vector3.Distance(brick.transform.position, pos) < Vector3.Distance(closest.transform.position, pos))
            {
                closest = brick;
            }
        }
        return closest;
    }
    internal Vector3 getRandomVector()
    {
        return new Vector3(Random.Range(-100, 100) / 100f, Random.Range(-100, 100) / 100f, Random.Range(-100, 100) / 100f);
    }
    public virtual void OnWallCollide()
    {

    }

    internal void OnBrickCollide(Brick brick)
    {
        brick.Health = brick.Health - (int) Mathf.Ceil(damage);
        MoneyCounter.AddMoney((int)Mathf.Clamp(damage, 0, brick.Health));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Brick>())
        {
            Debug.Log("brick");
            vector = Vector3.Reflect(vector, collision.GetContact(0).normal);
            OnBrickCollide(collision.collider.GetComponent<Brick>());
        }
        else if(collision.collider.GetComponent<Ball>())
        {
            Debug.Log("ball");
        }
        else
        {
            vector = Vector3.Reflect(vector, collision.GetContact(0).normal);
            Debug.Log("wall");
            OnWallCollide();
        }
    }
}
