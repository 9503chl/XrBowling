using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] Image Image1;
    bool Active1 = false;
    bool isNext = false;
    float alpha = 0;
    bool isblack = false;
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ball")
        {
            isNext = true;
            Destroy(other.gameObject);
            Invoke("Loading", 2.0f);
            Image1.color = new Color(Image1.color.r, Image1.color.g, Image1.color.b, alpha);
        }
        if (other.transform.name == "Shoes")
        {
            isNext = true;
            Destroy(other.gameObject);
            Invoke("Quiting", 2.0f);
            if (!isblack)
            {
                Image1.color = new Color(0, 0, 0, 0);
                isblack = true;
            }
            Image1.color = new Color(Image1.color.r, Image1.color.g, Image1.color.b, alpha);
        }
        if (other.transform.name == "Pinp")
        {
            Destroy(other.gameObject);
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
    private void Update()
    {
        Image1.transform.position = gameObject.transform.position + new Vector3(0, 0, 0.5f);
        alpha = Mathf.Clamp(alpha, 0, 1);
        if(isNext) alpha += Time.deltaTime;
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
