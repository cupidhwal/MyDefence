using UnityEngine;

namespace SOLID
{
    public class UnrefactoredAreaCalculator
    {
        //매개변수로 사각형을 받아 면적을 반환하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.width * rectangle.height;
        }

        //매개변수로 원을 받아 면적을 반환하는 함수
        public float GetCircleArea(Circle circle)
        {
            return circle.radius * circle.radius * Mathf.PI;
        }
    }

    //사각형 클래스
    public class Rectangle
    {
        public float width;
        public float height;
    }

    //원 클래스
    public class Circle
    {
        public float radius;
    }
}