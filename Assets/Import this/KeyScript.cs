//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEngine;

//public class KeyScript : MonoBehaviour
//{
//    public int levelKey = 1;
//    public GameObject key;
//    public Transform player;
//    public Text keyText;
//    public Text currenttKey;
//    public bool haskey = false;
//    public int currentKey;
    
//    void OnMouseDown()
//    {
//        if (haskey == false && levelKey > currentKey)
//        {
//            keyText.text = "You have picked up a key, level " + levelKey + " acess granted.";
//            levelKey = currentKey;
//            StartCoroutine(KeyWait());
//            haskey = true;
//        }
//        else
//        {
//            keyText.text = "You already have this key, or one of greater value.";
//            StartCoroutine(KeyWait());
//        }
//    }
//    IEnumerator KeyWait() //wait function
//    {
//        yield return new WaitForSeconds(4f);
//        keyText.text = " ";
//    }

//}
