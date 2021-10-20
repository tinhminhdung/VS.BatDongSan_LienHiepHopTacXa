using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Album_Images
    {
        #region[Entity Private]
        private int _ID;
        private int _Menu_ALB;
        private int _Menu_ID;
        private string _Title;
        private string _Brief;
        private string _Images;
        private string _ImagesSmall;
        private int _Equals;
        private int _Orders;
        private int _Status;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int Menu_ALB { get { return _Menu_ALB; } set { _Menu_ALB = value; } }
        public int Menu_ID { get { return _Menu_ID; } set { _Menu_ID = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Brief { get { return _Brief; } set { _Brief = value; } }
        public string Images { get { return _Images; } set { _Images = value; } }
        public string ImagesSmall { get { return _ImagesSmall; } set { _ImagesSmall = value; } }
        public int Equals { get { return _Equals; } set { _Equals = value; } }
        public int Orders { get { return _Orders; } set { _Orders = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        #endregion

    }
}
