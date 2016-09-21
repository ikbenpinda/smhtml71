using System;

namespace formsapp2
{
    public class Media
    {
        private string title;
        private string base64;

        public Type type;
        public string ext;
        public Media(string title, string base64)
        {
            this.title = title;
            this.base64 = base64;
        }

        public string getTitle()
        {
            return this.title;
        }

        public string getBase64()
        {
            return this.base64;
        }

        public string getExt()
        {
            return this.ext;
        }
        public void setExt(string type)
        {
            this.ext = type;
        }
    }
}

