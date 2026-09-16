using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{   
    private bool isDead = false;
    private Rigidbody2D rb2D;
    private Animator anim;

    public float upForce = 200f;
    public int ID = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && ID == 1)
            {
                rb2D.linearVelocity = Vector2.zero;
                rb2D.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame && ID == 2)
            {
                rb2D.linearVelocity = Vector2.zero;
                rb2D.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.linearVelocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied(ID);
    }
}
