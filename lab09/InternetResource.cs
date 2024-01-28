using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    internal class InternetResource<T> 
    {
        private string name;
        private T content;

        public string Name { get { return name; } }
        public T Content { get { return content; }set { content = value; } }

        public InternetResource() { }

        public InternetResource(string name, T content)
        {
            if (name != "" || name.Length != 0)
                this.name = name;
            else throw new Exception("Некорректное имя ресурса!");

            this.content = content;
        }
        public override string ToString()
        {
            return this.name + " " + this.content;
        }

    }
}

