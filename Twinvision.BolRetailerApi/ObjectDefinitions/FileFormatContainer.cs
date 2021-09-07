using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions.V4
{
    public class FileFormatContainer
    {
        public string format { get; set; }

        public FileFormatContainer(string format)
        {
            this.format = format;
        }
    }
}
