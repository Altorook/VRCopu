using UnityEngine;

public class RubCubeLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int[,] faceA = new int[3,3];
    public int[,] faceB = new int[3,3];
    public int[,] faceC = new int[3,3];
    public int[,] faceD = new int[3,3];
    public int[,] faceE = new int[3,3];
    public int[,] faceF = new int[3,3];
    bool isComplete = false;
    void Start()
    {
        GenerateFaceValues(faceA, 0);
        GenerateFaceValues(faceB, 1);
        GenerateFaceValues(faceC, 2);
        GenerateFaceValues(faceD, 3);
        GenerateFaceValues(faceE, 4);
        GenerateFaceValues(faceF, 5);

        ////test zone
        //RotateFace(faceA, true);
        //RotateFace(faceD, true);
        //RotateFace(faceC, false);
        ////RotateFace(faceE, false);
        //RotateFace(faceF, true);
        //RotateFace(faceB, true);
        
        ////for(int i = 0; i < faceA.GetLength(0); i++)
        //{
        //    for(int j = 0; j < faceA.GetLength(1); j++)
        //    {
        //        faceA[i, j] = Random.Range(0, 6);
        //    }
        //    Debug.Log(faceA[i, 0] + "," + faceA[i, 1] + "," + faceA[i, 2]);
        //}
        //RotateFace(faceA, false);
        //Debug.Log("-------");
       
    }
    public bool CheckWin()
    {
        bool hasWon = true;
        for(int i = 0; i < faceA.GetLength(0); i++)
        {
            for(int j = 0; j < faceA.GetLength(1); j++)
            {
                if (faceA[i,j] != 0)
                {
                    hasWon = false;
                }
            }
        }
        for (int i = 0; i < faceB.GetLength(0); i++)
        {
            for (int j = 0; j < faceB.GetLength(1); j++)
            {
                if (faceB[i, j] != 1)
                {
                    hasWon = false;
                }
            }
        }
        for (int i = 0; i < faceC.GetLength(0); i++)
        {
            for (int j = 0; j < faceC.GetLength(1); j++)
            {
                if (faceC[i, j] != 2)
                {
                    hasWon = false;
                }
            }
        }
        for (int i = 0; i < faceD.GetLength(0); i++)
        {
            for (int j = 0; j < faceD.GetLength(1); j++)
            {
                if (faceD[i, j] != 3)
                {
                    hasWon = false;
                }
            }
        }
        for (int i = 0; i < faceE.GetLength(0); i++)
        {
            for (int j = 0; j < faceE.GetLength(1); j++)
            {
                if (faceE[i, j] != 4)
                {
                    hasWon = false;
                }
            }
        }
        for (int i = 0; i < faceF.GetLength(0); i++)
        {
            for (int j = 0; j < faceF.GetLength(1); j++)
            {
                if (faceF[i, j] != 5)
                {
                    hasWon = false;
                }
            }
        }
        isComplete = hasWon;
        return isComplete;
       // Debug.Log(isComplete.ToString());
    }
    public void PrintFaceA()
    {
        for (int i = 0; i < faceA.GetLength(0); i++)
        {
            Debug.Log(faceA[i, 0] + "," + faceA[i, 1] + "," + faceA[i, 2]);
        }
    }
    public void GenerateFaceValues(int[,] face, int val)
    {
        for(int i = 0; i < face.GetLength(0); i++)
        {
            for(int j = 0; j < face.GetLength(1); j++)
            {
                face[i,j] = val;
            }
        }
    }
    public void RotateFace(int[,] face, bool turnLeft)
    {
        int[] topVal = new int[3];
        int[] rightVal = new int[3];
        int[] bottomVal = new int[3];
        int[] leftVal = new int[3];

        //set hold values
        for(int i = 0; i<topVal.Length; i++)
        {
            topVal[i] = face[0,i];
        }
        for (int i = 0; i < rightVal.Length; i++)
        {
            rightVal[i] = face[i, 2];
        }
        for (int i = 0; i < bottomVal.Length; i++)
        {
            bottomVal[i] = face[2, i];
        }
        for (int i = 0; i < leftVal.Length; i++)
        {
            leftVal[i] = face[i, 0];
        }
        //Debug.Log(topVal[0] + " - " + topVal[1] + " - " + topVal[2]);
        //Debug.Log(rightVal[0] + " - " + rightVal[1] + " - " + rightVal[2]);
        //Debug.Log(bottomVal[0] + " - " + bottomVal[1] + " - " + bottomVal[2]);
        //Debug.Log(leftVal[0] + " - " + leftVal[1]+ " - " + leftVal[2]);

        //set values to new
        if (turnLeft)
        {
            for (int i = 0; i < topVal.Length; i++)
            {
                face[0, i] = rightVal[i];
            }
            for (int i = 0; i < rightVal.Length ; i++) // flipped
            {
                face[i, 2] = bottomVal[2-i];
            }
            for (int i = 0; i < bottomVal.Length; i++)
            {
                face[2, i] = leftVal[i];
            }
            for (int i = 0; i < leftVal.Length; i++)//flipped
            {
                face[i, 0] = topVal[2-i];
            }
        }
        else
        {

            for (int i = 0; i < topVal.Length; i++)
            {
                face[0, i] = leftVal[2-i];
            }
            for (int i = 0; i < rightVal.Length; i++) 
            {
                face[i, 2] = topVal[i];
            }
            for (int i = 0; i < bottomVal.Length; i++)
            {
                face[2, i] = rightVal[2-i];
            }
            for (int i = 0; i < leftVal.Length; i++)
            {
                face[i, 0] = bottomVal[i];
            }
        }
        SetOtherFaces(face, turnLeft);
       
    }
   
    public void SetOtherFaces(int[,] rotatedFace,bool isLeft)
    {
        if (rotatedFace[1,1] == 0)
        {
            RotatedAFace(rotatedFace,isLeft);
        }else if(rotatedFace[1,1] == 1)
        {
            RotatedBFace(rotatedFace, isLeft);
        }else if (rotatedFace[1,1] == 2)
        {
            RotatedCFace(rotatedFace, isLeft);
        }
        else if (rotatedFace[1, 1] == 3)
        {
            RotatedDFace(rotatedFace, isLeft);
        }
        else if (rotatedFace[1, 1] == 4)
        {
            RotatedEFace(rotatedFace, isLeft);
        }
        else if (rotatedFace[1, 1] == 5)
        {
            RotatedFFace(rotatedFace, isLeft);
        }
    }

    //top of face == 0,i
    //right of face == i,2
    //bottom of face == 2,i
    //left of face == i,0
    public void RotatedAFace(int[,] face, bool isLeft)
    {
        int[] firstVal = new int[3];
        int[] secondVal = new int[3];
        int[] thirdVal = new int[3];
        int[] fourthVal = new int[3];
        for (int i = 0; i < firstVal.Length; i++)
        {
            firstVal[i] = faceB[0, i];
        }
        for (int i = 0; i < secondVal.Length; i++)
        {
            secondVal[i] = faceE[i, 2];
        }
        for (int i = 0; i < thirdVal.Length; i++)
        {
            thirdVal[i] = faceF[2, 2-i];//inverted
        }
        for (int i = 0; i < fourthVal.Length; i++)
        {
            fourthVal[i] = faceC[2-i, 0];//inverted
        }
        if (!isLeft)
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceC[2 - i, 0] = firstVal[i];//c > b
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceB[0, i] = secondVal[i];//B > E
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceE[i, 2] = thirdVal[i];//E > F
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceF[2, 2 - i] = fourthVal[i];//F > C
            }
        }
        else
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceE[i, 2] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceF[2, 2 - i] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceC[2 - i, 0] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceB[0, i] = fourthVal[i];
            }
        }
    }
    public void RotatedBFace(int[,] face,bool isLeft)
    {
        int[] firstVal = new int[3];
        int[] secondVal = new int[3];
        int[] thirdVal = new int[3];
        int[] fourthVal = new int[3];
        for (int i = 0; i < firstVal.Length; i++)
        {
            firstVal[i] = faceC[0, i];
        }
        for (int i = 0; i < secondVal.Length; i++)
        {
            secondVal[i] = faceD[0, i];
        }
        for (int i = 0; i < thirdVal.Length; i++)
        {
            thirdVal[i] = faceE[0, i];
        }
        for (int i = 0; i < fourthVal.Length; i++)
        {
            fourthVal[i] = faceA[2, 2 - i];
        }
        if (!isLeft)
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceA[2, 2 - i] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceC[0, i] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceD[0, i] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceE[0, i] = fourthVal[i];
            }
        }
        else
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceD[0, i] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceE[0, i] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceA[2, 2 - i] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceC[0, i] = fourthVal[i];
            }
        }
    }
    public void RotatedCFace(int[,] face, bool isLeft)
    {
        int[] firstVal = new int[3];
        int[] secondVal = new int[3];
        int[] thirdVal = new int[3];
        int[] fourthVal = new int[3];
        for (int i = 0; i < firstVal.Length; i++)
        {
            firstVal[i] = faceA[i, 0];
        }
        for (int i = 0; i < secondVal.Length; i++)
        {
            secondVal[i] = faceB[i, 0];
        }
        for (int i = 0; i < thirdVal.Length; i++)
        {
            thirdVal[i] = faceD[i, 0];
        }
        for (int i = 0; i < fourthVal.Length; i++)
        {
            fourthVal[i] = faceF[i, 0];
        }
        if (isLeft)
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceF[i, 0] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceA[i, 0] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceB[i, 0] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceD[i, 0] = fourthVal[i];
            }
        }
        else
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceB[i, 0] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceD[i, 0] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceF[i, 0] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceA[i, 0] = fourthVal[i];
            }
        }
    }
    public void RotatedDFace(int[,] face, bool isLeft)
    {
        int[] firstVal = new int[3];
        int[] secondVal = new int[3];
        int[] thirdVal = new int[3];
        int[] fourthVal = new int[3];
        for (int i = 0; i < firstVal.Length; i++)
        {
            firstVal[i] = faceB[2, 2-i];//Inverted
        }
        for (int i = 0; i < secondVal.Length; i++)
        {
            secondVal[i] = faceE[2-i, 0];//inverted
        }
        for (int i = 0; i < thirdVal.Length; i++)
        {
            thirdVal[i] = faceF[0, i];
        }
        for (int i = 0; i < fourthVal.Length; i++)
        {
            fourthVal[i] = faceC[i, 2];
        }
        if (isLeft)
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceC[i, 2] = firstVal[i];//c > b
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceB[2, 2 - i] = secondVal[i];//B > E
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceE[2-i, 0] = thirdVal[i];//E > F
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceF[0, i] = fourthVal[i];//F > C
            }
        }
        else
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceE[2 - i, 0] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceF[0, i] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceC[i, 2] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceB[2, 2 - i] = fourthVal[i];
            }
        }
    }

    //top of face == 0,i
    //right of face == i,2
    //bottom of face == 2,i
    //left of face == i,0
    public void RotatedEFace(int[,] face, bool isLeft)
    {
        int[] firstVal = new int[3];
        int[] secondVal = new int[3];
        int[] thirdVal = new int[3];
        int[] fourthVal = new int[3];
        for(int i = 0; i < firstVal.Length; i++)
        {
            firstVal[i] = faceA[i, 2];
        }
        for (int i = 0; i < secondVal.Length; i++)
        {
            secondVal[i] = faceB[i, 2];
        }
        for (int i = 0; i < thirdVal.Length; i++)
        {
            thirdVal[i] = faceD[i, 2];
        }
        for (int i = 0; i < fourthVal.Length; i++)
        {
            fourthVal[i] = faceF[i, 2];
        }
        if (isLeft)
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceB[i,2] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceD[i,2] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceF[i,2] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceA[i,2] = fourthVal[i];
            }
        }
        else
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceF[i, 2] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceA[i, 2] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceB[i, 2] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceD[i, 2] = fourthVal[i];
            }
        }
    }
    public void RotatedFFace(int[,] face, bool isLeft)
    {
        int[] firstVal = new int[3];
        int[] secondVal = new int[3];
        int[] thirdVal = new int[3];
        int[] fourthVal = new int[3];
        for (int i = 0; i < firstVal.Length; i++)
        {
            firstVal[i] = faceC[2, i];
        }
        for (int i = 0; i < secondVal.Length; i++)
        {
            secondVal[i] = faceD[2, i];
        }
        for (int i = 0; i < thirdVal.Length; i++)
        {
            thirdVal[i] = faceE[2, i];
        }
        for (int i = 0; i < fourthVal.Length; i++)
        {
            fourthVal[i] = faceA[0, 2-i];
        }
        if (isLeft)
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceA[0, 2-i] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceC[2, i] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceD[2, i] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceE[2, i] = fourthVal[i];
            }
        }
        else
        {
            for (int i = 0; i < firstVal.Length; i++)
            {
                faceD[2, i] = firstVal[i];
            }
            for (int i = 0; i < secondVal.Length; i++)
            {
                faceE[2, i] = secondVal[i];
            }
            for (int i = 0; i < thirdVal.Length; i++)
            {
                faceA[0, 2 - i] = thirdVal[i];
            }
            for (int i = 0; i < fourthVal.Length; i++)
            {
                faceC[2, i] = fourthVal[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
