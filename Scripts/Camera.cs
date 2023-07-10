using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject player; // наш обьеккт которым движемся
    private Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // узнаем какой отступ у нашего обьекта к камере
    }

    // Update is called once per frame
    void LateUpdate() // late - вызывается один раз вконце фрейма, не вначале, счтобы видно было что обьект движется 
    {
        transform.position = player.transform.position + offset; // движение за обьектом
    }
}
