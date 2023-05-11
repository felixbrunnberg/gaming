using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private const string Tag = "MainCamera";
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public Transform GunTransform;
    // Start is called before the first frame update
    void Start()
    {
        shooting shootingScript = FindObjectOfType<shooting>();

        GunTransform = shootingScript.transform;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        // rb.velocity = new Vector2(direction.x, -direction.y).normalized * force;
        rb.AddForce(GunTransform.right * 10, ForceMode2D.Impulse);
        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().DamageEnemy();
        }
        Debug.Log("AMONGUS");
        gameObject.SetActive(false);
    }
}
