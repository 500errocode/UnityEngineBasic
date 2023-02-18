int a = 14;
int b = 6;
int c = 0;

// 산술 연산
// 더하기, 빼기, 나누기, 곱하기, 나머지
//==========================================
Console.WriteLine("산술연산");

 // 더하기
 c = a + b;
 Console.WriteLine(c);

 // 빼기
 c = a - b;
 Console.WriteLine(c);

 // 나누기 - 정수연산시 나머지 버림
 c = a / b;
 Console.WriteLine(c);

 // 곱하기
 c = a * b;
 Console.WriteLine(c);

 // 나머지 - 실수 연산시 정수연산과 동일함
 c = a % b;
 Console.WriteLine(c);

// 증감 연산
// 증가, 감소 연산자
//=============================
// 증가
Console.WriteLine("증감 연산");

 ++c; // 전위연산 c = c + 1;
 c++; // 후위연산
 c = 0;
 Console.WriteLine(++c);
 Console.WriteLine(c++);
 Console.WriteLine(c);

 // 감소
 --c; // c = c - 1;
 c--;

 // 관계 연산
 // 같음, 다름, 크기 비교 연산
 //==================================================================

 Console.WriteLine("관계연산");

 // 같다
 Console.WriteLine(a == b);

 // 다르다
 Console.WriteLine(a != b);

 // 크기 비교
 Console.WriteLine(a > b);
 Console.WriteLine(a < b);
 Console.WriteLine(a >= b);
 Console.WriteLine(a <= b);

 // 복합 대입 연산
 //산술연산자와 복합해놓은 대입연산자
 //==================================================================

 c = 20;
 c += b;
 c -= b;
 c /= b;
 c *= b;
 c %= b;

 // 논리 연산
 // 논리형의 피연산자들을 대상으로 연산수행
 // or, and, xor, not
 //==================================================================
 Console.WriteLine("논리연산");
 bool A = true;
 bool B = false;

 // or
 // A 와 B 둘중 하나라도 true 이면 true 반환, 나머지경우 false 반환
 Console.WriteLine(A | B);

 // and
 // A 와 B 둘 다 true 이면 true 반환 ,나머지경우 false 반환
 Console.WriteLine(A & B);

 // xor
 // A 와 B 둘중 하나만 true 일때 true 반환, 나머지경우 false 반환
 Console.WriteLine(A ^ B);

 // not
 // bool 값을 반전시키는 연산수행 (true -> false, false -> true)
 Console.WriteLine(!A);

 // 조건부 논리연산자
 // 조건부 or, 조건부 and
 // =====================================================
 Console.WriteLine(A || B);

 // 조건부 and
 // 첫번째 피연산자가 false 이면 B 읽지 않고 false 반환
 Console.WriteLine(A && B);

 // 비트 연산자
 // or, and, xor, not, shift-left, shift-right
 // ===================================================================== 

 // a == 2^3 + 2^2 + 2^1 == 00000000 00000000 00000000 00001110
 // b == 2^2 + 2^0       == 00000000 00000000 00000000 00000101
 //
 // or
 Console.WriteLine(a | b);
 // result

 // and
 Console.WriteLine(a & b);
 // result

 // xor
 Console.WriteLine(a ^ b);
 // result

 // not
 Console.WriteLine(~a);
// result

// 2의 보수
// : 2진수로 표현했을때 모든 자릿수 반전후에 +1
// 컴퓨터가 마이너스 부호를 처리하는 방법
// ~a + 1 == -a
// ~~a + 1 == a

// -a     == 11111111 11111111 11111111 11110010
//~~a     == 00000000 00000000 00000000 00001101
//~~a + 1 == 00000000 00000000 00000000 00001110 == a

// a      == 00000000 00000000 00000000 00001110 == 14
// a << 2 == 00000000 00000000 00000000 00111000 = 56
Console.WriteLine(a << 2);
Console.WriteLine(a >> 1);