using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Alejandria.Logica
{
    class Desencryptacion
    {
        static private AES aes = new AES();
        static public string CnString;
        static string dbcnString;
        static public string appPwdUnique = "Ada369.codigo369.BASEADA.Hola_MundoÑ";


        public static object checkServer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            dbcnString = root.Attributes[0].Value;
            CnString = (aes.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
            return CnString;

        }
       
       
    }
}
