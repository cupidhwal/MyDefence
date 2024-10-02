using UnityEngine;

namespace SOLID
{
    public class UnrefactoredAreaCalculator
    {
        //�Ű������� �簢���� �޾� ������ ��ȯ�ϴ� �Լ�
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.width * rectangle.height;
        }

        //�Ű������� ���� �޾� ������ ��ȯ�ϴ� �Լ�
        public float GetCircleArea(Circle circle)
        {
            return circle.radius * circle.radius * Mathf.PI;
        }
    }

    //�簢�� Ŭ����
    public class Rectangle
    {
        public float width;
        public float height;
    }

    //�� Ŭ����
    public class Circle
    {
        public float radius;
    }
}