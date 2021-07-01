using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    public class Kalendar
    {
        public static List<string> dani = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
        "11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29",
            "30","31",};

        public static List<string> meseci = new List<string>() { "Januar","Februar", "Mart", "April","Maj",
            "Jun", "Jul", "Avgust","Septembar","Oktobar","Novembar","Decembar"};


        public static List<string> godine = new List<string>() {
        "1880.","1881.","1882.","1883.", "1884.", "1885.", "1886.", "1887.", "1888.", "1888.","1889.","1890.","1891.","1892.","1893.","1894.","1895.","1896."
        ,"1897.","1898.","1899.","1900.",
        "1910.","1926.","1947.","1951.","1957.","1963.","1972.",
        "1980.","1981.","1982.","1983.", "1984.", "1985.", "1986.", "1987.", "1988.", "1988.",
        "1989.","1990.","1991.","1992.","1993.","1994.","1995.","1996.","1997.","1998.","1999.","2000.","2001.","2002.","2003.","2004.",
            "2005.","2006.","2007.","2008.","2009.","2010.","2011.","2012.","2013.","2014.","2015.","2016."};

        public static List<string> meseci_koji_imaju_31_dan = new List<string>() { "Januar" , "Mart" , "Maj", "Jul" ,
         "Avgust", "Oktobar", "Decembar"};
        

    }
}
