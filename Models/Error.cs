using System;
namespace LightspeedNET.Models
{
    public class Error
    {
        public int httpCode { get; set; }
        public string httpMessage { get; set; }
        public string message { get; set; }
        public string errorClass { get; set; }
    }
}
//<Error><httpCode>401</httpCode>
//<httpMessage>Unauthorized</httpMessage>
//    <message>Token has expired</message>
//    <errorClass>BadAuthenticationRequestException</errorClass>
//    </Error>