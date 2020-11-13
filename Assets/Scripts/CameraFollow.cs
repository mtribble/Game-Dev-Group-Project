 using UnityEngine;
 using System.Collections;
 
 public class CameraFollow : MonoBehaviour {
 
     private Transform player;
     public float speed;
 
     void Start () {
         player = GameObject.Find ("Player").transform;
     }
     
     void LateUpdate () {
         Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
         Debug.Log(Vector3.MoveTowards(transform.position, targetPos, speed));
         transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
     }
 }