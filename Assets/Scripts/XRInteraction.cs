using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Box1;
    [SerializeField] Material material1;
    bool Active1 = false;
    bool isNext = false;
    bool isblack = false;
    bool isEnd = false;
    float color = 0;
    int count = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")
        {
            Destroy(other.gameObject);
            isEnd = true;
            isNext = true;
            material1.color = new Color(material1.color.r, material1.color.g, material1.color.b, color);
            Invoke("Loading", 2.0f);
        }
        if (other.transform.name == "Shoes")
        {
            Destroy(other.gameObject);
            isEnd = true;
            isNext = true;
            if (!isblack)
            {
                material1.color = new Color(0, 0, 0, 0);
                isblack = true;
            }
            material1.color = new Color(material1.color.r, material1.color.g, material1.color.b, color);
            Invoke("Quiting", 2.0f);
        }
        if (other.transform.name == "Pinp")
        {
            Destroy(other.gameObject);
            count++;
            if (!Active1)
            {
                Panel1.SetActive(true);
                Active1 = true;
            }
            else
            {
                Panel1.SetActive(false);
                Active1 = false;
            }
        }
    }
    private void FixedUpdate()
    {
        color = Mathf.Clamp(color, 0, 1);
        if (isNext) color += Time.deltaTime;
        if (isEnd) Box1.transform.position = gameObject.transform.position + new Vector3(0, 0, 0.5f);
        if (count == 10)
        {
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3;
            count = 0;
        }
    }
    void Loading()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Quiting()
    {
        Application.Quit();
    }
}
