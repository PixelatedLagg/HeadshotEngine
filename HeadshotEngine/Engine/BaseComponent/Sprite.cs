namespace HeadshotEngine
{
    public struct Sprite : BaseComponent
    {
        private Vector transform;
        private Vector size;
        internal string? tag;
        public Sprite(float x, float y, float sizex, float sizey, string file, string? tag = null)
        {
            if (tag != null)
            {
                this.tag = tag;
            }
            else
            {
                this.tag = null;
            }
            transform = new Vector(x, y);
            size = new Vector(sizex, sizey);
            tag = null;
        }
        public void Render()
        {
            //render
        }
    }
}