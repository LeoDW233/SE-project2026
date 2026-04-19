using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBlcok : MonoBehaviour{

    [SerializeField]private Transform PosA,PosB;
    private Transform tragetPos;
    [SerializeField]private float speed;
    


    // Start is called before the first frame update
    void Start()
    {
        tragetPos = PosB;
    }

    // Update is called once per frame
    void Update()
    {
      if(Vector2.Distance(transform.position,PosA.position)<0.1f){
        tragetPos = PosB;
      }
      if(Vector2.Distance(transform.position,PosB.position)<0.1f){
        tragetPos = PosA;
      }
      transform.position = Vector2.MoveTowards(transform.position,tragetPos.position,speed * Time.deltaTime);//第一个传入自身坐标，第二个传入目标坐标，第三个传入速度
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            collision.transform.parent = this.transform;

        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            collision.transform.parent = null;
        }
    }
}
