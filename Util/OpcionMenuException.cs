using System;

namespace CentralTelefonica.Util
{
    public class OpcionMenuException: Exception
    {
        public string message= "Error, debe de ingresar un numero";
        public override string Message 
        {
            get{return message;}
        }
    }
}