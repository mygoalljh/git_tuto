﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FUP
{
    public class BodyRequest : ISerializable
    {
        public long FILESIZE;
        public byte[] FILENAME;

        public BodyRequest() { }
        public BodyRequest(byte[] bytes)
        {
            FILESIZE = BitConverter.ToInt64(bytes, 0);
            FILENAME = new byte[bytes.Length - sizeof(long)];
            Array.Copy(bytes, sizeof(long), FILENAME, 0, FILENAME.Length);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(FILESIZE);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            Array.Copy(FILENAME, 0, bytes, temp.Length, FILENAME.Length);

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(long) + FILENAME.Length;
        }
    }
        public class BodyResponse : ISerializable
        {
            public uint MSGID;
            public byte RESPONSE;
            public BodyResponse() { }
            public BodyResponse(byte[] bytes)
            {
                MSGID = BitConverter.ToUInt32(bytes, 0);
                RESPONSE = bytes[4];
            }

            public byte[] GetBytes()
            {
                byte[] bytes = new byte[GetSize()];
                byte[] temp = BitConverter.GetBytes(MSGID);
                Array.Copy(temp, 0, bytes, 0, temp.Length);
                bytes[temp.Length] = RESPONSE;

                return bytes;
            }

            public int GetSize()
            {
                return sizeof(uint) + sizeof(byte);
            }


        }

        public class BodyData : ISerializable
        {
            public byte[] Data;
            public BodyData() { }
            public BodyData(byte[] bytes)
            {
                Data = new byte[bytes.Length];
                bytes.CopyTo(Data, 0);
            }

            public byte[] GetBytes()
            {
                return Data;
            }

            public int GetSize()
            {
                return Data.Length;
            }
        }

        public class BodyResult : ISerializable
        {
            public uint MSGID;
            public byte RESULT;

            public BodyResult() { }
            public BodyResult(byte[] bytes)
            {
                MSGID = BitConverter.ToUInt32(bytes, 0);
                RESULT = bytes[4];
            }

            public byte[] GetBytes()
            {
                byte[] bytes = new byte[GetSize()];
                byte[] temp = BitConverter.GetBytes(MSGID);
                Array.Copy(temp, 0, bytes, 0, temp.Length);
                bytes[temp.Length] = RESULT;

                return bytes;
            }
            public int GetSize()
            {
                return sizeof(uint) + sizeof(byte); 
            }
        }


    
}
