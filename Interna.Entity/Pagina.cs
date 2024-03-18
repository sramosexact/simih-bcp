using System;

namespace Interna.Entity
{
    [Serializable]
    public class Pagina : Interna.Core.Entity
    {
        private const int LONGITUD_PAGINA = 100;
        #region Privado
        private int iPageRecordIndex = 0;
        private int iPageRecordLen = 0;
        private int iPageLen = 1;
        private int iPageIndex = 1;
        private int iPageWidth = LONGITUD_PAGINA;
        private int iPageLastIndex = 1;
        private int iPageError = 0;
        #endregion

        #region Propiedades
        public int PageRecordIndex { get { return iPageRecordIndex; } set { iPageRecordIndex = value; PageCalc(); } }
        public int PageLen { get { return iPageLen; } set { } }
        public int PageIndex { get { return iPageIndex; } set { iPageIndex = value; PageCalc(); } }
        public int PageWidth { get { return iPageWidth; } set { iPageWidth = value; PageCalc(); } }
        public int PageLastIndex { get { return iPageLastIndex; } set { } }
        public int PageError { get { return iPageError; } set { } }
        public int PageRecordLen
        {
            set
            {
                if (value <= 0)
                {
                    iPageError = -1;
                    iPageRecordIndex = 0;
                    iPageRecordLen = 0;
                    return;
                }
                iPageRecordLen = value;
                iPageRecordIndex = 1;
                if (iPageRecordLen > iPageWidth)
                {
                    iPageWidth = LONGITUD_PAGINA;
                }
                iPageError = 0;
                PageCalc();
            }

            get
            {
                return iPageRecordLen;
            }
        }
        #endregion

        #region Metodos

        private int PageCalc()
        {
            if (iPageRecordLen < 1) iPageRecordLen = 1;
            if (iPageRecordIndex < 1) iPageRecordIndex = 1;
            if (iPageLen < 1) iPageLen = 1;
            if (iPageWidth < 1) iPageWidth = 1;
            if (iPageIndex < 1) iPageIndex = 1;
            if (iPageRecordIndex > iPageRecordLen) iPageRecordIndex = iPageRecordLen;
            if (iPageWidth > iPageRecordLen) iPageWidth = iPageRecordLen;

            iPageLen = int.Parse(Math.Ceiling((double)iPageRecordLen / iPageWidth).ToString());
            if (iPageIndex > iPageLen) iPageIndex = iPageLen;

            // Indice final
            iPageLastIndex = ((iPageLen - 1) * iPageWidth) + 1;

            // Registro Actual
            iPageRecordIndex = (iPageIndex * iPageWidth) - (iPageWidth - 1);

            return iPageRecordIndex;
        }

        public int MoveFirst()
        {
            iPageIndex = 1;
            return PageCalc();
        }

        public int MoveNext()
        {
            iPageIndex++;
            return PageCalc();
        }

        public int MoveBack()
        {
            iPageIndex--;
            return PageCalc();
        }

        public int MoveLast()
        {
            iPageIndex = this.PageLastIndex;
            return PageCalc();
        }

        #endregion
    }
}

