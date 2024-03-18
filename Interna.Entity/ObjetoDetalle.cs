using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoDetalle : Interna.Core.Entity
    {
        [DataMember]
        [Column(Name = "iID")]
        public int ID { get; set; }
        [DataMember]
        public string Campos { get; set; }
        [DataMember]
        public string s01 { get; set; }
        [DataMember]
        public string s02 { get; set; }
        [DataMember]
        public string s03 { get; set; }
        [DataMember]
        public string s04 { get; set; }
        [DataMember]
        public string s05 { get; set; }
        [DataMember]
        public string s06 { get; set; }
        [DataMember]
        public string s07 { get; set; }
        [DataMember]
        public string s08 { get; set; }
        [DataMember]
        public string s09 { get; set; }
        [DataMember]
        public string s10 { get; set; }
        [DataMember]
        public string s11 { get; set; }
        [DataMember]
        public string s12 { get; set; }
        [DataMember]
        public string s13 { get; set; }
        [DataMember]
        public string s14 { get; set; }
        [DataMember]
        public string s15 { get; set; }
        [DataMember]
        public string s16 { get; set; }
        [DataMember]
        public string s17 { get; set; }
        [DataMember]
        public string s18 { get; set; }
        [DataMember]
        public string s19 { get; set; }
        [DataMember]
        public string s20 { get; set; }
        [DataMember]
        public string s21 { get; set; }
        [DataMember]
        public string s22 { get; set; }
        [DataMember]
        public string s23 { get; set; }
        [DataMember]
        public string s24 { get; set; }
        [DataMember]
        public string s25 { get; set; }
        [DataMember]
        public string s26 { get; set; }
        [DataMember]
        public string s27 { get; set; }
        [DataMember]
        public string s28 { get; set; }
        [DataMember]
        public string s29 { get; set; }
        [DataMember]
        public string s30 { get; set; }
        [DataMember]
        public string s31 { get; set; }
        [DataMember]
        public string s32 { get; set; }
        [DataMember]
        public string s33 { get; set; }
        [DataMember]
        public string s34 { get; set; }
        [DataMember]
        public string s35 { get; set; }
        [DataMember]
        public string s36 { get; set; }
        [DataMember]
        public string s37 { get; set; }
        [DataMember]
        public string s38 { get; set; }
        [DataMember]
        public string s39 { get; set; }
        [DataMember]
        public string s40 { get; set; }
        [DataMember]
        public string s41 { get; set; }
        [DataMember]
        public string s42 { get; set; }
        [DataMember]
        public string s43 { get; set; }
        [DataMember]
        public string s44 { get; set; }
        [DataMember]
        public string s45 { get; set; }
        [DataMember]
        public string s46 { get; set; }
        [DataMember]
        public string s47 { get; set; }
        [DataMember]
        public string s48 { get; set; }
        [DataMember]
        public string s49 { get; set; }
        [DataMember]
        public string s50 { get; set; }
        [DataMember]
        public string s51 { get; set; }
        [DataMember]
        public string s52 { get; set; }
        [DataMember]
        public string s53 { get; set; }
        [DataMember]
        public string s54 { get; set; }
        [DataMember]
        public string s55 { get; set; }
        [DataMember]
        public string s56 { get; set; }
        [DataMember]
        public string s57 { get; set; }
        [DataMember]
        public string s58 { get; set; }
        [DataMember]
        public string s59 { get; set; }
        [DataMember]
        public string s60 { get; set; }
        [DataMember]
        public int i01 { get; set; }
        [DataMember]
        public int i02 { get; set; }
        [DataMember]
        public int i03 { get; set; }
        [DataMember]
        public int i04 { get; set; }
        [DataMember]
        public int i05 { get; set; }
        [DataMember]
        public int i06 { get; set; }
        [DataMember]
        public int i07 { get; set; }
        [DataMember]
        public int i08 { get; set; }
        [DataMember]
        public int i09 { get; set; }
        [DataMember]
        public int i10 { get; set; }
        [DataMember]
        public int i11 { get; set; }
        [DataMember]
        public int i12 { get; set; }
        [DataMember]
        public int i13 { get; set; }
        [DataMember]
        public int i14 { get; set; }
        [DataMember]
        public int i15 { get; set; }

        [DataMember]
        private DateTime d01_p;
        [DataMember]
        public DateTime d01
        {
            get
            {
                return d01_p;
            }
            set
            {
                if (value != null) d01_p = value;
            }
        }
        [DataMember]
        private DateTime d02_p;
        [DataMember]
        public DateTime d02
        {
            get
            {
                return d02_p;
            }
            set
            {
                if (value != null) d02_p = value;
            }
        }
        [DataMember]
        private DateTime d03_p;
        [DataMember]
        public DateTime d03
        {
            get
            {
                return d03_p;
            }
            set
            {
                if (value != null) d03_p = value;
            }
        }
        [DataMember]
        private DateTime d04_p;
        [DataMember]
        public DateTime d04

        {
            get
            {
                return d04_p;
            }
            set
            {
                if (value != null) d04_p = value;
            }
        }
        [DataMember]
        private DateTime d05_p;
        [DataMember]
        public DateTime d05
        {
            get
            {
                return d05_p;
            }
            set
            {
                if (value != null) d05_p = value;
            }
        }
        [DataMember]
        public decimal f01 { get; set; }
        [DataMember]
        public decimal f02 { get; set; }
        [DataMember]
        public decimal f03 { get; set; }
        [DataMember]
        public decimal f04 { get; set; }
        [DataMember]
        public decimal f05 { get; set; }
        [DataMember]
        public string x01 { get; set; }
        [DataMember]
        public string x02 { get; set; }


        public ObjetoDetalle()
        {
            IFormatProvider culture = new CultureInfo("es-PE", true);

            d01_p = DateTime.Parse("01/01/1980", culture);
            d02_p = DateTime.Parse("01/01/1980", culture);
            d03_p = DateTime.Parse("01/01/1980", culture);
            d04_p = DateTime.Parse("01/01/1980", culture);
            d05_p = DateTime.Parse("01/01/1980", culture);
        }

        public List<ObjetoDetalle> rObtenerDetalle(ObjetoDetalle oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", oO.ID));
            return oSql.TablaParametro<ObjetoDetalle>("EXI_R_OBJETO_DETALLE", oP);
        }
    }
}
