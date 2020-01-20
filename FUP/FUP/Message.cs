using System;
using System.Collections.Generic;
using System.Text;

namespace FUP
{
    public class Constant
    {
        public const uint REQ_FILE_SEND = 0x01;
        public const uint REP_FILE_SEND = 0x02;
        public const uint FILE_SEND_DATA = 0x03;
        public const uint FILE_SEND_RES = 0x04;

        public const byte NOT_FRAGMENT = 0x0;
        public const byte FRAGMENT = 0x1;

        public const byte NOT_LASTMSG = 0x0;
        public const byte LASTMSG = 0x1;

        public const byte DINYED = 0x1;
        public const byte ACCEPT = 0x2;

        public const byte SEND_FAIL = 0x0;
        public const byte SEND_SUCCESS = 0x1;
    }

    public interface ISerializable
    {
        byte[] GetBytes();
        int GetSize();
    }
    public class Message : ISerializable
    {
        public Header Header {get; set; }
        public ISerializable Body { get; set; }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            Header.GetBytes().CopyTo(bytes, 0);
            Body.GetBytes().CopyTo(bytes, Header.GetSize());

            return bytes;

        }

        public int GetSize()
        {
            return Header.GetSize() + Body.GetSize();
        }
       

    }
}
