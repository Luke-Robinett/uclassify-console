using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleMenus
{
    public class Menu
    {
        private readonly Stream _inputStream;
        private readonly Stream _outputStream;

        public Menu(Stream inputStream, Stream outputStream)
        {
            _inputStream = inputStream;
            _outputStream = outputStream;
        }

        public string Prompt { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public string Show()
        {
            _outputStream.Write((Prompt + Environment.NewLine).ToByteArray());
        }
    }
}
