using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyZip.Database
{
    public delegate object LoadDataProcess(MyZipArchive.Reader reader);
    public delegate T LoadDataProcess<T>(MyZipArchive.Reader reader);
    public delegate void LoadDataIntoProcess<T>(MyZipArchive.Reader reader, ref T value);
}
