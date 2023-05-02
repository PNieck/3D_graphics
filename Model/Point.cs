namespace _3D_graphics.Model
{
    public class Point
    {
        private float _x;
        public float x { get { return _x; } set { _x = value; } }

        private float _y;
        public float y { get { return _y; } set { _y = value; } }

        private float _z;
        public float z { get { return _z; } set { _z = value; } }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
