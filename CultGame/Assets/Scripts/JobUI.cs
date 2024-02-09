using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class JobUI : MonoBehaviour
{
    [SerializeField] PriorityList list;
    public Image BackGround;
    private void Awake()
    {
        list = FindObjectOfType<PriorityList>();
    }
    public void TaskOnClick()
    {
        Debug.Log("Button Hit");
        list.OnButton(gameObject);
    }
}
