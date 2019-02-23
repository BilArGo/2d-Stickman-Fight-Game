using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyClass
{
    public bool StringArrayCheck(string[] array, string value)
    {
        bool b = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) b = true;
        }
        return b;
    }

    public bool IntArrayCheck(int[] array, int value)
    {
        bool b = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) b = true;
        }
        return b;
    }

    public bool FloatArrayCheck(float[] array, float value)
    {
        bool b = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) b = true;
        }
        return b;
    }

    public static GameObject OldestParent(GameObject child)
    {
        GameObject oldestParent = child;
        while (true)
        {
            if (oldestParent.transform.parent != null) oldestParent = oldestParent.transform.parent.gameObject;
            else break;
        }
        if (oldestParent == child) Debug.Log(child.name + " is already the oldest parent.");
        return oldestParent;
    }

    public static void print(string text) { print(text); }

    public static bool CheckTransitionName(Animator anim, string animName, int index)
    {
        return anim.GetAnimatorTransitionInfo(index).IsName(animName);
    }

    public static bool CheckStatenName(Animator anim, string animName, int index)
    {
        return anim.GetCurrentAnimatorStateInfo(index).IsName(animName);
    }



}
