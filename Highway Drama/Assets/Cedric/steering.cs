using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 7.83f;

    Vector3 position;
    public AudioManager am;
    // Start is called before the first frame update
    void Awake()
    {
        am.carSound.Play();
    }
    void Start()
    {
        
        position = transform.position;
   
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -0.11f, 7.83f);

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            am.carSound.Stop();
        }
    }
}
