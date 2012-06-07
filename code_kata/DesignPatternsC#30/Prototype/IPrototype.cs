using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern
{
    // Prototype Pattern        Judith Bishop  Nov 2007
    // Serialization is used for the deep copy option
    // The type T must be marked with the attribute [Serializable(  )]

    [Serializable]
    public abstract class IPrototype<T>
    {
        // Shallow copy
        public T Clone()
        {
            return (T) MemberwiseClone();
        }

        // Deep Copy
        public T DeepCopy()
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = (T) formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }
}