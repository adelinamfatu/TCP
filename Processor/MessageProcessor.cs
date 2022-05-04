using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    static public class MessageProcessor
    {
        static Byte[] buffer = null;
        static int size;
        static int index;
        static public void process(Byte[] bytes, int dim, Action<string> addMessage)
        {
            if (buffer == null)
            {
                size = 256 * bytes[0] + bytes[1];
                buffer = new Byte[size];
                if (dim - 2 < size)
                {
                    Buffer.BlockCopy(bytes, 2, buffer, 0, dim - 2);
                    index = dim - 2;
                }
                else
                {
                    Buffer.BlockCopy(bytes, 2, buffer, 0, size);
                    string data = System.Text.Encoding.ASCII.GetString(buffer, 0, size);
                    addMessage(data);
                    buffer = null;
                    if (dim - 2 - size > 0)
                    {
                        Byte[] aux = new Byte[dim - 2 - size];
                        Buffer.BlockCopy(bytes, size + 2, aux, 0, dim - 2 - size);
                        process(aux, dim - 2 - size, addMessage);
                    }
                }
            }
            else
            {
                if (dim <= size - index)
                {
                    Buffer.BlockCopy(bytes, 0, buffer, index, dim);
                    index = index + dim;
                    if (index == size)
                    {
                        string data = System.Text.Encoding.ASCII.GetString(buffer, 0, size);
                        addMessage(data);
                        buffer = null;
                    }
                }
                else
                {
                    Buffer.BlockCopy(bytes, 0, buffer, index, size - index);
                    string data = System.Text.Encoding.ASCII.GetString(buffer, 0, size);
                    addMessage(data);
                    buffer = null;
                    Byte[] aux = new Byte[dim - (size - index)];
                    Buffer.BlockCopy(bytes, size - index, aux, 0, dim - (size - index));
                    process(aux, dim - (size - index), addMessage);
                }
            }
        }
    }
}
