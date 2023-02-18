// 배열
// 특정한 자료구조를 연속적으로 할당해놓은 형태의 자료구조

// 배열 선언 형태
// : 자료형[] 배열이름
// 배열 동적할당 형태
// : 
// 1. new 자료형[자료갯수]
// 2. {자료1, 자료2 ...}
// 3. new 자료형 [자료갯수] {자료1, 자료2 ...}
// 배열은 '참조'형 이며, 힘영역에 동적할당함
int[] arrint = new int[3];
int[] arrint2 = { 1, 3, 5, 2 };
float[] arrfloat = new float[4] { 1.0f, 2.1f, 3.4f, 2.2f };

// 인덱서
// []
// 인덱스 접근하기위한 연산자
// 일반적인 배열에서 인덱서는
// 일반적인 배열에서 인덱서는 해당 배열의 주소 + 인덱스 * 단위 자료형 위치의 주소에 접근함
arrint[0] = 1;
arrint[1] = 2;
//arrint[3] = 3; // 범위를 벗어난 인덱스 접근은 예외처리됨
int index = 0;
while (index < arrfloat.Length)
{
    Console.WriteLine(arrfloat[index]);
    index++;
}
/*
for (int i = 0; i < arrfloat.Length; i++)
{
    Console.WriteLine(arrfloat[i]);
}
*/