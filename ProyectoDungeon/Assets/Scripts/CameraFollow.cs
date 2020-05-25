using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    Vector3 targetPos;
    public Vector2 minPos;
    public Vector2 maxPos;
    public float lerp;

    
    // Start is called before the first frame update
    void Start()
    {
        //Para inicializar la camara en la posicion del personaje
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (transform.position != target.position)
        {
            targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(target.position.x, minPos.x, maxPos.x); //Seteo los maximos y minimos de la camara
            targetPos.y = Mathf.Clamp(target.position.y, minPos.y, maxPos.y); //
            transform.position = Vector3.Lerp(transform.position, targetPos, lerp); //Mueve la camara a la posicion del target con un delay = a lerp
        }

    }
}
