using System;
using UnityEngine;

public class Indexes : MonoBehaviour
{
    private static byte[] indexes = new byte[10]{255,255,255,255,255,255,255,255,255,255}; // convenient to check if we have random since we can lose 0th element
    
    public static void generateRandomIndexes(){
        byte numberOfQuestions = database.numberOfQuestions;
        System.Random rand = new System.Random();
        for(int i=0 ; i < 10; i++){
            byte index =  Convert.ToByte(rand.Next(0, numberOfQuestions));
            while(contain(indexes, index))index =  Convert.ToByte(rand.Next(0, numberOfQuestions));
            indexes[i] = index;
            //Debug.Log($"index {i} = {index}");
            
        }
    }

    private static bool contain(byte[] a,byte  b){
        for(byte i=0; i < 10; i++)if(a[i] == b)return true;
        return false;
    }

    public static byte getIndex(byte i){return indexes[i];}


}
