using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] Rigidbody rig;

    [SerializeField] private AudioSource audioSource; // Компонент AudioSource
    [SerializeField] private AudioClip coinSound; // Звуковой файл для монеты

    // text
    public Text countText, winText, mass;
    private int count;

    //private bool isJumping = false;
     

    private void Start()
    {
        count = 0;
        winText.text = "";
        mass.text = "";
        setCount();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rig.AddForce(movement * speed);
    }

    // собираем коины
    private void OnTriggerEnter(Collider other) // когда стоит isTrigger на обьекте с которым нам надо столкнуться, то эта функция срабатывает
    {
        if (other.tag == "Coin") // по тегу ищем
        {
            Destroy(other.gameObject); // уничтожаем обьект с которым прикосаемся
            count++;
            setCount(); 
        }

        // Воспроизводим звук монеты
        if (coinSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }

    void setCount()
    {
        countText.text = "Score: \n" + count.ToString(); // обратились к конвасу - текст
        if (count == 1)
        {
            winText.text = "WIINER!";
            mass.text = "to contunue, pick up coin";
        }
        else if (count >= 2)
        {
            winText.text = "";
            mass.text = "";
        }
    }
}
