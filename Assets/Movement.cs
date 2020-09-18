using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Movement : MonoBehaviour
{
    public float speed = 2.5f;
    float speedMultiplier = 1;
    private Vector3 initialScale;
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            speedMultiplier = 0.4f;
            transform.DOScale(initialScale * 1.6f, 0.4f).OnComplete(() => { speedMultiplier = 1; transform.DOScale(initialScale, 0.4f); });
            transform.DOLocalMoveY(transform.position.y + 1, 0.4f).onComplete+=()=>transform.DOLocalMoveY(transform.position.y - 1, 0.4f);

        }
    }
    void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right * movement * speed * speedMultiplier, Time.deltaTime);

    }
}
